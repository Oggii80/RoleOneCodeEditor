namespace Role_One_Code_Editor
{
    partial class findForm
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
            findLabel = new Label();
            searchBox = new TextBox();
            searchButton = new Button();
            SuspendLayout();
            // 
            // findLabel
            // 
            findLabel.AutoSize = true;
            findLabel.Font = new Font("Another Mans Treasure MIII 64C", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            findLabel.ForeColor = Color.Lime;
            findLabel.Location = new Point(12, 9);
            findLabel.Name = "findLabel";
            findLabel.Size = new Size(58, 19);
            findLabel.TabIndex = 0;
            findLabel.Text = "Search:";
            // 
            // searchBox
            // 
            searchBox.ForeColor = Color.Lime;
            searchBox.Location = new Point(76, 6);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(100, 23);
            searchBox.TabIndex = 1;
            // 
            // searchButton
            // 
            searchButton.AutoSize = true;
            searchButton.BackColor = Color.Black;
            searchButton.Font = new Font("Another Mans Treasure MIII 64C", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchButton.ForeColor = Color.Lime;
            searchButton.Location = new Point(86, 35);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(75, 29);
            searchButton.TabIndex = 2;
            searchButton.Text = "Find";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // findForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(211, 76);
            Controls.Add(searchButton);
            Controls.Add(searchBox);
            Controls.Add(findLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "findForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Find";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label findLabel;
        private Button searchButton;
        public TextBox searchBox;
    }
}