namespace Database_App
{
    partial class PassengerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtPassport = new TextBox();
            txtName = new TextBox();
            txtContact = new TextBox();
            btnList = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(397, 254);
            dataGridView1.TabIndex = 0;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(443, 21);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 1;
            label1.Text = "Passport No";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(425, 50);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 2;
            label2.Text = "Name Surname";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(441, 74);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 3;
            label3.Text = "Contact İnfo";
            // 
            // txtPassport
            // 
            txtPassport.Location = new Point(520, 13);
            txtPassport.Name = "txtPassport";
            txtPassport.Size = new Size(100, 23);
            txtPassport.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(520, 42);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 5;
            // 
            // txtContact
            // 
            txtContact.Location = new Point(520, 71);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(100, 23);
            txtContact.TabIndex = 6;
            // 
            // btnList
            // 
            btnList.Location = new Point(655, 243);
            btnList.Name = "btnList";
            btnList.Size = new Size(75, 23);
            btnList.TabIndex = 7;
            btnList.Text = "List";
            btnList.UseVisualStyleBackColor = true;
            btnList.Click += btnList_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(545, 243);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(439, 243);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 457);
            Controls.Add(btnAdd);
            Controls.Add(btnDelete);
            Controls.Add(btnList);
            Controls.Add(txtContact);
            Controls.Add(txtName);
            Controls.Add(txtPassport);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPassport;
        private TextBox txtName;
        private TextBox txtContact;
        private Button btnList;
        private Button btnDelete;
        private Button btnAdd;
    }
}
