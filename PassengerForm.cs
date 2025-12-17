using System.Data;

namespace Database_App
{
    public partial class 
        PassengerForm : Form
    {
        DbHelper db = new DbHelper();

        public PassengerForm()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            ListPassengers();
        }

        
        void ListPassengers()
        {
            string sql = "SELECT * FROM Passenger";
            DataTable dt = db.GetTable(sql);
            dataGridView1.DataSource = dt;
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            if (txtPassport.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Please fill in the name and passport fields.");
                return;
            }

            
            string sql = $"INSERT INTO Passenger (Passport_Number, Full_Name, Contact_Info) " +
                         $"VALUES ('{txtPassport.Text}', '{txtName.Text}', '{txtContact.Text}')";

            try
            {
                db.ExecuteQuery(sql);
                MessageBox.Show("Passanger added successfuly!");
                ListPassengers(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var cell = dataGridView1.SelectedRows[0].Cells["Passport_Number"];
                if (cell?.Value is string passport && !string.IsNullOrEmpty(passport))
                {
                    string sql = $"DELETE FROM Passenger WHERE Passport_Number = '{passport}'";

                    DialogResult sor = MessageBox.Show("Are you sure to delete it?", "Warning", MessageBoxButtons.YesNo);

                    if (sor == DialogResult.Yes)
                    {
                        db.ExecuteQuery(sql);
                        ListPassengers(); 
                    }
                }
                else
                {
                    MessageBox.Show("No suitable passport no in selected area.");
                }
            }
            else
            {
                MessageBox.Show("Please select the area to be deleted.");
            }
        }

        
        private void btnList_Click(object sender, EventArgs e)
        {
            ListPassengers();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassport.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Please fill the passport and name areas.");
                return;
            }
            string sql = $"UPDATE Passenger SET Full_Name = '{txtName.Text}', Contact_Info = '{txtContact.Text}' " +
                         $"WHERE Passport_Number = '{txtPassport.Text}'";
            try
            {
                db.ExecuteQuery(sql);
                MessageBox.Show("Passanger info updated successfuly!");
                ListPassengers(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                txtPassport.Text = row.Cells["Passport_Number"].Value?.ToString() ?? string.Empty;
                txtName.Text = row.Cells["Full_Name"].Value?.ToString() ?? string.Empty;
                txtContact.Text = row.Cells["Contact_Info"].Value?.ToString() ?? string.Empty;
            }
        }
    }
}
