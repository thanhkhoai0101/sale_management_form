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
    public class BAL_ProductSerial
    {
        public DataTable showListProductSerial()
        {
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            return _ProductSerial.showListProductSerial();
        }
        public bool addProductSerial(ProductSerial productSerial)
        {
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            return _ProductSerial.addProductSerial(productSerial);
        }
        public bool deleteProductSerial(ProductSerial productSerial)
        {
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            return _ProductSerial.deleteProductSerial(productSerial);
        }
        public bool updateProductSerial(ProductSerial productSerial)
        {
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            return _ProductSerial.updateProductSerial(productSerial);
        }
        public DataTable searchListProductSerial(ProductSerial productSerial)
        {
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            return _ProductSerial.searchProductSerial(productSerial);
        }
    }
}
