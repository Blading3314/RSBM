using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public partial class Dashboard : Form
    {
        private string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;
        Initial Catalog=RestaurantDB;
        Integrated Security=True";

        public Dashboard()
        {
            InitializeComponent();
            ApplyLanguage();
            LoadCustomerCount();
        }

        public void ApplyLanguage()
        {
            LanguageManager.ApplyLanguageToForm(this);

            lblDateTitle.Text = LanguageManager.GetString("Dashboard_Date");
            lblTimeDate.Text = LanguageManager.GetString("Dashboard_Time");
            lblCustomerTitle.Text = LanguageManager.GetString("Dashboard_CustomerCount");
        }

        private void dashboardTimer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void LoadCustomerCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query =
                @"SELECT COUNT(*)
                  FROM Reservations
                  WHERE ReservationDate = @Today";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Today", DateTime.Today);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    lblCustomerCount.Text = count.ToString();
                }
            }
        }
    }
}