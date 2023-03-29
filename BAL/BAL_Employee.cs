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
    public class BAL_Employee
    {
        public DataTable showListEmployee()
        {
            DAL_Employee _Employee = new DAL_Employee();
            return _Employee.showListEmployee();
        }
        public bool addEmployee(Employee employee)
        {
            DAL_Employee _Employee = new DAL_Employee();
            return _Employee.addEmployee(employee);
        }
        public bool deleteEmployee(int id)
        {
            DAL_Employee _Employee = new DAL_Employee();
            return _Employee.deleteEmployee(id);
        }
        public bool updateEmployee(Employee employee)
        {
            DAL_Employee _Employee = new DAL_Employee();
            return _Employee.updateEmployee(employee);
        }
        public DataTable searchListEmployee(string name)
        {
            DAL_Employee _Employee = new DAL_Employee();
            return _Employee.searchEmployee(name);
        }
        public string checkAccount(string username, string password)
        {
            string resulf = null;
            DAL_Employee _Employee = new DAL_Employee();
            if (_Employee.checkUsername(username) == false)
            {
                resulf = "Tên tài khoản không hợp lệ!";
            }
            else if (_Employee.checkPassword(password) == false)
            {
                resulf = "Mật khẩu không đúng!";
            }
            else
            {
                resulf = "Đăng nhập thành công! ";
            }

            return resulf;
        }

        public bool checkUsername(string Username)
        {
            DAL_Employee _Employee = new DAL_Employee();
            return _Employee.checkUsername(Username);
        }
        public bool checkEmail(string email)
        {
            DAL_Employee _Employee = new DAL_Employee();
            return _Employee.checkEmail(email);
        }

        public bool updateEmployeetinhtrang(string username)
        {
            DAL_Employee _Employee = new DAL_Employee();
            return _Employee.updateEmployeetinhtrang(username);
        }

    }
}
