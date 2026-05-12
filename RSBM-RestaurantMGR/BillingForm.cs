using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSBM_RestaurantMGR
{
    public partial class BillingForm : Form
    {
        private string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;
        Initial Catalog=RestaurantDB;
        Integrated Security=True";
        public BillingForm()
        {
            InitializeComponent();
            LoadPaymentMethods();
            ApplyLanguage();
            LoadBills();
        }
      
        public void ApplyLanguage()
        {
            string selectedPayment =
                GetSelectedValue(paymentMethodComboBox);

            LanguageManager.ApplyLanguageToForm(this);

            LoadPaymentMethods();

            SelectComboBoxValue(
                paymentMethodComboBox,
                selectedPayment);
        }

        private void LoadPaymentMethods()
        {
            paymentMethodComboBox.Items.Clear();

            paymentMethodComboBox.Items.Add(
                new ComboBoxItem(
                    LanguageManager.GetString("Payment_Cash"),
                    "Cash"));

            paymentMethodComboBox.Items.Add(
                new ComboBoxItem(
                    LanguageManager.GetString("Payment_Debit"),
                    "Debit"));

            paymentMethodComboBox.Items.Add(
                new ComboBoxItem(
                    LanguageManager.GetString("Payment_Credit"),
                    "Credit"));
        }

        private static string GetSelectedValue(
            ComboBox comboBox)
        {
            ComboBoxItem item =
                comboBox.SelectedItem as ComboBoxItem;

            return item == null
                ? null
                : item.Value;
        }

        private static void SelectComboBoxValue(
            ComboBox comboBox,
            string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                comboBox.SelectedIndex = -1;
                return;
            }

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                ComboBoxItem item =
                    comboBox.Items[i] as ComboBoxItem;

                if (item != null &&
                    item.Value == value)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }

            comboBox.SelectedIndex = -1;
        }

        private class ComboBoxItem
        {
            public ComboBoxItem(
                string text,
                string value)
            {
                Text = text;
                Value = value;
            }

            public string Text { get; private set; }

            public string Value { get; private set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void CalculateBill()
        {
            int people = (int)numberOfPeople.Value;

            if (people <= 0)
                return;

            decimal subTotal = 50 * people;

            if (drinksCheckBox.Checked)
                subTotal += 5 * people;

            if (premiumCheckBox.Checked)
                subTotal += 25 * people;

            decimal tipPercent = numericUpDown1.Value; 

            decimal tipAmount = subTotal * (tipPercent / 100);

            decimal total = subTotal + tipAmount;

            
            subtotalTextBox.Text = subTotal.ToString("0.00");
            totalTextBox.Text = total.ToString("0.00");

            pricePerPersonTextBox.Text =
                (subTotal / people).ToString("0.00");
        }
        private void LoadBills()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Bills";

                SqlDataAdapter adapter =
                    new SqlDataAdapter(query, conn);

                DataTable table = new DataTable();

                adapter.Fill(table);

                dataGridBill.DataSource = table;
            }
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            CalculateBill();

            if (paymentMethodComboBox.SelectedIndex == -1)
            {
                ShowMessage("Message_SelectPaymentMethod");
                return;
            }

            ComboBoxItem paymentItem =
                paymentMethodComboBox.SelectedItem as ComboBoxItem;

            if (paymentItem == null)
            {
                ShowMessage("Message_SelectPaymentMethod");
                return;
            }

            string paymentMethod = paymentItem.Value;

            decimal subtotal;
            decimal total;

            if (!decimal.TryParse(subtotalTextBox.Text, out subtotal) ||
                !decimal.TryParse(totalTextBox.Text, out total))
            {
                ShowMessage("Message_InvalidBillTotal");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query =
                        @"INSERT INTO Bills
                ( SubTotal, TaxAmount, TotalAmount, PaymentMethod, PaymentStatus)
                VALUES
                ( @SubTotal, @TaxAmount, @TotalAmount, @PaymentMethod, @PaymentStatus)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@SubTotal", subtotal);
                    cmd.Parameters.AddWithValue("@TaxAmount", numericUpDown1.Value);
                    cmd.Parameters.AddWithValue("@TotalAmount", total);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@PaymentStatus", "Paid");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                ShowMessage("Message_BillSaved");
            }
            catch (Exception ex)
            {
                ShowError("Message_BillSaveError", ex);
            }
        }

        private void ShowMessage(string resourceKey)
        {
            MessageBox.Show(LanguageManager.GetString(resourceKey));
        }

        private void ShowError(string resourceKey, Exception ex)
        {
            MessageBox.Show(
                string.Format("{0}\n\n{1}", LanguageManager.GetString(resourceKey), ex.Message),
                LanguageManager.GetString("Message_ErrorTitle"),
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void dataGridBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }

}
