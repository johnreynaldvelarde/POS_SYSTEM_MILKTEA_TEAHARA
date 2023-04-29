
namespace SystemSample1
{
    partial class UserForm
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
            this.flowUser = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlfillUser = new System.Windows.Forms.Panel();
            this.pnlfillUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowUser
            // 
            this.flowUser.AutoScroll = true;
            this.flowUser.BackColor = System.Drawing.Color.Transparent;
            this.flowUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowUser.Location = new System.Drawing.Point(0, 0);
            this.flowUser.Name = "flowUser";
            this.flowUser.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.flowUser.Size = new System.Drawing.Size(1198, 598);
            this.flowUser.TabIndex = 0;
            // 
            // pnlfillUser
            // 
            this.pnlfillUser.Controls.Add(this.flowUser);
            this.pnlfillUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlfillUser.Location = new System.Drawing.Point(0, 0);
            this.pnlfillUser.Name = "pnlfillUser";
            this.pnlfillUser.Size = new System.Drawing.Size(1198, 598);
            this.pnlfillUser.TabIndex = 2;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 598);
            this.ControlBox = false;
            this.Controls.Add(this.pnlfillUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.pnlfillUser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlfillUser;
        private System.Windows.Forms.FlowLayoutPanel flowUser;
    }
}