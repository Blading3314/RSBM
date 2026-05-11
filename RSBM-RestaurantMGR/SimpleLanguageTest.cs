using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public static class SimpleLanguageTest
    {
        public static void TestResourceLoading()
        {
            try
            {
                var rm = new ResourceManager(
                    "RSBM_RestaurantMGR.Resources.Resources",
                    System.Reflection.Assembly.GetExecutingAssembly());

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                string enHeader = rm.GetString("MainForm_Header") ?? "NOT FOUND";

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr");
                string frHeader = rm.GetString("MainForm_Header") ?? "NOT FOUND";

                Thread.CurrentThread.CurrentUICulture = new CultureInfo("es");
                string esHeader = rm.GetString("MainForm_Header") ?? "NOT FOUND";

                string result = string.Format(
                    "Resource Loading Test Results:\n\n" +
                    "English: {0}\n" +
                    "French: {1}\n" +
                    "Spanish: {2}",
                    enHeader,
                    frHeader,
                    esHeader);

                MessageBox.Show(result, "Resource Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(
                    string.Format("Resource test error: {0}", ex.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
