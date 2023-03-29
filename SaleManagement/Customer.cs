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
    public partial class Customer : Form
    {
        public int CurrentSelectedId { get; set; }
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            showListCustomer(dgvListCustomer);
        }
        private void showListCustomer(DataGridView dgv)
        {
            BAL_Customer customer = new BAL_Customer();
            dgv.DataSource = customer.showListCustomer();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtName.Text = null;
            txtAddress.Text = null;
            txtPhoneNumber.Text = null;
            txtEmail.Text = null;
        }

        private void dgvListCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectedId = (int)dgvListCustomer.CurrentRow.Cells[0].Value;

            txtName.Text = dgvListCustomer.CurrentRow.Cells["Name"].Value.ToString();
            txtAddress.Text = dgvListCustomer.CurrentRow.Cells["Address"].Value.ToString();
            txtPhoneNumber.Text = dgvListCustomer.CurrentRow.Cells["PhoneNumber"].Value.ToString();
            txtEmail.Text = dgvListCustomer.CurrentRow.Cells["Email"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address=txtAddress.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            BAL_Customer _Customer = new BAL_Customer();
            BEL.Customer customer = new BEL.Customer(name, address, phone, email);
            bool resultAdd = _Customer.addCustomer(customer);
            if (resultAdd == true)
            {
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListCustomer(dgvListCustomer);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string phone = txtPhoneNumber.Text;
            string email = txtEmail.Text;
            BAL_Customer _Customer = new BAL_Customer();
            BEL.Customer customer = new BEL.Customer(name, address, phone, email);
            customer.Id = CurrentSelectedId;
            bool result = _Customer.updateCustomer(customer);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListCustomer(dgvListCustomer);
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

            BAL_Customer _Customer = new BAL_Customer();
            bool reusult = _Customer.deleteCustomer(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListCustomer(dgvListCustomer);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_Customer customer = new BAL_Customer();
            dgvListCustomer.DataSource = customer.searchListCustomer(int.Parse(txtSearch.Text));
            if (customer.searchListCustomer(int.Parse(txtSearch.Text)).Rows.Count > 0)
            {
                dgvListCustomer.DataSource = customer.searchListCustomer(int.Parse(txtSearch.Text));
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
