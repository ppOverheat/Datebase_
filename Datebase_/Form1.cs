using System.Data;
using System;
using System.Data.SqlClient;
using System.Xml.Linq;
using System.Data.Common;
using Microsoft.VisualBasic;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Diagnostics;
//using System.Windows.Controls;
namespace Datebase_
{
    public partial class Form1 : Form
    {
        string dbName = "Db3";
        string connectionStr = "Server=localhost;Integrated security=SSPI;database=master";
        string img_path = Application.StartupPath + "img/";
        string input_path = Application.StartupPath + "input.txt";
        string emails_path = Application.StartupPath + "emails.txt";

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
        private void updateOrganizationBox(List<Organization> organizations)
        {
            int i = 1;
            //OrganizationDrop.DataSource = 
            foreach (Organization organization in organizations)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = organization.Name;
                item.Value = i;
                OrganizationDrop.Items.Add(item);
                //OrganizationDrop.
                i++;
            }
            OrganizationDrop.DisplayMember = "Text";
            OrganizationDrop.ValueMember = "Value";
        }
        void updateGrid()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            List<Organization> organizations = new List<Organization>();
            List<Employee> employees = new List<Employee>();
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand("SELECT * FROM Organization", connection);
                using (SqlDataReader reader = command_.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Organization organization = new Organization
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2)
                        };
                        organizations.Add(organization);
                    }
                }
                updateOrganizationBox(organizations);
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
                            Image = System.Drawing.Image.FromFile(reader.GetString(3)),
                            Email = reader.GetString(4),
                            Organization = organizations[reader.GetInt32(5) - 1].Name,
                            OrganizationID = reader.GetInt32(5)
                        };
                        employees.Add(employee);
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
            int index = 0;
            foreach (Employee employee in employees)
            {
                if (index != employees.Count - 1) dataGridView.Rows.Add(new DataGridViewRow());
                dataGridView.Rows[index].Cells[0].Value = employee.ID;
                dataGridView.Rows[index].Cells[1].Value = employee.Name;
                dataGridView.Rows[index].Cells[2].Value = employee.Age;
                dataGridView.Rows[index].Cells[3].Value = employee.Email;
                dataGridView.Rows[index].Cells[4].Value = employee.OrganizationID;
                dataGridView.Rows[index].Cells[5].Value = employee.Image;
                index++;
            }
            index = 0;
            foreach (Organization organization in organizations)
            {
                if (index != organizations.Count - 1) dataGridOrg.Rows.Add(new DataGridViewRow());
                dataGridOrg.Rows[index].Cells[0].Value = organization.ID;
                dataGridOrg.Rows[index].Cells[1].Value = organization.Name;
                dataGridOrg.Rows[index].Cells[2].Value = organization.Address;
                index++;
            }
        }

        private List<String> getEmails()
        {
            List<string> emails = new List<string>();
            using (StreamReader reader = new StreamReader(emails_path))
            {
                reader.ReadLine();
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    emails.Add(currentLine);
                    currentLine = reader.ReadLine();
                }
            }
            return emails;
        }

        private List<String> getEmployeesNames()
        {
            List<string> names = new List<string>();
            using (StreamReader reader = new StreamReader(input_path))
            {
                reader.ReadLine();
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    names.Add(currentLine);
                    currentLine = reader.ReadLine();
                }
            }
            return names;
        }
        private int getRandomValue(int min, int max)
        {
            return new Random().Next(min, max);
        }
        private void btnFillDb(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionStr);

            try
            {
                connection.Open();

                using (DbCommand command_ = new SqlCommand("INSERT INTO Organization (Name, Address) " +
                    "VALUES ('Blizzard Entertainment', '49 Sussex Dr. Herndon, VA 20170'), ('Ubisoft', '918 Maple St. Lawrence Township, NJ 08648'), " +
                    "('Riot Games', '8888 3rd St. Everett, MA 02149'), ('Bethesda Softworks', '6 Shady Lane Clinton, MD 20735'), " +
                    "('Nintendo', '9 County St. Lafayette, IN 47905'), ('Electronic Arts, Inc', '805 Vale Street Franklin, MA 02038')," +
                    "('Xbox Game Studios', '96 Brickell Ave. Lapeer, MI 48446'), ('Warner Bros. Entertainment Inc', '436 Henry Dr. Mundelein, IL 60060')," +
                    " ('RockStar Games', '67 Devon Drive Madison, AL 35758'), ('Valve Corporation', '218 Adams Ave. Auburn, NY 13021');"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                List<string> names = getEmployeesNames();
                List<string> emails = getEmails();
                int index = 0;
                for (int i = 1; i < 3; i++)
                {
                    foreach (string name in names)
                    {
                        char c = (char)i;
                        using (DbCommand command_ = new SqlCommand("INSERT INTO Employee (Name, Age, ImageUrl, Email, OrganizationID) " +
                        "VALUES ('"+ name +"'," + getRandomValue(18, 45) + ",'" + img_path + getRandomValue(0, 11) + ".jpg', '" + c + emails[index++] + "', " + i + ");"))
                        {
                            command_.Connection = connection;
                            command_.ExecuteNonQuery();
                        }
                    }
                    index = 0;
                }
                MessageBox.Show("Successfully Inserted Data", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void AddOrganizationClick(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionStr);

            try
            {
                connection.Open();

                using (DbCommand command_ = new SqlCommand("INSERT INTO Organization (Name) VALUES ('"+""+"');"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                //MessageBox.Show("Successfully Inserted Data", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}