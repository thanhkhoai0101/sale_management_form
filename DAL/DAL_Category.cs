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
    public class DAL_Category:General
    {
        public DataTable showListCategory()
        {
            DataTable dt = new DataTable();
            
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, Status, ParentID from Category where tinhtrang = 1", conn);
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
        public bool updateParentId(Category category)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update Category set  ParentId='" + category.Id + "' where Id = '" + category.Id + "'";
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
        public string createCategory(Category category)
        {
            string result = null;

            if (issetCategoryID(category.ParentID)== false)
            {                                        
                    result = "parent_err";             
            }
            else if (issetCategoryName(category.Name))
            {
                result = "name_err";
            }
            else
            {
                if (ConnectionState.Closed == conn.State)
                    conn.Open();
                string sql = "insert into Category(Name, Status, ParentID) values(N'" + category.Name + "', N'" + category.Status + "','" + category.ParentID + "')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    if (cmd.ExecuteNonQuery() > 0)
                        result = null;
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
        public bool issetCategoryID(int categoryID)
        {
            bool resulf = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();

            }
            SqlCommand cmd = new SqlCommand("select Id from Category where Id ='" + categoryID + "'", conn);
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
        public bool issetCategoryName(string categoryName)
        {
            bool resulf = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
            {
                conn.Open();

            }
            SqlCommand cmd = new SqlCommand("select Name from Category where Name like N'" + categoryName + "'", conn);
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

        public string updateCategory(Category category)
        {
           
            string result = null;

            if (issetCategoryID(category.ParentID) == false)
            {
                result = "parent_err";
            }
            else
            {
                if (ConnectionState.Closed == conn.State)
                    conn.Open();
                string sql = "update Category set Name=N'" + category.Name + "',Status='" + category.Status + "', ParentId='" + category.ParentID + "' where Id = '"+category.Id+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    if (cmd.ExecuteNonQuery() > 0)
                        result = null;
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
        public bool deleteCategory(int id)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update Category set tinhtrang = 0 where Id='" + id + "'";
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
        public DataTable searchCategory(string name)
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, Name, Status, ParentID from Category where name like '"+name+"'", conn);
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

        public DataTable bieuDoLoaiSanPham()
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select category.Name, count(category.id) as 'San pham ton kho' from Category,Product where Category.Id = CategoryId and Category.Status = 'ACTIVE' group by Category.Name ",conn);
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
