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
    public class DAL_ProductSerial:General
    {
        public DataTable showListProductSerial()
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, ProductId, Serial, StockQuantity from ProductSerial", conn);
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
        public bool addProductSerial(ProductSerial productSerial)
        {
            bool result = false;

            if (issetSerial(productSerial.Serial))
            {
                result = false;
            }
            else
            {
                if (ConnectionState.Closed == conn.State)
                    conn.Open();
                string sql = "insert into ProductSerial(ProductId, Serial, StockQuantity) values('" + productSerial.ProductID + "','" + productSerial.Serial + "','" + productSerial.StockQuantity + "')";
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
            }
            return result;
        }
        public bool deleteProductSerial(int id)
        {
            bool result = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "Delete from ProductSerial where Id='" + id + "' ";
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
        public bool updateProductSerial(ProductSerial productSerial)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update ProductSerial set ProductId='" + productSerial.ProductID+"', Serial='"+productSerial.Serial+"', StockQuantity='"+productSerial.StockQuantity+"' where Id=N'" + productSerial.Id + "'";
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
        public DataTable searchProductSerial(int id)
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, ProductId, Serial, StockQuantity from ProductSerial where Id=N'" + id + "'", conn);
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

        public bool issetSerial(string serial)
        {
            bool resulf = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();

            }
            SqlCommand cmd = new SqlCommand("select Serial from ProductSerial where Serial = '" + serial + "'", conn);
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
