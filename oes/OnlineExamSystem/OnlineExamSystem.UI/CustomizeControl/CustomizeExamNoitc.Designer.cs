namespace OnlineExamSystem.UI
{
    partial class CustomizeExamNoitc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizeExamNoitc));
            this.lblPlease = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblExamname = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlease
            // 
            resources.ApplyResources(this.lblPlease, "lblPlease");
            this.lblPlease.Name = "lblPlease";
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.Name = "lblTime";
            // 
            // lblExamname
            // 
            resources.ApplyResources(this.lblExamname, "lblExamname");
            this.lblExamname.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExamname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.lblExamname.Name = "lblExamname";
            // 
            // lblIndex
            // 
            resources.ApplyResources(this.lblIndex, "lblIndex");
            this.lblIndex.Name = "lblIndex";
            // 
            // CustomizeExamNoitc
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.lblExamname);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPlease);
            this.Name = "CustomizeExamNoitc";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlease;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblExamname;
        private System.Windows.Forms.Label lblIndex;
    }
}
