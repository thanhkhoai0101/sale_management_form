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
    public class BAL_Product
    {
        public DataTable showListProduct()
        {
            DAL_Product _Product = new DAL_Product();
            return _Product.showListProduct();
        }
        public bool addProduct(Product product)
        {
            DAL_Product _Product = new DAL_Product();
            return _Product.addProduct(product);
        }

        public bool checkName(string name)
        {
            DAL_Product _Product = new DAL_Product();
            return _Product.CheckNameProduct(name);
        }

        public bool deleteProduct(int id)
        {
            DAL_Product _Product = new DAL_Product();
            return _Product.deleteProduct(id);
        }
        public bool updateProduct(Product product)
        {
            DAL_Product _Product = new DAL_Product();
            return _Product.updateProduct(product);
        }
        public DataTable searchListProduct(string name)
        {
            DAL_Product _Product = new DAL_Product();
            return _Product.searchProduct(name);
        }
    }
}
