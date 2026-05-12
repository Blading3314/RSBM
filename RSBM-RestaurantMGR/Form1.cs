using System;
using System.Data.SqlClient;
using System.Drawing;
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
            OpenChildForm(new Dashboard());
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
                LanguageManager.ApplyLanguageToForm(this);

                if (mainPanel.Controls.Count > 0 && mainPanel.Controls[0] is Form)
                {
                    Form childForm = (Form)mainPanel.Controls[0];

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
                    else if (childForm is Dashboard)
                    {
                        ((Dashboard)childForm).ApplyLanguage();
                    }
                    else
                    {
                        LanguageManager.ApplyLanguageToForm(childForm);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("{0}\n\n{1}", LanguageManager.GetString("Message_LanguageLoadError"), ex.Message),
                    LanguageManager.GetString("Message_ErrorTitle"),
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void OpenChildForm(Form childForm)
        {
            mainPanel.Controls.Clear();

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            mainPanel.Controls.Add(childForm);
            mainPanel.Tag = childForm;

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
            else if (childForm is Dashboard)
            {
                ((Dashboard)childForm).ApplyLanguage();
            }
            else
            {
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
                case 1:
                    cultureCode = "fr";
                    break;
                case 2:
                    cultureCode = "es";
                    break;
                default:
                    cultureCode = "en";
                    break;
            }

            LanguageManager.SetCulture(cultureCode);

            Properties.Settings.Default.Language = cultureCode;
            Properties.Settings.Default.Save();

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

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Dashboard());
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            string message = GetLocalizedText("MainForm_QuitConfirmation", "Are you sure you want to quit?");
            string caption = GetLocalizedText("MainForm_Quit", "Quit");
            string yesText = GetLocalizedText("MainForm_Yes", "Yes");
            string noText = GetLocalizedText("MainForm_No", "No");
            DialogResult result = ShowLocalizedYesNoDialog(message, caption, yesText, noText);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private string GetLocalizedText(string resourceKey, string fallback)
        {
            string text = LanguageManager.GetString(resourceKey);
            return string.IsNullOrWhiteSpace(text) || text == resourceKey ? fallback : text;
        }

        private DialogResult ShowLocalizedYesNoDialog(string message, string caption, string yesText, string noText)
        {
            using (Form dialog = new Form())
            using (Label messageLabel = new Label())
            using (Button yesButton = new Button())
            using (Button noButton = new Button())
            {
                dialog.Text = caption;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ClientSize = new Size(360, 145);
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;
                dialog.ShowInTaskbar = false;
                dialog.AcceptButton = yesButton;
                dialog.CancelButton = noButton;

                messageLabel.Text = message;
                messageLabel.Location = new Point(18, 18);
                messageLabel.Size = new Size(324, 55);
                messageLabel.TextAlign = ContentAlignment.MiddleLeft;

                yesButton.Text = yesText;
                yesButton.DialogResult = DialogResult.Yes;
                yesButton.Location = new Point(156, 94);
                yesButton.Size = new Size(88, 30);

                noButton.Text = noText;
                noButton.DialogResult = DialogResult.No;
                noButton.Location = new Point(254, 94);
                noButton.Size = new Size(88, 30);

                dialog.Controls.Add(messageLabel);
                dialog.Controls.Add(yesButton);
                dialog.Controls.Add(noButton);

                return dialog.ShowDialog(this);
            }
        }

        private void dashboardTimer_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}