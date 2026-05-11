using System;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public partial class RestoForm : Form
    {
        private bool _isInitializingLanguage;

        public RestoForm()
        {
            InitializeComponent();
            InitializeLanguage();
            ApplyLanguage();
        }

        private void InitializeLanguage()
        {
            _isInitializingLanguage = true;

            string savedLanguage = Properties.Settings.Default.Language;
            if (string.IsNullOrWhiteSpace(savedLanguage))
            {
                savedLanguage = "en";
            }

            switch (savedLanguage)
            {
                case "fr":
                    cmbLanguage.SelectedIndex = 1;
                    break;
                case "es":
                    cmbLanguage.SelectedIndex = 2;
                    break;
                default:
                    cmbLanguage.SelectedIndex = 0;
                    break;
            }

            LanguageManager.SetCulture(savedLanguage);
            _isInitializingLanguage = false;
        }

        private void ApplyLanguage()
        {
            try
            {
                // Apply language to main form
                LanguageManager.ApplyLanguageToForm(this);
                
                // Apply language to current child form if exists
                if (mainPanel.Controls.Count > 0 && mainPanel.Controls[0] is Form)
                {
                    Form childForm = (Form)mainPanel.Controls[0];
                    
                    // Call the specific ApplyLanguage method if it exists
                    if (childForm is ReservationForm)
                    {
                        ((ReservationForm)childForm).ApplyLanguage();
                    }
                    else if (childForm is TableForm)
                    {
                        ((TableForm)childForm).ApplyLanguage();
                    }
                    else if (childForm is BillingForm)
                    {
                        ((BillingForm)childForm).ApplyLanguage();
                    }
                    else
                    {
                        // Fallback to generic language application
                        LanguageManager.ApplyLanguageToForm(childForm);
                    }
                }
            }
            catch (Exception ex)
            {
                // If language loading fails, show error but continue
                MessageBox.Show(string.Format("Language loading error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

            // Apply language to child form
            if (childForm is ReservationForm)
            {
                ((ReservationForm)childForm).ApplyLanguage();
            }
            else if (childForm is TableForm)
            {
                ((TableForm)childForm).ApplyLanguage();
            }
            else if (childForm is BillingForm)
            {
                ((BillingForm)childForm).ApplyLanguage();
            }
            else
            {
                // Fallback to generic language application
                LanguageManager.ApplyLanguageToForm(childForm);
            }

            childForm.BringToFront();
            childForm.Show();
        }

        private void cmbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isInitializingLanguage)
            {
                return;
            }

            string cultureCode = "en";
            switch (cmbLanguage.SelectedIndex)
            {
                case 1: // French
                    cultureCode = "fr";
                    break;
                case 2: // Spanish
                    cultureCode = "es";
                    break;
                default: // English
                    cultureCode = "en";
                    break;
            }

            // Set the culture
            LanguageManager.SetCulture(cultureCode);
            
            Properties.Settings.Default.Language = cultureCode;
            Properties.Settings.Default.Save();

            // Apply language to all forms
            ApplyLanguage();
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

        private void quitButton_Click(object sender, EventArgs e)
        {
            //Confirm before quitting
            var result = MessageBox.Show("Are you sure you want to quit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }


        }
    }
}
