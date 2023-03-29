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
    public class BAL_Supplier
    {
        public DataTable showListSupplier()
        {
            DAL_Supplier _Supplier = new DAL_Supplier();
            return _Supplier.showListSupplier();
        }
        public bool addSupplier(Supplier supplier)
        {
            DAL_Supplier _Supplier = new DAL_Supplier();
            return _Supplier.addSupplier(supplier);
        }
        public bool deleteSupplier(int id)
        {
            DAL_Supplier _Supplier = new DAL_Supplier();
            return _Supplier.deleteSupplier(id);
        }
        public bool updateSupplier(Supplier supplier)
        {
            DAL_Supplier _Supplier = new DAL_Supplier();
            return _Supplier.updateSupplier(supplier);
        }
        public DataTable searchListSupplier(string name)
        {
            DAL_Supplier _Supplier = new DAL_Supplier();
            return _Supplier.searchSupplier(name);
        }
    }
}
