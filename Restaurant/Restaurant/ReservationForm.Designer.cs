namespace Restaurant
{
    partial class ReservationForm
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
            this.reservations = new System.Windows.Forms.Label();
            this.resCustName = new System.Windows.Forms.Label();
            this.resCustPhone = new System.Windows.Forms.Label();
            this.resPartySize = new System.Windows.Forms.Label();
            this.resDate = new System.Windows.Forms.Label();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.partySizeNum = new System.Windows.Forms.NumericUpDown();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.resTime = new System.Windows.Forms.Label();
            this.timeSlots = new System.Windows.Forms.ComboBox();
            this.btnAddReservation = new System.Windows.Forms.Button();
            this.btnEditReservation = new System.Windows.Forms.Button();
            this.btnDeleteReservation = new System.Windows.Forms.Button();
            this.reservationDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.partySizeNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reservations
            // 
            this.reservations.AutoSize = true;
            this.reservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservations.Location = new System.Drawing.Point(9, 7);
            this.reservations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.reservations.Name = "reservations";
            this.reservations.Size = new System.Drawing.Size(188, 20);
            this.reservations.TabIndex = 0;
            this.reservations.Text = "Manage Reservations:";
            // 
            // resCustName
            // 
            this.resCustName.AutoSize = true;
            this.resCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resCustName.Location = new System.Drawing.Point(165, 54);
            this.resCustName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resCustName.Name = "resCustName";
            this.resCustName.Size = new System.Drawing.Size(113, 17);
            this.resCustName.TabIndex = 1;
            this.resCustName.Text = "Customer Name:";
            // 
            // resCustPhone
            // 
            this.resCustPhone.AutoSize = true;
            this.resCustPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resCustPhone.Location = new System.Drawing.Point(165, 88);
            this.resCustPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resCustPhone.Name = "resCustPhone";
            this.resCustPhone.Size = new System.Drawing.Size(53, 17);
            this.resCustPhone.TabIndex = 2;
            this.resCustPhone.Text = "Phone:";
            // 
            // resPartySize
            // 
            this.resPartySize.AutoSize = true;
            this.resPartySize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resPartySize.Location = new System.Drawing.Point(165, 124);
            this.resPartySize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resPartySize.Name = "resPartySize";
            this.resPartySize.Size = new System.Drawing.Size(76, 17);
            this.resPartySize.TabIndex = 3;
            this.resPartySize.Text = "Party Size:";
            // 
            // resDate
            // 
            this.resDate.AutoSize = true;
            this.resDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resDate.Location = new System.Drawing.Point(165, 161);
            this.resDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resDate.Name = "resDate";
            this.resDate.Size = new System.Drawing.Size(42, 17);
            this.resDate.TabIndex = 4;
            this.resDate.Text = "Date:";
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Location = new System.Drawing.Point(289, 54);
            this.customerNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(156, 20);
            this.customerNameTextBox.TabIndex = 5;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(289, 88);
            this.phoneTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(156, 20);
            this.phoneTextBox.TabIndex = 6;
            // 
            // partySizeNum
            // 
            this.partySizeNum.Location = new System.Drawing.Point(289, 125);
            this.partySizeNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.partySizeNum.Name = "partySizeNum";
            this.partySizeNum.Size = new System.Drawing.Size(154, 20);
            this.partySizeNum.TabIndex = 7;
            this.partySizeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(289, 159);
            this.datePicker.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(156, 20);
            this.datePicker.TabIndex = 8;
            // 
            // resTime
            // 
            this.resTime.AutoSize = true;
            this.resTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resTime.Location = new System.Drawing.Point(165, 194);
            this.resTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.resTime.Name = "resTime";
            this.resTime.Size = new System.Drawing.Size(43, 17);
            this.resTime.TabIndex = 9;
            this.resTime.Text = "Time:";
            // 
            // timeSlots
            // 
            this.timeSlots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeSlots.FormattingEnabled = true;
            this.timeSlots.Location = new System.Drawing.Point(289, 191);
            this.timeSlots.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.timeSlots.Name = "timeSlots";
            this.timeSlots.Size = new System.Drawing.Size(156, 21);
            this.timeSlots.TabIndex = 10;
            // 
            // btnAddReservation
            // 
            this.btnAddReservation.Location = new System.Drawing.Point(493, 54);
            this.btnAddReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddReservation.Name = "btnAddReservation";
            this.btnAddReservation.Size = new System.Drawing.Size(77, 34);
            this.btnAddReservation.TabIndex = 11;
            this.btnAddReservation.Text = "Add Reservation";
            this.btnAddReservation.UseVisualStyleBackColor = true;
            // 
            // btnEditReservation
            // 
            this.btnEditReservation.Location = new System.Drawing.Point(493, 116);
            this.btnEditReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditReservation.Name = "btnEditReservation";
            this.btnEditReservation.Size = new System.Drawing.Size(77, 34);
            this.btnEditReservation.TabIndex = 12;
            this.btnEditReservation.Text = "Edit Reservation";
            this.btnEditReservation.UseVisualStyleBackColor = true;
            // 
            // btnDeleteReservation
            // 
            this.btnDeleteReservation.Location = new System.Drawing.Point(493, 176);
            this.btnDeleteReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteReservation.Name = "btnDeleteReservation";
            this.btnDeleteReservation.Size = new System.Drawing.Size(77, 34);
            this.btnDeleteReservation.TabIndex = 13;
            this.btnDeleteReservation.Text = "Delete Reservation";
            this.btnDeleteReservation.UseVisualStyleBackColor = true;
            // 
            // reservationDataGridView
            // 
            this.reservationDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.reservationDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.reservationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reservationDataGridView.Location = new System.Drawing.Point(21, 243);
            this.reservationDataGridView.Name = "reservationDataGridView";
            this.reservationDataGridView.Size = new System.Drawing.Size(663, 194);
            this.reservationDataGridView.TabIndex = 14;
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 455);
            this.Controls.Add(this.reservationDataGridView);
            this.Controls.Add(this.btnDeleteReservation);
            this.Controls.Add(this.btnEditReservation);
            this.Controls.Add(this.btnAddReservation);
            this.Controls.Add(this.timeSlots);
            this.Controls.Add(this.resTime);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.partySizeNum);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.customerNameTextBox);
            this.Controls.Add(this.resDate);
            this.Controls.Add(this.resPartySize);
            this.Controls.Add(this.resCustPhone);
            this.Controls.Add(this.resCustName);
            this.Controls.Add(this.reservations);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReservationForm";
            this.Text = "Reservation MGR";
            ((System.ComponentModel.ISupportInitialize)(this.partySizeNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label reservations;
        private System.Windows.Forms.Label resCustName;
        private System.Windows.Forms.Label resCustPhone;
        private System.Windows.Forms.Label resPartySize;
        private System.Windows.Forms.Label resDate;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.NumericUpDown partySizeNum;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label resTime;
        private System.Windows.Forms.ComboBox timeSlots;
        private System.Windows.Forms.Button btnAddReservation;
        private System.Windows.Forms.Button btnEditReservation;
        private System.Windows.Forms.Button btnDeleteReservation;
        private System.Windows.Forms.DataGridView reservationDataGridView;
    }
}