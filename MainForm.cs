using System;
using System.Windows.Forms;

namespace Database_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Havayolu Yönetim Sistemi - Ana Menü";
            this.StartPosition = FormStartPosition.CenterScreen; 
        }

        
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm empForm = new EmployeeForm();
            
            empForm.ShowDialog();
        }

        
        private void btnPassenger_Click(object sender, EventArgs e)
        {
            
            PassengerForm passForm = new PassengerForm();
           

            passForm.ShowDialog();
        }

        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}