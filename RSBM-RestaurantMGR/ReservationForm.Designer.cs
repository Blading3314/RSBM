namespace RSBM_RestaurantMGR
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.reservations = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblPartySize = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.resName = new System.Windows.Forms.TextBox();
            this.resPhone = new System.Windows.Forms.TextBox();
            this.resPartySize = new System.Windows.Forms.NumericUpDown();
            this.resDate = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.resTimeSlot = new System.Windows.Forms.ComboBox();
            this.btnAddReservation = new System.Windows.Forms.Button();
            this.btnEditReservation = new System.Windows.Forms.Button();
            this.btnDeleteReservation = new System.Windows.Forms.Button();
            this.reservationGrid = new System.Windows.Forms.DataGridView();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTable = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.resTable = new System.Windows.Forms.ComboBox();
            this.resStatus = new System.Windows.Forms.ComboBox();
            this.pnlReservationInfo = new System.Windows.Forms.Panel();
            this.lblReservationDetails = new System.Windows.Forms.Label();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resPartySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationGrid)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.pnlReservationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // reservations
            // 
            this.reservations.AutoSize = true;
            this.reservations.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reservations.ForeColor = System.Drawing.Color.White;
            this.reservations.Location = new System.Drawing.Point(2, 0);
            this.reservations.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.reservations.Name = "reservations";
            this.reservations.Size = new System.Drawing.Size(241, 30);
            this.reservations.TabIndex = 0;
            this.reservations.Text = "Manage Reservations:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(14, 46);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(119, 20);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Customer Name:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(14, 80);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(53, 20);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Phone:";
            // 
            // lblPartySize
            // 
            this.lblPartySize.AutoSize = true;
            this.lblPartySize.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartySize.Location = new System.Drawing.Point(338, 45);
            this.lblPartySize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPartySize.Name = "lblPartySize";
            this.lblPartySize.Size = new System.Drawing.Size(75, 20);
            this.lblPartySize.TabIndex = 3;
            this.lblPartySize.Text = "Party Size:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(338, 80);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(44, 20);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date:";
            // 
            // resName
            // 
            this.resName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.resName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resName.Location = new System.Drawing.Point(137, 46);
            this.resName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resName.MaxLength = 60;
            this.resName.Name = "resName";
            this.resName.Size = new System.Drawing.Size(132, 16);
            this.resName.TabIndex = 5;
            // 
            // resPhone
            // 
            this.resPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.resPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resPhone.Location = new System.Drawing.Point(137, 80);
            this.resPhone.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resPhone.MaxLength = 10;
            this.resPhone.Name = "resPhone";
            this.resPhone.Size = new System.Drawing.Size(132, 16);
            this.resPhone.TabIndex = 6;
            // 
            // resPartySize
            // 
            this.resPartySize.BackColor = System.Drawing.Color.White;
            this.resPartySize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resPartySize.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resPartySize.Location = new System.Drawing.Point(506, 44);
            this.resPartySize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resPartySize.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.resPartySize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resPartySize.Name = "resPartySize";
            this.resPartySize.Size = new System.Drawing.Size(68, 23);
            this.resPartySize.TabIndex = 7;
            this.resPartySize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.resPartySize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // resDate
            // 
            this.resDate.CalendarMonthBackground = System.Drawing.Color.White;
            this.resDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.resDate.Location = new System.Drawing.Point(418, 79);
            this.resDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resDate.Name = "resDate";
            this.resDate.Size = new System.Drawing.Size(156, 23);
            this.resDate.TabIndex = 8;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(338, 115);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(45, 20);
            this.lblTime.TabIndex = 9;
            this.lblTime.Text = "Time:";
            // 
            // resTimeSlot
            // 
            this.resTimeSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.resTimeSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resTimeSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resTimeSlot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resTimeSlot.FormattingEnabled = true;
            this.resTimeSlot.Location = new System.Drawing.Point(418, 112);
            this.resTimeSlot.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resTimeSlot.Name = "resTimeSlot";
            this.resTimeSlot.Size = new System.Drawing.Size(156, 23);
            this.resTimeSlot.TabIndex = 10;
            // 
            // btnAddReservation
            // 
            this.btnAddReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnAddReservation.FlatAppearance.BorderSize = 0;
            this.btnAddReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddReservation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddReservation.ForeColor = System.Drawing.Color.White;
            this.btnAddReservation.Location = new System.Drawing.Point(9, 310);
            this.btnAddReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddReservation.Name = "btnAddReservation";
            this.btnAddReservation.Size = new System.Drawing.Size(98, 45);
            this.btnAddReservation.TabIndex = 11;
            this.btnAddReservation.Text = "Add Reservation";
            this.btnAddReservation.UseVisualStyleBackColor = false;
            this.btnAddReservation.Click += new System.EventHandler(this.btnAddReservation_Click);
            // 
            // btnEditReservation
            // 
            this.btnEditReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnEditReservation.FlatAppearance.BorderSize = 0;
            this.btnEditReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditReservation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditReservation.ForeColor = System.Drawing.Color.White;
            this.btnEditReservation.Location = new System.Drawing.Point(129, 310);
            this.btnEditReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditReservation.Name = "btnEditReservation";
            this.btnEditReservation.Size = new System.Drawing.Size(98, 45);
            this.btnEditReservation.TabIndex = 12;
            this.btnEditReservation.Text = "Edit Reservation";
            this.btnEditReservation.UseVisualStyleBackColor = false;
            this.btnEditReservation.Click += new System.EventHandler(this.btnEditReservation_Click);
            // 
            // btnDeleteReservation
            // 
            this.btnDeleteReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnDeleteReservation.FlatAppearance.BorderSize = 0;
            this.btnDeleteReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteReservation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteReservation.ForeColor = System.Drawing.Color.White;
            this.btnDeleteReservation.Location = new System.Drawing.Point(249, 310);
            this.btnDeleteReservation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteReservation.Name = "btnDeleteReservation";
            this.btnDeleteReservation.Size = new System.Drawing.Size(98, 45);
            this.btnDeleteReservation.TabIndex = 13;
            this.btnDeleteReservation.Text = "Delete Reservation";
            this.btnDeleteReservation.UseVisualStyleBackColor = false;
            this.btnDeleteReservation.Click += new System.EventHandler(this.btnDeleteReservation_Click);
            // 
            // reservationGrid
            // 
            this.reservationGrid.AllowUserToAddRows = false;
            this.reservationGrid.AllowUserToDeleteRows = false;
            this.reservationGrid.AllowUserToResizeColumns = false;
            this.reservationGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.reservationGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.reservationGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.reservationGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.reservationGrid.BackgroundColor = System.Drawing.Color.White;
            this.reservationGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.reservationGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reservationGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.reservationGrid.ColumnHeadersHeight = 33;
            this.reservationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.reservationGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.reservationGrid.EnableHeadersVisualStyles = false;
            this.reservationGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.reservationGrid.Location = new System.Drawing.Point(8, 371);
            this.reservationGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reservationGrid.Name = "reservationGrid";
            this.reservationGrid.ReadOnly = true;
            this.reservationGrid.RowHeadersVisible = false;
            this.reservationGrid.RowHeadersWidth = 51;
            this.reservationGrid.RowTemplate.Height = 24;
            this.reservationGrid.Size = new System.Drawing.Size(651, 244);
            this.reservationGrid.TabIndex = 14;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.headerPanel.Controls.Add(this.reservations);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(670, 37);
            this.headerPanel.TabIndex = 15;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(369, 310);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(98, 45);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.Location = new System.Drawing.Point(338, 146);
            this.lblTable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(47, 20);
            this.lblTable.TabIndex = 18;
            this.lblTable.Text = "Table:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(338, 181);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(49, 20);
            this.lblStatus.TabIndex = 19;
            this.lblStatus.Text = "Status";
            // 
            // resTable
            // 
            this.resTable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.resTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resTable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resTable.FormattingEnabled = true;
            this.resTable.Location = new System.Drawing.Point(418, 147);
            this.resTable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resTable.Name = "resTable";
            this.resTable.Size = new System.Drawing.Size(156, 23);
            this.resTable.TabIndex = 20;
            // 
            // resStatus
            // 
            this.resStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.resStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resStatus.FormattingEnabled = true;
            this.resStatus.Location = new System.Drawing.Point(418, 185);
            this.resStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resStatus.Name = "resStatus";
            this.resStatus.Size = new System.Drawing.Size(156, 23);
            this.resStatus.TabIndex = 21;
            // 
            // pnlReservationInfo
            // 
            this.pnlReservationInfo.BackColor = System.Drawing.Color.White;
            this.pnlReservationInfo.Controls.Add(this.lblReservationDetails);
            this.pnlReservationInfo.Controls.Add(this.lblCustomerInfo);
            this.pnlReservationInfo.Controls.Add(this.lblPartySize);
            this.pnlReservationInfo.Controls.Add(this.lblName);
            this.pnlReservationInfo.Controls.Add(this.resStatus);
            this.pnlReservationInfo.Controls.Add(this.lblPhone);
            this.pnlReservationInfo.Controls.Add(this.resTable);
            this.pnlReservationInfo.Controls.Add(this.lblDate);
            this.pnlReservationInfo.Controls.Add(this.lblStatus);
            this.pnlReservationInfo.Controls.Add(this.resName);
            this.pnlReservationInfo.Controls.Add(this.lblTable);
            this.pnlReservationInfo.Controls.Add(this.resPhone);
            this.pnlReservationInfo.Controls.Add(this.resPartySize);
            this.pnlReservationInfo.Controls.Add(this.resDate);
            this.pnlReservationInfo.Controls.Add(this.lblTime);
            this.pnlReservationInfo.Controls.Add(this.resTimeSlot);
            this.pnlReservationInfo.Location = new System.Drawing.Point(9, 52);
            this.pnlReservationInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlReservationInfo.Name = "pnlReservationInfo";
            this.pnlReservationInfo.Size = new System.Drawing.Size(650, 240);
            this.pnlReservationInfo.TabIndex = 23;
            // 
            // lblReservationDetails
            // 
            this.lblReservationDetails.AutoSize = true;
            this.lblReservationDetails.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservationDetails.Location = new System.Drawing.Point(338, 10);
            this.lblReservationDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReservationDetails.Name = "lblReservationDetails";
            this.lblReservationDetails.Size = new System.Drawing.Size(186, 21);
            this.lblReservationDetails.TabIndex = 23;
            this.lblReservationDetails.Text = "RESERVATION DETAILS:";
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerInfo.Location = new System.Drawing.Point(14, 10);
            this.lblCustomerInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(141, 21);
            this.lblCustomerInfo.TabIndex = 22;
            this.lblCustomerInfo.Text = "CUSTOMER INFO:";
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(670, 623);
            this.Controls.Add(this.pnlReservationInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.reservationGrid);
            this.Controls.Add(this.btnDeleteReservation);
            this.Controls.Add(this.btnEditReservation);
            this.Controls.Add(this.btnAddReservation);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReservationForm";
            this.Text = "Reservation MGR";
            ((System.ComponentModel.ISupportInitialize)(this.resPartySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationGrid)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.pnlReservationInfo.ResumeLayout(false);
            this.pnlReservationInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label reservations;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblPartySize;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox resName;
        private System.Windows.Forms.TextBox resPhone;
        private System.Windows.Forms.NumericUpDown resPartySize;
        private System.Windows.Forms.DateTimePicker resDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox resTimeSlot;
        private System.Windows.Forms.Button btnAddReservation;
        private System.Windows.Forms.Button btnEditReservation;
        private System.Windows.Forms.Button btnDeleteReservation;
        private System.Windows.Forms.DataGridView reservationGrid;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox resTable;
        private System.Windows.Forms.ComboBox resStatus;
        private System.Windows.Forms.Panel pnlReservationInfo;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.Label lblReservationDetails;
    }
}