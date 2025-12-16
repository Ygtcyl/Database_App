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
            label1 = new Label();
            SuspendLayout();
            // 
            // btnEmployee
            // 
            btnEmployee.Location = new Point(105, 117);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(100, 50);
            btnEmployee.TabIndex = 0;
            btnEmployee.Text = "Employee";
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnPassenger
            // 
            btnPassenger.Location = new Point(597, 117);
            btnPassenger.Name = "btnPassenger";
            btnPassenger.Size = new Size(100, 50);
            btnPassenger.TabIndex = 1;
            btnPassenger.Text = "Passenger";
            btnPassenger.UseVisualStyleBackColor = true;
            btnPassenger.Click += btnPassenger_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(346, 117);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 50);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search Routes";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveBorder;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 30F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(776, 77);
            label1.TabIndex = 3;
            label1.Text = "Main Menu";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
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
        private Label label1;
    }
}