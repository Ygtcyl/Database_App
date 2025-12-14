using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Database_App
{
    public partial class EmployeeForm : Form
    {
        DbHelper db = new DbHelper(); 

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployees();
          
            if (cmbType.Items.Count > 0)
            {
                cmbType.SelectedIndex = 0;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedItem != null && cmbType.SelectedItem.ToString() == "Pilot")
            {
                txtLicense.Enabled = true;
                txtFlightHours.Enabled = true;
                txtRank.Enabled = false;
                txtRank.Clear();
                txtLicense.BackColor = Color.White;
                txtRank.BackColor = Color.LightGray;
            }
            else
            {
                txtLicense.Enabled = false;
                txtFlightHours.Enabled = false;
                txtRank.Enabled = true;
                txtLicense.Clear();
                txtFlightHours.Clear();
                txtLicense.BackColor = Color.LightGray;
                txtRank.BackColor = Color.White;
            }
        }

        void LoadEmployees()
        {
           
            DataTable dt = db.GetTable("SELECT * FROM Employee ORDER BY Employee_ID DESC");
            gridEmployees.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                MessageBox.Show("Lütfen İsim ve Maaş alanlarını doldurun.");
                return;
            }

            string name = txtName.Text;
            decimal salary;

         
            if (!decimal.TryParse(txtSalary.Text, out salary))
            {
                MessageBox.Show("Lütfen maaş kısmına geçerli bir sayı girin.");
                return;
            }

            string type = (cmbType.SelectedItem != null && cmbType.SelectedItem.ToString() == "Pilot") ? "Pilot" : "Cabin_Crew";

            
            string connString = "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=AirlineDB";

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string sqlEmployee = "INSERT INTO Employee (Name, Hire_Date, Base_Salary, Employee_Type) " +
                                             "VALUES (@name, CURRENT_DATE, @salary, @type) RETURNING Employee_ID";

                        int newId;
                        using (NpgsqlCommand cmd = new NpgsqlCommand(sqlEmployee, conn))
                        {
                            cmd.Parameters.AddWithValue("name", name);
                            cmd.Parameters.AddWithValue("salary", salary);
                            cmd.Parameters.AddWithValue("type", type);
                            newId = (int)cmd.ExecuteScalar();
                        }

                       
                        if (type == "Pilot")
                        {
                            
                            if (!int.TryParse(txtFlightHours.Text, out int hours))
                            {
                                hours = 0;
                            }

                            string sqlPilot = "INSERT INTO Pilot (Employee_ID, LicenseType, FlightHours) VALUES (@id, @license, @hours)";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlPilot, conn))
                            {
                                cmd.Parameters.AddWithValue("id", newId);
                                cmd.Parameters.AddWithValue("license", txtLicense.Text);
                                cmd.Parameters.AddWithValue("hours", hours);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string sqlCabin = "INSERT INTO Cabin_Crew (Employee_ID, Rank) VALUES (@id, @rank)";
                            using (NpgsqlCommand cmd = new NpgsqlCommand(sqlCabin, conn))
                            {
                                cmd.Parameters.AddWithValue("id", newId);
                                cmd.Parameters.AddWithValue("rank", txtRank.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Personel başarıyla kaydedildi!");

                       
                        txtName.Clear();
                        txtSalary.Clear();
                        txtLicense.Clear();
                        txtFlightHours.Clear();
                        txtRank.Clear();

                        LoadEmployees(); 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Kaydetme Hatası: " + ex.Message);
                    }
                }
            }
        }

        private void btnBonus_Click(object sender, EventArgs e)
        {
            if (gridEmployees.SelectedRows.Count > 0)
            {
                object? idObj = gridEmployees.SelectedRows[0].Cells["Employee_ID"].Value;
                object? typeObj = gridEmployees.SelectedRows[0].Cells["Employee_Type"].Value;

                if (idObj == null || typeObj == null) return;

                int id = Convert.ToInt32(idObj);
                string type = typeObj.ToString() ?? string.Empty;

                if (type != "Pilot")
                {
                    MessageBox.Show("Bonus hesaplaması sadece Pilotlar içindir!");
                    return;
                }

             
                string sql = $"SELECT calculate_pilot_bonus({id})";
                DataTable dt = db.GetTable(sql);

                if (dt.Rows.Count > 0)
                {
                    string bonus = dt.Rows[0][0] != null ? dt.Rows[0][0]!.ToString()! : "0";
                    MessageBox.Show($"Seçilen pilotun hak ettiği bonus: {bonus} TL");
                }
            }
            else
            {
                MessageBox.Show("Lütfen listeden bir pilot seçin.");
            }
        }
    }
}