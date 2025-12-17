using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Database_App
{
    public partial class SearchForm : Form
    {
        DbHelper db = new DbHelper();

        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string iataCode = txtIata.Text.Trim();

            if (string.IsNullOrEmpty(iataCode))
            {
                MessageBox.Show("Enter an IATA Code (Exp: IST, JFK).");
                return;
            }
            string sql = $"SELECT * FROM search_routes_by_airport('{iataCode}')";

            try
            {
                DataTable dt = db.GetTable(sql);

                if (dt.Rows.Count > 0)
                {
                    gridRoutes.DataSource = dt;
                }
                else
                {
                    gridRoutes.DataSource = null;
                    MessageBox.Show("No Route Found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search Error: " + ex.Message);
            }
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
