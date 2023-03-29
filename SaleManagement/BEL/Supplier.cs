using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Supplier
    {
        private int id;
        private string name;
        private string address;
        private string status;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Status { get => status; set => status = value; }

        public Supplier()
        {
            this.name = null;
            this.address = null;
            this.status = null;
        }
        public Supplier(string name, string address, string status)
        {
            this.name = name;
            this.address = address;
            this.status = status;
        }
    }
}
