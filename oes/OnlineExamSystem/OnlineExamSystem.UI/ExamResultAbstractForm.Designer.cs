namespace OnlineExamSystem.UI
{
    partial class ExamResultAbstractForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamResultAbstractForm));
            this.pnlTitleControl = new System.Windows.Forms.Panel();
            this.lblOperaMin = new System.Windows.Forms.Label();
            this.lblOpreaClose = new System.Windows.Forms.Label();
            this.lblOpreaMax = new System.Windows.Forms.Label();
            this.lblTitleName = new System.Windows.Forms.Label();
            this.lblIco = new System.Windows.Forms.Label();
            this.lblMassageModel = new System.Windows.Forms.Label();
            this.lblTotalScore = new System.Windows.Forms.Label();
            this.lblRightCount = new System.Windows.Forms.Label();
            this.btnViewDetail = new System.Windows.Forms.Button();
            this.lblTimeOutMessage = new System.Windows.Forms.Label();
            this.pnlTitleControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTitleControl
            // 
            this.pnlTitleControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.pnlTitleControl.Controls.Add(this.lblOperaMin);
            this.pnlTitleControl.Controls.Add(this.lblOpreaClose);
            this.pnlTitleControl.Controls.Add(this.lblOpreaMax);
            this.pnlTitleControl.Controls.Add(this.lblTitleName);
            this.pnlTitleControl.Controls.Add(this.lblIco);
            this.pnlTitleControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitleControl.Location = new System.Drawing.Point(0, 0);
            this.pnlTitleControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTitleControl.MaximumSize = new System.Drawing.Size(1024, 30);
            this.pnlTitleControl.MinimumSize = new System.Drawing.Size(1024, 30);
            this.pnlTitleControl.Name = "pnlTitleControl";
            this.pnlTitleControl.Size = new System.Drawing.Size(1024, 30);
            this.pnlTitleControl.TabIndex = 1;
            // 
            // lblOperaMin
            // 
            this.lblOperaMin.Image = ((System.Drawing.Image)(resources.GetObject("lblOperaMin.Image")));
            this.lblOperaMin.Location = new System.Drawing.Point(936, 10);
            this.lblOperaMin.Name = "lblOperaMin";
            this.lblOperaMin.Size = new System.Drawing.Size(16, 16);
            this.lblOperaMin.TabIndex = 4;
            // 
            // lblOpreaClose
            // 
            this.lblOpreaClose.Image = ((System.Drawing.Image)(resources.GetObject("lblOpreaClose.Image")));
            this.lblOpreaClose.Location = new System.Drawing.Point(988, 7);
            this.lblOpreaClose.Name = "lblOpreaClose";
            this.lblOpreaClose.Size = new System.Drawing.Size(16, 16);
            this.lblOpreaClose.TabIndex = 3;
            // 
            // lblOpreaMax
            // 
            this.lblOpreaMax.Image = ((System.Drawing.Image)(resources.GetObject("lblOpreaMax.Image")));
            this.lblOpreaMax.Location = new System.Drawing.Point(962, 7);
            this.lblOpreaMax.Name = "lblOpreaMax";
            this.lblOpreaMax.Size = new System.Drawing.Size(16, 16);
            this.lblOpreaMax.TabIndex = 2;
            // 
            // lblTitleName
            // 
            this.lblTitleName.AutoSize = true;
            this.lblTitleName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitleName.ForeColor = System.Drawing.Color.White;
            this.lblTitleName.Location = new System.Drawing.Point(160, 7);
            this.lblTitleName.Name = "lblTitleName";
            this.lblTitleName.Size = new System.Drawing.Size(177, 16);
            this.lblTitleName.TabIndex = 1;
            this.lblTitleName.Text = "Online Exam System Client";
            // 
            // lblIco
            // 
            this.lblIco.AutoSize = true;
            this.lblIco.Image = ((System.Drawing.Image)(resources.GetObject("lblIco.Image")));
            this.lblIco.Location = new System.Drawing.Point(20, 5);
            this.lblIco.MaximumSize = new System.Drawing.Size(120, 20);
            this.lblIco.MinimumSize = new System.Drawing.Size(120, 20);
            this.lblIco.Name = "lblIco";
            this.lblIco.Size = new System.Drawing.Size(120, 20);
            this.lblIco.TabIndex = 0;
            // 
            // lblMassageModel
            // 
            this.lblMassageModel.AutoSize = true;
            this.lblMassageModel.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblMassageModel.Location = new System.Drawing.Point(233, 260);
            this.lblMassageModel.Name = "lblMassageModel";
            this.lblMassageModel.Size = new System.Drawing.Size(480, 21);
            this.lblMassageModel.TabIndex = 2;
            this.lblMassageModel.Text = "Your score is        points, you got        questions in this test.";
            // 
            // lblTotalScore
            // 
            this.lblTotalScore.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalScore.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalScore.Location = new System.Drawing.Point(342, 261);
            this.lblTotalScore.Name = "lblTotalScore";
            this.lblTotalScore.Size = new System.Drawing.Size(40, 21);
            this.lblTotalScore.TabIndex = 3;
            this.lblTotalScore.Text = "02";
            this.lblTotalScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRightCount
            // 
            this.lblRightCount.BackColor = System.Drawing.Color.Transparent;
            this.lblRightCount.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblRightCount.Location = new System.Drawing.Point(503, 261);
            this.lblRightCount.Name = "lblRightCount";
            this.lblRightCount.Size = new System.Drawing.Size(36, 21);
            this.lblRightCount.TabIndex = 4;
            this.lblRightCount.Text = "02";
            this.lblRightCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnViewDetail
            // 
            this.btnViewDetail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.btnViewDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetail.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnViewDetail.Location = new System.Drawing.Point(410, 328);
            this.btnViewDetail.Name = "btnViewDetail";
            this.btnViewDetail.Size = new System.Drawing.Size(200, 35);
            this.btnViewDetail.TabIndex = 5;
            this.btnViewDetail.Text = "View the exam result detail";
            this.btnViewDetail.UseVisualStyleBackColor = true;
            // 
            // lblTimeOutMessage
            // 
            this.lblTimeOutMessage.AutoSize = true;
            this.lblTimeOutMessage.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTimeOutMessage.Location = new System.Drawing.Point(233, 217);
            this.lblTimeOutMessage.Name = "lblTimeOutMessage";
            this.lblTimeOutMessage.Size = new System.Drawing.Size(500, 21);
            this.lblTimeOutMessage.TabIndex = 6;
            this.lblTimeOutMessage.Text = "Your time is up, the system automatically submited to the test.";
            // 
            // ExamResultAbstractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 760);
            this.Controls.Add(this.lblTimeOutMessage);
            this.Controls.Add(this.btnViewDetail);
            this.Controls.Add(this.lblRightCount);
            this.Controls.Add(this.lblTotalScore);
            this.Controls.Add(this.lblMassageModel);
            this.Controls.Add(this.pnlTitleControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExamResultAbstractForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamResultAbstractForm";
            this.pnlTitleControl.ResumeLayout(false);
            this.pnlTitleControl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleControl;
        private System.Windows.Forms.Label lblOperaMin;
        private System.Windows.Forms.Label lblOpreaClose;
        private System.Windows.Forms.Label lblOpreaMax;
        private System.Windows.Forms.Label lblTitleName;
        private System.Windows.Forms.Label lblIco;
        private System.Windows.Forms.Label lblMassageModel;
        private System.Windows.Forms.Label lblTotalScore;
        private System.Windows.Forms.Label lblRightCount;
        private System.Windows.Forms.Button btnViewDetail;
        private System.Windows.Forms.Label lblTimeOutMessage;
    }
}