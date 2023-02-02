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
using System.Reflection.PortableExecutable;

namespace Datebase_
{
    public partial class Form1 : Form
    {
        string base_path = Application.StartupPath;
        string dbName = "DB_employees";
        string connectionStr = "Server=localhost;Database=DB_employees;Trusted_Connection = true";
        string img_path = Application.StartupPath + "../../../resources/img/";
        string input_names_path = Application.StartupPath + "../../../resources/input.txt";
        string input_emails_path = Application.StartupPath + "../../../resources/emails.txt";
        string input_org_path = Application.StartupPath + "../../../resources/org_data.txt";
        string image_path = "";
        int selected_org = 0, selected_emp = 0;
        List<string> emp_fields = new List<string>() { "ID", "Name", "Age", "Email", "Organization"};
        List<string> org_fields = new List<string>() { "ID", "Name", "Address" };
        public Form1()
        {
            InitializeComponent();
            if (!File.Exists(base_path + dbName + ".mdf")) Common.CreateDB();
            else SetDataSource();
            empComboBoxSearch.SelectedIndex = 0;
            orgComboBoxSearch.SelectedIndex = 0;
        }
        private void SetDataSource()
        {
            UpdateGrid();
        }
        private void BtnAddImageClick(object sender, EventArgs e)
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
        private void UpdateOrganizationBox(List<Organization> organizations)
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
        private void UpdateOrganization()
        {
            List<Organization> organizations = OrganizationData.UpdateOrganization();
            UpdateOrgGridView(organizations);
            UpdateOrganizationBox(organizations);
        }
        private void UpdateGrid()
        {
            UpdateOrganization();
            UpdateDataGridView(EmployeeData.UpdateEmployees());
        }
        private void BtnFillDb(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                List<string> org_data = Common.GetList(input_org_path);
                int i = 0, j = 1;
                for (i = 0; i < 20; i += 2)
                {
                    if (OrganizationData.AddOrganization_(org_data[i], org_data[j], 0)) break;
                    j += 2;
                }
                List<string> names = Common.GetList(input_names_path);
                List<string> emails = Common.GetList(input_emails_path);
                int index = 0;
                for (i = 1; i < 11; i++)
                {
                    foreach (string name in names)
                    {
                        if (EmployeeData.AddEmployee_(name, Common.GetRandomValue(18, 45), img_path + Common.GetRandomValue(0, 11) + ".jpg", i + emails[index++], i, 0)) break;
                    }
                    index = 0;
                }
                MessageBox.Show("Please wait", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
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
        private void AddOrganizationClick(object sender, EventArgs e)
        {
            if (!OrganizationData.AddOrganization_(nameOrgTextBox.Text, addressTextBox.Text, selected_org)) 
            {
                UpdateOrganization();
                ClearOrganizationForm(); 
            }
        }
        private void UpdateEmployeeForm(Employee emp)
        {
            nameTextBox.Text = emp.Name;
            ageTextBox.Text = "" + emp.Age;
            emailTextBox.Text = emp.Email;
            orgsBox.SelectedIndex = emp.OrganizationID;
            pictureBox1.Image = emp.Image;
            image_path = emp.ImageURL;
        }
        private void UpdateOrgForm(Organization organization)
        {
            nameOrgTextBox.Text = organization.Name;
            addressTextBox.Text = organization.Address;
        }
        private void ClearOrganizationForm()
        {
            nameOrgTextBox.Text = "";
            addressTextBox.Text = "";
            selected_org = 0;
        }
        private void ClearEmployeeForm()
        {
            nameTextBox.Text = "";
            ageTextBox.Text = "";
            emailTextBox.Text = "";
            orgsBox.SelectedIndex = 0;
            pictureBox1.Image = null;
            image_path = "";
            selected_emp = 0;
        }
        private void UpdateDataGridView(List<Employee> employees)
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
        private void UpdateOrgGridView(List<Organization> organizations)
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
        private void BtnAddEmployeeClick(object sender, EventArgs e)
        {
            try
            {
                int value = Int32.Parse(ageTextBox.Text);
                if (!EmployeeData.AddEmployee_(nameTextBox.Text, value, image_path, emailTextBox.Text, orgsBox.SelectedIndex, selected_emp))
                {
                    UpdateDataGridView(EmployeeData.UpdateEmployees());
                    ClearEmployeeForm(); 
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Field 'Age' is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnRemoveClick(object sender, EventArgs e)
        {
            if (selected_org != 0) { RemoveItem("Organization", selected_org); ClearOrganizationForm(); }
            else if (selected_emp != 0) { RemoveItem("Employee", selected_emp); ClearEmployeeForm(); }
        }
        private void RemoveItem(string table, int id)
        {
            if (!Common.RemoveRow(table, id))
            {
                UpdateGrid();
            }
        }
        private void OnCellOrgClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearEmployeeForm();
            DataGridView gridView = (DataGridView)sender;
            selected_org = (int)dataGridOrg.Rows[gridView.CurrentRow.Index].Cells[0].Value;
            UpdateOrgForm(OrganizationData.SelectOrganization(selected_org));
        }
        private void BtnClearClick(object sender, EventArgs e)
        {
            ClearEmployeeForm();
            ClearOrganizationForm();
        }
        private void EmpSearchClick(object sender, EventArgs e)
        {
            if (empComboBoxSearch.SelectedIndex != 0)
            {
                UpdateDataGridView(EmployeeData.SearchEmployee(emp_fields[empComboBoxSearch.SelectedIndex - 1], empSearchBox.Text));
            } else
            {
                MessageBox.Show("Select the field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OrgSearchClick(object sender, EventArgs e)
        {
            if (orgComboBoxSearch.SelectedIndex != 0)
            {
                UpdateOrgGridView(OrganizationData.SearchOrganization(org_fields[orgComboBoxSearch.SelectedIndex - 1], orgSearchBox.Text));
            }
            else
            {
                MessageBox.Show("Select the field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearOrganizationForm();
            DataGridView gridView = (DataGridView)sender;
            selected_emp = (int)dataGridView.Rows[gridView.CurrentRow.Index].Cells[0].Value;
            UpdateEmployeeForm(EmployeeData.SelectEmployee(selected_emp));
        }
    }
}