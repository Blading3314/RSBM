namespace RSBM_RestaurantMGR
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tables = new System.Windows.Forms.Label();
            this.tableID = new System.Windows.Forms.Label();
            this.editTableLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.selectBillId = new System.Windows.Forms.TextBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableStatusDateLabel = new System.Windows.Forms.Label();
            this.tableStatusDatePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tables
            // 
            this.tables.AutoSize = true;
            this.tables.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tables.ForeColor = System.Drawing.Color.White;
            this.tables.Location = new System.Drawing.Point(3, 0);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(220, 38);
            this.tables.TabIndex = 1;
            this.tables.Text = "Manage Tables:";
            // 
            // tableID
            // 
            this.tableID.AutoSize = true;
            this.tableID.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.tableID.Location = new System.Drawing.Point(18, 55);
            this.tableID.Name = "tableID";
            this.tableID.Size = new System.Drawing.Size(127, 25);
            this.tableID.TabIndex = 2;
            this.tableID.Text = "Selected Table:";
            // 
            // editTableLabel
            // 
            this.editTableLabel.AutoSize = true;
            this.editTableLabel.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTableLabel.Location = new System.Drawing.Point(18, 13);
            this.editTableLabel.Name = "editTableLabel";
            this.editTableLabel.Size = new System.Drawing.Size(110, 28);
            this.editTableLabel.TabIndex = 3;
            this.editTableLabel.Text = "Edit Table:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.statusLabel.Location = new System.Drawing.Point(315, 55);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(64, 25);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.typeLabel.Location = new System.Drawing.Point(594, 55);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(53, 25);
            this.typeLabel.TabIndex = 5;
            this.typeLabel.Text = "Type:";
            // 
            // selectBillId
            // 
            this.selectBillId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.selectBillId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectBillId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectBillId.Location = new System.Drawing.Point(168, 59);
            this.selectBillId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selectBillId.Name = "selectBillId";
            this.selectBillId.ReadOnly = true;
            this.selectBillId.Size = new System.Drawing.Size(108, 20);
            this.selectBillId.TabIndex = 6;
            this.selectBillId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // statusComboBox
            // 
            this.statusComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statusComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusComboBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(396, 56);
            this.statusComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(156, 28);
            this.statusComboBox.TabIndex = 7;
            // 
            // typeComboBox
            // 
            this.typeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.typeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.typeComboBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(670, 56);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(171, 28);
            this.typeComboBox.TabIndex = 8;
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnUpdateTable.FlatAppearance.BorderSize = 0;
            this.btnUpdateTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTable.ForeColor = System.Drawing.Color.White;
            this.btnUpdateTable.Location = new System.Drawing.Point(10, 569);
            this.btnUpdateTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(130, 55);
            this.btnUpdateTable.TabIndex = 9;
            this.btnUpdateTable.Text = "Update Table";
            this.btnUpdateTable.UseVisualStyleBackColor = false;
            // 
            // tableGrid
            // 
            this.tableGrid.AllowUserToAddRows = false;
            this.tableGrid.AllowUserToDeleteRows = false;
            this.tableGrid.AllowUserToResizeColumns = false;
            this.tableGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.tableGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tableGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableGrid.BackgroundColor = System.Drawing.Color.White;
            this.tableGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tableGrid.ColumnHeadersHeight = 33;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.tableGrid.EnableHeadersVisualStyles = false;
            this.tableGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.tableGrid.Location = new System.Drawing.Point(12, 183);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowHeadersVisible = false;
            this.tableGrid.RowHeadersWidth = 51;
            this.tableGrid.RowTemplate.Height = 24;
            this.tableGrid.Size = new System.Drawing.Size(883, 371);
            this.tableGrid.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.panel1.Controls.Add(this.tables);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 45);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tableStatusDatePicker);
            this.panel2.Controls.Add(this.tableStatusDateLabel);
            this.panel2.Controls.Add(this.editTableLabel);
            this.panel2.Controls.Add(this.tableID);
            this.panel2.Controls.Add(this.statusLabel);
            this.panel2.Controls.Add(this.typeLabel);
            this.panel2.Controls.Add(this.typeComboBox);
            this.panel2.Controls.Add(this.selectBillId);
            this.panel2.Controls.Add(this.statusComboBox);
            this.panel2.Location = new System.Drawing.Point(10, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(885, 101);
            this.panel2.TabIndex = 12;
            // 
            // tableStatusDateLabel
            // 
            this.tableStatusDateLabel.AutoSize = true;
            this.tableStatusDateLabel.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.tableStatusDateLabel.Location = new System.Drawing.Point(594, 13);
            this.tableStatusDateLabel.Name = "tableStatusDateLabel";
            this.tableStatusDateLabel.Size = new System.Drawing.Size(52, 25);
            this.tableStatusDateLabel.TabIndex = 9;
            this.tableStatusDateLabel.Text = "Date:";
            // 
            // tableStatusDatePicker
            // 
            this.tableStatusDatePicker.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tableStatusDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tableStatusDatePicker.Location = new System.Drawing.Point(670, 13);
            this.tableStatusDatePicker.Name = "tableStatusDatePicker";
            this.tableStatusDatePicker.Size = new System.Drawing.Size(171, 27);
            this.tableStatusDatePicker.TabIndex = 10;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(915, 636);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.btnUpdateTable);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TableForm";
            this.Text = "Table MGR";
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label tables;
        private System.Windows.Forms.Label tableID;
        private System.Windows.Forms.Label editTableLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox selectBillId;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.DataGridView tableGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label tableStatusDateLabel;
        private System.Windows.Forms.DateTimePicker tableStatusDatePicker;
    }
}
