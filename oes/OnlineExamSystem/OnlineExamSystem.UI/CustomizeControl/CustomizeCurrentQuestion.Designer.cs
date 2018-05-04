namespace OnlineExamSystem.UI.CustomizeControl
{
    partial class CustomizeCurrentQuestion
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
            this.lblBackGrand = new System.Windows.Forms.Label();
            this.lblCurrentQuestionIndex = new System.Windows.Forms.Label();
            this.lblQuestionDescription = new System.Windows.Forms.Label();
            this.rdoA = new System.Windows.Forms.RadioButton();
            this.rdoB = new System.Windows.Forms.RadioButton();
            this.rdoC = new System.Windows.Forms.RadioButton();
            this.rdoD = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // LblBackGrand
            // 
            this.lblBackGrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.lblBackGrand.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblBackGrand.ForeColor = System.Drawing.Color.Transparent;
            this.lblBackGrand.Location = new System.Drawing.Point(0, 0);
            this.lblBackGrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBackGrand.Name = "LblBackGrand";
            this.lblBackGrand.Size = new System.Drawing.Size(39, 28);
            this.lblBackGrand.TabIndex = 1;
            this.lblBackGrand.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblCurrentQuestionIndex
            // 
            this.lblCurrentQuestionIndex.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentQuestionIndex.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCurrentQuestionIndex.Location = new System.Drawing.Point(2, 2);
            this.lblCurrentQuestionIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentQuestionIndex.Name = "LblCurrentQuestionIndex";
            this.lblCurrentQuestionIndex.Size = new System.Drawing.Size(35, 24);
            this.lblCurrentQuestionIndex.TabIndex = 0;
            this.lblCurrentQuestionIndex.Text = "12";
            this.lblCurrentQuestionIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblQuestionDescription
            // 
            this.lblQuestionDescription.AutoSize = true;
            this.lblQuestionDescription.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblQuestionDescription.Location = new System.Drawing.Point(48, 4);
            this.lblQuestionDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestionDescription.MaximumSize = new System.Drawing.Size(500, 50);
            this.lblQuestionDescription.MinimumSize = new System.Drawing.Size(500, 50);
            this.lblQuestionDescription.Name = "LblQuestionDescription";
            this.lblQuestionDescription.Size = new System.Drawing.Size(500, 50);
            this.lblQuestionDescription.TabIndex = 2;
            this.lblQuestionDescription.Text = "label1";
            // 
            // RdoA
            // 
            this.rdoA.AutoSize = true;
            this.rdoA.Location = new System.Drawing.Point(50, 60);
            this.rdoA.Name = "RdoA";
            this.rdoA.Size = new System.Drawing.Size(107, 20);
            this.rdoA.TabIndex = 3;
            this.rdoA.Text = "radioButton1";
            this.rdoA.UseVisualStyleBackColor = true;
            // 
            // RdoB
            // 
            this.rdoB.AutoSize = true;
            this.rdoB.Location = new System.Drawing.Point(50, 88);
            this.rdoB.Name = "RdoB";
            this.rdoB.Size = new System.Drawing.Size(107, 20);
            this.rdoB.TabIndex = 4;
            this.rdoB.Text = "radioButton2";
            this.rdoB.UseVisualStyleBackColor = true;
            // 
            // RdoC
            // 
            this.rdoC.AutoSize = true;
            this.rdoC.Location = new System.Drawing.Point(51, 119);
            this.rdoC.Name = "RdoC";
            this.rdoC.Size = new System.Drawing.Size(107, 20);
            this.rdoC.TabIndex = 5;
            this.rdoC.Text = "radioButton3";
            this.rdoC.UseVisualStyleBackColor = true;
            // 
            // RdoD
            // 
            this.rdoD.AutoSize = true;
            this.rdoD.Location = new System.Drawing.Point(51, 149);
            this.rdoD.Name = "RdoD";
            this.rdoD.Size = new System.Drawing.Size(107, 20);
            this.rdoD.TabIndex = 6;
            this.rdoD.Text = "radioButton4";
            this.rdoD.UseVisualStyleBackColor = true;
            // 
            // CustomCurrentQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.rdoD);
            this.Controls.Add(this.rdoC);
            this.Controls.Add(this.rdoB);
            this.Controls.Add(this.rdoA);
            this.Controls.Add(this.lblQuestionDescription);
            this.Controls.Add(this.lblCurrentQuestionIndex);
            this.Controls.Add(this.lblBackGrand);
            this.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomCurrentQuestion";
            this.Size = new System.Drawing.Size(754, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBackGrand;
        private System.Windows.Forms.Label lblCurrentQuestionIndex;
        private System.Windows.Forms.Label lblQuestionDescription;
        private System.Windows.Forms.RadioButton rdoA;
        private System.Windows.Forms.RadioButton rdoB;
        private System.Windows.Forms.RadioButton rdoC;
        private System.Windows.Forms.RadioButton rdoD;
    }
}
