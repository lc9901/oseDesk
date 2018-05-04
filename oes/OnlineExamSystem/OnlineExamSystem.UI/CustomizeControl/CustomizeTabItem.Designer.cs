namespace OnlineExamSystem.UI
{
    partial class CustomizeTabItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeTabItem));
            this.lblIco = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblIco
            // 
            this.lblIco.AutoSize = true;
            this.lblIco.Image = ((System.Drawing.Image)(resources.GetObject("LblIco.Image")));
            this.lblIco.Location = new System.Drawing.Point(10, 10);
            this.lblIco.MaximumSize = new System.Drawing.Size(20, 20);
            this.lblIco.MinimumSize = new System.Drawing.Size(20, 20);
            this.lblIco.Name = "LblIco";
            this.lblIco.Size = new System.Drawing.Size(20, 20);
            this.lblIco.TabIndex = 0;
            // 
            // LblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(35, 14);
            this.lblContent.Name = "LblContent";
            this.lblContent.Size = new System.Drawing.Size(73, 16);
            this.lblContent.TabIndex = 1;
            this.lblContent.Text = "UserName";
            // 
            // CustomizeTabItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblIco);
            this.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(100, 40);
            this.MinimumSize = new System.Drawing.Size(100, 40);
            this.Name = "CustomizeTabItem";
            this.Size = new System.Drawing.Size(100, 40);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIco;
        private System.Windows.Forms.Label lblContent;
    }
}
