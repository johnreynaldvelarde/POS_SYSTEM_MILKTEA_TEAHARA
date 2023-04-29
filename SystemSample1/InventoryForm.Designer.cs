
namespace SystemSample1
{
    partial class InventoryForm
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
            this.panelInventory = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnViewCategory = new System.Windows.Forms.Button();
            this.btnitemView = new System.Windows.Forms.Button();
            this.btnproductVIew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInventory
            // 
            this.panelInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInventory.Location = new System.Drawing.Point(20, 117);
            this.panelInventory.Name = "panelInventory";
            this.panelInventory.Size = new System.Drawing.Size(1160, 463);
            this.panelInventory.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.panel5.Controls.Add(this.btnViewCategory);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.btnitemView);
            this.panel5.Controls.Add(this.btnproductVIew);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(20, 20);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1160, 97);
            this.panel5.TabIndex = 4;
            // 
            // btnViewCategory
            // 
            this.btnViewCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(124)))), ((int)(((byte)(214)))));
            this.btnViewCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewCategory.FlatAppearance.BorderSize = 0;
            this.btnViewCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewCategory.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewCategory.ForeColor = System.Drawing.Color.White;
            this.btnViewCategory.Location = new System.Drawing.Point(319, 52);
            this.btnViewCategory.Name = "btnViewCategory";
            this.btnViewCategory.Size = new System.Drawing.Size(132, 33);
            this.btnViewCategory.TabIndex = 8;
            this.btnViewCategory.Text = "Category List";
            this.btnViewCategory.UseVisualStyleBackColor = false;
            this.btnViewCategory.Click += new System.EventHandler(this.btnViewCategory_Click);
            // 
            // btnitemView
            // 
            this.btnitemView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(124)))), ((int)(((byte)(214)))));
            this.btnitemView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnitemView.FlatAppearance.BorderSize = 0;
            this.btnitemView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnitemView.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnitemView.ForeColor = System.Drawing.Color.White;
            this.btnitemView.Location = new System.Drawing.Point(154, 52);
            this.btnitemView.Name = "btnitemView";
            this.btnitemView.Size = new System.Drawing.Size(144, 33);
            this.btnitemView.TabIndex = 7;
            this.btnitemView.Text = "Item List";
            this.btnitemView.UseVisualStyleBackColor = false;
            this.btnitemView.Click += new System.EventHandler(this.btnitemView_Click);
            // 
            // btnproductVIew
            // 
            this.btnproductVIew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(124)))), ((int)(((byte)(214)))));
            this.btnproductVIew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnproductVIew.FlatAppearance.BorderSize = 0;
            this.btnproductVIew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproductVIew.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproductVIew.ForeColor = System.Drawing.Color.White;
            this.btnproductVIew.Location = new System.Drawing.Point(0, 52);
            this.btnproductVIew.Name = "btnproductVIew";
            this.btnproductVIew.Size = new System.Drawing.Size(134, 33);
            this.btnproductVIew.TabIndex = 6;
            this.btnproductVIew.Text = "Products List";
            this.btnproductVIew.UseVisualStyleBackColor = false;
            this.btnproductVIew.Click += new System.EventHandler(this.btnproductVIew_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(124)))), ((int)(((byte)(214)))));
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(329, 33);
            this.label4.TabIndex = 7;
            this.label4.Text = "Inventory Management";
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelInventory);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InventoryForm";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelInventory;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnitemView;
        private System.Windows.Forms.Button btnproductVIew;
        private System.Windows.Forms.Button btnViewCategory;
        private System.Windows.Forms.Label label4;
    }
}