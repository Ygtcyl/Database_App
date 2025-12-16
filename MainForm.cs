using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Database_App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Airline Management System - Main Menu";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}