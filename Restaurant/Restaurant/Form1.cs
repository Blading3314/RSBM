using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class RestoForm : Form
    {
        public RestoForm()
        {
            InitializeComponent();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            new ReservationForm().Show();
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            new TableForm().Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            new BillingForm().Show();
        }
    }
}
