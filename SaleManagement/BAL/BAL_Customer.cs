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
    public class BAL_Customer
    {
        public DataTable showListCustomer()
        {
            DAL_Customer _Customer = new DAL_Customer();
            return _Customer.showListCustomer();
        }
        public bool addCustomer(Customer customer)
        {
            DAL_Customer _Customer = new DAL_Customer();
            return _Customer.createCustomer(customer);
        }
        public bool deleteCustomer(int id)
        {
            DAL_Customer _Customer = new DAL_Customer();
            return _Customer.deleteCustomer(id);
        }
        public bool updateCustomer(Customer customer)
        {
            DAL_Customer _Customer = new DAL_Customer();
            return _Customer.updateECustomer(customer);
        }
        public DataTable searchListCustomer(int id)
        {
            DAL_Customer _Customer = new DAL_Customer();
            return _Customer.searchCustomer(id);
        }
    }
}
