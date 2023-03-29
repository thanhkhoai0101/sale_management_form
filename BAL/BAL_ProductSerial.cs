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
        public string addProductSerial(ProductSerial productSerial)
        {
            string resulf = null;
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            if(_ProductSerial.addProductSerial(productSerial))
            {
                resulf = "Đã thêm thành công!";
            }
            else
            {
                resulf = "Serial đã tồn tại!";
            }
            return resulf;
        }
        public bool deleteProductSerial(int id)
        {
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            return _ProductSerial.deleteProductSerial(id);
        }
        public bool updateProductSerial(ProductSerial productSerial)
        {
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            return _ProductSerial.updateProductSerial(productSerial);
        }
        public DataTable searchListProductSerial(int id)
        {
            DAL_ProductSerial _ProductSerial = new DAL_ProductSerial();
            return _ProductSerial.searchProductSerial(id);
        }
    }
}
