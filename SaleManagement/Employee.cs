using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using BEL;

namespace SaleManagement
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        public int CurrentSelectedId { get; set; }
        private void Employee_Load(object sender, EventArgs e)
        {
            showListEmployee(dgvListEmployee);
        }
        private void showListEmployee(DataGridView dgv)
        {
            BAL_Employee employee = new BAL_Employee();
            dgv.DataSource = employee.showListEmployee();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string addr = txtAddress.Text;
            string userName = txtUserName.Text;
            string pass = txtPassword.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmail.Text;

            BAL_Employee _Employee = new BAL_Employee();
            BEL.Employee employee = new BEL.Employee(name, addr, userName, pass, phone, email);
            if (_Employee.checkUsername(userName))
            {
                MessageBox.Show("Username đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_Employee.checkEmail(email))
            {
                MessageBox.Show("Email đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bool resultAdd = _Employee.addEmployee(employee);
                if (resultAdd == true)
                {
                    MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showListEmployee(dgvListEmployee);
                }
                else
                {
                    MessageBox.Show("Đã thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string addr = txtAddress.Text;
            string userName = txtUserName.Text;
            string pass = txtPassword.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmail.Text;

            BEL.Employee employee = new BEL.Employee(name, addr, userName, pass, phone, email);           
            BAL_Employee _Employee = new BAL_Employee();
            employee.Id = CurrentSelectedId;
            bool result = _Employee.updateEmployee(employee);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListEmployee(dgvListEmployee);
            }
            else
            {
                MessageBox.Show("Đã sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (CurrentSelectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            BAL_Employee _Employee = new BAL_Employee();
            bool reusult = _Employee.deleteEmployee(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListEmployee(dgvListEmployee);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtName.Text = null;
            txtAddress.Text = null;
            txtUserName.Text = null;
            txtPassword.Text = null;
            txtPhoneNumber.Text = null;
            txtEmail.Text = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_Employee employee = new BAL_Employee();
            dgvListEmployee.DataSource = employee.searchListEmployee(txtSearch.Text);
            if (employee.searchListEmployee(txtSearch.Text).Rows.Count > 0)
            {
                dgvListEmployee.DataSource = employee.searchListEmployee(txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectedId=(int)dgvListEmployee.CurrentRow.Cells[0].Value;

            txtName.Text = dgvListEmployee.CurrentRow.Cells["Name"].Value.ToString();
            txtAddress.Text = dgvListEmployee.CurrentRow.Cells["Address"].Value.ToString();
            txtUserName.Text = dgvListEmployee.CurrentRow.Cells["Username"].Value.ToString();
            txtPassword.Text = dgvListEmployee.CurrentRow.Cells["Password"].Value.ToString();
            txtPhoneNumber.Text = dgvListEmployee.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            txtEmail.Text = dgvListEmployee.CurrentRow.Cells["Email"].Value.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Hide();
                Home home = new Home();
                home.ShowDialog();
                this.Close();
            }
        }
    }
}
