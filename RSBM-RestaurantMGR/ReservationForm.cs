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
        public ReservationForm()
        {
            InitializeComponent();

            LoadReservations();
        }

        private void LoadReservations()
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
        }
    }
}
