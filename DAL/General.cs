using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAL
{
    public class General
    {
       public SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-M2GUH4I;Initial Catalog=sale_management;Integrated Security=True");
    }
}
