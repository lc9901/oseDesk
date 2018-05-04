namespace OnlineExamSystem.UI
{
    partial class CustomizeHead
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
            this.lblIoc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblContent
            // 
            this.lblContent.AutoSize = true;
            this.lblContent.BackColor = System.Drawing.Color.Transparent;
            this.lblContent.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblContent.Location = new System.Drawing.Point(10, 10);
            this.lblContent.Margin = new System.Windows.Forms.Padding(0);
            this.lblContent.Name = "LblContent";
            this.lblContent.Size = new System.Drawing.Size(46, 16);
            this.lblContent.TabIndex = 0;
            this.lblContent.Text = "label1";
            // 
            // LblIoc
            // 
            this.lblIoc.BackColor = System.Drawing.Color.Transparent;
            this.lblIoc.ImageKey = "(none)";
            this.lblIoc.Location = new System.Drawing.Point(125, 32);
            this.lblIoc.Name = "LblIoc";
            this.lblIoc.Size = new System.Drawing.Size(10, 15);
            this.lblIoc.TabIndex = 1;
            // 
            // CostumizeHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIoc);
            this.Controls.Add(this.lblContent);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CostumizeHead";
            this.Size = new System.Drawing.Size(225, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.Label lblIoc;
    }
}
