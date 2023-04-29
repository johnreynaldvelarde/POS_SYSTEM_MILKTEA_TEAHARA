
namespace SystemSample1
{
    partial class HistoryForm
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
            this.btnActivityLog = new System.Windows.Forms.Button();
            this.btnHistoryOrder = new System.Windows.Forms.Button();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnActivityLog
            // 
            this.btnActivityLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(124)))), ((int)(((byte)(214)))));
            this.btnActivityLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActivityLog.FlatAppearance.BorderSize = 0;
            this.btnActivityLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivityLog.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivityLog.ForeColor = System.Drawing.Color.White;
            this.btnActivityLog.Location = new System.Drawing.Point(177, 48);
            this.btnActivityLog.Name = "btnActivityLog";
            this.btnActivityLog.Size = new System.Drawing.Size(131, 33);
            this.btnActivityLog.TabIndex = 7;
            this.btnActivityLog.Text = "Activity Log";
            this.btnActivityLog.UseVisualStyleBackColor = false;
            this.btnActivityLog.Click += new System.EventHandler(this.btnActivityLog_Click);
            // 
            // btnHistoryOrder
            // 
            this.btnHistoryOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(124)))), ((int)(((byte)(214)))));
            this.btnHistoryOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistoryOrder.FlatAppearance.BorderSize = 0;
            this.btnHistoryOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoryOrder.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoryOrder.ForeColor = System.Drawing.Color.White;
            this.btnHistoryOrder.Location = new System.Drawing.Point(0, 48);
            this.btnHistoryOrder.Name = "btnHistoryOrder";
            this.btnHistoryOrder.Size = new System.Drawing.Size(151, 33);
            this.btnHistoryOrder.TabIndex = 6;
            this.btnHistoryOrder.Text = "Order Transaction";
            this.btnHistoryOrder.UseVisualStyleBackColor = false;
            this.btnHistoryOrder.Click += new System.EventHandler(this.btnHistoryOrder_Click);
            // 
            // panelHistory
            // 
            this.panelHistory.AutoScroll = true;
            this.panelHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHistory.Location = new System.Drawing.Point(20, 105);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(1158, 473);
            this.panelHistory.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnActivityLog);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnHistoryOrder);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1158, 85);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(124)))), ((int)(((byte)(214)))));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 33);
            this.label4.TabIndex = 6;
            this.label4.Text = "Transaction History";
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 598);
            this.ControlBox = false;
            this.Controls.Add(this.panelHistory);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "HistoryForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnActivityLog;
        private System.Windows.Forms.Button btnHistoryOrder;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}