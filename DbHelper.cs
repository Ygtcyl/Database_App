using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Database_App
{
    public class DbHelper
    {
        private string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=AirlineDB";
        public DataTable GetTable(string query)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
            return dt;
        }
        public void ExecuteQuery(string query)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Operation Error: " + ex.Message);
                }
            }
        }
    }
}