namespace OnlineExamSystem.UI
{
    partial class CustomizeTabLbl
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
            this.lblContent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblContent
            // 
            this.lblContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblContent.Location = new System.Drawing.Point(0, 0);
            this.lblContent.MaximumSize = new System.Drawing.Size(100, 30);
            this.lblContent.MinimumSize = new System.Drawing.Size(100, 30);
            this.lblContent.Name = "LblContent";
            this.lblContent.Size = new System.Drawing.Size(100, 30);
            this.lblContent.TabIndex = 0;
            this.lblContent.Text = "All";
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CostomizeTabLbl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblContent);
            this.Name = "CostomizeTabLbl";
            this.Size = new System.Drawing.Size(100, 30);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContent;
    }
}
