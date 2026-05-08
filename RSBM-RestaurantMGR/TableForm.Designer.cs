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
            this.tables = new System.Windows.Forms.Label();
            this.tableID = new System.Windows.Forms.Label();
            this.editTableLabel = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.tableIdTextBox = new System.Windows.Forms.TextBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.btnUpdateTable = new System.Windows.Forms.Button();
            this.tableGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tables
            // 
            this.tables.AutoSize = true;
            this.tables.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tables.Location = new System.Drawing.Point(12, 9);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(169, 25);
            this.tables.TabIndex = 1;
            this.tables.Text = "Manage Tables:";
            // 
            // tableID
            // 
            this.tableID.AutoSize = true;
            this.tableID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableID.Location = new System.Drawing.Point(12, 321);
            this.tableID.Name = "tableID";
            this.tableID.Size = new System.Drawing.Size(125, 20);
            this.tableID.TabIndex = 2;
            this.tableID.Text = "Selected Table:";
            // 
            // editTableLabel
            // 
            this.editTableLabel.AutoSize = true;
            this.editTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editTableLabel.Location = new System.Drawing.Point(12, 286);
            this.editTableLabel.Name = "editTableLabel";
            this.editTableLabel.Size = new System.Drawing.Size(100, 20);
            this.editTableLabel.TabIndex = 3;
            this.editTableLabel.Text = "Edit Table:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(284, 321);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(62, 20);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "Status:";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(529, 319);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(50, 20);
            this.typeLabel.TabIndex = 5;
            this.typeLabel.Text = "Type:";
            // 
            // tableIdTextBox
            // 
            this.tableIdTextBox.BackColor = System.Drawing.Color.White;
            this.tableIdTextBox.Location = new System.Drawing.Point(160, 319);
            this.tableIdTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableIdTextBox.Name = "tableIdTextBox";
            this.tableIdTextBox.ReadOnly = true;
            this.tableIdTextBox.Size = new System.Drawing.Size(108, 22);
            this.tableIdTextBox.TabIndex = 6;
            // 
            // statusComboBox
            // 
            this.statusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Location = new System.Drawing.Point(352, 321);
            this.statusComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(156, 24);
            this.statusComboBox.TabIndex = 7;
            // 
            // typeComboBox
            // 
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(585, 321);
            this.typeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(100, 24);
            this.typeComboBox.TabIndex = 8;
            // 
            // btnUpdateTable
            // 
            this.btnUpdateTable.Location = new System.Drawing.Point(17, 354);
            this.btnUpdateTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateTable.Name = "btnUpdateTable";
            this.btnUpdateTable.Size = new System.Drawing.Size(120, 38);
            this.btnUpdateTable.TabIndex = 9;
            this.btnUpdateTable.Text = "Update Table";
            this.btnUpdateTable.UseVisualStyleBackColor = true;
            // 
            // tableGrid
            // 
            this.tableGrid.AllowUserToAddRows = false;
            this.tableGrid.AllowUserToDeleteRows = false;
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.Location = new System.Drawing.Point(16, 47);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowHeadersWidth = 51;
            this.tableGrid.RowTemplate.Height = 24;
            this.tableGrid.Size = new System.Drawing.Size(684, 223);
            this.tableGrid.TabIndex = 10;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 405);
            this.Controls.Add(this.tableGrid);
            this.Controls.Add(this.btnUpdateTable);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.tableIdTextBox);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.editTableLabel);
            this.Controls.Add(this.tableID);
            this.Controls.Add(this.tables);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TableForm";
            this.Text = "Table MGR";
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tables;
        private System.Windows.Forms.Label tableID;
        private System.Windows.Forms.Label editTableLabel;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox tableIdTextBox;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Button btnUpdateTable;
        private System.Windows.Forms.DataGridView tableGrid;
    }
}