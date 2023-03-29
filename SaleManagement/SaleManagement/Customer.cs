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
    }
}
