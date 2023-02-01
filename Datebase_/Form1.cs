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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Mail;
using System.ComponentModel.Design;
using System.Reflection;

namespace Datebase_
{
    public partial class Form1 : Form
    {
        string dbName = "DB_employees";
        string connectionStr = "Server=localhost;Database=DB_employees;Trusted_Connection = true";
        string createStr = "Server=localhost;Integrated security=SSPI;database=master";
        string img_path = Application.StartupPath + "img/";
        string input_names_path = Application.StartupPath + "input.txt";
        string input_emails_path = Application.StartupPath + "emails.txt";
        string input_org_path = Application.StartupPath + "org_data.txt";
        string image_path = "";
        int selected_org = 0, selected_emp = 0;
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(Application.StartupPath + dbName + ".mdf")) createDB();
            else setDataSource();
        }
        private void setDataSource()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();

                //using (DbCommand command_ = new SqlCommand("DROP TABLE Employee"))
                //{
                //    command_.Connection = connection;
                //    command_.ExecuteNonQuery();
                //}
                //using (DbCommand command_ = new SqlCommand("DROP TABLE Organization"))
                //{
                //    command_.Connection = connection;
                //    command_.ExecuteNonQuery();
                //}
                //using (DbCommand command_ = new SqlCommand("CREATE TABLE Organization (" +
                //   "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                //   "Name VARCHAR(100) UNIQUE NOT NULL," +
                //   "Address VARCHAR(250));"))
                //{
                //    command_.Connection = connection;
                //    command_.ExecuteNonQuery();
                //}
                //using (DbCommand command_ = new SqlCommand("CREATE TABLE Employee (" +
                //    "ID INT UNIQUE NOT NULL IDENTITY(1, 1)," +
                //    "Name VARCHAR(100) NOT NULL," +
                //    "Age INT NOT NULL," +
                //    "ImageURL VARCHAR(250)," +
                //    "Email VARCHAR(100) UNIQUE NOT NULL," +
                //    "OrganizationID INT," +
                //    "FOREIGN KEY (OrganizationID) REFERENCES Organization (ID));"))
                //{
                //    command_.Connection = connection;
                //    command_.ExecuteNonQuery();
                //}
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
        private void btnAddImageClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == DialogResult.OK)
            {
                image_path = op.FileName;
                pictureBox1.Image = System.Drawing.Image.FromFile(op.FileName);
            }
        }
        private void updateOrganizationBox(List<Organization> organizations)
        {
            OrganizationDrop.Items.Clear();
            orgsBox.Items.Clear();
            int i = 0;
            ComboboxItem item = new ComboboxItem();
            item.Text = "-Select-";
            item.Value = i;
            OrganizationDrop.Items.Add(item);
            orgsBox.Items.Add(item);
            foreach (Organization organization in organizations)
            {
                i++;
                item = new ComboboxItem();
                item.Text = organization.Name;
                item.Value = i;
                OrganizationDrop.Items.Add(item);
                orgsBox.Items.Add(item);
            }
            OrganizationDrop.DisplayMember = "Text";
            OrganizationDrop.ValueMember = "Value";
            orgsBox.DisplayMember = "Text";
            orgsBox.ValueMember = "Value";
            orgsBox.SelectedIndex = 0;
        }
        private void updateOrganization()
        {
            List<Organization> organizations = OrganizationData.updateOrganization();
            updateOrgGridView(organizations);
            updateOrganizationBox(organizations);
        }
        private void updateGrid()
        {
            updateOrganization();
            updateDataGridView(EmployeeData.updateEmployees());
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
                List<string> org_data = Common.getList(input_org_path);
                int i = 0, j = 1;
                for (i = 0; i < 20; i += 2)
                {
                    if (OrganizationData.addOrganization_(org_data[i], org_data[j], 0)) break;
                    j += 2;
                }
                List<string> names = Common.getList(input_names_path);
                List<string> emails = Common.getList(input_emails_path);
                int index = 0;
                for (i = 1; i < 3; i++) // i < 11
                {
                    foreach (string name in names)
                    {
                        if (EmployeeData.addEmployee_(name, getRandomValue(18, 45), img_path + getRandomValue(0, 11) + ".jpg", i + emails[index++], i, 0)) break;
                    }
                    index = 0;
                }
                MessageBox.Show("Please wait", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updateGrid();
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
        private void createDB()
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
        private string GetDbCreationQuery()
        {
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
        private void addOrganizationClick(object sender, EventArgs e)
        {
            if (!OrganizationData.addOrganization_(nameOrgTextBox.Text, addressTextBox.Text, selected_org)) 
            {
                updateOrganization();
                clearOrganizationForm(); 
            }
        }
        private void updateEmployeeForm(Employee emp)
        {
            nameTextBox.Text = emp.Name;
            ageTextBox.Text = "" + emp.Age;
            emailTextBox.Text = emp.Email;
            orgsBox.SelectedIndex = emp.OrganizationID;
            pictureBox1.Image = emp.Image;
            image_path = emp.ImageURL;
        }
        private void updateOrgForm(Organization organization)
        {
            nameOrgTextBox.Text = organization.Name;
            addressTextBox.Text = organization.Address;
        }
        private void clearOrganizationForm()
        {
            nameOrgTextBox.Text = "";
            addressTextBox.Text = "";
            selected_org = 0;
        }
        private void clearEmployeeForm()
        {
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            emailTextBox.Text = "";
            orgsBox.SelectedIndex = 0;
            pictureBox1.Image = null;
            image_path = "";
            selected_emp = 0;
        }
        private void updateDataGridView(List<Employee> employees)
        {
            int index = 0;
            dataGridView.Rows.Clear();
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
        }
        private void updateOrgGridView(List<Organization> organizations)
        {
            int index = 0;
            dataGridOrg.Rows.Clear();
            foreach (Organization organization in organizations)
            {
                if (index != organizations.Count - 1) dataGridOrg.Rows.Add(new DataGridViewRow());
                dataGridOrg.Rows[index].Cells[0].Value = organization.ID;
                dataGridOrg.Rows[index].Cells[1].Value = organization.Name;
                dataGridOrg.Rows[index].Cells[2].Value = organization.Address;
                index++;
            }
        }
        private void btnAddEmployeeClick(object sender, EventArgs e)
        {
            try
            {
                int value = Int32.Parse(ageTextBox.Text);
                if (!EmployeeData.addEmployee_(nameTextBox.Text, value, image_path, emailTextBox.Text, orgsBox.SelectedIndex, selected_emp))
                {
                    updateDataGridView(EmployeeData.updateEmployees());
                    clearEmployeeForm(); 
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Field 'Age' is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnRemoveClick(object sender, EventArgs e)
        {
            if (selected_org != 0) { removeItem("Organization", selected_org); clearOrganizationForm(); }
            else if (selected_emp != 0) { removeItem("Employee", selected_emp); clearEmployeeForm(); }
        }
        private void removeItem(string table, int id)
        {
            if (!Common.removeRow(table, id))
            {
                updateGrid();
            }
        }
        private void onCellOrgClick(object sender, DataGridViewCellEventArgs e)
        {
            clearEmployeeForm();
            DataGridView gridView = (DataGridView)sender;
            selected_org = (int)dataGridOrg.Rows[gridView.CurrentRow.Index].Cells[0].Value;
            updateOrgForm(OrganizationData.selectOrganization(selected_org));
        }
        private void btnClearClick(object sender, EventArgs e)
        {
            clearEmployeeForm();
            clearOrganizationForm();
        }
        private void onCellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearOrganizationForm();
            DataGridView gridView = (DataGridView)sender;
            selected_emp = (int)dataGridView.Rows[gridView.CurrentRow.Index].Cells[0].Value;
            updateEmployeeForm(EmployeeData.selectEmployee(selected_emp));
        }
    }
}