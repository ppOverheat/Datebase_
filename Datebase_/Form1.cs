using System.Data;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Data.Common;
using Microsoft.VisualBasic;
using System.Windows.Input;
using System.Windows.Forms;

namespace Datebase_
{
    public partial class Form1 : Form
    {
        string dbName = "Db3";
        string connectionStr = "Server=localhost;Integrated security=SSPI;database=master";
        BindingSource bindingSource = new BindingSource();
        BindingSource bindingSource_1 = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(Application.StartupPath + dbName + ".mdf")) createBd();
            else setDataSource();
        }
        private void setDataSource()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();

                using (DbCommand command_ = new SqlCommand("DROP TABLE Employee"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                using (DbCommand command_ = new SqlCommand("DROP TABLE Organization"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }


                using (DbCommand command_ = new SqlCommand("CREATE TABLE Organization (" +
                   "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                   "Name VARCHAR(100) UNIQUE NOT NULL);"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }

                using (DbCommand command_ = new SqlCommand("CREATE TABLE Employee (" +
                    "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                    "Name VARCHAR(100) NOT NULL," +
                    "Age INT NOT NULL," +
                    "ImageURL VARCHAR(250)," +
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
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            updateGrid();
        }
        private void btnAddClick(object sender, EventArgs e)
        {
            
        }

        private void nameTextBoxOnChange(object sender, EventArgs e)
        {

        }

        private void btnAddImageClick(object sender, EventArgs e)
        {

        }
        void updateGrid()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            List<Organization> organizations = new List<Organization>();
            List<Employee> employees = new List<Employee>();
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            ImageURL = reader.GetString(3),
                            OrganizationID = reader.GetInt32(4)
                        };
                        employees.Add(employee);
                    }
                }
                SqlCommand command_ = new SqlCommand("SELECT * FROM Organization", connection);
                using (SqlDataReader reader = command_.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Organization organization = new Organization
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                        organizations.Add(organization);
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            bindingSource.DataSource = employees;
            bindingSource_1.DataSource = organizations;
            dataGridView.DataSource = bindingSource;
            dataGridOrg.DataSource = bindingSource_1;

        }

        private void btnFillDb(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionStr);

            try
            {
                connection.Open();

                using (DbCommand command_ = new SqlCommand("INSERT INTO Organization (Name, )" +
                    "VALUES ('Сбер');"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }

                using (DbCommand command_ = new SqlCommand("INSERT INTO Employee (Name, Age, OrganizationID)" +
                    "VALUES ('Сергей Беляков', 30, (SELECT ID from Organization WHERE Name='Сбер' ) );"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }

                //using (DbCommand command = new SqlCommand("ALTER TABLE Employee ADD ID int default 0 NOT NULL, add Name varchar(100), add Age int, add ImageURL varchar(250);"))
                //{
                //    command.Connection = connection;
                //    command.ExecuteNonQuery();
                //}
                MessageBox.Show("Inserted Data Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            updateGrid();
        }

        private void createBd()
        {
            SqlConnection connection = new SqlConnection(connectionStr);

            String str = GetDbCreationQuery();

            SqlCommand myCommand = new SqlCommand(str, connection);
            try
            {
                connection.Open();
                myCommand.ExecuteNonQuery();

                using (DbCommand command_ = new SqlCommand("CREATE TABLE Organization (" +
                   "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                   "Name VARCHAR(100) UNIQUE NOT NULL);"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }

                using (DbCommand command_ = new SqlCommand("CREATE TABLE Employee (" +
                    "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                    "Name VARCHAR(100) NOT NULL," +
                    "Age INT NOT NULL," +
                    "ImageURL VARCHAR(250)," +
                    "OrganizationID INT," +
                    "FOREIGN KEY (OrganizationID) REFERENCES Organization (ID));"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }

                //using (DbCommand command = new SqlCommand("ALTER TABLE Employee ADD ID int default 0 NOT NULL, add Name varchar(100), add Age int, add ImageURL varchar(250);"))
                //{
                //    command.Connection = connection;
                //    command.ExecuteNonQuery();
                //}
                MessageBox.Show("Database is Created Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnCreateDB_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Application.StartupPath + "Db.mdf")) createBd();
            else MessageBox.Show("Database is created already", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        static string GetDbCreationQuery()
        {
            string dbName = "Db3";

            string[] files = { Path.Combine(Application.StartupPath, dbName + ".mdf"),
                       Path.Combine(Application.StartupPath, dbName + ".ldf") };

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
    }

}