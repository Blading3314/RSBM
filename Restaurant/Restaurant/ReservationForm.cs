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
using System.Configuration;

namespace Restaurant
{
    public partial class ReservationForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RestaurantDatabase"].ConnectionString;
        public ReservationForm()
        {
            InitializeComponent();
            LoadReservations();
        }
        private void LoadReservations()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Reservations";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable reservationData = new DataTable();
                adapter.Fill(reservationData);
                reservationDataGridView.DataSource = reservationData;
            }
        }
    }
}
