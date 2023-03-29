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
    public class DAL_Customer:General
    {
        public DataTable showListCustomer()
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, Address, PhoneNumber, Email from Customer", conn);
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
        public bool createCustomer(Customer customer)
        {
            bool result = false;

            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "insert into Customer(Name, Address, PhoneNumber, Email) values(N'" + customer.Name + "',N'" + customer.Address + "','" + customer.Phone + "','" + customer.Email + "')";
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
        public bool deleteCustomer(int id)
        {
            bool result = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "Delete from Customer where Id='" + id + "' ";
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
        public bool updateECustomer(Customer customer)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update Customer set Address=N'" + customer.Address + "',PhoneNumber='" + customer.Phone + "',Email='" + customer.Email + "' where Id=N'" + customer.Id + "'";
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
        public string getIDbyEmailCustomer(string email)
        {
            DataTable dt = new DataTable();
           
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id from Customer where email='" + email + "'", conn); ;
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt.Rows[0][0].ToString();
            }
            catch
            {
                throw;
            }
            finally
            {
            DataTable dt = new DataTable();
         
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Name from Customer where Id='" + id + "'",
                conn.Close();
            }
        }
        public string getNamebyIdCustomer(string id)
        { conn); ;
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt.Rows[0][0].ToString();
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


        public DataTable searchCustomer(int id)
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, Address, PhoneNumber, Email from Customer where Id=N'" + id + "'", conn);
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
    }
}
