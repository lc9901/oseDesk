namespace OnlineExamSystem.UI
{
    partial class TeacherMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherMainForm));
            this.pnlTitleControl = new System.Windows.Forms.Panel();
            this.lblOperaMin = new System.Windows.Forms.Label();
            this.lblOpreaClose = new System.Windows.Forms.Label();
            this.lblOpreaMax = new System.Windows.Forms.Label();
            this.lblTitleName = new System.Windows.Forms.Label();
            this.lblIco = new System.Windows.Forms.Label();
            this.pnlTab = new System.Windows.Forms.Panel();
            this.lblLogout = new System.Windows.Forms.Label();
            this.lblChangeLanguage = new System.Windows.Forms.Label();
            this.customizeUserInfo = new OnlineExamSystem.UI.CustomizeTabItem();
            this.lblTabExamList = new System.Windows.Forms.Label();
            this.pnlExamListBack = new System.Windows.Forms.Panel();
            this.customizePassRate = new OnlineExamSystem.UI.CustomizeHead();
            this.lblDuration = new System.Windows.Forms.Label();
            this.costumizeNumberOfQualified = new OnlineExamSystem.UI.CustomizeHead();
            this.costumizeId = new OnlineExamSystem.UI.CustomizeHead();
            this.costumizeAverageScore = new OnlineExamSystem.UI.CustomizeHead();
            this.costumizeExamCount = new OnlineExamSystem.UI.CustomizeHead();
            this.costumizeEffectTime = new OnlineExamSystem.UI.CustomizeHead();
            this.costumizeHeadName = new OnlineExamSystem.UI.CustomizeHead();
            this.lblLineDown = new System.Windows.Forms.Label();
            this.lblLineUp = new System.Windows.Forms.Label();
            this.pnlExamListBody = new System.Windows.Forms.Panel();
            this.pnlTitleControl.SuspendLayout();
            this.pnlTab.SuspendLayout();
            this.pnlExamListBack.SuspendLayout();
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
            // pnlTab
            // 
            this.pnlTab.BackColor = System.Drawing.Color.White;
            this.pnlTab.Controls.Add(this.lblLogout);
            this.pnlTab.Controls.Add(this.lblChangeLanguage);
            this.pnlTab.Controls.Add(this.customizeUserInfo);
            this.pnlTab.Controls.Add(this.lblTabExamList);
            this.pnlTab.Location = new System.Drawing.Point(0, 30);
            this.pnlTab.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTab.Name = "pnlTab";
            this.pnlTab.Size = new System.Drawing.Size(1024, 40);
            this.pnlTab.TabIndex = 2;
            // 
            // lblLogout
            // 
            this.lblLogout.AutoSize = true;
            this.lblLogout.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLogout.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLogout.Location = new System.Drawing.Point(927, 0);
            this.lblLogout.MaximumSize = new System.Drawing.Size(80, 40);
            this.lblLogout.MinimumSize = new System.Drawing.Size(80, 40);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(80, 40);
            this.lblLogout.TabIndex = 4;
            this.lblLogout.Text = "Logout";
            this.lblLogout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChangeLanguage
            // 
            this.lblChangeLanguage.AutoSize = true;
            this.lblChangeLanguage.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblChangeLanguage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblChangeLanguage.Location = new System.Drawing.Point(855, 0);
            this.lblChangeLanguage.MaximumSize = new System.Drawing.Size(80, 40);
            this.lblChangeLanguage.MinimumSize = new System.Drawing.Size(80, 40);
            this.lblChangeLanguage.Name = "lblChangeLanguage";
            this.lblChangeLanguage.Size = new System.Drawing.Size(80, 40);
            this.lblChangeLanguage.TabIndex = 3;
            this.lblChangeLanguage.Text = "中文";
            this.lblChangeLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customizeUserInfo
            // 
            this.customizeUserInfo.BackColor = System.Drawing.Color.White;
            this.customizeUserInfo.ContentText = "UserName";
            this.customizeUserInfo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.customizeUserInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.customizeUserInfo.Location = new System.Drawing.Point(750, 0);
            this.customizeUserInfo.Margin = new System.Windows.Forms.Padding(0);
            this.customizeUserInfo.MaximumSize = new System.Drawing.Size(100, 40);
            this.customizeUserInfo.MinimumSize = new System.Drawing.Size(100, 40);
            this.customizeUserInfo.Name = "customizeUserInfo";
            this.customizeUserInfo.Size = new System.Drawing.Size(100, 40);
            this.customizeUserInfo.TabIndex = 2;
            // 
            // lblTabExamList
            // 
            this.lblTabExamList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.lblTabExamList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabExamList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTabExamList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblTabExamList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTabExamList.Location = new System.Drawing.Point(22, 0);
            this.lblTabExamList.Margin = new System.Windows.Forms.Padding(0);
            this.lblTabExamList.Name = "lblTabExamList";
            this.lblTabExamList.Size = new System.Drawing.Size(100, 40);
            this.lblTabExamList.TabIndex = 1;
            this.lblTabExamList.Text = "Exam List";
            this.lblTabExamList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlExamListBack
            // 
            this.pnlExamListBack.BackColor = System.Drawing.Color.White;
            this.pnlExamListBack.Controls.Add(this.pnlExamListBody);
            this.pnlExamListBack.Controls.Add(this.customizePassRate);
            this.pnlExamListBack.Controls.Add(this.lblDuration);
            this.pnlExamListBack.Controls.Add(this.costumizeNumberOfQualified);
            this.pnlExamListBack.Controls.Add(this.costumizeId);
            this.pnlExamListBack.Controls.Add(this.costumizeAverageScore);
            this.pnlExamListBack.Controls.Add(this.costumizeExamCount);
            this.pnlExamListBack.Controls.Add(this.costumizeEffectTime);
            this.pnlExamListBack.Controls.Add(this.costumizeHeadName);
            this.pnlExamListBack.Controls.Add(this.lblLineDown);
            this.pnlExamListBack.Controls.Add(this.lblLineUp);
            this.pnlExamListBack.Location = new System.Drawing.Point(22, 90);
            this.pnlExamListBack.Name = "pnlExamListBack";
            this.pnlExamListBack.Size = new System.Drawing.Size(980, 640);
            this.pnlExamListBack.TabIndex = 3;
            // 
            // customizePassRate
            // 
            this.customizePassRate.ContentText = "PassRate";
            this.customizePassRate.CulomeName = "display_id";
            this.customizePassRate.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.customizePassRate.IcoLocation = new System.Drawing.Point(80, 10);
            this.customizePassRate.IcoSrc = false;
            this.customizePassRate.ItemSize = new System.Drawing.Size(95, 40);
            this.customizePassRate.Location = new System.Drawing.Point(877, 71);
            this.customizePassRate.Margin = new System.Windows.Forms.Padding(4);
            this.customizePassRate.Name = "customizePassRate";
            this.customizePassRate.Selected = true;
            this.customizePassRate.Size = new System.Drawing.Size(95, 40);
            this.customizePassRate.TabIndex = 21;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDuration.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDuration.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDuration.Location = new System.Drawing.Point(295, 84);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(149, 16);
            this.lblDuration.TabIndex = 19;
            this.lblDuration.Text = "Total Question Quality";
            // 
            // costumizeNumberOfQualified
            // 
            this.costumizeNumberOfQualified.ContentText = "NumberOfQualified";
            this.costumizeNumberOfQualified.CulomeName = "exam_status";
            this.costumizeNumberOfQualified.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.costumizeNumberOfQualified.IcoLocation = new System.Drawing.Point(140, 10);
            this.costumizeNumberOfQualified.IcoSrc = false;
            this.costumizeNumberOfQualified.ItemSize = new System.Drawing.Size(157, 40);
            this.costumizeNumberOfQualified.Location = new System.Drawing.Point(717, 71);
            this.costumizeNumberOfQualified.Margin = new System.Windows.Forms.Padding(4);
            this.costumizeNumberOfQualified.Name = "costumizeNumberOfQualified";
            this.costumizeNumberOfQualified.Selected = true;
            this.costumizeNumberOfQualified.Size = new System.Drawing.Size(157, 40);
            this.costumizeNumberOfQualified.TabIndex = 18;
            // 
            // costumizeId
            // 
            this.costumizeId.ContentText = "ID";
            this.costumizeId.CulomeName = "display_id";
            this.costumizeId.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.costumizeId.IcoLocation = new System.Drawing.Point(30, 10);
            this.costumizeId.IcoSrc = false;
            this.costumizeId.ItemSize = new System.Drawing.Size(51, 40);
            this.costumizeId.Location = new System.Drawing.Point(110, 71);
            this.costumizeId.Margin = new System.Windows.Forms.Padding(4);
            this.costumizeId.Name = "costumizeId";
            this.costumizeId.Selected = true;
            this.costumizeId.Size = new System.Drawing.Size(51, 40);
            this.costumizeId.TabIndex = 17;
            // 
            // costumizeAverageScore
            // 
            this.costumizeAverageScore.ContentText = "Average Score";
            this.costumizeAverageScore.CulomeName = "pass_criteria";
            this.costumizeAverageScore.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.costumizeAverageScore.IcoLocation = new System.Drawing.Point(110, 10);
            this.costumizeAverageScore.IcoSrc = false;
            this.costumizeAverageScore.ItemSize = new System.Drawing.Size(128, 40);
            this.costumizeAverageScore.Location = new System.Drawing.Point(444, 71);
            this.costumizeAverageScore.Margin = new System.Windows.Forms.Padding(4);
            this.costumizeAverageScore.Name = "costumizeAverageScore";
            this.costumizeAverageScore.Selected = true;
            this.costumizeAverageScore.Size = new System.Drawing.Size(128, 40);
            this.costumizeAverageScore.TabIndex = 16;
            // 
            // costumizeExamCount
            // 
            this.costumizeExamCount.ContentText = "Examinee Count";
            this.costumizeExamCount.CulomeName = "score";
            this.costumizeExamCount.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.costumizeExamCount.IcoLocation = new System.Drawing.Point(120, 10);
            this.costumizeExamCount.IcoSrc = false;
            this.costumizeExamCount.ItemSize = new System.Drawing.Size(139, 40);
            this.costumizeExamCount.Location = new System.Drawing.Point(578, 71);
            this.costumizeExamCount.Margin = new System.Windows.Forms.Padding(4);
            this.costumizeExamCount.Name = "costumizeExamCount";
            this.costumizeExamCount.Selected = true;
            this.costumizeExamCount.Size = new System.Drawing.Size(139, 40);
            this.costumizeExamCount.TabIndex = 15;
            // 
            // costumizeEffectTime
            // 
            this.costumizeEffectTime.ContentText = "Effective Time";
            this.costumizeEffectTime.CulomeName = "effective_time";
            this.costumizeEffectTime.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.costumizeEffectTime.IcoLocation = new System.Drawing.Point(110, 10);
            this.costumizeEffectTime.IcoSrc = false;
            this.costumizeEffectTime.ItemSize = new System.Drawing.Size(128, 40);
            this.costumizeEffectTime.Location = new System.Drawing.Point(167, 71);
            this.costumizeEffectTime.Margin = new System.Windows.Forms.Padding(4);
            this.costumizeEffectTime.Name = "costumizeEffectTime";
            this.costumizeEffectTime.Selected = true;
            this.costumizeEffectTime.Size = new System.Drawing.Size(128, 40);
            this.costumizeEffectTime.TabIndex = 14;
            // 
            // costumizeHeadName
            // 
            this.costumizeHeadName.ContentText = "name";
            this.costumizeHeadName.CulomeName = "name";
            this.costumizeHeadName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.costumizeHeadName.IcoLocation = new System.Drawing.Point(55, 10);
            this.costumizeHeadName.IcoSrc = false;
            this.costumizeHeadName.ItemSize = new System.Drawing.Size(67, 40);
            this.costumizeHeadName.Location = new System.Drawing.Point(29, 71);
            this.costumizeHeadName.Margin = new System.Windows.Forms.Padding(4);
            this.costumizeHeadName.Name = "costumizeHeadName";
            this.costumizeHeadName.Selected = true;
            this.costumizeHeadName.Size = new System.Drawing.Size(67, 40);
            this.costumizeHeadName.TabIndex = 13;
            // 
            // lblLineDown
            // 
            this.lblLineDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLineDown.Location = new System.Drawing.Point(0, 111);
            this.lblLineDown.Name = "lblLineDown";
            this.lblLineDown.Size = new System.Drawing.Size(980, 2);
            this.lblLineDown.TabIndex = 12;
            this.lblLineDown.Text = "label1";
            // 
            // lblLineUp
            // 
            this.lblLineUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLineUp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLineUp.Location = new System.Drawing.Point(0, 69);
            this.lblLineUp.Name = "lblLineUp";
            this.lblLineUp.Size = new System.Drawing.Size(980, 2);
            this.lblLineUp.TabIndex = 11;
            this.lblLineUp.Text = "label1";
            // 
            // pnlExamListBody
            // 
            this.pnlExamListBody.Location = new System.Drawing.Point(0, 112);
            this.pnlExamListBody.Name = "pnlExamListBody";
            this.pnlExamListBody.Size = new System.Drawing.Size(980, 310);
            this.pnlExamListBody.TabIndex = 22;
            // 
            // TeacherMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1024, 760);
            this.Controls.Add(this.pnlExamListBack);
            this.Controls.Add(this.pnlTab);
            this.Controls.Add(this.pnlTitleControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TeacherMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TeacherMainForm";
            this.pnlTitleControl.ResumeLayout(false);
            this.pnlTitleControl.PerformLayout();
            this.pnlTab.ResumeLayout(false);
            this.pnlTab.PerformLayout();
            this.pnlExamListBack.ResumeLayout(false);
            this.pnlExamListBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitleControl;
        private System.Windows.Forms.Label lblOperaMin;
        private System.Windows.Forms.Label lblOpreaClose;
        private System.Windows.Forms.Label lblOpreaMax;
        private System.Windows.Forms.Label lblTitleName;
        private System.Windows.Forms.Label lblIco;
        private System.Windows.Forms.Panel pnlTab;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblChangeLanguage;
        private CustomizeTabItem customizeUserInfo;
        private System.Windows.Forms.Label lblTabExamList;
        private System.Windows.Forms.Panel pnlExamListBack;
        private System.Windows.Forms.Label lblLineUp;
        private System.Windows.Forms.Label lblLineDown;
        private System.Windows.Forms.Label lblDuration;
        private CustomizeHead costumizeNumberOfQualified;
        private CustomizeHead costumizeId;
        private CustomizeHead costumizeAverageScore;
        private CustomizeHead costumizeExamCount;
        private CustomizeHead costumizeEffectTime;
        private CustomizeHead costumizeHeadName;
        private CustomizeHead customizePassRate;
        private System.Windows.Forms.Panel pnlExamListBody;
        private CustomizeControl.CustomizePagenaitionBlock costomizePagenaitionBlock;
    }
}