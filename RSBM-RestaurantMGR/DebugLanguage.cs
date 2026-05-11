using System;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public static class DebugLanguage
    {
        public static void TestLanguageSwitching()
        {
            try
            {
                // Test if we can access the language controls
                Form mainForm = Application.OpenForms["RestoForm"] as RestoForm;
                if (mainForm != null)
                {
                    var comboBox = mainForm.Controls.Find("cmbLanguage", true);
                    if (comboBox.Length > 0)
                    {
                        MessageBox.Show("Language combo found!", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Test switching to French
                        if (comboBox[0] is ComboBox)
                        {
                            ComboBox cmb = (ComboBox)comboBox[0];
                            cmb.SelectedIndex = 1;
                            MessageBox.Show("Switched to French", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Language combo NOT found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Main form not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Debug error: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
