using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BEL;
namespace DAL
{
    public class DAL_Employee : General
    {
        public DataTable showListEmployee()
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, Address, Username, Password, PhoneNumber, Email from Employee", conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public bool addEmployee(Employee employee)
        {
            bool result = false;

            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "insert into Employee(Name, Address, Username, Password, PhoneNumber, Email) values(N'" + employee.Name + "',N'" + employee.Address + "',N'" + employee.Username + "','" + employee.Password + "','" + employee.Phonenumber + "','" + employee.Email + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public bool deleteEmployee(string name)
        {
            bool result = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "Delete from Employee where Name='" + name + "' ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public bool updateEmployee(Employee employee)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update Employee set Address=N'" + employee.Address + "',Username=N'" + employee.Username + "',Password='" + employee.Password + "',PhoneNumber='" + employee.Phonenumber + "',Email='" + employee.Email + "' where Name=N'" + employee.Name + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                if (cmd.ExecuteNonQuery() > 0)
                    result = true;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public DataTable searchEmployee(string name)
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, Address, Username, Password, PhoneNumber, Email from Employee where Name=N'" + name + "'", conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool issetEmployeeName(string employeeName)
        {
            bool resulf = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();

            }
            SqlCommand cmd = new SqlCommand("select Name from Employee where Name like '" + employeeName + "'", conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                if (dt.Rows.Count > 0)
                    resulf = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resulf;
        }

        public bool checkUsername(string username)
        {
            bool resulf = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();

            }
            SqlCommand cmd = new SqlCommand("select Name from Employee where Username = '" +username + "'", conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                if (dt.Rows.Count > 0)
                    resulf = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resulf;
        }

        public bool checkPassword(string password)
        {
            bool resulf = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("select Name from Employee where Password = '" + password + "'", conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                if (dt.Rows.Count > 0)
                    resulf = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resulf;
        }

        public bool checkEmail(string email)
        {
            bool resulf = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();

            }
            SqlCommand cmd = new SqlCommand("select Name from Employee where Email = '" + email + "'", conn);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                if (dt.Rows.Count > 0)
                    resulf = true;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resulf;
        }
       
     

    }
}