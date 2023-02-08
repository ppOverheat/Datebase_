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
        public static string res_path = Application.StartupPath + "../../../resources/";
        static string base_path = Application.StartupPath;
        static string dbName = "DB_employees";
        public static string connectionStr = "";
        static string createStr = "";
        public static string CpyImgToRes(string img_path)
        {
            string path = $"{res_path}img/{Path.GetFileName(img_path)}";
            System.IO.File.Copy(img_path, path, true);
            return path;
        }
        public static bool ConnectStr(string server_name, string user_id, string pwd, bool logged)
        {
            if (server_name.Equals("")) server_name = "localhost";
            bool error = false;
            if (logged)
            {
                connectionStr = $@"Server={server_name};Database=DB_employees;user id={user_id};pwd={pwd}";
                createStr = $@"Server={server_name};Integrated security=SSPI;user id={user_id};pwd={pwd};database=master";
            } else
            {
                connectionStr = $@"Server={server_name};Database=DB_employees;Trusted_Connection=True";
                createStr = $@"Server={server_name};Integrated security=SSPI;database=master";
            }
            try
            {
                if (!HasDatabase()) error = CreateDB();
            }
            catch
            {
                error = true;
            }
            return error;
        }
        public static bool HasDatabase()
        {
            bool has = false;
            SqlConnection connection = new SqlConnection(createStr);
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand($"SELECT * FROM master.dbo.sysdatabases where name = '{dbName}'", connection);
                using (SqlDataReader reader = command_.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        has = true;
                    }
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
            return has;
        }
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
        public static bool EmptyTableContent(string table)
        {
            bool error = false;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                using (DbCommand command_ = new SqlCommand($"DELETE FROM {table}"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                _ = Log.WriteLog("Removed content of " + table + " - " + DateTime.Now.ToString());
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
        public static bool CreateDB()
        {
            bool error = false;
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
    }
}
