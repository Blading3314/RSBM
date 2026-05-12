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
            ApplyLanguage();
            LoadBills();
        }

        public void ApplyLanguage()
        {
            string selectedPayment = GetSelectedValue(paymentMethodComboBox);
            string selectedStatus = GetSelectedValue(Status);

            LanguageManager.ApplyLanguageToForm(this);

            LoadPaymentMethods();
            LoadPaymentStatus();

            SelectComboBoxValue(paymentMethodComboBox, selectedPayment);
            SelectComboBoxValue(Status, selectedStatus);
        }

        private void LoadPaymentMethods()
        {
            paymentMethodComboBox.BeginUpdate();
            paymentMethodComboBox.Items.Clear();

            paymentMethodComboBox.Items.Add(new ComboBoxItem(
                LanguageManager.GetString("Payment_Cash"),
                "Cash"));

            paymentMethodComboBox.Items.Add(new ComboBoxItem(
                LanguageManager.GetString("Payment_Debit"),
                "Debit"));

            paymentMethodComboBox.Items.Add(new ComboBoxItem(
                LanguageManager.GetString("Payment_Credit"),
                "Credit"));

            paymentMethodComboBox.EndUpdate();
        }
        private void LoadPaymentStatus()
        {
            Status.BeginUpdate();
            Status.Items.Clear();

            Status.Items.Add(new ComboBoxItem(
                LanguageManager.GetString("Paid"),
                "Paid"));

            Status.Items.Add(new ComboBoxItem(
                LanguageManager.GetString("Waiting"),
                "Waiting"));

            Status.EndUpdate();
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

        private static void SelectComboBoxValue(ComboBox comboBox, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                comboBox.SelectedIndex = -1;
                return;
            }

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.Items[i] is ComboBoxItem item)
                {
                    if (string.Equals(item.Value, value, StringComparison.Ordinal))
                    {
                        comboBox.SelectedIndex = i;
                        return;
                    }
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
                return Text ?? Value;
            }
        }
        private void CalculateBill()
        {
            int people = (int)numberOfPeople.Value;

            if (people <= 0)
                return;

            // BASE PRICE
            decimal subTotal = 50 * people;

            // EXTRAS
            if (drinksCheckBox.Checked)
                subTotal += 5 * people;

            if (premiumCheckBox.Checked)
                subTotal += 25 * people;

            // AUTO TAX 15%
            decimal taxAmount = subTotal * 0.15m;

            // USER TIP %
            decimal tipPercent = numericUpDown1.Value;

            decimal tipAmount =
                subTotal * (tipPercent / 100);

            // FINAL TOTAL
            decimal total =
                subTotal + taxAmount + tipAmount;

            // UI
            subtotalTextBox.Text =
                subTotal.ToString("0.00");

            totalTextBox.Text =
                total.ToString("0.00");

            // PER PERSON
            pricePerPersonTextBox.Text =
                (total / people).ToString("0.00");
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
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            // Get BillID from selected row
            int billID = 0;
            if (!string.IsNullOrEmpty(selectedBillId.Text))
            {
                int.TryParse(selectedBillId.Text, out billID);
            }
            else if (dataGridBill.SelectedRows.Count > 0)
            {
                billID = Convert.ToInt32(
                    dataGridBill.SelectedRows[0]
                    .Cells["BillID"].Value);
            }

            if (billID == 0)
            {
                MessageBox.Show("Please select a bill.");
                return;
            }

            if (Status.SelectedItem == null)
            {
                MessageBox.Show("Select Paid or Waiting.");
                return;
            }

            // Get selected status
            string paymentStatus = string.Empty;
            if (Status.SelectedItem is ComboBoxItem item)
            {
                paymentStatus = item.Value;
            }
            else
            {
                paymentStatus = Status.SelectedItem.ToString();
            }

            using (SqlConnection conn =
                new SqlConnection(connectionString))
            {
                string query =
                    @"UPDATE Bills
              SET PaymentStatus = @PaymentStatus
              WHERE BillID = @BillID";

                SqlCommand cmd =
                    new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                cmd.Parameters.AddWithValue("@BillID", billID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Payment status updated!");

            selectedBillId.Clear();
            Status.SelectedIndex = -1;
            dataGridBill.ClearSelection();

            LoadBills();
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
            decimal taxAmount = subtotal * 0.15m;

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
                    cmd.Parameters.AddWithValue("@TaxAmount",taxAmount);
                    cmd.Parameters.AddWithValue("@TotalAmount", total);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@PaymentStatus", "Waiting");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                ShowMessage("Message_BillSaved");
                LoadBills();
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
            LoadSelectedBill();
        }

        private void dataGridBill_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedBill();
        }

        private void LoadSelectedBill()
        {
            if (dataGridBill.CurrentRow == null || dataGridBill.CurrentRow.IsNewRow)
                return;

            object billIdValue = dataGridBill.CurrentRow.Cells["BillID"].Value;

            if (billIdValue == null || billIdValue == DBNull.Value)
                return;

            int id;
            if (!int.TryParse(billIdValue.ToString(), out id))
                return;

            selectedBillId.Text = id.ToString();

            object statusValue = dataGridBill.CurrentRow.Cells["PaymentStatus"].Value;
            if (statusValue != null && statusValue != DBNull.Value)
            {
                SelectComboBoxValue(Status, statusValue.ToString());
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedBillId.Text))
            {
                MessageBox.Show("Please select a bill to delete.");
                return;
            }

            int billID;
            if (!int.TryParse(selectedBillId.Text, out billID))
            {
                MessageBox.Show("Invalid Bill ID.");
                return;
            }

            DialogResult result = MessageBox.Show($"Are you sure you want to delete Bill ID: {billID}?", "Delete Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Bills WHERE BillID = @BillID";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@BillID", billID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Bill successfully deleted.");
                    selectedBillId.Clear();
                    Status.SelectedIndex = -1;
                    LoadBills();
                }
                catch (Exception ex)
                {
                    ShowError("Message_DeleteError", ex);
                }
            }
        }
    }

}
