using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace Datebase_
{
     internal class EmployeeData : Common
    {
        public static bool AddEmployee_(string name, int age, string img_url, string email, int org_id, int selected_id)
        {
            bool error = false;
            if (selected_id == 0) error = AddEmployee(name, age, img_url, email, org_id);
            else error = ChangeEmployee(name, age, img_url, email, org_id, selected_id);
            return error;
        }
        private static bool AddEmployee(string name, int age, string img_url, string email, int org_id)
        {
            bool error = CheckData(name, age, img_url, email, org_id, false);
            if (error) return error;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                //string img_path = CpyImgToRes(img_url);
                using (DbCommand command_ = new SqlCommand("INSERT INTO Employee (Name, Age, ImageUrl, Email, OrganizationID) VALUES " +
                    "('" + name + "'," + age + ",'" + img_url + "','" + email + "'," + org_id + ");"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                _ = Log.WriteLog("Added Item (Name = " + name + ") into Employee - " + DateTime.Now.ToString());
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
        private static bool ChangeEmployee(string name, int age, string img_url, string email, int org_id, int selected_emp)
        {
            bool error = CheckData(name, age, img_url, email, org_id, true);
            if (error) return error;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
               // string img_path = CpyImgToRes(img_url);
                using (DbCommand command_ = new SqlCommand("UPDATE Employee SET Name = '" + name + "', Age = " + age + "," +
                    " ImageURL = '" + img_url + "', Email = '" + email + "', OrganizationID = " + org_id + " WHERE ID = " + selected_emp + ";"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                _ = Log.WriteLog("Updated Item (ID = " + selected_emp + ") from Employee - " + DateTime.Now.ToString());
                MessageBox.Show("Data changed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public static Employee SelectEmployee(int index)
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            Employee emp = null;
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand("SELECT * from Employee where ID=" + index + ";", connection);
                using (SqlDataReader reader = command_.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Image image = null;
                        try
                        {
                            image = System.Drawing.Image.FromFile(reader.GetString(3));
                        }
                        catch
                        { }
                        emp = new Employee()
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            Image = image,
                            ImageURL = reader.GetString(3),
                            Email = reader.GetString(4),
                            OrganizationID = reader.GetInt32(5)
                        };
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
            return emp;
        }
        public static List<Employee> UpdateEmployees()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            List<Employee> employees = new List<Employee>();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Image image = null;
                        try
                        {
                            image = System.Drawing.Image.FromFile(reader.GetString(3));
                        }
                        catch
                        { }
                        Employee employee = new Employee
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            ImageURL = reader.GetString(3),
                            Image = image,
                            Email = reader.GetString(4),
                            OrganizationID = reader.GetInt32(5)
                        };
                        employees.Add(employee);
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
            return employees;
        }
        private static List<Employee> GetEmployeesByOrg(string search)
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection connection = new SqlConnection(connectionStr);
            List<int> ids = OrganizationData.GetIdBySearchString(search);
            try
            {
                connection.Open();
                foreach (int id in ids)
                {
                    SqlCommand command_ = new SqlCommand("SELECT * FROM Employee WHERE OrganizationID="+id+";", connection);
                    using (SqlDataReader reader = command_.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Image image = null;
                            try
                            {
                                image = System.Drawing.Image.FromFile(reader.GetString(3));
                            }
                            catch
                            { }
                            Employee employee = new Employee()
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Age = reader.GetInt32(2),
                                Image = image,
                                ImageURL = reader.GetString(3),
                                Email = reader.GetString(4),
                                OrganizationID = reader.GetInt32(5)
                            };
                            employees.Add(employee);
                        }
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
            return employees;
        }
        public static List<Employee> SelectByOrg(int id)
        {
            List<Employee> employees = new List<Employee>();
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand("SELECT * FROM Employee WHERE OrganizationID="+ id +";", connection);
                using (SqlDataReader reader = command_.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Image image = null;
                        try
                        {
                            image = System.Drawing.Image.FromFile(reader.GetString(3));
                        }
                        catch
                        { }
                        Employee employee = new Employee()
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            Image = image,
                            ImageURL = reader.GetString(3),
                            Email = reader.GetString(4),
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
            return employees;
        }
        public static List<Employee> SearchEmployee(string property, string search)
        {
            List<Employee> employees = new List<Employee>();
            string query = "SELECT * FROM Employee WHERE " + property + " LIKE '%" + search + "%';";
            if (property.Equals("Organization"))
            {
                return GetEmployeesByOrg(search);
            }
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand("SELECT * FROM Employee WHERE " + property + " LIKE '%" + search + "%';", connection);
                using (SqlDataReader reader = command_.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Image image = null;
                        try
                        {
                            image = System.Drawing.Image.FromFile(reader.GetString(3));
                        }
                        catch
                        { }
                        Employee employee = new Employee()
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Age = reader.GetInt32(2),
                            Image = image,
                            ImageURL = reader.GetString(3),
                            Email = reader.GetString(4),
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
            return employees;
        }
        private static bool CheckData(string name, int age, string img_url, string email, int org_id, bool change)
        {
            bool error = true;
            if (name == "")
            {
                MessageBox.Show("Employee's Name is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (org_id == 0)
            {
                MessageBox.Show("Select the Organization.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!IsValidEmail(email))
            {
                MessageBox.Show("Employee's Email is not valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!change && HasMail(email))
            {
                MessageBox.Show("Employee's Email must be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (age > 99 || age < 18)
            {
                MessageBox.Show("Invalid value of field 'Age'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                error = false;
            }
            return error;
        }
        private static bool HasMail(string mail)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand("SELECT (Email) from Employee where Email='" + mail + "';", connection);
                using (SqlDataReader reader = command_.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = true;
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
            return result;
        }
        private static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
