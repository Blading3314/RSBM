namespace RSBM_RestaurantMGR
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel dashboardPanel;
        private System.Windows.Forms.Label lblDashboard;

        private System.Windows.Forms.Panel datePanel;
        private System.Windows.Forms.Panel timePanel;
        private System.Windows.Forms.Panel customerPanel;

        private System.Windows.Forms.Label lblDateTitle;
        private System.Windows.Forms.Label lblTimeDate;
        private System.Windows.Forms.Label lblCustomerTitle;

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblCustomerCount;

        private System.Windows.Forms.Timer dashboardTimer;

        /// <summary>
        /// Clean up resources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dashboardPanel = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.datePanel = new System.Windows.Forms.Panel();
            this.lblDateTitle = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timePanel = new System.Windows.Forms.Panel();
            this.lblTimeDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.customerPanel = new System.Windows.Forms.Panel();
            this.lblCustomerTitle = new System.Windows.Forms.Label();
            this.lblCustomerCount = new System.Windows.Forms.Label();
            this.dashboardTimer = new System.Windows.Forms.Timer(this.components);
            this.dashboardPanel.SuspendLayout();
            this.datePanel.SuspendLayout();
            this.timePanel.SuspendLayout();
            this.customerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dashboardPanel
            // 
            this.dashboardPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.dashboardPanel.Controls.Add(this.lblDashboard);
            this.dashboardPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.dashboardPanel.Location = new System.Drawing.Point(0, 0);
            this.dashboardPanel.Name = "dashboardPanel";
            this.dashboardPanel.Size = new System.Drawing.Size(900, 55);
            this.dashboardPanel.TabIndex = 0;
            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDashboard.ForeColor = System.Drawing.Color.White;
            this.lblDashboard.Location = new System.Drawing.Point(331, 9);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(157, 37);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Dashboard";
            // 
            // datePanel
            // 
            this.datePanel.BackColor = System.Drawing.Color.White;
            this.datePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.datePanel.Controls.Add(this.lblDateTitle);
            this.datePanel.Controls.Add(this.lblDate);
            this.datePanel.Location = new System.Drawing.Point(20, 80);
            this.datePanel.Name = "datePanel";
            this.datePanel.Size = new System.Drawing.Size(250, 120);
            this.datePanel.TabIndex = 1;
            // 
            // lblDateTitle
            // 
            this.lblDateTitle.AutoSize = true;
            this.lblDateTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDateTitle.Location = new System.Drawing.Point(10, 10);
            this.lblDateTitle.Name = "lblDateTitle";
            this.lblDateTitle.Size = new System.Drawing.Size(133, 28);
            this.lblDateTitle.TabIndex = 0;
            this.lblDateTitle.Text = "Today\'s Date";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDate.Location = new System.Drawing.Point(10, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 25);
            this.lblDate.TabIndex = 1;
            // 
            // timePanel
            // 
            this.timePanel.BackColor = System.Drawing.Color.White;
            this.timePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timePanel.Controls.Add(this.lblTimeDate);
            this.timePanel.Controls.Add(this.lblTime);
            this.timePanel.Location = new System.Drawing.Point(310, 80);
            this.timePanel.Name = "timePanel";
            this.timePanel.Size = new System.Drawing.Size(250, 120);
            this.timePanel.TabIndex = 2;
            // 
            // lblTimeDate
            // 
            this.lblTimeDate.AutoSize = true;
            this.lblTimeDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimeDate.Location = new System.Drawing.Point(10, 10);
            this.lblTimeDate.Name = "lblTimeDate";
            this.lblTimeDate.Size = new System.Drawing.Size(136, 28);
            this.lblTimeDate.TabIndex = 0;
            this.lblTimeDate.Text = "Current Time";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTime.Location = new System.Drawing.Point(10, 60);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 25);
            this.lblTime.TabIndex = 1;
            // 
            // customerPanel
            // 
            this.customerPanel.BackColor = System.Drawing.Color.White;
            this.customerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customerPanel.Controls.Add(this.lblCustomerTitle);
            this.customerPanel.Controls.Add(this.lblCustomerCount);
            this.customerPanel.Location = new System.Drawing.Point(600, 80);
            this.customerPanel.Name = "customerPanel";
            this.customerPanel.Size = new System.Drawing.Size(250, 120);
            this.customerPanel.TabIndex = 3;
            // 
            // lblCustomerTitle
            // 
            this.lblCustomerTitle.AutoSize = true;
            this.lblCustomerTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCustomerTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCustomerTitle.Name = "lblCustomerTitle";
            this.lblCustomerTitle.Size = new System.Drawing.Size(173, 28);
            this.lblCustomerTitle.TabIndex = 0;
            this.lblCustomerTitle.Text = "Customers Today";
            // 
            // lblCustomerCount
            // 
            this.lblCustomerCount.AutoSize = true;
            this.lblCustomerCount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCustomerCount.Location = new System.Drawing.Point(10, 60);
            this.lblCustomerCount.Name = "lblCustomerCount";
            this.lblCustomerCount.Size = new System.Drawing.Size(22, 25);
            this.lblCustomerCount.TabIndex = 1;
            this.lblCustomerCount.Text = "0";
            // 
            // dashboardTimer
            // 
            this.dashboardTimer.Enabled = true;
            this.dashboardTimer.Interval = 1000;
            this.dashboardTimer.Tick += new System.EventHandler(this.dashboardTimer_Tick);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.dashboardPanel);
            this.Controls.Add(this.datePanel);
            this.Controls.Add(this.timePanel);
            this.Controls.Add(this.customerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.dashboardPanel.ResumeLayout(false);
            this.dashboardPanel.PerformLayout();
            this.datePanel.ResumeLayout(false);
            this.datePanel.PerformLayout();
            this.timePanel.ResumeLayout(false);
            this.timePanel.PerformLayout();
            this.customerPanel.ResumeLayout(false);
            this.customerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}