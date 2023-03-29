using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Category
    {
        private int id;
        private string name;
        private string status;
        private int parentID;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Status { get => status; set => status = value; }
        public int ParentID { get => parentID; set => parentID = value; }

        public Category()
        {
            this.name = null;
            this.status = "ACTIVE";
            this.parentID = 0;
        }
        public Category(string name, string status, int parentID)
        {
            this.name = name;
            this.status = status;
            this.parentID = parentID;
        }
    }
}
