using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ProductSerial
    {
        private int id;
        private int productID;
        private string serial;
        private int stockQuantity;

        public int Id { get => id; set => id = value; }
        public int ProductID { get => productID; set => productID = value; }
        public string Serial { get => serial; set => serial = value; }
        public int StockQuantity { get => stockQuantity; set => stockQuantity = value; }
        
        public ProductSerial()
        {
            this.productID = 0;
            this.serial = null;
            this.stockQuantity = 0;
        }
        public ProductSerial(int productID, string serial, int stockQuantity)
        {
            this.productID = productID;
            this.serial = serial;
            this.stockQuantity = stockQuantity;
        }
    }
}
