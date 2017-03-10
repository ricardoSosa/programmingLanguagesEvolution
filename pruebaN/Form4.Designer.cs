namespace pruebaN
{
    partial class Form4
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
            this.languageText = new System.Windows.Forms.TextBox();
            this.resultList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.parentsButton = new System.Windows.Forms.Button();
            this.childrenButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // languageText
            // 
            this.languageText.Location = new System.Drawing.Point(34, 61);
            this.languageText.Name = "languageText";
            this.languageText.Size = new System.Drawing.Size(100, 20);
            this.languageText.TabIndex = 0;
            // 
            // resultList
            // 
            this.resultList.FormattingEnabled = true;
            this.resultList.Location = new System.Drawing.Point(34, 132);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(100, 95);
            this.resultList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Language:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result:";
            // 
            // parentsButton
            // 
            this.parentsButton.Location = new System.Drawing.Point(164, 132);
            this.parentsButton.Name = "parentsButton";
            this.parentsButton.Size = new System.Drawing.Size(89, 23);
            this.parentsButton.TabIndex = 4;
            this.parentsButton.Text = "Show parents";
            this.parentsButton.UseVisualStyleBackColor = true;
            this.parentsButton.Click += new System.EventHandler(this.parentsButton_Click);
            // 
            // childrenButton
            // 
            this.childrenButton.Location = new System.Drawing.Point(164, 170);
            this.childrenButton.Name = "childrenButton";
            this.childrenButton.Size = new System.Drawing.Size(89, 23);
            this.childrenButton.TabIndex = 5;
            this.childrenButton.Text = "Show Children";
            this.childrenButton.UseVisualStyleBackColor = true;
            this.childrenButton.Click += new System.EventHandler(this.childrenButton_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 261);
            this.Controls.Add(this.childrenButton);
            this.Controls.Add(this.parentsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultList);
            this.Controls.Add(this.languageText);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox languageText;
        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button parentsButton;
        private System.Windows.Forms.Button childrenButton;
    }
}