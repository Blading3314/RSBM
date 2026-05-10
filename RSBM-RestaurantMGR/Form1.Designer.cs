namespace RSBM_RestaurantMGR
{
    partial class RestoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnReservations = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.header = new System.Windows.Forms.Panel();
            this.sidebar = new System.Windows.Forms.Panel();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.header.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Restaurant Manager System";
            // 
            // btnReservations
            // 
            this.btnReservations.FlatAppearance.BorderSize = 0;
            this.btnReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservations.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservations.ForeColor = System.Drawing.Color.White;
            this.btnReservations.Location = new System.Drawing.Point(0, 0);
            this.btnReservations.Name = "btnReservations";
            this.btnReservations.Size = new System.Drawing.Size(180, 45);
            this.btnReservations.TabIndex = 1;
            this.btnReservations.Text = "Reservations";
            this.btnReservations.UseVisualStyleBackColor = true;
            this.btnReservations.Click += new System.EventHandler(this.btnReservations_Click);
            // 
            // btnTables
            // 
            this.btnTables.FlatAppearance.BorderSize = 0;
            this.btnTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTables.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTables.ForeColor = System.Drawing.Color.White;
            this.btnTables.Location = new System.Drawing.Point(0, 51);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(180, 45);
            this.btnTables.TabIndex = 2;
            this.btnTables.Text = "Tables";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.FlatAppearance.BorderSize = 0;
            this.btnBilling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBilling.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilling.ForeColor = System.Drawing.Color.White;
            this.btnBilling.Location = new System.Drawing.Point(0, 102);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(180, 45);
            this.btnBilling.TabIndex = 3;
            this.btnBilling.Text = "Billing";
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.header.Controls.Add(this.label1);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1098, 60);
            this.header.TabIndex = 4;
            // 
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.sidebar.Controls.Add(this.btnBilling);
            this.sidebar.Controls.Add(this.btnReservations);
            this.sidebar.Controls.Add(this.btnTables);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(0, 60);
            this.sidebar.Name = "sidebar";
            this.sidebar.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.sidebar.Size = new System.Drawing.Size(180, 639);
            this.sidebar.TabIndex = 5;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.ForeColor = System.Drawing.Color.Black;
            this.mainPanel.Location = new System.Drawing.Point(180, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(918, 639);
            this.mainPanel.TabIndex = 6;
            // 
            // RestoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1098, 699);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RestoForm";
            this.Text = "RestoMGR";
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReservations;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Panel header;
        private System.Windows.Forms.Panel sidebar;
        private System.Windows.Forms.Panel mainPanel;
    }
}

