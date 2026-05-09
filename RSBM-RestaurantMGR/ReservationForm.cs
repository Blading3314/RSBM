using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            LoadTimeSlots();
            LoadStatusOptions();
            //LoadReservations();

            ClearForm();

            //btnEditReservation.Enabled = false;
            //btnDeleteReservation.Enabled = false;
        }

        /*private void LoadReservations()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
        SELECT
            Reservations.ReservationID,
            Customers.CustomerName,
            Customers.Phone,
            Reservations.Guests,
            Reservations.ReservationDate,
            RestaurantTables.TableID
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
        }*/

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query =
                @"INSERT INTO Reservations
                (
                    CustomerName,
                    Phone,
                    PartySize,
                    ReservationDate,
                    ReservationTime,
                    TableId,
                    Status
                )
                VALUES
                (
                    @CustomerName,
                    @Phone,
                    @PartySize,
                    @ReservationDate,
                    @ReservationTime,
                    @TableId,
                    @Status
                )";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@CustomerName",
                    resName.Text);

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    resPhone.Text);

                cmd.Parameters.AddWithValue(
                    "@PartySize",
                    resPartySize.Value);

                cmd.Parameters.AddWithValue(
                    "@ReservationDate",
                    resDate.Value.Date);

                cmd.Parameters.AddWithValue(
                    "@ReservationTime",
                    resTimeSlot.Text);

                cmd.Parameters.AddWithValue(
                    "@TableId",
                    resTable.Text);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    resStatus.Text);

                conn.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Reservation added successfully.");

                //LoadReservations();

                ClearForm();
            }
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == 0)
            {
                MessageBox.Show(
                    "Please select a reservation.");

                return;
            }

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query =
                @"UPDATE Reservations
                  SET
                    CustomerName = @CustomerName,
                    Phone = @Phone,
                    PartySize = @PartySize,
                    ReservationDate = @ReservationDate,
                    ReservationTime = @ReservationTime,
                    TableId = @TableId,
                    Status = @Status
                  WHERE ReservationId = @ReservationId";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue(
                    "@CustomerName",
                    resName.Text);

                cmd.Parameters.AddWithValue(
                    "@Phone",
                    resPhone.Text);

                cmd.Parameters.AddWithValue(
                    "@PartySize",
                    resPartySize.Value);

                cmd.Parameters.AddWithValue(
                    "@ReservationDate",
                    resDate.Value.Date);

                cmd.Parameters.AddWithValue(
                    "@ReservationTime",
                    resTimeSlot.Text);

                cmd.Parameters.AddWithValue(
                    "@TableId",
                    resTable.Text);

                cmd.Parameters.AddWithValue(
                    "@Status",
                    resStatus.Text);

                cmd.Parameters.AddWithValue(
                    "@ReservationId",
                    selectedReservationId);

                conn.Open();

                cmd.ExecuteNonQuery();

                MessageBox.Show(
                    "Reservation updated successfully.");

                //LoadReservations();

                ClearForm();
            }
        }

        private void btnDeleteReservation_Click(object sender, EventArgs e)
        {
            if (selectedReservationId == 0)
            {
                MessageBox.Show(
                    "Please select a reservation.");

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Delete this reservation?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo
                );

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    string query =
                    @"DELETE FROM Reservations
                      WHERE ReservationId = @ReservationId";

                    SqlCommand cmd =
                        new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue(
                        "@ReservationId",
                        selectedReservationId);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Reservation deleted.");

                    //LoadReservations();

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
        }

        private void LoadTimeSlots()
        {
            DateTime start = DateTime.Parse("4:00 PM");
            DateTime end = DateTime.Parse("9:00 PM");

            while (start <= end)
            {
                resTimeSlot.Items.Add(start.ToString("hh:mm tt"));
                start = start.AddMinutes(30);
            }
        }

        private void LoadStatusOptions()
        {
            resStatus.Items.Add("Confirmed");
            resStatus.Items.Add("Pending");
            resStatus.Items.Add("Seated");
            resStatus.Items.Add("Completed");
            resStatus.Items.Add("Cancelled");
            resStatus.Items.Add("No-show");
        }

    }
}