namespace pruebaN
{
    partial class Form3
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
            this.selectTextField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.parentsList = new System.Windows.Forms.ListBox();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.addPButton = new System.Windows.Forms.Button();
            this.deletePButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectTextField
            // 
            this.selectTextField.Location = new System.Drawing.Point(37, 72);
            this.selectTextField.Name = "selectTextField";
            this.selectTextField.Size = new System.Drawing.Size(129, 20);
            this.selectTextField.TabIndex = 0;
            this.selectTextField.TextChanged += new System.EventHandler(this.selectTextField_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the language to modify:";
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(188, 69);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(93, 23);
            this.selectButton.TabIndex = 2;
            this.selectButton.Text = "Select";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // parentsList
            // 
            this.parentsList.FormattingEnabled = true;
            this.parentsList.Location = new System.Drawing.Point(37, 154);
            this.parentsList.Name = "parentsList";
            this.parentsList.Size = new System.Drawing.Size(120, 95);
            this.parentsList.TabIndex = 3;
            this.parentsList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedLabel.Location = new System.Drawing.Point(34, 116);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(71, 18);
            this.selectedLabel.TabIndex = 4;
            this.selectedLabel.Text = "Parents:";
            this.selectedLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // addPButton
            // 
            this.addPButton.Location = new System.Drawing.Point(188, 154);
            this.addPButton.Name = "addPButton";
            this.addPButton.Size = new System.Drawing.Size(93, 23);
            this.addPButton.TabIndex = 5;
            this.addPButton.Text = "Add new parent";
            this.addPButton.UseVisualStyleBackColor = true;
            this.addPButton.Click += new System.EventHandler(this.addPButton_Click);
            // 
            // deletePButton
            // 
            this.deletePButton.Location = new System.Drawing.Point(188, 194);
            this.deletePButton.Name = "deletePButton";
            this.deletePButton.Size = new System.Drawing.Size(93, 23);
            this.deletePButton.TabIndex = 6;
            this.deletePButton.Text = "Delete parent";
            this.deletePButton.UseVisualStyleBackColor = true;
            this.deletePButton.Click += new System.EventHandler(this.deletePButton_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 261);
            this.Controls.Add(this.deletePButton);
            this.Controls.Add(this.addPButton);
            this.Controls.Add(this.selectedLabel);
            this.Controls.Add(this.parentsList);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectTextField);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox selectTextField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.ListBox parentsList;
        private System.Windows.Forms.Label selectedLabel;
        private System.Windows.Forms.Button addPButton;
        private System.Windows.Forms.Button deletePButton;
    }
}