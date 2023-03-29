using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class OrderDetail
    {
        private int id;
        private int orderId;
        private int  productId;
        private int quantity;
        private int saleprice;
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get ; set ; }
        public int Saleprice { get; set ; }

        public OrderDetail()
        {
            this.OrderID = 0;
            this.ProductID = 0;
            this.Quantity = 0;
            this.Saleprice = 0;
        }

        public OrderDetail(int orderID, int productID,int quantity,int saleprice)
        {
            this.OrderID = orderID;
            this.ProductID = productID;
            this.Quantity = quantity; 
            this.Saleprice = saleprice;
        }
    }
}
