using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public partial class ReservationForm : Form
    {
        private string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;
        Initial Catalog=RestaurantDB;
        Integrated Security=True";

        private int selectedReservationId = 0;
        private const int ReservationDurationMinutes = 60;

        public ReservationForm()
        {
            InitializeComponent();

            resDate.Format = DateTimePickerFormat.Custom;
            resDate.CustomFormat = "MMM dd, yyyy";
            resDate.MinDate = DateTime.Today;
            resDate.MaxDate = DateTime.Today.AddMonths(2);

            LoadTimeSlots();
            ConfigureTimeSlotDisplay();
            LoadStatusOptions();
            SelectFirstItem(resTimeSlot);
            SelectFirstItem(resStatus);
            LoadReservations();
            LoadAvailableTables();

            btnEditReservation.Enabled = false;
            btnDeleteReservation.Enabled = false;

            reservationGrid.CellClick += reservationGrid_CellClick;
            resDate.ValueChanged += reservationDateOrTime_Changed;
            resTimeSlot.SelectedIndexChanged += reservationDateOrTime_Changed;
            resTable.SelectedIndexChanged += (s, e) => resTimeSlot.Invalidate();

            this.Shown += (s, e) =>
            {
                reservationGrid.ClearSelection();
                reservationGrid.CurrentCell = null;
            };
        }

        public void ApplyLanguage()
        {
            string selectedStatus = resStatus.Text;

            LanguageManager.ApplyLanguageToForm(this);

            LoadStatusOptions();

            if (resStatus.Items.Contains(selectedStatus))
            {
                resStatus.Text = selectedStatus;
            }
            else
            {
                SelectFirstItem(resStatus);
            }
        }

        private void LoadReservations()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query =
                    @"SELECT
                        Reservations.ReservationID AS ID,
                        Customers.CustomerName AS Name,
                        Customers.Phone,
                        Reservations.Guests,
                        Reservations.ReservationDate AS Date,
                        Reservations.ReservationTime AS Time,
                        RestaurantTables.TableID AS TableID,
                        Reservations.Status
                    FROM Reservations
                    JOIN Customers
                        ON Reservations.CustomerID = Customers.CustomerID
                    JOIN RestaurantTables
                        ON Reservations.TableID = RestaurantTables.TableID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    reservationGrid.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                ShowError("Message_ReservationLoadError", ex);
            }
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            if (!ValidateReservationInput())
            {
                return;
            }

            int tableId = Convert.ToInt32(resTable.SelectedItem);
            DateTime selectedTime = DateTime.Parse(resTimeSlot.Text);
            TimeSpan reservationStartTime = selectedTime.TimeOfDay;
            TimeSpan reservationEndTime = selectedTime.AddMinutes(ReservationDurationMinutes).TimeOfDay;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // CHECK TABLE CAPACITY
                    SqlCommand capacityCmd = new SqlCommand(
                        @"SELECT Capacity
                          FROM RestaurantTables
                          WHERE TableID = @TableID", conn);

                    capacityCmd.Parameters.AddWithValue("@TableID", tableId);

                    int capacity = Convert.ToInt32(capacityCmd.ExecuteScalar());

                    if (resPartySize.Value > capacity)
                    {
                        MessageBox.Show(
                            string.Format(
                                LanguageManager.GetString("Message_PartySizeExceedsCapacity"),
                                capacity));

                        return;
                    }

                    // CHECK EXISTING RESERVATION
                    SqlCommand checkCmd = new SqlCommand(
                        @"SELECT COUNT(*)
                          FROM Reservations
                          WHERE TableID = @TableID
                          AND CAST(ReservationDate AS date) = @ReservationDate
                          AND CAST(ReservationTime AS time) < @ReservationEndTime
                          AND DATEADD(minute, 60, CAST(ReservationTime AS time)) > @ReservationStartTime", conn);

                    checkCmd.Parameters.AddWithValue("@TableID", tableId);
                    checkCmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                    checkCmd.Parameters.AddWithValue("@ReservationStartTime", reservationStartTime);
                    checkCmd.Parameters.AddWithValue("@ReservationEndTime", reservationEndTime);

                    int existing = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existing > 0)
                    {
                        ShowMessage("Message_TableAlreadyReserved");
                        return;
                    }

                    // INSERT CUSTOMER
                    SqlCommand customerCmd = new SqlCommand(
                        @"INSERT INTO Customers (CustomerName, Phone)
                          VALUES (@CustomerName, @Phone);
                          SELECT SCOPE_IDENTITY();", conn);

                    customerCmd.Parameters.AddWithValue("@CustomerName", resName.Text.Trim());
                    customerCmd.Parameters.AddWithValue("@Phone", resPhone.Text.Trim());

                    int customerId = Convert.ToInt32(customerCmd.ExecuteScalar());

                    // INSERT RESERVATION
                    SqlCommand reservationCmd = new SqlCommand(
                        @"INSERT INTO Reservations
                          (CustomerID, TableID, ReservationDate,
                           ReservationTime, Guests, Status)
                          VALUES
                          (@CustomerID, @TableID, @ReservationDate,
                           @ReservationTime, @Guests, @Status)", conn);

                    reservationCmd.Parameters.AddWithValue("@CustomerID", customerId);
                    reservationCmd.Parameters.AddWithValue("@TableID", tableId);
                    reservationCmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                    reservationCmd.Parameters.AddWithValue("@ReservationTime", selectedTime.TimeOfDay);
                    reservationCmd.Parameters.AddWithValue("@Guests", resPartySize.Value);
                    reservationCmd.Parameters.AddWithValue("@Status", resStatus.Text);

                    reservationCmd.ExecuteNonQuery();

                    ShowMessage("Message_ReservationAdded");

                    ReloadReservationData();
                }
            }
            catch (Exception ex)
            {
                ShowError("Message_ReservationAddError", ex);
            }
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == 0)
            {
                ShowMessage("Message_SelectReservation");
                return;
            }

            if (!ValidateReservationInput())
            {
                return;
            }

            int tableId = Convert.ToInt32(resTable.SelectedItem);
            DateTime selectedTime = DateTime.Parse(resTimeSlot.Text);
            TimeSpan reservationStartTime = selectedTime.TimeOfDay;
            TimeSpan reservationEndTime = selectedTime.AddMinutes(ReservationDurationMinutes).TimeOfDay;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // CHECK CAPACITY
                    SqlCommand capacityCmd = new SqlCommand(
                        @"SELECT Capacity
                          FROM RestaurantTables
                          WHERE TableID = @TableID", conn);

                    capacityCmd.Parameters.AddWithValue("@TableID", tableId);

                    int capacity = Convert.ToInt32(capacityCmd.ExecuteScalar());

                    if (resPartySize.Value > capacity)
                    {
                        MessageBox.Show(
                            string.Format(
                                LanguageManager.GetString("Message_PartySizeExceedsCapacity"),
                                capacity));

                        return;
                    }

                    // CHECK EXISTING RESERVATION
                    SqlCommand checkCmd = new SqlCommand(
                        @"SELECT COUNT(*)
                          FROM Reservations
                          WHERE TableID = @TableID
                          AND CAST(ReservationDate AS date) = @ReservationDate
                          AND CAST(ReservationTime AS time) < @ReservationEndTime
                          AND DATEADD(minute, 60, CAST(ReservationTime AS time)) > @ReservationStartTime
                          AND ReservationID <> @ReservationID", conn);

                    checkCmd.Parameters.AddWithValue("@TableID", tableId);
                    checkCmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                    checkCmd.Parameters.AddWithValue("@ReservationStartTime", reservationStartTime);
                    checkCmd.Parameters.AddWithValue("@ReservationEndTime", reservationEndTime);
                    checkCmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    int existing = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (existing > 0)
                    {
                        ShowMessage("Message_TableAlreadyReserved");
                        return;
                    }

                    // UPDATE CUSTOMER
                    SqlCommand customerCmd = new SqlCommand(
                        @"UPDATE Customers
                          SET CustomerName = @CustomerName,
                              Phone = @Phone
                          WHERE CustomerID =
                          (
                              SELECT CustomerID
                              FROM Reservations
                              WHERE ReservationID = @ReservationID
                          )", conn);

                    customerCmd.Parameters.AddWithValue("@CustomerName", resName.Text.Trim());
                    customerCmd.Parameters.AddWithValue("@Phone", resPhone.Text.Trim());
                    customerCmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    customerCmd.ExecuteNonQuery();

                    // UPDATE RESERVATION
                    SqlCommand reservationCmd = new SqlCommand(
                        @"UPDATE Reservations
                          SET TableID = @TableID,
                              ReservationDate = @ReservationDate,
                              ReservationTime = @ReservationTime,
                              Guests = @Guests,
                              Status = @Status
                          WHERE ReservationID = @ReservationID", conn);

                    reservationCmd.Parameters.AddWithValue("@TableID", tableId);
                    reservationCmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                    reservationCmd.Parameters.AddWithValue("@ReservationTime", selectedTime.TimeOfDay);
                    reservationCmd.Parameters.AddWithValue("@Guests", resPartySize.Value);
                    reservationCmd.Parameters.AddWithValue("@Status", resStatus.Text);
                    reservationCmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    reservationCmd.ExecuteNonQuery();

                    ShowMessage("Message_ReservationUpdated");

                    ReloadReservationData();
                }
            }
            catch (Exception ex)
            {
                ShowError("Message_ReservationUpdateError", ex);
            }
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == 0)
            {
                ShowMessage("Message_SelectReservation");
                return;
            }

            DialogResult result =
                MessageBox.Show(
                    LanguageManager.GetString("Message_ConfirmDelete"),
                    LanguageManager.GetString("Message_ConfirmDeleteTitle"),
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // DELETE RESERVATION
                    SqlCommand deleteCmd = new SqlCommand(
                        @"DELETE FROM Reservations
                          WHERE ReservationID = @ReservationID", conn);

                    deleteCmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    deleteCmd.ExecuteNonQuery();

                    ShowMessage("Message_ReservationDeleted");

                    ReloadReservationData();
                }
            }
            catch (Exception ex)
            {
                ShowError("Message_ReservationDeleteError", ex);
            }
        }

        private bool ValidateReservationInput()
        {
            if (string.IsNullOrWhiteSpace(resName.Text))
            {
                ShowMessage("Message_CustomerNameRequired");
                resName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(resPhone.Text))
            {
                ShowMessage("Message_PhoneRequired");
                resPhone.Focus();
                return false;
            }

            string digitsOnly = new string(resPhone.Text.Where(char.IsDigit).ToArray());

            if (digitsOnly.Length < 10)
            {
                ShowMessage("Message_InvalidPhone");
                resPhone.Focus();
                return false;
            }

            if (resTable.SelectedItem == null)
            {
                ShowMessage("Message_SelectTable");
                return false;
            }

            if (resTimeSlot.SelectedItem == null)
            {
                ShowMessage("Message_SelectReservationTime");
                return false;
            }

            if (resStatus.SelectedItem == null)
            {
                ShowMessage("Message_SelectReservationStatus");
                return false;
            }

            return true;
        }

        private void reservationGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            try
            {
                DataGridViewRow row = reservationGrid.Rows[e.RowIndex];

                selectedReservationId = Convert.ToInt32(row.Cells["ID"].Value);

                resName.Text = Convert.ToString(row.Cells["Name"].Value);
                resPhone.Text = Convert.ToString(row.Cells["Phone"].Value);

                resPartySize.Value =
                    Convert.ToDecimal(row.Cells["Guests"].Value);

                resDate.Value =
                    Convert.ToDateTime(row.Cells["Date"].Value);

                DateTime timeValue =
                    DateTime.Today.Add((TimeSpan)row.Cells["Time"].Value);

                resTimeSlot.Text = timeValue.ToString("hh:mm tt");

                string tableId =
                    Convert.ToString(row.Cells["TableID"].Value);

                if (!resTable.Items.Contains(tableId))
                {
                    resTable.Items.Add(tableId);
                }

                resTable.Text = tableId;

                resStatus.Text =
                    Convert.ToString(row.Cells["Status"].Value);

                btnEditReservation.Enabled = true;
                btnDeleteReservation.Enabled = true;
            }
            catch (Exception ex)
            {
                ClearForm();
                ShowError("Message_ReservationSelectionError", ex);
            }
        }

        private void LoadTimeSlots()
        {
            DateTime start = DateTime.Today.AddHours(16);
            DateTime end = DateTime.Today.AddHours(21);

            resTimeSlot.Items.Clear();

            while (start <= end)
            {
                resTimeSlot.Items.Add(start.ToString("hh:mm tt"));

                start = start.AddMinutes(30);
            }
        }

        private void ConfigureTimeSlotDisplay()
        {
            resTimeSlot.DrawMode = DrawMode.OwnerDrawFixed;
            resTimeSlot.DrawItem += resTimeSlot_DrawItem;
        }

        private void resTimeSlot_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            e.DrawBackground();

            string timeText = resTimeSlot.Items[e.Index].ToString();
            DateTime selectedTime;
            bool unavailable = DateTime.TryParse(timeText, out selectedTime) &&
                               IsTimeSlotUnavailable(selectedTime);

            Color textColor = unavailable ? Color.Firebrick : e.ForeColor;

            using (Brush textBrush = new SolidBrush(textColor))
            {
                e.Graphics.DrawString(timeText, e.Font, textBrush, e.Bounds);
            }

            e.DrawFocusRectangle();
        }

        private bool IsTimeSlotUnavailable(DateTime selectedTime)
        {
            TimeSpan reservationStartTime = selectedTime.TimeOfDay;
            TimeSpan reservationEndTime = selectedTime.AddMinutes(ReservationDurationMinutes).TimeOfDay;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    if (resTable.SelectedItem != null)
                    {
                        cmd.CommandText =
                            @"SELECT COUNT(*)
                              FROM Reservations
                              WHERE TableID = @TableID
                              AND CAST(ReservationDate AS date) = @ReservationDate
                              AND CAST(ReservationTime AS time) < @ReservationEndTime
                              AND DATEADD(minute, 60, CAST(ReservationTime AS time)) > @ReservationStartTime
                              AND ReservationID <> @ReservationID";

                        cmd.Parameters.AddWithValue("@TableID", Convert.ToInt32(resTable.SelectedItem));
                    }
                    else
                    {
                        cmd.CommandText =
                            @"SELECT COUNT(*)
                              FROM RestaurantTables
                              WHERE NOT EXISTS
                              (
                                  SELECT 1
                                  FROM Reservations
                                  WHERE Reservations.TableID = RestaurantTables.TableID
                                  AND CAST(Reservations.ReservationDate AS date) = @ReservationDate
                                  AND CAST(Reservations.ReservationTime AS time) < @ReservationEndTime
                                  AND DATEADD(minute, 60, CAST(Reservations.ReservationTime AS time)) > @ReservationStartTime
                                  AND Reservations.ReservationID <> @ReservationID
                              )";
                    }

                    cmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                    cmd.Parameters.AddWithValue("@ReservationStartTime", reservationStartTime);
                    cmd.Parameters.AddWithValue("@ReservationEndTime", reservationEndTime);
                    cmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return resTable.SelectedItem != null ? count > 0 : count == 0;
                }
            }
            catch
            {
                return false;
            }
        }

        private void LoadStatusOptions()
        {
            LanguageManager.UpdateComboBoxItems(
                resStatus,
                "Status_Confirmed",
                "Status_Seated",
                "Status_Completed",
                "Status_Cancelled",
                "Status_NoShow"
            );
        }

        private void LoadAvailableTables()
        {
            try
            {
                resTable.Items.Clear();

                DateTime selectedTime;
                if (resTimeSlot.SelectedItem == null ||
                    !DateTime.TryParse(resTimeSlot.SelectedItem.ToString(), out selectedTime))
                {
                    return;
                }

                TimeSpan reservationStartTime = selectedTime.TimeOfDay;
                TimeSpan reservationEndTime = selectedTime.AddMinutes(ReservationDurationMinutes).TimeOfDay;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query =
                    @"SELECT TableID
                      FROM RestaurantTables
                      WHERE NOT EXISTS
                      (
                          SELECT 1
                          FROM Reservations
                          WHERE Reservations.TableID = RestaurantTables.TableID
                          AND CAST(Reservations.ReservationDate AS date) = @ReservationDate
                          AND CAST(Reservations.ReservationTime AS time) < @ReservationEndTime
                          AND DATEADD(minute, 60, CAST(Reservations.ReservationTime AS time)) > @ReservationStartTime
                          AND Reservations.ReservationID <> @ReservationID
                      )
                      ORDER BY TableNumber";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                    cmd.Parameters.AddWithValue("@ReservationStartTime", reservationStartTime);
                    cmd.Parameters.AddWithValue("@ReservationEndTime", reservationEndTime);
                    cmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        resTable.Items.Add(reader["TableID"].ToString());
                    }
                }

                if (resTable.Items.Count > 0)
                {
                    resTable.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowError("Message_TableLoadError", ex);
            }
        }

        private void reservationDateOrTime_Changed(object sender, EventArgs e)
        {
            LoadAvailableTables();
            resTimeSlot.Invalidate();
        }

        private void ReloadReservationData()
        {
            LoadReservations();
            LoadAvailableTables();
            ClearForm();
        }

        private void ClearForm()
        {
            resName.Clear();
            resPhone.Clear();

            selectedReservationId = 0;

            resPartySize.Value = 1;
            resDate.Value = DateTime.Now;

            SelectFirstItem(resTimeSlot);
            SelectFirstItem(resStatus);

            reservationGrid.ClearSelection();

            btnEditReservation.Enabled = false;
            btnDeleteReservation.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void SelectFirstItem(ComboBox comboBox)
        {
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private void ShowMessage(string resourceKey)
        {
            MessageBox.Show(LanguageManager.GetString(resourceKey));
        }

        private void ShowError(string resourceKey, Exception ex)
        {
            MessageBox.Show(
                string.Format(
                    "{0}\n\n{1}",
                    LanguageManager.GetString(resourceKey),
                    ex.Message),
                LanguageManager.GetString("Message_ErrorTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
