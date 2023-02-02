using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Datebase_
{
    internal class Common
    {
        static string base_path = Application.StartupPath;
        static string dbName = "DB_employees";
        public static string connectionStr = "Server=localhost;Database=DB_employees;Trusted_Connection = true";
        static string createStr = "Server=localhost;Integrated security=SSPI;database=master";
        public static bool RemoveRow(string table, int id)
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
                MessageBox.Show("Data removed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = Log.WriteLog("Removed Item (ID = "+id+") from " + table + " - " + DateTime.Now.ToString());
            }
            catch (System.Exception ex)
            {
                error = true;
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = Log.WriteLog("Error: " + ex.ToString() + " - " + DateTime.Now.ToString());
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
        public static List<String> GetList(string path)
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
        public static int GetRandomValue(int min, int max)
        {
            return new Random().Next(min, max);
        }
        private static string GetDbCreationQuery()
        {
            string[] files = { Path.Combine(base_path, dbName + ".mdf"),
                       Path.Combine(base_path, dbName + ".ldf") };
            string query = "CREATE DATABASE " + dbName +
                " ON PRIMARY" +
                " (NAME = " + dbName + "_data," +
                " FILENAME = '" + files[0] + "'," +
                " SIZE = 3MB," +
                " MAXSIZE = 10MB," +
                " FILEGROWTH = 10%)" +
                " LOG ON" +
                " (NAME = " + dbName + "_log," +
                " FILENAME = '" + files[1] + "'," +
                " SIZE = 1MB," +
                " MAXSIZE = 5MB," +
                " FILEGROWTH = 10%)" +
                ";";
            return query;
        }
        private static void CreateTables()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                using (DbCommand command_ = new SqlCommand("CREATE TABLE Organization (" +
                    "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                    "Name VARCHAR(100) UNIQUE NOT NULL," +
                    "Address VARCHAR(250));"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                using (DbCommand command_ = new SqlCommand("CREATE TABLE Employee (" +
                    "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                    "Name VARCHAR(100) NOT NULL," +
                    "Age INT NOT NULL," +
                    "ImageURL VARCHAR(250)," +
                    "Email VARCHAR(100) UNIQUE NOT NULL," +
                    "OrganizationID INT," +
                    "FOREIGN KEY (OrganizationID) REFERENCES Organization (ID));"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = Log.WriteLog("Error: " + ex.ToString() + " - " + DateTime.Now.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public static void CreateDB()
        {
            SqlConnection connection = new SqlConnection(createStr);
            String str = GetDbCreationQuery();
            SqlCommand myCommand = new SqlCommand(str, connection);
            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();
                using (DbCommand command_ = new SqlCommand("CREATE TABLE Organization (" +
                    "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                    "Name VARCHAR(100) UNIQUE NOT NULL," +
                    "Address VARCHAR(250));"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                using (DbCommand command_ = new SqlCommand("CREATE TABLE Employee (" +
                    "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                    "Name VARCHAR(100) NOT NULL," +
                    "Age INT NOT NULL," +
                    "ImageURL VARCHAR(250)," +
                    "Email VARCHAR(100) UNIQUE NOT NULL," +
                    "OrganizationID INT," +
                    "FOREIGN KEY (OrganizationID) REFERENCES Organization (ID));"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                MessageBox.Show("Database is Created Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = Log.WriteLog("Database " + dbName + " created - " + DateTime.Now.ToString());
                CreateTables();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = Log.WriteLog("Error: " + ex.ToString() + " - " + DateTime.Now.ToString());
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
