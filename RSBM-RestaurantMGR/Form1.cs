using System;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public partial class RestoForm : Form
    {
        public RestoForm()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            // Clear previous form
            mainPanel.Controls.Clear();

            // Configure child form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add to panel
            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        private void btnReservations_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ReservationForm());
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TableForm());
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BillingForm());
        }
    }
}