using System;
using System.Data;
using System.Data.SqlClient;
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

        public ReservationForm()
        {
            InitializeComponent();

            resDate.Format = DateTimePickerFormat.Custom;
            resDate.CustomFormat = "MMM dd, yyyy";

            LoadTimeSlots();
            LoadStatusOptions();
            LoadReservations();
            LoadAvailableTables();

            SelectFirstItem(resTimeSlot);
            SelectFirstItem(resStatus);

            btnEditReservation.Enabled = false;
            btnDeleteReservation.Enabled = false;

            reservationGrid.CellClick += reservationGrid_CellClick;

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
                          AND ReservationDate = @ReservationDate
                          AND ReservationTime = @ReservationTime", conn);

                    checkCmd.Parameters.AddWithValue("@TableID", tableId);
                    checkCmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                    checkCmd.Parameters.AddWithValue("@ReservationTime", selectedTime.TimeOfDay);

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

                    // UPDATE TABLE STATUS
                    string tableStatus =
                        resStatus.Text == "Confirmed" ||
                        resStatus.Text == "Seated"
                        ? "Reserved"
                        : "Available";

                    SqlCommand tableCmd = new SqlCommand(
                        @"UPDATE RestaurantTables
                          SET Status = @Status
                          WHERE TableID = @TableID", conn);

                    tableCmd.Parameters.AddWithValue("@Status", tableStatus);
                    tableCmd.Parameters.AddWithValue("@TableID", tableId);

                    tableCmd.ExecuteNonQuery();

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

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // GET OLD TABLE ID
                    SqlCommand oldTableCmd = new SqlCommand(
                        @"SELECT TableID
                          FROM Reservations
                          WHERE ReservationID = @ReservationID", conn);

                    oldTableCmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    int oldTableId = Convert.ToInt32(oldTableCmd.ExecuteScalar());

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
                          AND ReservationDate = @ReservationDate
                          AND ReservationTime = @ReservationTime
                          AND ReservationID <> @ReservationID", conn);

                    checkCmd.Parameters.AddWithValue("@TableID", tableId);
                    checkCmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                    checkCmd.Parameters.AddWithValue("@ReservationTime", selectedTime.TimeOfDay);
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

                    // RESET OLD TABLE
                    if (oldTableId != tableId)
                    {
                        SqlCommand oldTableUpdate = new SqlCommand(
                            @"UPDATE RestaurantTables
                              SET Status = 'Available'
                              WHERE TableID = @TableID", conn);

                        oldTableUpdate.Parameters.AddWithValue("@TableID", oldTableId);

                        oldTableUpdate.ExecuteNonQuery();
                    }

                    // UPDATE NEW TABLE STATUS
                    string tableStatus =
                        resStatus.Text == "Confirmed" ||
                        resStatus.Text == "Seated"
                        ? "Reserved"
                        : "Available";

                    SqlCommand tableCmd = new SqlCommand(
                        @"UPDATE RestaurantTables
                          SET Status = @Status
                          WHERE TableID = @TableID", conn);

                    tableCmd.Parameters.AddWithValue("@Status", tableStatus);
                    tableCmd.Parameters.AddWithValue("@TableID", tableId);

                    tableCmd.ExecuteNonQuery();

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

                    // GET TABLE ID
                    SqlCommand tableCmd = new SqlCommand(
                        @"SELECT TableID
                          FROM Reservations
                          WHERE ReservationID = @ReservationID", conn);

                    tableCmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    int tableId = Convert.ToInt32(tableCmd.ExecuteScalar());

                    // DELETE RESERVATION
                    SqlCommand deleteCmd = new SqlCommand(
                        @"DELETE FROM Reservations
                          WHERE ReservationID = @ReservationID", conn);

                    deleteCmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);

                    deleteCmd.ExecuteNonQuery();

                    // UPDATE TABLE STATUS
                    SqlCommand updateCmd = new SqlCommand(
                        @"UPDATE RestaurantTables
                          SET Status = 'Available'
                          WHERE TableID = @TableID", conn);

                    updateCmd.Parameters.AddWithValue("@TableID", tableId);

                    updateCmd.ExecuteNonQuery();

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

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query =
                    @"SELECT TableID
                      FROM RestaurantTables
                      WHERE Status = 'Available'
                      ORDER BY TableNumber";

                    SqlCommand cmd = new SqlCommand(query, conn);

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

            resPartySize.Value = 1;
            resDate.Value = DateTime.Now;

            SelectFirstItem(resTimeSlot);
            SelectFirstItem(resStatus);

            reservationGrid.ClearSelection();

            selectedReservationId = 0;

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