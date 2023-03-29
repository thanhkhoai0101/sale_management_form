using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BEL;
namespace BAL
{
    public class BAL_ImportRequestDetail
    {
        public DataTable showListImportRequestDetail()
        {
            DAL_ImportRequestDetail _ImportRequestDetail = new DAL_ImportRequestDetail();
            return _ImportRequestDetail.showListImportRequestDetail();
        }
        public bool addImportRequestDetail(ImportRequestDetail importdetail)
        {
            DAL_ImportRequestDetail _ImportRequestDetail = new DAL_ImportRequestDetail();
            return _ImportRequestDetail.addImportRequestDetail(importdetail);
        }
        public bool deleteImportRequestDetail(int id)
        {
            DAL_ImportRequestDetail _ImportRequestDetail = new DAL_ImportRequestDetail();
            return _ImportRequestDetail.deleteImportRequestDetail(id);
        }
        public bool updateImportRequestDetail(ImportRequestDetail importdetail)
        {
            DAL_ImportRequestDetail _ImportRequestDetail = new DAL_ImportRequestDetail();
            return _ImportRequestDetail.updateImportRequestDetail(importdetail);
        }
        public DataTable searchListImportRequestDetail(int id)
        {
            DAL_ImportRequestDetail _ImportRequestDetail = new DAL_ImportRequestDetail();
            return _ImportRequestDetail.searchImportRequestDetail(id);
        }
        
    }
}
