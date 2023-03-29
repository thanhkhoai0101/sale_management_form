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
    public class DAL_Supplier:General
    {
        public DataTable showListSupplier()
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, Address, Status from Supplier", conn);
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
        public bool addSupplier(Supplier supplier)
        {
            bool result = false;

            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "insert into Supplier(Name, Address, Status) values(N'"+supplier.Name+"',N'"+supplier.Address+"',N'"+supplier.Status+"')";
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
        public bool deleteSupplier(int id)
        {
            bool result = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "Delete from Supplier where Id='" + id + "' ";
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
        public bool updateSupplier(Supplier supplier)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update Supplier set Name=N'"+supplier.Name+"', Address=N'"+supplier.Address+"', Status=N'"+supplier.Status+"' where Id='" + supplier.Id + "'";
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
        public DataTable searchSupplier(string name)
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, Address, Status from Supplier where Name=N'" + name + "'", conn);
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
