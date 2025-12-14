namespace Database_App
{
    partial class EmployeeForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            txtSalary = new TextBox();
            cmbType = new ComboBox();
            label4 = new Label();
            txtRank = new TextBox();
            label5 = new Label();
            label6 = new Label();
            txtLicense = new TextBox();
            txtFlightHours = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnBonus = new Button();
            btnSave = new Button();
            gridEmployees = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridEmployees).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 86);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 115);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "Salary";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 15);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 2;
            label3.Text = "Type";
            // 
            // txtName
            // 
            txtName.Location = new Point(57, 83);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 3;
            // 
            // txtSalary
            // 
            txtSalary.Location = new Point(56, 112);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(100, 23);
            txtSalary.TabIndex = 4;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "Pilot", "Cabin_Crew" });
            cmbType.Location = new Point(56, 12);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(121, 23);
            cmbType.TabIndex = 5;
            cmbType.Text = "Employee Type";
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(237, 86);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 6;
            label4.Text = "License";
            // 
            // txtRank
            // 
            txtRank.Location = new Point(554, 83);
            txtRank.Name = "txtRank";
            txtRank.Size = new Size(100, 23);
            txtRank.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(211, 115);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 9;
            label5.Text = "Flight Hours";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(515, 86);
            label6.Name = "label6";
            label6.Size = new Size(33, 15);
            label6.TabIndex = 10;
            label6.Text = "Rank";
            // 
            // txtLicense
            // 
            txtLicense.Location = new Point(289, 83);
            txtLicense.Name = "txtLicense";
            txtLicense.Size = new Size(100, 23);
            txtLicense.TabIndex = 11;
            // 
            // txtFlightHours
            // 
            txtFlightHours.Location = new Point(289, 112);
            txtFlightHours.Name = "txtFlightHours";
            txtFlightHours.Size = new Size(100, 23);
            txtFlightHours.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(71, 65);
            label7.Name = "label7";
            label7.Size = new Size(59, 15);
            label7.TabIndex = 12;
            label7.Text = "Employee";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(323, 65);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 13;
            label8.Text = "Pilot";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(570, 65);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 14;
            label9.Text = "Cabin Crew";
            // 
            // btnBonus
            // 
            btnBonus.Location = new Point(700, 107);
            btnBonus.Name = "btnBonus";
            btnBonus.Size = new Size(75, 23);
            btnBonus.TabIndex = 16;
            btnBonus.Text = "Bonus";
            btnBonus.UseVisualStyleBackColor = true;
            btnBonus.Click += btnBonus_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(700, 78);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // gridEmployees
            // 
            gridEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridEmployees.BackgroundColor = SystemColors.ControlLightLight;
            gridEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridEmployees.Location = new Point(13, 156);
            gridEmployees.Name = "gridEmployees";
            gridEmployees.Size = new Size(698, 258);
            gridEmployees.TabIndex = 18;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gridEmployees);
            Controls.Add(btnSave);
            Controls.Add(btnBonus);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(txtFlightHours);
            Controls.Add(txtLicense);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtRank);
            Controls.Add(label4);
            Controls.Add(cmbType);
            Controls.Add(txtSalary);
            Controls.Add(txtName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            ((System.ComponentModel.ISupportInitialize)gridEmployees).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private TextBox txtSalary;
        private ComboBox cmbType;
        private Label label4;
        private TextBox textBox3;
        private TextBox txtRank;
        private Label label5;
        private Label label6;
        private TextBox txtLicense;
        private TextBox txtFlightHours;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnBonus;
        private Button btnSave;
        private DataGridView gridEmployees;
        private GroupBox groupBox1;
    }
}