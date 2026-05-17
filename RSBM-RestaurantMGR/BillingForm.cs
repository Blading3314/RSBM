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
            string selectedReservation = GetSelectedValue(reservationComboBox);

            LanguageManager.ApplyLanguageToForm(this);

            LoadPaymentMethods();
            LoadPaymentStatus();
            LoadReservationsForBilling();

            SelectComboBoxValue(paymentMethodComboBox, selectedPayment);
            SelectComboBoxValue(Status, selectedStatus);
            SelectComboBoxValue(reservationComboBox, selectedReservation);
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

        private void LoadReservationsForBilling()
        {
            try
            {
                reservationComboBox.BeginUpdate();
                reservationComboBox.Items.Clear();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query =
                        @"SELECT
                              r.ReservationID,
                              c.CustomerName,
                              rt.TableNumber,
                              r.ReservationDate,
                              r.ReservationTime
                          FROM Reservations r
                          INNER JOIN Customers c
                              ON r.CustomerID = c.CustomerID
                          INNER JOIN RestaurantTables rt
                              ON r.TableID = rt.TableID
                          LEFT JOIN Bills b
                              ON b.ReservationID = r.ReservationID
                          WHERE b.BillID IS NULL
                          ORDER BY r.ReservationDate, r.ReservationTime, c.CustomerName";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        DateTime reservationDate = Convert.ToDateTime(reader["ReservationDate"]);
                        TimeSpan reservationTime = (TimeSpan)reader["ReservationTime"];
                        string displayText = string.Format(
                            "#{0} - {1} - Table {2} - {3} {4}",
                            reader["ReservationID"],
                            reader["CustomerName"],
                            reader["TableNumber"],
                            reservationDate.ToString("MMM dd"),
                            DateTime.Today.Add(reservationTime).ToString("hh:mm tt"));

                        reservationComboBox.Items.Add(new ComboBoxItem(
                            displayText,
                            reader["ReservationID"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError("Message_BillReservationLoadError", ex);
            }
            finally
            {
                reservationComboBox.EndUpdate();
            }
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
            decimal subTotal;
            decimal taxAmount;
            decimal tipAmount;
            decimal total;
            decimal pricePerPerson;

            if (!TryCalculateBill(out subTotal, out taxAmount, out tipAmount, out total, out pricePerPerson))
            {
                return;
            }

            subtotalTextBox.Text = subTotal.ToString("0.00");
            totalTextBox.Text = total.ToString("0.00");
            pricePerPersonTextBox.Text = pricePerPerson.ToString("0.00");
        }

        private bool TryCalculateBill(
            out decimal subTotal,
            out decimal taxAmount,
            out decimal tipAmount,
            out decimal total,
            out decimal pricePerPerson)
        {
            subTotal = 0;
            taxAmount = 0;
            tipAmount = 0;
            total = 0;
            pricePerPerson = 0;

            int people = (int)numberOfPeople.Value;

            if (people <= 0)
            {
                return false;
            }

            // BASE PRICE
            subTotal = 50 * people;

            // EXTRAS
            if (drinksCheckBox.Checked)
                subTotal += 5 * people;

            if (premiumCheckBox.Checked)
                subTotal += 25 * people;

            // AUTO TAX 15%
            taxAmount = subTotal * 0.15m;

            // USER TIP %
            decimal tipPercent = numericUpDown1.Value;

            tipAmount =
                subTotal * (tipPercent / 100);

            // FINAL TOTAL
            total =
                subTotal + taxAmount + tipAmount;

            // PER PERSON
            pricePerPerson = total / people;
            return true;
        }

        private void LoadBills()
        {
            try
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
            catch (Exception ex)
            {
                ShowError("Message_BillLoadError", ex);
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
                ShowMessage("Message_SelectBill");
                return;
            }

            if (Status.SelectedItem == null)
            {
                ShowMessage("Message_SelectPaymentStatus");
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

            try
            {
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

                ShowMessage("Message_PaymentStatusUpdated");

                selectedBillId.Clear();
                Status.SelectedIndex = -1;
                dataGridBill.ClearSelection();

                LoadBills();
            }
            catch (Exception ex)
            {
                ShowError("Message_PaymentStatusUpdateError", ex);
            }
        }

        private void btnGenerateBill_Click(object sender, EventArgs e)
        {
            ComboBoxItem reservationItem =
                reservationComboBox.SelectedItem as ComboBoxItem;

            if (reservationItem == null)
            {
                ShowMessage("Message_SelectReservationForBill");
                return;
            }

            int reservationId;
            if (!int.TryParse(reservationItem.Value, out reservationId))
            {
                ShowMessage("Message_InvalidReservation");
                return;
            }

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
            decimal taxAmount;
            decimal tipAmount;
            decimal total;
            decimal pricePerPerson;

            if (!TryCalculateBill(out subtotal, out taxAmount, out tipAmount, out total, out pricePerPerson))
            {
                ShowMessage("Message_InvalidBillTotal");
                return;
            }

            string paymentStatus = "Waiting";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query =
                        @"INSERT INTO Bills
                ( ReservationID, SubTotal, TaxAmount, TotalAmount, PaymentMethod, PaymentStatus)
                VALUES
                ( @ReservationID, @SubTotal, @TaxAmount, @TotalAmount, @PaymentMethod, @PaymentStatus)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@ReservationID", reservationId);
                    cmd.Parameters.AddWithValue("@SubTotal", subtotal);
                    cmd.Parameters.AddWithValue("@TaxAmount",taxAmount);
                    cmd.Parameters.AddWithValue("@TotalAmount", total);
                    cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadBills();
                LoadReservationsForBilling();
                ShowReceiptWindow(subtotal, taxAmount, tipAmount, total, pricePerPerson, paymentItem.Text, paymentStatus);
            }
            catch (Exception ex)
            {
                ShowError("Message_BillSaveError", ex);
            }
        }

        private void ShowReceiptWindow(
            decimal subtotal,
            decimal taxAmount,
            decimal tipAmount,
            decimal total,
            decimal pricePerPerson,
            string paymentMethod,
            string paymentStatus)
        {
            Form receiptForm = new Form();
            receiptForm.Text = LanguageManager.GetString("Receipt_Title");
            receiptForm.StartPosition = FormStartPosition.CenterParent;
            receiptForm.Size = new Size(420, 520);
            receiptForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            receiptForm.MaximizeBox = false;
            receiptForm.MinimizeBox = false;

            TextBox receiptTextBox = new TextBox();
            receiptTextBox.Multiline = true;
            receiptTextBox.ReadOnly = true;
            receiptTextBox.ScrollBars = ScrollBars.Vertical;
            receiptTextBox.Font = new Font("Consolas", 10F);
            receiptTextBox.Dock = DockStyle.Fill;
            receiptTextBox.Text = BuildReceiptText(
                subtotal,
                taxAmount,
                tipAmount,
                total,
                pricePerPerson,
                paymentMethod,
                paymentStatus);

            Button closeButton = new Button();
            closeButton.Text = LanguageManager.GetString("Receipt_Close");
            closeButton.Dock = DockStyle.Bottom;
            closeButton.Height = 36;
            closeButton.Click += (s, e) => receiptForm.Close();

            receiptForm.Controls.Add(receiptTextBox);
            receiptForm.Controls.Add(closeButton);
            receiptForm.ShowDialog(this);
        }

        private string BuildReceiptText(
            decimal subtotal,
            decimal taxAmount,
            decimal tipAmount,
            decimal total,
            decimal pricePerPerson,
            string paymentMethod,
            string paymentStatus)
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("RSBM Korean BBQ");
            receipt.AppendLine(LanguageManager.GetString("Receipt_Header"));
            receipt.AppendLine("----------------------------------------");
            receipt.AppendLine(string.Format("{0}: {1}", LanguageManager.GetString("Receipt_Date"), DateTime.Now));
            receipt.AppendLine(string.Format("{0}: {1}", LanguageManager.GetString("Receipt_Guests"), numberOfPeople.Value));
            receipt.AppendLine(string.Format("{0}: {1}", LanguageManager.GetString("Receipt_PremiumMeat"), premiumCheckBox.Checked ? LanguageManager.GetString("MainForm_Yes") : LanguageManager.GetString("MainForm_No")));
            receipt.AppendLine(string.Format("{0}: {1}", LanguageManager.GetString("Receipt_Drinks"), drinksCheckBox.Checked ? LanguageManager.GetString("MainForm_Yes") : LanguageManager.GetString("MainForm_No")));
            receipt.AppendLine("----------------------------------------");
            receipt.AppendLine(string.Format("{0}: ${1:0.00}", LanguageManager.GetString("Receipt_Subtotal"), subtotal));
            receipt.AppendLine(string.Format("{0}: ${1:0.00}", LanguageManager.GetString("Receipt_Tax"), taxAmount));
            receipt.AppendLine(string.Format("{0}: ${1:0.00}", LanguageManager.GetString("Receipt_Tip"), tipAmount));
            receipt.AppendLine(string.Format("{0}: ${1:0.00}", LanguageManager.GetString("Receipt_Total"), total));
            receipt.AppendLine(string.Format("{0}: ${1:0.00}", LanguageManager.GetString("Receipt_PerPerson"), pricePerPerson));
            receipt.AppendLine("----------------------------------------");
            receipt.AppendLine(string.Format("{0}: {1}", LanguageManager.GetString("Receipt_PaymentMethod"), paymentMethod));
            receipt.AppendLine(string.Format("{0}: {1}", LanguageManager.GetString("Receipt_Status"), LanguageManager.GetString(paymentStatus)));
            receipt.AppendLine();
            receipt.AppendLine(LanguageManager.GetString("Receipt_ThankYou"));
            return receipt.ToString();
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
                ShowMessage("Message_SelectBillToDelete");
                return;
            }

            int billID;
            if (!int.TryParse(selectedBillId.Text, out billID))
            {
                ShowMessage("Message_InvalidBillId");
                return;
            }

            DialogResult result = MessageBox.Show(
                string.Format(LanguageManager.GetString("Message_ConfirmBillDelete"), billID),
                LanguageManager.GetString("Message_DeleteBillTitle"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

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

                    ShowMessage("Message_BillDeleted");
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
