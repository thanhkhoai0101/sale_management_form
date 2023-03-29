using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Order
    {
        private int id;
        private DateTime orderDatetime;
        private string note;
        private int customerID;
        private string status;

        public DateTime OrderDatetime { get => orderDatetime; set => orderDatetime = value; }
        public string Note { get => note; set => note = value; }
        public int CustomerID { get => customerID; set => customerID = value; }
        public string Status { get => status; set => status = value; }
        public int Id { get => id; set => id = value; }

        public Order()
        {
            this.orderDatetime = DateTime.Now;
            this.note = null;
            this.customerID = 0;
            this.status = null;
        }
        public Order(DateTime orderDatetime, string note, int customerID,string status)
        {
            this.orderDatetime = orderDatetime;
            this.note = note;
            this.customerID = customerID;
            this.status = status;
        }
    }
}
