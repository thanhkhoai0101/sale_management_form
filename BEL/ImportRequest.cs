using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ImportRequest
    {
        private int id;
        private DateTime importDate;
        private string note;
        private string status;
        private int supplierID;
        private int employeeID;

        public DateTime ImportDate { get => importDate; set => importDate = value; }
        public string Note { get => note; set => note = value; }
        public string Status { get => status; set => status = value; }
        public int SupplierID { get => supplierID; set => supplierID = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public int Id { get => id; set => id = value; }

        public ImportRequest()
        {
            this.importDate = DateTime.Now;
            this.note = null;
            this.status = null;
            this.supplierID = 0;
            this.employeeID = 0;
        }
        public ImportRequest(DateTime importDate, string note, string status, int supplierID,int employeeID)
        {
            this.importDate = importDate;
            this.note = note;
            this.status = status;
            this.supplierID = supplierID;
            this.employeeID = employeeID;
        }
    }
}
