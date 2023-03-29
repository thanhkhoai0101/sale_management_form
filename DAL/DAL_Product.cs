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
    public class DAL_Product:General
    {
        public DataTable showListProduct()
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Product.Id, Product.Name, Product.SalePrice, Product.StockQuantity, Product.CategoryId, Product.Type, Product.Image from Product,Category where Product.CategoryId = Category.Id and Category.Status = 'ACTIVE'", conn);
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

        public bool addProduct(Product product)
        {
            bool result = false;

            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "insert into Product(Name, SalePrice, StockQuantity, CategoryId, Type, Image) values(N'"+product.Name+"','"+product.SalePrice+"','"+product.StockQuantity+"','"+product.CategoryID+"',N'"+product.Type+ "','" + product.Image +"')";
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


        


        public bool deleteProduct(int id )
        {
            bool result = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "Delete from Product where Id='" + id + "' ";
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
        public bool updateProduct(Product product)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update Product set Name='"+product.Name+"', SalePrice='"+product.SalePrice+"',StockQuantity='"+product.StockQuantity+"',CategoryId='"+product.CategoryID+"', Type='"+product.Type+"' where Id='"+product.Id+"'";
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
        public DataTable searchProduct(string name )
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, SalePrice, StockQuantity, CategoryId, type from Product where Name like N'%" + name + "%'", conn);
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

       
        public bool CheckNameProduct(string name)
        {
            bool resulf = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();

            }
            string sql = "select * from Product where Name like '" + name + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
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
