using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ImportRequestDetail
    {
        private int id;
        private int importRequestID;
        private int productID;
        private int quantity;
        private string serial;

        public int ImportRequestID { get => importRequestID; set => importRequestID = value; }
        public int ProductID { get => productID; set => productID = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Serial { get => serial; set => serial = value; }
        public int Id { get => id; set => id = value; }

        public ImportRequestDetail()
        {
            this.importRequestID = 0;
            this.productID = 0;
            this.quantity = 0;
            this.serial = null;
        }
        public ImportRequestDetail(int importRequestID, int productID, int quantity, string serial)
        {
            this.importRequestID = importRequestID;
            this.productID = productID;
            this.quantity = quantity;
            this.serial = serial;
        }
    }
}
