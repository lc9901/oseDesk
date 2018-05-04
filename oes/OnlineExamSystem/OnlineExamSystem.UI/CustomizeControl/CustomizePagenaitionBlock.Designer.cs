namespace OnlineExamSystem.UI.CustomizeControl
{
    partial class CustomizePagenaitionBlock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizePagenaitionBlock));
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.lblPerPage = new System.Windows.Forms.Label();
            this.txtTagPage = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.pnlPageNumberPanel = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblNextPage = new System.Windows.Forms.Label();
            this.lblPervPage = new System.Windows.Forms.Label();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboPageSize
            // 
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cboPageSize.Location = new System.Drawing.Point(39, 3);
            this.cboPageSize.Margin = new System.Windows.Forms.Padding(4);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.Size = new System.Drawing.Size(40, 23);
            this.cboPageSize.TabIndex = 7;
            this.cboPageSize.Text = "10";
            // 
            // lblPerPage
            // 
            this.lblPerPage.AutoSize = true;
            this.lblPerPage.Location = new System.Drawing.Point(88, 7);
            this.lblPerPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPerPage.Name = "lblPerPage";
            this.lblPerPage.Size = new System.Drawing.Size(57, 15);
            this.lblPerPage.TabIndex = 8;
            this.lblPerPage.Text = "Per page";
            this.lblPerPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTagPage
            // 
            this.txtTagPage.Font = new System.Drawing.Font("SimSun", 8F);
            this.txtTagPage.Location = new System.Drawing.Point(148, 5);
            this.txtTagPage.Margin = new System.Windows.Forms.Padding(4);
            this.txtTagPage.MaximumSize = new System.Drawing.Size(22, 20);
            this.txtTagPage.MinimumSize = new System.Drawing.Size(22, 20);
            this.txtTagPage.Name = "txtTagPage";
            this.txtTagPage.Size = new System.Drawing.Size(22, 20);
            this.txtTagPage.TabIndex = 9;
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnGo.Location = new System.Drawing.Point(178, 2);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(29, 25);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = false;
            // 
            // pnlPageNumberPanel
            // 
            this.pnlPageNumberPanel.AutoSize = true;
            this.pnlPageNumberPanel.Location = new System.Drawing.Point(54, 2);
            this.pnlPageNumberPanel.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPageNumberPanel.Name = "pnlPageNumberPanel";
            this.pnlPageNumberPanel.Size = new System.Drawing.Size(33, 26);
            this.pnlPageNumberPanel.TabIndex = 11;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.cboPageSize);
            this.pnlRight.Controls.Add(this.lblPerPage);
            this.pnlRight.Controls.Add(this.lblNextPage);
            this.pnlRight.Controls.Add(this.btnGo);
            this.pnlRight.Controls.Add(this.txtTagPage);
            this.pnlRight.Location = new System.Drawing.Point(195, -1);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(235, 29);
            this.pnlRight.TabIndex = 12;
            // 
            // lblNextPage
            // 
            this.lblNextPage.Image = ((System.Drawing.Image)(resources.GetObject("lblNextPage.Image")));
            this.lblNextPage.Location = new System.Drawing.Point(4, 6);
            this.lblNextPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNextPage.Name = "lblNextPage";
            this.lblNextPage.Size = new System.Drawing.Size(24, 19);
            this.lblNextPage.TabIndex = 1;
            // 
            // lblPervPage
            // 
            this.lblPervPage.Image = ((System.Drawing.Image)(resources.GetObject("lblPervPage.Image")));
            this.lblPervPage.Location = new System.Drawing.Point(22, 4);
            this.lblPervPage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPervPage.Name = "lblPervPage";
            this.lblPervPage.Size = new System.Drawing.Size(24, 19);
            this.lblPervPage.TabIndex = 0;
            // 
            // CustomizePagenaitionBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlPageNumberPanel);
            this.Controls.Add(this.lblPervPage);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomizePagenaitionBlock";
            this.Size = new System.Drawing.Size(471, 27);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPervPage;
        private System.Windows.Forms.Label lblNextPage;
        private System.Windows.Forms.ComboBox cboPageSize;
        private System.Windows.Forms.Label lblPerPage;
        private System.Windows.Forms.TextBox txtTagPage;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel pnlPageNumberPanel;
        private System.Windows.Forms.Panel pnlRight;
    }
}
