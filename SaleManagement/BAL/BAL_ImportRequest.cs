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
    public class BAL_ImportRequest
    {
        public DataTable showListImportRequest()
        {
            DAL_ImportRequest _ImportRequest = new DAL_ImportRequest();
            return _ImportRequest.showListImportRequest();
        }
        public bool addImportRequest(ImportRequest import)
        {
            DAL_ImportRequest _Employee = new DAL_ImportRequest();
            return _Employee.addImportRequest(import);
        }
        public bool deleteImportRequest(ImportRequest import)
        {
            DAL_ImportRequest _Employee = new DAL_ImportRequest();
            return _Employee.deleteImportRequest(import);
        }
        public bool updateImportRequest(ImportRequest import)
        {
            DAL_ImportRequest _Employee = new DAL_ImportRequest();
            return _Employee.updateImportRequest(import);
        }
        public DataTable searchListImportRequest(ImportRequest import)
        {
            DAL_ImportRequest _Employee = new DAL_ImportRequest();
            return _Employee.searchImportRequest(import);
        }
    }
}
