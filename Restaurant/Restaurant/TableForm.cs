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
    public partial class TableForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["RestaurantDatabase"].ConnectionString;
        public TableForm()
        {
            InitializeComponent();
            LoadTables();
        }
        private void LoadTables()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Tables";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable tableData = new DataTable();
                adapter.Fill(tableData);
                tablesDataGridView.DataSource = tableData;
            }
        }
    }
}
