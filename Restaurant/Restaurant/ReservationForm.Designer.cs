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
            ((System.ComponentModel.ISupportInitialize)(this.partySizeNum)).BeginInit();
            this.SuspendLayout();
            // 
            // reservations
            // 
            this.reservations.AutoSize = true;
            this.reservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservations.Location = new System.Drawing.Point(12, 9);
            this.reservations.Name = "reservations";
            this.reservations.Size = new System.Drawing.Size(228, 25);
            this.reservations.TabIndex = 0;
            this.reservations.Text = "Manage Reservations:";
            // 
            // resCustName
            // 
            this.resCustName.AutoSize = true;
            this.resCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resCustName.Location = new System.Drawing.Point(24, 61);
            this.resCustName.Name = "resCustName";
            this.resCustName.Size = new System.Drawing.Size(136, 20);
            this.resCustName.TabIndex = 1;
            this.resCustName.Text = "Customer Name:";
            // 
            // resCustPhone
            // 
            this.resCustPhone.AutoSize = true;
            this.resCustPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resCustPhone.Location = new System.Drawing.Point(24, 104);
            this.resCustPhone.Name = "resCustPhone";
            this.resCustPhone.Size = new System.Drawing.Size(61, 20);
            this.resCustPhone.TabIndex = 2;
            this.resCustPhone.Text = "Phone:";
            // 
            // resPartySize
            // 
            this.resPartySize.AutoSize = true;
            this.resPartySize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resPartySize.Location = new System.Drawing.Point(24, 148);
            this.resPartySize.Name = "resPartySize";
            this.resPartySize.Size = new System.Drawing.Size(91, 20);
            this.resPartySize.TabIndex = 3;
            this.resPartySize.Text = "Party Size:";
            // 
            // resDate
            // 
            this.resDate.AutoSize = true;
            this.resDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resDate.Location = new System.Drawing.Point(24, 193);
            this.resDate.Name = "resDate";
            this.resDate.Size = new System.Drawing.Size(50, 20);
            this.resDate.TabIndex = 4;
            this.resDate.Text = "Date:";
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.Location = new System.Drawing.Point(190, 61);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(206, 22);
            this.customerNameTextBox.TabIndex = 5;
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(190, 104);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(206, 22);
            this.phoneTextBox.TabIndex = 6;
            // 
            // partySizeNum
            // 
            this.partySizeNum.Location = new System.Drawing.Point(190, 149);
            this.partySizeNum.Name = "partySizeNum";
            this.partySizeNum.Size = new System.Drawing.Size(206, 22);
            this.partySizeNum.TabIndex = 7;
            this.partySizeNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(190, 191);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(206, 22);
            this.datePicker.TabIndex = 8;
            // 
            // resTime
            // 
            this.resTime.AutoSize = true;
            this.resTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resTime.Location = new System.Drawing.Point(24, 234);
            this.resTime.Name = "resTime";
            this.resTime.Size = new System.Drawing.Size(51, 20);
            this.resTime.TabIndex = 9;
            this.resTime.Text = "Time:";
            // 
            // timeSlots
            // 
            this.timeSlots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeSlots.FormattingEnabled = true;
            this.timeSlots.Location = new System.Drawing.Point(190, 230);
            this.timeSlots.Name = "timeSlots";
            this.timeSlots.Size = new System.Drawing.Size(206, 24);
            this.timeSlots.TabIndex = 10;
            // 
            // btnAddReservation
            // 
            this.btnAddReservation.Location = new System.Drawing.Point(462, 61);
            this.btnAddReservation.Name = "btnAddReservation";
            this.btnAddReservation.Size = new System.Drawing.Size(103, 42);
            this.btnAddReservation.TabIndex = 11;
            this.btnAddReservation.Text = "Add Reservation";
            this.btnAddReservation.UseVisualStyleBackColor = true;
            // 
            // btnEditReservation
            // 
            this.btnEditReservation.Location = new System.Drawing.Point(462, 138);
            this.btnEditReservation.Name = "btnEditReservation";
            this.btnEditReservation.Size = new System.Drawing.Size(103, 42);
            this.btnEditReservation.TabIndex = 12;
            this.btnEditReservation.Text = "Edit Reservation";
            this.btnEditReservation.UseVisualStyleBackColor = true;
            // 
            // btnDeleteReservation
            // 
            this.btnDeleteReservation.Location = new System.Drawing.Point(462, 212);
            this.btnDeleteReservation.Name = "btnDeleteReservation";
            this.btnDeleteReservation.Size = new System.Drawing.Size(103, 42);
            this.btnDeleteReservation.TabIndex = 13;
            this.btnDeleteReservation.Text = "Delete Reservation";
            this.btnDeleteReservation.UseVisualStyleBackColor = true;
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 499);
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
            this.Name = "ReservationForm";
            this.Text = "Reservation MGR";
            ((System.ComponentModel.ISupportInitialize)(this.partySizeNum)).EndInit();
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
    }
}