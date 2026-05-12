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

            reservationGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reservationGrid.AllowUserToAddRows = false;
            reservationGrid.ReadOnly = true;
            reservationGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadTimeSlots();
            LoadStatusOptions();
            LoadReservations();
            LoadAvailableTables();

            SelectFirstItem(resTimeSlot);
            SelectFirstItem(resStatus);

            btnEditReservation.Enabled = false;
            btnDeleteReservation.Enabled = false;

            reservationGrid.CellClick += reservationGrid_CellClick;
        }

        public void ApplyLanguage()
        {
            string selectedStatus = resStatus.Text;

            LanguageManager.ApplyLanguageToForm(this);
            LoadStatusOptions();

            if (!string.IsNullOrWhiteSpace(selectedStatus) && resStatus.Items.Contains(selectedStatus))
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
            int selectedTableId;
            DateTime selectedTime;

            if (!ValidateReservationInput(out selectedTableId, out selectedTime))
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (!ValidateTableCapacity(conn, selectedTableId))
                    {
                        return;
                    }

                    if (ReservationExists(conn, selectedTableId, selectedTime, 0))
                    {
                        ShowMessage("Message_TableAlreadyReserved");
                        return;
                    }

                    int customerId = InsertCustomer(conn);
                    InsertReservation(conn, customerId, selectedTableId, selectedTime);
                    UpdateTableStatus(conn, selectedTableId, "Reserved");

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

            int selectedTableId;
            DateTime selectedTime;

            if (!ValidateReservationInput(out selectedTableId, out selectedTime))
            {
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    object customerValue = ExecuteScalar(conn,
                        "SELECT CustomerID FROM Reservations WHERE ReservationID = @ReservationID",
                        "@ReservationID", selectedReservationId);

                    object oldTableValue = ExecuteScalar(conn,
                        "SELECT TableID FROM Reservations WHERE ReservationID = @ReservationID",
                        "@ReservationID", selectedReservationId);

                    if (customerValue == null || customerValue == DBNull.Value ||
                        oldTableValue == null || oldTableValue == DBNull.Value)
                    {
                        ShowMessage("Message_ReservationNotFound");
                        ReloadReservationData();
                        return;
                    }

                    if (!ValidateTableCapacity(conn, selectedTableId))
                    {
                        return;
                    }

                    if (ReservationExists(conn, selectedTableId, selectedTime, selectedReservationId))
                    {
                        ShowMessage("Message_TableAlreadyReserved");
                        return;
                    }

                    int customerId = Convert.ToInt32(customerValue);
                    int oldTableId = Convert.ToInt32(oldTableValue);

                    UpdateCustomer(conn, customerId);
                    UpdateReservation(conn, selectedTableId, selectedTime);

                    if (oldTableId != selectedTableId)
                    {
                        UpdateTableStatus(conn, oldTableId, "Available");
                    }

                    UpdateTableStatus(conn, selectedTableId, "Reserved");

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

                    object tableValue = ExecuteScalar(conn,
                        "SELECT TableID FROM Reservations WHERE ReservationID = @ReservationID",
                        "@ReservationID", selectedReservationId);

                    if (tableValue == null || tableValue == DBNull.Value)
                    {
                        ShowMessage("Message_ReservationNotFound");
                        ReloadReservationData();
                        return;
                    }

                    int tableId = Convert.ToInt32(tableValue);

                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Reservations WHERE ReservationID = @ReservationID", conn))
                    {
                        cmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);
                        cmd.ExecuteNonQuery();
                    }

                    UpdateTableStatus(conn, tableId, "Available");

                    ShowMessage("Message_ReservationDeleted");
                    ReloadReservationData();
                }
            }
            catch (Exception ex)
            {
                ShowError("Message_ReservationDeleteError", ex);
            }
        }

        private bool ValidateReservationInput(out int selectedTableId, out DateTime selectedTime)
        {
            selectedTableId = 0;
            selectedTime = DateTime.MinValue;

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

            if (resTable.SelectedItem == null || !int.TryParse(resTable.SelectedItem.ToString(), out selectedTableId))
            {
                ShowMessage("Message_SelectTable");
                resTable.Focus();
                return false;
            }

            if (resTimeSlot.SelectedItem == null || !DateTime.TryParse(resTimeSlot.SelectedItem.ToString(), out selectedTime))
            {
                ShowMessage("Message_SelectReservationTime");
                resTimeSlot.Focus();
                return false;
            }

            if (resStatus.SelectedItem == null)
            {
                ShowMessage("Message_SelectReservationStatus");
                resStatus.Focus();
                return false;
            }

            return true;
        }

        private bool ValidateTableCapacity(SqlConnection conn, int tableId)
        {
            object capacityValue = ExecuteScalar(conn,
                "SELECT Capacity FROM RestaurantTables WHERE TableID = @TableID",
                "@TableID", tableId);

            if (capacityValue == null || capacityValue == DBNull.Value)
            {
                ShowMessage("Message_TableNotFound");
                return false;
            }

            int tableCapacity = Convert.ToInt32(capacityValue);

            if (resPartySize.Value > tableCapacity)
            {
                MessageBox.Show(string.Format(
                    LanguageManager.GetString("Message_PartySizeExceedsCapacity"),
                    tableCapacity));
                return false;
            }

            return true;
        }

        private bool ReservationExists(SqlConnection conn, int tableId, DateTime selectedTime, int ignoredReservationId)
        {
            string query =
            @"SELECT COUNT(*)
              FROM Reservations
              WHERE TableID = @TableID
              AND ReservationDate = @ReservationDate
              AND ReservationTime = @ReservationTime
              AND ReservationID <> @ReservationID";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TableID", tableId);
                cmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                cmd.Parameters.AddWithValue("@ReservationTime", selectedTime.TimeOfDay);
                cmd.Parameters.AddWithValue("@ReservationID", ignoredReservationId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private int InsertCustomer(SqlConnection conn)
        {
            string query =
            @"INSERT INTO Customers (CustomerName, Phone)
              VALUES (@CustomerName, @Phone);
              SELECT SCOPE_IDENTITY();";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerName", resName.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", resPhone.Text.Trim());
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void InsertReservation(SqlConnection conn, int customerId, int tableId, DateTime selectedTime)
        {
            string query =
            @"INSERT INTO Reservations
              (CustomerID, TableID, ReservationDate, ReservationTime, Guests, Status)
              VALUES
              (@CustomerID, @TableID, @ReservationDate, @ReservationTime, @Guests, @Status)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.Parameters.AddWithValue("@TableID", tableId);
                cmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                cmd.Parameters.AddWithValue("@ReservationTime", selectedTime.TimeOfDay);
                cmd.Parameters.AddWithValue("@Guests", resPartySize.Value);
                cmd.Parameters.AddWithValue("@Status", resStatus.Text);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateCustomer(SqlConnection conn, int customerId)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Customers
                  SET CustomerName = @CustomerName,
                      Phone = @Phone
                  WHERE CustomerID = @CustomerID", conn))
            {
                cmd.Parameters.AddWithValue("@CustomerName", resName.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone", resPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@CustomerID", customerId);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateReservation(SqlConnection conn, int tableId, DateTime selectedTime)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Reservations
                  SET TableID = @TableID,
                      ReservationDate = @ReservationDate,
                      ReservationTime = @ReservationTime,
                      Guests = @Guests,
                      Status = @Status
                  WHERE ReservationID = @ReservationID", conn))
            {
                cmd.Parameters.AddWithValue("@TableID", tableId);
                cmd.Parameters.AddWithValue("@ReservationDate", resDate.Value.Date);
                cmd.Parameters.AddWithValue("@ReservationTime", selectedTime.TimeOfDay);
                cmd.Parameters.AddWithValue("@Guests", resPartySize.Value);
                cmd.Parameters.AddWithValue("@Status", resStatus.Text);
                cmd.Parameters.AddWithValue("@ReservationID", selectedReservationId);
                cmd.ExecuteNonQuery();
            }
        }

        private void UpdateTableStatus(SqlConnection conn, int tableId, string status)
        {
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE RestaurantTables
                  SET Status = @Status
                  WHERE TableID = @TableID", conn))
            {
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@TableID", tableId);
                cmd.ExecuteNonQuery();
            }
        }

        private object ExecuteScalar(SqlConnection conn, string query, string parameterName, object value)
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue(parameterName, value);
                return cmd.ExecuteScalar();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
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
                resPartySize.Value = Convert.ToDecimal(row.Cells["Guests"].Value);
                resDate.Value = Convert.ToDateTime(row.Cells["Date"].Value);

                DateTime timeValue = DateTime.Today.Add((TimeSpan)row.Cells["Time"].Value);
                resTimeSlot.Text = timeValue.ToString("hh:mm tt");

                string tableId = Convert.ToString(row.Cells["TableID"].Value);
                if (!resTable.Items.Contains(tableId))
                {
                    resTable.Items.Add(tableId);
                }
                resTable.Text = tableId;

                resStatus.Text = Convert.ToString(row.Cells["Status"].Value);

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
                "Status_Pending",
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

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resTable.Items.Add(reader["TableID"].ToString());
                        }
                    }
                }

                if (resTable.Items.Count > 0)
                {
                    resTable.SelectedIndex = 0;
                }
                else
                {
                    ShowMessage("Message_NoAvailableTables");
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
                string.Format("{0}\n\n{1}", LanguageManager.GetString(resourceKey), ex.Message),
                LanguageManager.GetString("Message_ErrorTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
