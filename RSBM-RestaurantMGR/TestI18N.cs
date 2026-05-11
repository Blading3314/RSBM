using System;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public class TestI18N
    {
        public static void TestLanguageManager()
        {
            try
            {
                // Test English
                LanguageManager.SetCulture("en");
                string englishTitle = LanguageManager.GetString("MainForm_Title");
                string englishHeader = LanguageManager.GetString("MainForm_Header");
                
                // Test French
                LanguageManager.SetCulture("fr");
                string frenchTitle = LanguageManager.GetString("MainForm_Title");
                string frenchHeader = LanguageManager.GetString("MainForm_Header");
                
                // Test Spanish
                LanguageManager.SetCulture("es");
                string spanishTitle = LanguageManager.GetString("MainForm_Title");
                string spanishHeader = LanguageManager.GetString("MainForm_Header");
                
                // Display results
                string result = string.Format(
                    "Internationalization Test Results:\n\n" +
                    "English:\n" +
                    "  Title: {0}\n" +
                    "  Header: {1}\n\n" +
                    "French:\n" +
                    "  Title: {2}\n" +
                    "  Header: {3}\n\n" +
                    "Spanish:\n" +
                    "  Title: {4}\n" +
                    "  Header: {5}",
                    englishTitle, englishHeader, frenchTitle, frenchHeader, spanishTitle, spanishHeader);
                
                MessageBox.Show(result, "I18N Test Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Reset to English
                LanguageManager.SetCulture("en");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error testing internationalization: {0}", ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
