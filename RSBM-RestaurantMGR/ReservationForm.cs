using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public partial class ReservationForm : Form
    {
        private string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;
        Initial Catalog=RestaurantDB;
        Integrated Security=True";

        int selectedReservationId = 0;

        public ReservationForm()
        {
            InitializeComponent();

            resDate.Format = DateTimePickerFormat.Custom;
            resDate.CustomFormat = "MMM dd, yyyy";

            reservationGrid.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            reservationGrid.AllowUserToAddRows = false;

            reservationGrid.ReadOnly = true;

            reservationGrid.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            LoadTimeSlots();
            LoadStatusOptions();
            LoadReservations();
            LoadAvailableTables();

            resTimeSlot.SelectedIndex = 0;
            resStatus.SelectedIndex = 0;

            btnEditReservation.Enabled = false;
            btnDeleteReservation.Enabled = false;

            reservationGrid.CellClick += reservationGrid_CellClick;
        }

        public void ApplyLanguage()
        {
            LanguageManager.ApplyLanguageToForm(this);

            LanguageManager.UpdateComboBoxItems(
                resStatus,
                "Status_Confirmed",
                "Status_Pending",
                "Status_Seated",
                "Status_Completed",
                "Status_Cancelled",
                "Status_NoShow"
            );

            if (resStatus.Items.Count > 0)
                resStatus.SelectedIndex = 0;
        }

        private void LoadReservations()
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
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

                SqlDataAdapter adapter =
                    new SqlDataAdapter(query, conn);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                reservationGrid.DataSource = dt;
            }
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            // VALIDATION

            if (string.IsNullOrWhiteSpace(resName.Text))
            {
                MessageBox.Show("Please enter a customer name.");
                resName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(resPhone.Text))
            {
                MessageBox.Show("Please enter a phone number.");
                resPhone.Focus();
                return;
            }

            if (resPhone.Text.Length < 10)
            {
                MessageBox.Show("Invalid phone number.");
                resPhone.Focus();
                return;
            }

            if (resTable.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a table.");
                resTable.Focus();
                return;
            }

            int selectedTableId =
                Convert.ToInt32(resTable.Text);

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                // CHECK TABLE CAPACITY

                string capacityQuery =
                @"SELECT Capacity
                  FROM RestaurantTables
                  WHERE TableID = @TableID";

                SqlCommand capacityCmd =
                    new SqlCommand(capacityQuery, conn);

                capacityCmd.Parameters.AddWithValue(
                    "@TableID",
                    selectedTableId);

                int tableCapacity =
                    Convert.ToInt32(capacityCmd.ExecuteScalar());

                if (resPartySize.Value > tableCapacity)
                {
                    MessageBox.Show(
                        $"Party size exceeds table capacity ({tableCapacity} seats).");

                    return;
                }

                // CHECK DUPLICATE RESERVATION

                string duplicateQuery =
                @"SELECT COUNT(*)
                  FROM Reservations
                  WHERE TableID = @TableID
                  AND ReservationDate = @ReservationDate
                  AND ReservationTime = @ReservationTime";

                SqlCommand duplicateCmd =
                    new SqlCommand(duplicateQuery, conn);

                duplicateCmd.Parameters.AddWithValue(
                    "@TableID",
                    selectedTableId);

                duplicateCmd.Parameters.AddWithValue(
                    "@ReservationDate",
                    resDate.Value.Date);

                DateTime duplicateTime =
                    DateTime.Parse(resTimeSlot.Text);

                duplicateCmd.Parameters.AddWithValue(
                    "@ReservationTime",
                    duplicateTime.TimeOfDay);

                int duplicateCount =
                    Convert.ToInt32(duplicateCmd.ExecuteScalar());

                if (duplicateCount > 0)
                {
                    MessageBox.Show(
                        "Table already reserved for this time.");

                    return;
                }

                // INSERT CUSTOMER

                string customerQuery =
                @"INSERT INTO Customers
                (
                    CustomerName,
                    Phone
                )
                VALUES
                (
                    @CustomerName,
                    @Phone
                );

                SELECT SCOPE_IDENTITY();";

                SqlCommand customerCmd =
                    new SqlCommand(customerQuery, conn);

                customerCmd.Parameters.AddWithValue(
                    "@CustomerName",
                    resName.Text.Trim());

                customerCmd.Parameters.AddWithValue(
                    "@Phone",
                    resPhone.Text.Trim());

                int customerId =
                    Convert.ToInt32(customerCmd.ExecuteScalar());

                // INSERT RESERVATION

                string reservationQuery =
                @"INSERT INTO Reservations
                (
                    CustomerID,
                    TableID,
                    ReservationDate,
                    ReservationTime,
                    Guests,
                    Status
                )
                VALUES
                (
                    @CustomerID,
                    @TableID,
                    @ReservationDate,
                    @ReservationTime,
                    @Guests,
                    @Status
                )";

                SqlCommand reservationCmd =
                    new SqlCommand(reservationQuery, conn);

                reservationCmd.Parameters.AddWithValue(
                    "@CustomerID",
                    customerId);

                reservationCmd.Parameters.AddWithValue(
                    "@TableID",
                    selectedTableId);

                reservationCmd.Parameters.AddWithValue(
                    "@ReservationDate",
                    resDate.Value.Date);

                DateTime selectedTime =
                    DateTime.Parse(resTimeSlot.Text);

                reservationCmd.Parameters.AddWithValue(
                    "@ReservationTime",
                    selectedTime.TimeOfDay);

                reservationCmd.Parameters.AddWithValue(
                    "@Guests",
                    resPartySize.Value);

                reservationCmd.Parameters.AddWithValue(
                    "@Status",
                    resStatus.Text);

                reservationCmd.ExecuteNonQuery();

                // UPDATE TABLE STATUS

                string updateTableQuery =
                @"UPDATE RestaurantTables
                  SET Status = 'Reserved'
                  WHERE TableID = @TableID";

                SqlCommand updateTableCmd =
                    new SqlCommand(updateTableQuery, conn);

                updateTableCmd.Parameters.AddWithValue(
                    "@TableID",
                    selectedTableId);

                updateTableCmd.ExecuteNonQuery();

                MessageBox.Show(
                    LanguageManager.GetString("Message_ReservationAdded"));

                LoadReservations();
                LoadAvailableTables();

                ClearForm();
            }
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == 0)
            {
                MessageBox.Show(
                    LanguageManager.GetString("Message_SelectReservation"));

                return;
            }

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                // GET CUSTOMER ID

                string getCustomerQuery =
                @"SELECT CustomerID
                  FROM Reservations
                  WHERE ReservationID = @ReservationID";

                SqlCommand getCustomerCmd =
                    new SqlCommand(getCustomerQuery, conn);

                getCustomerCmd.Parameters.AddWithValue(
                    "@ReservationID",
                    selectedReservationId);

                int customerId =
                    Convert.ToInt32(getCustomerCmd.ExecuteScalar());

                // GET OLD TABLE

                string oldTableQuery =
                @"SELECT TableID
                  FROM Reservations
                  WHERE ReservationID = @ReservationID";

                SqlCommand oldTableCmd =
                    new SqlCommand(oldTableQuery, conn);

                oldTableCmd.Parameters.AddWithValue(
                    "@ReservationID",
                    selectedReservationId);

                int oldTableId =
                    Convert.ToInt32(oldTableCmd.ExecuteScalar());

                // UPDATE CUSTOMER

                string customerQuery =
                @"UPDATE Customers
                  SET
                    CustomerName = @CustomerName,
                    Phone = @Phone
                  WHERE CustomerID = @CustomerID";

                SqlCommand customerCmd =
                    new SqlCommand(customerQuery, conn);

                customerCmd.Parameters.AddWithValue(
                    "@CustomerName",
                    resName.Text);

                customerCmd.Parameters.AddWithValue(
                    "@Phone",
                    resPhone.Text);

                customerCmd.Parameters.AddWithValue(
                    "@CustomerID",
                    customerId);

                customerCmd.ExecuteNonQuery();

                // UPDATE RESERVATION

                string reservationQuery =
                @"UPDATE Reservations
                  SET
                    TableID = @TableID,
                    ReservationDate = @ReservationDate,
                    ReservationTime = @ReservationTime,
                    Guests = @Guests,
                    Status = @Status
                  WHERE ReservationID = @ReservationID";

                SqlCommand reservationCmd =
                    new SqlCommand(reservationQuery, conn);

                reservationCmd.Parameters.AddWithValue(
                    "@TableID",
                    Convert.ToInt32(resTable.Text));

                reservationCmd.Parameters.AddWithValue(
                    "@ReservationDate",
                    resDate.Value.Date);

                DateTime selectedTime =
                    DateTime.Parse(resTimeSlot.Text);

                reservationCmd.Parameters.AddWithValue(
                    "@ReservationTime",
                    selectedTime.TimeOfDay);

                reservationCmd.Parameters.AddWithValue(
                    "@Guests",
                    resPartySize.Value);

                reservationCmd.Parameters.AddWithValue(
                    "@Status",
                    resStatus.Text);

                reservationCmd.Parameters.AddWithValue(
                    "@ReservationID",
                    selectedReservationId);

                reservationCmd.ExecuteNonQuery();

                // FREE OLD TABLE

                string freeOldTableQuery =
                @"UPDATE RestaurantTables
                  SET Status = 'Available'
                  WHERE TableID = @TableID";

                SqlCommand freeOldTableCmd =
                    new SqlCommand(freeOldTableQuery, conn);

                freeOldTableCmd.Parameters.AddWithValue(
                    "@TableID",
                    oldTableId);

                freeOldTableCmd.ExecuteNonQuery();

                // RESERVE NEW TABLE

                string reserveNewTableQuery =
                @"UPDATE RestaurantTables
                  SET Status = 'Reserved'
                  WHERE TableID = @TableID";

                SqlCommand reserveNewTableCmd =
                    new SqlCommand(reserveNewTableQuery, conn);

                reserveNewTableCmd.Parameters.AddWithValue(
                    "@TableID",
                    Convert.ToInt32(resTable.Text));

                reserveNewTableCmd.ExecuteNonQuery();

                MessageBox.Show(
                    LanguageManager.GetString("Message_ReservationUpdated"));

                LoadReservations();
                LoadAvailableTables();

                ClearForm();
            }
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == 0)
            {
                MessageBox.Show(
                    LanguageManager.GetString("Message_SelectReservation"));

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    LanguageManager.GetString("Message_ConfirmDelete"),
                    LanguageManager.GetString("Message_ConfirmDeleteTitle"),
                    MessageBoxButtons.YesNo
                );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    conn.Open();

                    // GET TABLE ID

                    string getTableQuery =
                    @"SELECT TableID
                      FROM Reservations
                      WHERE ReservationID = @ReservationID";

                    SqlCommand getTableCmd =
                        new SqlCommand(getTableQuery, conn);

                    getTableCmd.Parameters.AddWithValue(
                        "@ReservationID",
                        selectedReservationId);

                    int tableId =
                        Convert.ToInt32(getTableCmd.ExecuteScalar());

                    // DELETE RESERVATION

                    string query =
                    @"DELETE FROM Reservations
                      WHERE ReservationID = @ReservationID";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ReservationID",
                        selectedReservationId);

                    cmd.ExecuteNonQuery();

                    // FREE TABLE

                    string updateTableQuery =
                    @"UPDATE RestaurantTables
                      SET Status = 'Available'
                      WHERE TableID = @TableID";

                    SqlCommand updateTableCmd =
                        new SqlCommand(updateTableQuery, conn);

                    updateTableCmd.Parameters.AddWithValue(
                        "@TableID",
                        tableId);

                    updateTableCmd.ExecuteNonQuery();

                    MessageBox.Show(
                        LanguageManager.GetString("Message_ReservationDeleted"));

                    LoadReservations();
                    LoadAvailableTables();

                    ClearForm();
                }
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

            resTimeSlot.SelectedIndex = 0;
            resStatus.SelectedIndex = 0;

            reservationGrid.ClearSelection();

            selectedReservationId = 0;

            btnEditReservation.Enabled = false;
            btnDeleteReservation.Enabled = false;
        }

        private void reservationGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row =
                    reservationGrid.Rows[e.RowIndex];

                selectedReservationId =
                    Convert.ToInt32(row.Cells["ID"].Value);

                resName.Text =
                    row.Cells["Name"].Value.ToString();

                resPhone.Text =
                    row.Cells["Phone"].Value.ToString();

                resPartySize.Value =
                    Convert.ToDecimal(row.Cells["Guests"].Value);

                resDate.Value =
                    Convert.ToDateTime(row.Cells["Date"].Value);

                DateTime timeValue =
                    DateTime.Today.Add(
                        (TimeSpan)row.Cells["Time"].Value);

                resTimeSlot.Text =
                    timeValue.ToString("hh:mm tt");

                resTable.Text =
                    row.Cells["TableID"].Value.ToString();

                resStatus.Text =
                    row.Cells["Status"].Value.ToString();

                btnEditReservation.Enabled = true;
                btnDeleteReservation.Enabled = true;
            }
        }

        private void LoadTimeSlots()
        {
            DateTime start = DateTime.Parse("4:00 PM");
            DateTime end = DateTime.Parse("9:00 PM");

            while (start <= end)
            {
                resTimeSlot.Items.Add(
                    start.ToString("hh:mm tt"));

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
            resTable.Items.Clear();

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                conn.Open();

                string query =
                @"SELECT TableID
                  FROM RestaurantTables
                  WHERE Status = 'Available'";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                SqlDataReader reader =
                    cmd.ExecuteReader();

                while (reader.Read())
                {
                    resTable.Items.Add(
                        reader["TableID"].ToString());
                }
            }

            if (resTable.Items.Count > 0)
            {
                resTable.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No available tables.");
            }
        }
    }
}