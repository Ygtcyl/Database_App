using System.Data;

namespace Database_App
{
    public partial class 
        PassengerForm : Form
    {
        DbHelper db = new DbHelper(); // Veritabaný yardýmcýmýzý çaðýrdýk

        public PassengerForm()
        {
            InitializeComponent();
        }

        // Form açýlýnca verileri yükle
        private void Form1_Load(object sender, EventArgs e)
        {
            ListPassengers();
        }

        // LÝSTELEME METODU (SELECT)
        void ListPassengers()
        {
            string sql = "SELECT * FROM Passenger";
            DataTable dt = db.GetTable(sql);
            dataGridView1.DataSource = dt;
        }

        // EKLEME BUTONU (INSERT)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Basit doðrulama
            if (txtPassport.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Lütfen Pasaport ve Ýsim alanlarýný doldurun.");
                return;
            }

            // SQL Sorgusu (Tek týrnaklara dikkat et!)
            // Not: Trigger sayesinde ismi küçük harfle girsen bile veritabaný büyütecek.
            string sql = $"INSERT INTO Passenger (Passport_Number, Full_Name, Contact_Info) " +
                         $"VALUES ('{txtPassport.Text}', '{txtName.Text}', '{txtContact.Text}')";

            try
            {
                db.ExecuteQuery(sql);
                MessageBox.Show("Yolcu baþarýyla eklendi!");
                ListPassengers(); // Listeyi yenile ki yeni kaydý görelim
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // SÝLME BUTONU (DELETE)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var cell = dataGridView1.SelectedRows[0].Cells["Passport_Number"];
                if (cell?.Value is string passport && !string.IsNullOrEmpty(passport))
                {
                    string sql = $"DELETE FROM Passenger WHERE Passport_Number = '{passport}'";

                    DialogResult sor = MessageBox.Show("Silmek istediðine emin misin?", "Uyarý", MessageBoxButtons.YesNo);

                    if (sor == DialogResult.Yes)
                    {
                        db.ExecuteQuery(sql);
                        ListPassengers(); // Listeyi yenile
                    }
                }
                else
                {
                    MessageBox.Show("Seçili satýrda geçerli bir pasaport numarasý yok.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silinecek satýrý tablodan seçin.");
            }
        }

        // LÝSTELEME BUTONU
        private void btnList_Click(object sender, EventArgs e)
        {
            ListPassengers();
        }

        // Tablodan bir satýra týklayýnca bilgileri kutulara doldur (Update için hazýrlýk)
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
