namespace OnlineExamSystem.UI.CustomizeControl
{
    partial class CustomizeExamStausBar
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
            this.lblChoice = new System.Windows.Forms.Label();
            this.lblTips = new System.Windows.Forms.Label();
            this.lblTipQuestionIndex = new System.Windows.Forms.Label();
            this.lblTimeTip = new System.Windows.Forms.Label();
            this.lblTimrDisplay = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblPer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblChoice
            // 
            this.lblChoice.AutoSize = true;
            this.lblChoice.Font = new System.Drawing.Font("Arial", 9F);
            this.lblChoice.Location = new System.Drawing.Point(30, 18);
            this.lblChoice.Name = "LblChoice";
            this.lblChoice.Size = new System.Drawing.Size(46, 15);
            this.lblChoice.TabIndex = 0;
            this.lblChoice.Text = "Choice";
            // 
            // LblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.Font = new System.Drawing.Font("Arial", 9F);
            this.lblTips.Location = new System.Drawing.Point(105, 18);
            this.lblTips.Name = "LblTips";
            this.lblTips.Size = new System.Drawing.Size(220, 15);
            this.lblTips.TabIndex = 1;
            this.lblTips.Text = "Only One Correct Answer, 4 point each.";
            // 
            // LblTipQuestionIndex
            // 
            this.lblTipQuestionIndex.Location = new System.Drawing.Point(470, 18);
            this.lblTipQuestionIndex.Name = "LblTipQuestionIndex";
            this.lblTipQuestionIndex.Size = new System.Drawing.Size(21, 12);
            this.lblTipQuestionIndex.TabIndex = 2;
            this.lblTipQuestionIndex.Text = "12";
            this.lblTipQuestionIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTimeTip
            // 
            this.lblTimeTip.AutoSize = true;
            this.lblTimeTip.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeTip.Location = new System.Drawing.Point(746, 16);
            this.lblTimeTip.Name = "LblTimeTip";
            this.lblTimeTip.Size = new System.Drawing.Size(45, 15);
            this.lblTimeTip.TabIndex = 3;
            this.lblTimeTip.Text = "Timing";
            // 
            // LblTimrDisplay
            // 
            this.lblTimrDisplay.AutoSize = true;
            this.lblTimrDisplay.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTimrDisplay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.lblTimrDisplay.Location = new System.Drawing.Point(797, 7);
            this.lblTimrDisplay.Name = "LblTimrDisplay";
            this.lblTimrDisplay.Size = new System.Drawing.Size(133, 35);
            this.lblTimrDisplay.TabIndex = 4;
            this.lblTimrDisplay.Text = "00:00:00";
            // 
            // LblTotalCount
            // 
            this.lblTotalCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.lblTotalCount.Location = new System.Drawing.Point(492, 18);
            this.lblTotalCount.Name = "LblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(24, 15);
            this.lblTotalCount.TabIndex = 5;
            this.lblTotalCount.Text = "25";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPer
            // 
            this.lblPer.AutoSize = true;
            this.lblPer.BackColor = System.Drawing.Color.Transparent;
            this.lblPer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.lblPer.Location = new System.Drawing.Point(487, 18);
            this.lblPer.Name = "LblPer";
            this.lblPer.Size = new System.Drawing.Size(10, 15);
            this.lblPer.TabIndex = 6;
            this.lblPer.Text = "/";
            // 
            // ContumizeExamStausBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblPer);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblTimrDisplay);
            this.Controls.Add(this.lblTimeTip);
            this.Controls.Add(this.lblTipQuestionIndex);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.lblChoice);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ContumizeExamStausBar";
            this.Size = new System.Drawing.Size(960, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblChoice;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Label lblTipQuestionIndex;
        private System.Windows.Forms.Label lblTimeTip;
        private System.Windows.Forms.Label lblTimrDisplay;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblPer;
    }
}
