
namespace SystemSample1
{
    partial class UserControlUserView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptrProfile = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptrProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // ptrProfile
            // 
            this.ptrProfile.Location = new System.Drawing.Point(23, 16);
            this.ptrProfile.Name = "ptrProfile";
            this.ptrProfile.Size = new System.Drawing.Size(145, 144);
            this.ptrProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptrProfile.TabIndex = 0;
            this.ptrProfile.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(191, 51);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(58, 19);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "label1";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(88)))), ((int)(((byte)(87)))));
            this.lblRole.Location = new System.Drawing.Point(191, 94);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(58, 19);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "label2";
            // 
            // UserControlUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.ptrProfile);
            this.Name = "UserControlUserView";
            this.Size = new System.Drawing.Size(404, 181);
            ((System.ComponentModel.ISupportInitialize)(this.ptrProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptrProfile;
        private System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.Label lblRole;
    }
}
