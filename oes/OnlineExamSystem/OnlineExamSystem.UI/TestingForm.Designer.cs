namespace OnlineExamSystem.UI
{
    partial class TestingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestingForm));
            this.pnlTitleControl = new System.Windows.Forms.Panel();
            this.lblOperaMin = new System.Windows.Forms.Label();
            this.lblOpreaClose = new System.Windows.Forms.Label();
            this.lblOpreaMax = new System.Windows.Forms.Label();
            this.lblTitleName = new System.Windows.Forms.Label();
            this.lblIco = new System.Windows.Forms.Label();
            this.btnNextQuestion = new System.Windows.Forms.Button();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.customCurrentQuestionUse = new OnlineExamSystem.UI.CustomizeControl.CustomizeCurrentQuestion();
            this.customizeExamStausBarUse = new OnlineExamSystem.UI.CustomizeControl.CustomizeExamStausBar();
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
            this.pnlTitleControl.TabIndex = 2;
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
            // btnNextQuestion
            // 
            this.btnNextQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.btnNextQuestion.FlatAppearance.BorderSize = 0;
            this.btnNextQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextQuestion.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnNextQuestion.ForeColor = System.Drawing.Color.White;
            this.btnNextQuestion.Location = new System.Drawing.Point(437, 518);
            this.btnNextQuestion.Name = "btnNextQuestion";
            this.btnNextQuestion.Size = new System.Drawing.Size(150, 30);
            this.btnNextQuestion.TabIndex = 5;
            this.btnNextQuestion.Text = "Next Question";
            this.btnNextQuestion.UseVisualStyleBackColor = false;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Enabled = true;
            this.tmrTimer.Interval = 1000;
            // 
            // customCurrentQuestionUse
            // 
            this.customCurrentQuestionUse.Answer = null;
            this.customCurrentQuestionUse.BackColor = System.Drawing.Color.Transparent;
            this.customCurrentQuestionUse.CurrentIndex = 12;
            this.customCurrentQuestionUse.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.customCurrentQuestionUse.Location = new System.Drawing.Point(143, 188);
            this.customCurrentQuestionUse.Margin = new System.Windows.Forms.Padding(4);
            this.customCurrentQuestionUse.Name = "customCurrentQuestionUse";
            this.customCurrentQuestionUse.OptionA = "radioButton1";
            this.customCurrentQuestionUse.OptionB = "radioButton2";
            this.customCurrentQuestionUse.OptionC = "radioButton3";
            this.customCurrentQuestionUse.OptionD = "radioButton4";
            this.customCurrentQuestionUse.QuestionDescription = "label1";
            this.customCurrentQuestionUse.Size = new System.Drawing.Size(754, 216);
            this.customCurrentQuestionUse.TabIndex = 4;
            // 
            // customizeExamStausBarUse
            // 
            this.customizeExamStausBarUse.BackColor = System.Drawing.Color.White;
            this.customizeExamStausBarUse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customizeExamStausBarUse.CurrentQuestionIndex = 12;
            this.customizeExamStausBarUse.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.customizeExamStausBarUse.Location = new System.Drawing.Point(30, 80);
            this.customizeExamStausBarUse.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.customizeExamStausBarUse.Name = "customizeExamStausBarUse";
            this.customizeExamStausBarUse.QuestionTotal = 12;
            this.customizeExamStausBarUse.RemainingTime = "00:00:00";
            this.customizeExamStausBarUse.Size = new System.Drawing.Size(960, 50);
            this.customizeExamStausBarUse.TabIndex = 3;
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1024, 760);
            this.Controls.Add(this.btnNextQuestion);
            this.Controls.Add(this.customCurrentQuestionUse);
            this.Controls.Add(this.customizeExamStausBarUse);
            this.Controls.Add(this.pnlTitleControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestingForm";
            this.pnlTitleControl.ResumeLayout(false);
            this.pnlTitleControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleControl;
        private System.Windows.Forms.Label lblOperaMin;
        private System.Windows.Forms.Label lblOpreaClose;
        private System.Windows.Forms.Label lblOpreaMax;
        private System.Windows.Forms.Label lblTitleName;
        private System.Windows.Forms.Label lblIco;
        private CustomizeControl.CustomizeExamStausBar customizeExamStausBarUse;
        private CustomizeControl.CustomizeCurrentQuestion customCurrentQuestionUse;
        private System.Windows.Forms.Button btnNextQuestion;
        private System.Windows.Forms.Timer tmrTimer;

    }
}