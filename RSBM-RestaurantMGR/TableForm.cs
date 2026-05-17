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
    public partial class TableForm : Form
    {
        private string connectionString =
        @"Data Source=(LocalDB)\MSSQLLocalDB;
        Initial Catalog=RestaurantDB;
        Integrated Security=True";

        private int selectedTableId = 0;

        public TableForm()
        {
            InitializeComponent();

            InitializeTableControls();
            LoadTables();
        }

        public void ApplyLanguage()
        {
            string selectedStatus = GetSelectedValue(statusComboBox);
            string selectedType = GetSelectedValue(typeComboBox);

            LanguageManager.ApplyLanguageToForm(this);
            LoadStatusOptions();
            LoadTableTypeOptions();

            SelectComboBoxValue(statusComboBox, selectedStatus);
            SelectComboBoxValue(typeComboBox, selectedType);
            RefreshTableDisplayText();
            ApplyTableGridHeaders();
        }

        private void InitializeTableControls()
        {
            tableStatusDatePicker.CustomFormat = "MMM dd, yyyy";
            tableStatusDatePicker.MinDate = DateTime.Today;
            tableStatusDatePicker.MaxDate = DateTime.Today.AddMonths(2);
            tableStatusDatePicker.Value = DateTime.Today;
            tableStatusDatePicker.ValueChanged += tableStatusDatePicker_ValueChanged;

            tableGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableGrid.MultiSelect = false;
            tableGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tableGrid.CellClick += tableGrid_CellClick;
            tableGrid.SelectionChanged += tableGrid_SelectionChanged;

            btnUpdateTable.Click += btnUpdateTable_Click;

            LoadStatusOptions();
            LoadTableTypeOptions();
            ClearSelection();
        }

        private void LoadTables()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                        SELECT
                            rt.TableID,
                            rt.TableNumber,
                            rt.Capacity,
                            CASE
                                WHEN rt.Status = 'Occupied' THEN 'Occupied'
                                WHEN EXISTS
                                (
                                    SELECT 1
                                    FROM Reservations r
                                    WHERE r.TableID = rt.TableID
                                    AND CAST(r.ReservationDate AS date) = @StatusDate
                                ) THEN 'Reserved'
                                ELSE rt.Status
                            END AS Status
                        FROM RestaurantTables rt
                        ORDER BY rt.TableNumber";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@StatusDate", tableStatusDatePicker.Value.Date);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);
                    AddLocalizedDisplayColumns(dt);

                    tableGrid.DataSource = dt;

                    if (tableGrid.Columns["TableID"] != null)
                    {
                        tableGrid.Columns["TableID"].Visible = false;
                    }

                    if (tableGrid.Columns["Status"] != null)
                    {
                        tableGrid.Columns["Status"].Visible = false;
                    }

                    ApplyTableGridHeaders();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("{0}\n\n{1}", LanguageManager.GetString("Message_TableLoadError"), ex.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AddLocalizedDisplayColumns(DataTable dt)
        {
            if (!dt.Columns.Contains("TableType"))
            {
                dt.Columns.Add("TableType", typeof(string));
            }

            if (!dt.Columns.Contains("StatusDisplay"))
            {
                dt.Columns.Add("StatusDisplay", typeof(string));
            }

            foreach (DataRow row in dt.Rows)
            {
                int capacity = Convert.ToInt32(row["Capacity"]);
                string status = Convert.ToString(row["Status"]);

                row["TableType"] = GetTableTypeText(capacity);
                row["StatusDisplay"] = GetStatusText(status);
            }
        }

        private void RefreshTableDisplayText()
        {
            DataTable dt = tableGrid.DataSource as DataTable;
            if (dt == null)
            {
                return;
            }

            foreach (DataRow row in dt.Rows)
            {
                row["TableType"] = GetTableTypeText(Convert.ToInt32(row["Capacity"]));
                row["StatusDisplay"] = GetStatusText(Convert.ToString(row["Status"]));
            }
        }

        private void ApplyTableGridHeaders()
        {
            SetColumnHeader("TableNumber", "TableGrid_TableNumber");
            SetColumnHeader("Capacity", "TableGrid_Capacity");
            SetColumnHeader("TableType", "TableGrid_TableType");
            SetColumnHeader("StatusDisplay", "TableGrid_Status");
        }

        private void SetColumnHeader(string columnName, string resourceKey)
        {
            if (tableGrid.Columns[columnName] != null)
            {
                tableGrid.Columns[columnName].HeaderText = LanguageManager.GetString(resourceKey);
            }
        }

        private string GetTableTypeText(int capacity)
        {
            if (capacity <= 2)
            {
                return LanguageManager.GetString("TableType_TwoSeat");
            }

            if (capacity <= 4)
            {
                return LanguageManager.GetString("TableType_FourSeat");
            }

            if (capacity <= 6)
            {
                return LanguageManager.GetString("TableType_SixSeat");
            }

            return LanguageManager.GetString("TableType_EightSeat");
        }

        private string GetStatusText(string status)
        {
            switch (status)
            {
                case "Reserved":
                    return LanguageManager.GetString("TableStatus_Reserved");
                case "Occupied":
                    return LanguageManager.GetString("TableStatus_Occupied");
                default:
                    return LanguageManager.GetString("TableStatus_Available");
            }
        }

        private void LoadStatusOptions()
        {
            statusComboBox.Items.Clear();
            statusComboBox.Items.Add(new ComboBoxItem(LanguageManager.GetString("TableStatus_Available"), "Available"));
            statusComboBox.Items.Add(new ComboBoxItem(LanguageManager.GetString("TableStatus_Reserved"), "Reserved"));
            statusComboBox.Items.Add(new ComboBoxItem(LanguageManager.GetString("TableStatus_Occupied"), "Occupied"));
        }

        private void LoadTableTypeOptions()
        {
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.Items.Clear();
            typeComboBox.Items.Add(new ComboBoxItem(LanguageManager.GetString("TableType_TwoSeat"), "2"));
            typeComboBox.Items.Add(new ComboBoxItem(LanguageManager.GetString("TableType_FourSeat"), "4"));
            typeComboBox.Items.Add(new ComboBoxItem(LanguageManager.GetString("TableType_SixSeat"), "6"));
            typeComboBox.Items.Add(new ComboBoxItem(LanguageManager.GetString("TableType_EightSeat"), "8"));
        }

        private void tableGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadSelectedTable();
            }
        }

        private void tableGrid_SelectionChanged(object sender, EventArgs e)
        {
            LoadSelectedTable();
        }

        private void tableStatusDatePicker_ValueChanged(object sender, EventArgs e)
        {
            LoadTables();
            ClearSelection();
        }

        private void LoadSelectedTable()
        {
            if (tableGrid.CurrentRow == null || tableGrid.CurrentRow.IsNewRow)
            {
                return;
            }

            object tableIdValue = tableGrid.CurrentRow.Cells["TableID"].Value;
            object tableNumberValue = tableGrid.CurrentRow.Cells["TableNumber"].Value;
            object capacityValue = tableGrid.CurrentRow.Cells["Capacity"].Value;
            object statusValue = tableGrid.CurrentRow.Cells["Status"].Value;

            if (tableIdValue == null || tableIdValue == DBNull.Value)
            {
                ClearSelection();
                return;
            }

            selectedTableId = Convert.ToInt32(tableIdValue);
            selectBillId.Text = Convert.ToString(tableNumberValue);
            SelectComboBoxValue(typeComboBox, Convert.ToString(capacityValue));
            SelectComboBoxValue(statusComboBox, Convert.ToString(statusValue));
            btnUpdateTable.Enabled = true;
        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            if (selectedTableId == 0)
            {
                MessageBox.Show(LanguageManager.GetString("Message_SelectTable"));
                return;
            }

            string selectedStatus = GetSelectedValue(statusComboBox);
            string selectedCapacity = GetSelectedValue(typeComboBox);

            if (string.IsNullOrEmpty(selectedStatus) || string.IsNullOrEmpty(selectedCapacity))
            {
                MessageBox.Show(LanguageManager.GetString("Message_SelectTableOptions"));
                return;
            }

            if (tableGrid.CurrentRow != null &&
                tableGrid.CurrentRow.Cells["Status"].Value.ToString() == selectedStatus &&
                tableGrid.CurrentRow.Cells["Capacity"].Value.ToString() == selectedCapacity)
            {
                MessageBox.Show(LanguageManager.GetString("Message_NoChangesMade"));
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE RestaurantTables
                      SET Capacity = @Capacity,
                          Status = @Status
                      WHERE TableID = @TableID", conn))
                {
                    cmd.Parameters.AddWithValue("@Capacity", Convert.ToInt32(selectedCapacity));
                    cmd.Parameters.AddWithValue("@Status", selectedStatus);
                    cmd.Parameters.AddWithValue("@TableID", selectedTableId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(LanguageManager.GetString("Message_TableUpdated"));
                LoadTables();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("{0}\n\n{1}", LanguageManager.GetString("Message_TableUpdateError"), ex.Message),
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ClearSelection()
        {
            selectedTableId = 0;
            selectBillId.Clear();
            statusComboBox.SelectedIndex = -1;
            typeComboBox.SelectedIndex = -1;
            btnUpdateTable.Enabled = false;
        }

        private static string GetSelectedValue(ComboBox comboBox)
        {
            ComboBoxItem item = comboBox.SelectedItem as ComboBoxItem;
            return item == null ? null : item.Value;
        }

        private static void SelectComboBoxValue(ComboBox comboBox, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                comboBox.SelectedIndex = -1;
                return;
            }

            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                ComboBoxItem item = comboBox.Items[i] as ComboBoxItem;
                if (item != null && item.Value == value)
                {
                    comboBox.SelectedIndex = i;
                    return;
                }
            }

            comboBox.SelectedIndex = -1;
        }

        private class ComboBoxItem
        {
            public ComboBoxItem(string text, string value)
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
    }
}
