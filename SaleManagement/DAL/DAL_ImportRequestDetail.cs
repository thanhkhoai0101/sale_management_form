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
    public class DAL_ImportRequestDetail:General
    {
        public DataTable showListImportRequestDetail()
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, ImportRequestId, ProductId, Quantity, Serial from ImportRequestDetail", conn);
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
        public bool addImportRequestDetail(ImportRequestDetail importdetail)
        {
            bool result = false;

            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "insert into ImportRequestDetail(ImportRequestId, ProductId, Quantity, Serial) values('"+importdetail.ImportRequestID+"','"+importdetail.ProductID+"','"+importdetail.Quantity+"','"+importdetail.Serial+"')";
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
        public bool deleteImportRequestDetail(ImportRequestDetail importdetail)
        {
            bool result = false;
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "Delete from ImportRequestDetail where Id='" + importdetail.Id + "' ";
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
        public bool updateImportRequestDetail(ImportRequestDetail importdetail)
        {
            bool result = false;
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            string sql = "update ImportRequestDetail set ImportRequestId='"+importdetail.ImportRequestID+"',ProductId='"+importdetail.ProductID+"',Quantity='"+importdetail.Quantity+"',Serial='"+importdetail.Serial+"' where Id='"+importdetail.Id+"'";
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
        public DataTable searchImportRequestDetail(ImportRequestDetail importdetail)
        {
            DataTable dt = new DataTable();
            if (ConnectionState.Closed == conn.State)
                conn.Open();
            SqlCommand cmd = new SqlCommand("select Id, ImportRequestId, ProductId, Quantity, Serial from ImportRequestDetail where Id=N'" + importdetail.Id + "'", conn);
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
