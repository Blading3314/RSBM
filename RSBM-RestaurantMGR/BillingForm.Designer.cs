namespace RSBM_RestaurantMGR
{
    partial class BillingForm
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
            this.billing = new System.Windows.Forms.Label();
            this.tableInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.tableInfoBox = new System.Windows.Forms.TextBox();
            this.tableInfoLabel = new System.Windows.Forms.Label();
            this.tableIdLabel = new System.Windows.Forms.Label();
            this.tableIdComboBox = new System.Windows.Forms.ComboBox();
            this.aycePricingGrpupBox = new System.Windows.Forms.GroupBox();
            this.pricePerPersonTextBox = new System.Windows.Forms.TextBox();
            this.numberOfPeople = new System.Windows.Forms.NumericUpDown();
            this.numGuestsLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.paymentMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.subtotalTextBox = new System.Windows.Forms.TextBox();
            this.paymentMethodComboBox = new System.Windows.Forms.ComboBox();
            this.paymentMethodLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.totalLabel = new System.Windows.Forms.Label();
            this.tipLabel = new System.Windows.Forms.Label();
            this.subtotalLabel = new System.Windows.Forms.Label();
            this.extrasGroupBox = new System.Windows.Forms.GroupBox();
            this.premiumCheckBox = new System.Windows.Forms.CheckBox();
            this.drinksCheckBox = new System.Windows.Forms.CheckBox();
            this.btnGenerateBill = new System.Windows.Forms.Button();
            this.dataGridBill = new System.Windows.Forms.DataGridView();
            this.tableInfoGroupBox.SuspendLayout();
            this.aycePricingGrpupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPeople)).BeginInit();
            this.paymentMethodGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.extrasGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBill)).BeginInit();
            this.SuspendLayout();
            // 
            // billing
            // 
            this.billing.AutoSize = true;
            this.billing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billing.Location = new System.Drawing.Point(12, 9);
            this.billing.Name = "billing";
            this.billing.Size = new System.Drawing.Size(132, 25);
            this.billing.TabIndex = 2;
            this.billing.Text = "Manage Bill:";
            // 
            // tableInfoGroupBox
            // 
            this.tableInfoGroupBox.Controls.Add(this.tableInfoBox);
            this.tableInfoGroupBox.Controls.Add(this.tableInfoLabel);
            this.tableInfoGroupBox.Controls.Add(this.tableIdLabel);
            this.tableInfoGroupBox.Controls.Add(this.tableIdComboBox);
            this.tableInfoGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableInfoGroupBox.Location = new System.Drawing.Point(17, 57);
            this.tableInfoGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableInfoGroupBox.Name = "tableInfoGroupBox";
            this.tableInfoGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableInfoGroupBox.Size = new System.Drawing.Size(301, 206);
            this.tableInfoGroupBox.TabIndex = 3;
            this.tableInfoGroupBox.TabStop = false;
            this.tableInfoGroupBox.Text = "Table Info:";
            // 
            // tableInfoBox
            // 
            this.tableInfoBox.BackColor = System.Drawing.Color.White;
            this.tableInfoBox.Location = new System.Drawing.Point(24, 137);
            this.tableInfoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableInfoBox.Multiline = true;
            this.tableInfoBox.Name = "tableInfoBox";
            this.tableInfoBox.ReadOnly = true;
            this.tableInfoBox.Size = new System.Drawing.Size(241, 54);
            this.tableInfoBox.TabIndex = 3;
            // 
            // tableInfoLabel
            // 
            this.tableInfoLabel.AutoSize = true;
            this.tableInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableInfoLabel.Location = new System.Drawing.Point(21, 112);
            this.tableInfoLabel.Name = "tableInfoLabel";
            this.tableInfoLabel.Size = new System.Drawing.Size(36, 18);
            this.tableInfoLabel.TabIndex = 2;
            this.tableInfoLabel.Text = "Info:";
            // 
            // tableIdLabel
            // 
            this.tableIdLabel.AutoSize = true;
            this.tableIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableIdLabel.Location = new System.Drawing.Point(21, 39);
            this.tableIdLabel.Name = "tableIdLabel";
            this.tableIdLabel.Size = new System.Drawing.Size(48, 18);
            this.tableIdLabel.TabIndex = 1;
            this.tableIdLabel.Text = "Table:";
            // 
            // tableIdComboBox
            // 
            this.tableIdComboBox.FormattingEnabled = true;
            this.tableIdComboBox.Location = new System.Drawing.Point(25, 62);
            this.tableIdComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableIdComboBox.Name = "tableIdComboBox";
            this.tableIdComboBox.Size = new System.Drawing.Size(121, 28);
            this.tableIdComboBox.TabIndex = 0;
            // 
            // aycePricingGrpupBox
            // 
            this.aycePricingGrpupBox.Controls.Add(this.pricePerPersonTextBox);
            this.aycePricingGrpupBox.Controls.Add(this.numberOfPeople);
            this.aycePricingGrpupBox.Controls.Add(this.numGuestsLabel);
            this.aycePricingGrpupBox.Controls.Add(this.priceLabel);
            this.aycePricingGrpupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aycePricingGrpupBox.Location = new System.Drawing.Point(357, 281);
            this.aycePricingGrpupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aycePricingGrpupBox.Name = "aycePricingGrpupBox";
            this.aycePricingGrpupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.aycePricingGrpupBox.Size = new System.Drawing.Size(301, 126);
            this.aycePricingGrpupBox.TabIndex = 4;
            this.aycePricingGrpupBox.TabStop = false;
            this.aycePricingGrpupBox.Text = "Pricing:";
            // 
            // pricePerPersonTextBox
            // 
            this.pricePerPersonTextBox.BackColor = System.Drawing.Color.White;
            this.pricePerPersonTextBox.Location = new System.Drawing.Point(167, 32);
            this.pricePerPersonTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pricePerPersonTextBox.Name = "pricePerPersonTextBox";
            this.pricePerPersonTextBox.ReadOnly = true;
            this.pricePerPersonTextBox.Size = new System.Drawing.Size(129, 27);
            this.pricePerPersonTextBox.TabIndex = 13;
            // 
            // numberOfPeople
            // 
            this.numberOfPeople.Location = new System.Drawing.Point(167, 76);
            this.numberOfPeople.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numberOfPeople.Name = "numberOfPeople";
            this.numberOfPeople.Size = new System.Drawing.Size(129, 27);
            this.numberOfPeople.TabIndex = 6;
            // 
            // numGuestsLabel
            // 
            this.numGuestsLabel.AutoSize = true;
            this.numGuestsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGuestsLabel.Location = new System.Drawing.Point(17, 79);
            this.numGuestsLabel.Name = "numGuestsLabel";
            this.numGuestsLabel.Size = new System.Drawing.Size(132, 18);
            this.numGuestsLabel.TabIndex = 5;
            this.numGuestsLabel.Text = "Number of People:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.Location = new System.Drawing.Point(15, 36);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(123, 18);
            this.priceLabel.TabIndex = 4;
            this.priceLabel.Text = "Price per Person:";
            // 
            // paymentMethodGroupBox
            // 
            this.paymentMethodGroupBox.Controls.Add(this.totalTextBox);
            this.paymentMethodGroupBox.Controls.Add(this.subtotalTextBox);
            this.paymentMethodGroupBox.Controls.Add(this.paymentMethodComboBox);
            this.paymentMethodGroupBox.Controls.Add(this.paymentMethodLabel);
            this.paymentMethodGroupBox.Controls.Add(this.numericUpDown1);
            this.paymentMethodGroupBox.Controls.Add(this.totalLabel);
            this.paymentMethodGroupBox.Controls.Add(this.tipLabel);
            this.paymentMethodGroupBox.Controls.Add(this.subtotalLabel);
            this.paymentMethodGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMethodGroupBox.Location = new System.Drawing.Point(357, 57);
            this.paymentMethodGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paymentMethodGroupBox.Name = "paymentMethodGroupBox";
            this.paymentMethodGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paymentMethodGroupBox.Size = new System.Drawing.Size(301, 206);
            this.paymentMethodGroupBox.TabIndex = 4;
            this.paymentMethodGroupBox.TabStop = false;
            this.paymentMethodGroupBox.Text = "Payment method:";
            // 
            // totalTextBox
            // 
            this.totalTextBox.Location = new System.Drawing.Point(107, 121);
            this.totalTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(136, 27);
            this.totalTextBox.TabIndex = 12;
            // 
            // subtotalTextBox
            // 
            this.subtotalTextBox.Location = new System.Drawing.Point(107, 31);
            this.subtotalTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subtotalTextBox.Name = "subtotalTextBox";
            this.subtotalTextBox.Size = new System.Drawing.Size(136, 27);
            this.subtotalTextBox.TabIndex = 11;
            // 
            // paymentMethodComboBox
            // 
            this.paymentMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentMethodComboBox.FormattingEnabled = true;
            this.paymentMethodComboBox.Location = new System.Drawing.Point(107, 164);
            this.paymentMethodComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paymentMethodComboBox.Name = "paymentMethodComboBox";
            this.paymentMethodComboBox.Size = new System.Drawing.Size(136, 28);
            this.paymentMethodComboBox.TabIndex = 4;
            // 
            // paymentMethodLabel
            // 
            this.paymentMethodLabel.AutoSize = true;
            this.paymentMethodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMethodLabel.Location = new System.Drawing.Point(17, 167);
            this.paymentMethodLabel.Name = "paymentMethodLabel";
            this.paymentMethodLabel.Size = new System.Drawing.Size(70, 18);
            this.paymentMethodLabel.TabIndex = 10;
            this.paymentMethodLabel.Text = "Payment:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(107, 78);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(136, 27);
            this.numericUpDown1.TabIndex = 7;
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.Location = new System.Drawing.Point(17, 126);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(45, 18);
            this.totalLabel.TabIndex = 9;
            this.totalLabel.Text = "Total:";
            // 
            // tipLabel
            // 
            this.tipLabel.AutoSize = true;
            this.tipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipLabel.Location = new System.Drawing.Point(17, 81);
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(59, 18);
            this.tipLabel.TabIndex = 8;
            this.tipLabel.Text = "Tip (%):";
            // 
            // subtotalLabel
            // 
            this.subtotalLabel.AutoSize = true;
            this.subtotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalLabel.Location = new System.Drawing.Point(17, 34);
            this.subtotalLabel.Name = "subtotalLabel";
            this.subtotalLabel.Size = new System.Drawing.Size(66, 18);
            this.subtotalLabel.TabIndex = 7;
            this.subtotalLabel.Text = "Subtotal:";
            // 
            // extrasGroupBox
            // 
            this.extrasGroupBox.Controls.Add(this.premiumCheckBox);
            this.extrasGroupBox.Controls.Add(this.drinksCheckBox);
            this.extrasGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.extrasGroupBox.Location = new System.Drawing.Point(17, 281);
            this.extrasGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.extrasGroupBox.Name = "extrasGroupBox";
            this.extrasGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.extrasGroupBox.Size = new System.Drawing.Size(301, 126);
            this.extrasGroupBox.TabIndex = 5;
            this.extrasGroupBox.TabStop = false;
            this.extrasGroupBox.Text = "Extras:";
            // 
            // premiumCheckBox
            // 
            this.premiumCheckBox.AutoSize = true;
            this.premiumCheckBox.Location = new System.Drawing.Point(24, 78);
            this.premiumCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.premiumCheckBox.Name = "premiumCheckBox";
            this.premiumCheckBox.Size = new System.Drawing.Size(140, 24);
            this.premiumCheckBox.TabIndex = 1;
            this.premiumCheckBox.Text = "Premium Meat";
            this.premiumCheckBox.UseVisualStyleBackColor = true;
            // 
            // drinksCheckBox
            // 
            this.drinksCheckBox.AutoSize = true;
            this.drinksCheckBox.Location = new System.Drawing.Point(24, 36);
            this.drinksCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drinksCheckBox.Name = "drinksCheckBox";
            this.drinksCheckBox.Size = new System.Drawing.Size(80, 24);
            this.drinksCheckBox.TabIndex = 0;
            this.drinksCheckBox.Text = "Drinks";
            this.drinksCheckBox.UseVisualStyleBackColor = true;
            // 
            // btnGenerateBill
            // 
            this.btnGenerateBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateBill.Location = new System.Drawing.Point(17, 422);
            this.btnGenerateBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerateBill.Name = "btnGenerateBill";
            this.btnGenerateBill.Size = new System.Drawing.Size(164, 36);
            this.btnGenerateBill.TabIndex = 6;
            this.btnGenerateBill.Text = "Generate Bill";
            this.btnGenerateBill.UseVisualStyleBackColor = true;
            this.btnGenerateBill.Click += new System.EventHandler(this.btnGenerateBill_Click);
            // 
            // dataGridBill
            // 
            this.dataGridBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBill.Location = new System.Drawing.Point(17, 491);
            this.dataGridBill.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridBill.Name = "dataGridBill";
            this.dataGridBill.RowHeadersWidth = 51;
            this.dataGridBill.Size = new System.Drawing.Size(657, 332);
            this.dataGridBill.TabIndex = 7;
            this.dataGridBill.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBill_CellContentClick);
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(701, 853);
            this.Controls.Add(this.dataGridBill);
            this.Controls.Add(this.btnGenerateBill);
            this.Controls.Add(this.extrasGroupBox);
            this.Controls.Add(this.paymentMethodGroupBox);
            this.Controls.Add(this.aycePricingGrpupBox);
            this.Controls.Add(this.tableInfoGroupBox);
            this.Controls.Add(this.billing);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "BillingForm";
            this.Text = "Billing MGR";
            this.tableInfoGroupBox.ResumeLayout(false);
            this.tableInfoGroupBox.PerformLayout();
            this.aycePricingGrpupBox.ResumeLayout(false);
            this.aycePricingGrpupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfPeople)).EndInit();
            this.paymentMethodGroupBox.ResumeLayout(false);
            this.paymentMethodGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.extrasGroupBox.ResumeLayout(false);
            this.extrasGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label billing;
        private System.Windows.Forms.GroupBox tableInfoGroupBox;
        private System.Windows.Forms.GroupBox aycePricingGrpupBox;
        private System.Windows.Forms.GroupBox paymentMethodGroupBox;
        private System.Windows.Forms.GroupBox extrasGroupBox;
        private System.Windows.Forms.Label tableIdLabel;
        private System.Windows.Forms.ComboBox tableIdComboBox;
        private System.Windows.Forms.Label tableInfoLabel;
        private System.Windows.Forms.TextBox tableInfoBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label numGuestsLabel;
        private System.Windows.Forms.NumericUpDown numberOfPeople;
        private System.Windows.Forms.CheckBox premiumCheckBox;
        private System.Windows.Forms.CheckBox drinksCheckBox;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.Label tipLabel;
        private System.Windows.Forms.Label subtotalLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label paymentMethodLabel;
        private System.Windows.Forms.ComboBox paymentMethodComboBox;
        private System.Windows.Forms.TextBox subtotalTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.TextBox pricePerPersonTextBox;
        private System.Windows.Forms.Button btnGenerateBill;
        private System.Windows.Forms.DataGridView dataGridBill;
    }
}