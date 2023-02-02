using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datebase_
{
    internal class Common
    {
        public static string connectionStr = "Server=localhost;Database=DB_employees;Trusted_Connection = true";
        public static bool removeRow(string table, int id)
        {
            bool error = false;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();

                using (DbCommand command_ = new SqlCommand("DELETE FROM " + table + " WHERE ID = " + id + ";"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                MessageBox.Show("Data has removed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                error = true;
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return error;
        }
        public static List<String> getList(string path)
        {
            List<string> names = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    names.Add(currentLine);
                    currentLine = reader.ReadLine();
                }
            }
            return names;
        }
        public static int getRandomValue(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }
}
