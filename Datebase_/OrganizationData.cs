using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Net;

namespace Datebase_
{
    internal class OrganizationData : Common
    {
        public static bool addOrganization_(string name, string address, int selected_id)
        {
            bool error = false;
            if (selected_id == 0) error = addOrganization(name, address);
            else error = changeOrganization(name, address, selected_id);
            return error;
        }
        private static bool addOrganization(string name, string address)
        {
            bool error = checkDataOrg(name, false);
            if (error) return error;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();

                using (DbCommand command_ = new SqlCommand("INSERT INTO Organization (Name, Address) VALUES ('" + name + "','" + address + "');"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
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
        private static bool changeOrganization(string name, string address, int selected_org)
        {
            bool error = checkDataOrg(name, true);
            if (error) return error;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();

                using (DbCommand command_ = new SqlCommand("UPDATE Organization SET Name = '" + name + "', Address = '" + address + "' WHERE ID = " + selected_org + ";"))
                {
                    command_.Connection = connection;
                    command_.ExecuteNonQuery();
                }
                MessageBox.Show("Data has changed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private static bool checkDataOrg(string name, bool change)
        {
            bool error = true;
            if (name == "")
            {
                MessageBox.Show("Organization Name field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (!change && hasOrg(name))
            {
                MessageBox.Show("Organization Name must be unique.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                error = false;
            }
            return error;
        }
        private static bool hasOrg(string name)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand("SELECT (Name) from Organization where Name='" + name + "';", connection);
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
        public static Organization selectOrganization(int index)
        {
            Organization organization = null;
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand("SELECT * from Organization where ID=" + index + ";", connection);
                using (SqlDataReader reader = command_.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        organization = new Organization
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Address = reader.GetString(2)
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
            return organization;
        }
        public static List<Organization> updateOrganization()
        {
            SqlConnection connection = new SqlConnection(connectionStr);
            List<Organization> organizations = new List<Organization>();
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
            return organizations;
        }
        public static List<Organization> searchOrganization(string property, string search)
        {
            List<Organization> organizations = new List<Organization>();
            SqlConnection connection = new SqlConnection(connectionStr);
            try
            {
                connection.Open();
                SqlCommand command_ = new SqlCommand("SELECT * FROM Organization WHERE " + property + " LIKE '" + search + "%';", connection);
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
            return organizations;
        }
    }
}
