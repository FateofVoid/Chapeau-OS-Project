namespace Chapeau_Restaurant
{
    partial class OrderProcessingUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderProcessingUI));
            this.OrdStatusbtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listViewORDERS = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OrdStatusbtn
            // 
            this.OrdStatusbtn.BackColor = System.Drawing.Color.Aqua;
            this.OrdStatusbtn.Location = new System.Drawing.Point(70, 380);
            this.OrdStatusbtn.Name = "OrdStatusbtn";
            this.OrdStatusbtn.Size = new System.Drawing.Size(135, 46);
            this.OrdStatusbtn.TabIndex = 1;
            this.OrdStatusbtn.Text = "CHANGE ORDER STATUS";
            this.OrdStatusbtn.UseVisualStyleBackColor = false;
            this.OrdStatusbtn.Click += new System.EventHandler(this.OrdStatusbtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(294, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "REFRESH ORDERS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listViewORDERS
            // 
            this.listViewORDERS.FullRowSelect = true;
            this.listViewORDERS.Location = new System.Drawing.Point(25, 43);
            this.listViewORDERS.Name = "listViewORDERS";
            this.listViewORDERS.Size = new System.Drawing.Size(464, 302);
            this.listViewORDERS.TabIndex = 5;
            this.listViewORDERS.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(516, 25);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.stockToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(53, 21);
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.stockToolStripMenuItem_Click);
            // 
            // OrderProcessingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 459);
            this.Controls.Add(this.listViewORDERS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OrdStatusbtn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OrderProcessingUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderProcessing";
            this.Load += new System.EventHandler(this.OrderProcessingUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OrdStatusbtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listViewORDERS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
    }
}