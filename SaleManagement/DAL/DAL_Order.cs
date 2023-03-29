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
    public class DAL_Order:General
    {
        public DataTable showListOrder()
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, OrderDateTime, Note, CustomerId, Status from [Order]", conn);
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
        public bool addOrder(Order order)
        {
            bool result = false;

            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "insert into Order(OrderDateTime, Note, CustomerId, Status) values('"+order.OrderDatetime+"', '"+order.Note+"', '"+order.CustomerID+"','"+order.Status+"')";
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
        public bool deleteOrder(Order order)
        {
            bool result = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "Delete from Order where Id='" + order.Id + "' ";
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
        public bool updateOrder(Order order)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update Order set OrderDateTime='"+order.OrderDatetime+"', Note='"+order.Note+"', CustomerId='"+order.CustomerID+"', Status='"+order.Status+"' where Id=N'" + order.Id + "'";
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
        public DataTable searchOrder(Order order)
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, OrderDateTime, Note, CustomerId, Status from Order where Id='" + order.Id + "'", conn);
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
