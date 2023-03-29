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
    public class BAL_Order
    {
        public DataTable showListOrder()
        {
            DAL_Order _Order = new DAL_Order();
            return _Order.showListOrder();
        }
        public bool addOrder(Order order)
        {
            DAL_Order _Order = new DAL_Order();
            return _Order.addOrder(order);
        }
        public bool deleteOrder(string id)
        {
            DAL_Order _Order = new DAL_Order();
            return _Order.deleteOrder(id);
        }
        public bool updateOrder(Order order)
        {
            DAL_Order _Order = new DAL_Order();
            return _Order.updateOrder(order);
        }
        public DataTable searchListOrder(int id)
        {
            DAL_Order _Order = new DAL_Order();
            return _Order.searchOrder(id);
        }
    }
}
