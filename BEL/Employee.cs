using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class Employee
    {
        private int id;
        private string name;
        private string address;
        private string username;
        private string password;
        private string phonenumber;
        private string email;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Email { get => email; set => email = value; }
        public int Id { get => id; set => id = value; }

        public Employee()
        {
            this.name = null;
            this.address = null;
            this.username = null;
            this.password = null;
            this.phonenumber = null;
            this.email = null;
        }
        public Employee(string name, string address,string username, string password, string phonenumber, string email)
        {
            this.name = name;
            this.address = address;
            this.username = username;
            this.password = password;
            this.phonenumber = phonenumber;
            this.email = email;
        }
    }
}
