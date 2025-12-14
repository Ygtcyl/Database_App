namespace Database_App
{
    partial class MainForm
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
            btnEmployee = new Button();
            btnPassenger = new Button();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // btnEmployee
            // 
            btnEmployee.Location = new Point(23, 21);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(75, 23);
            btnEmployee.TabIndex = 0;
            btnEmployee.Text = "Employee";
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnPassenger
            // 
            btnPassenger.Location = new Point(549, 21);
            btnPassenger.Name = "btnPassenger";
            btnPassenger.Size = new Size(75, 23);
            btnPassenger.TabIndex = 1;
            btnPassenger.Text = "Passenger";
            btnPassenger.UseVisualStyleBackColor = true;
            btnPassenger.Click += btnPassenger_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(284, 21);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSearch);
            Controls.Add(btnPassenger);
            Controls.Add(btnEmployee);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnEmployee;
        private Button btnPassenger;
        private Button btnSearch;
    }
}