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
    public partial class Order : Form
    {
      
        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            showListOrder(dgvListOrder);
        }
        private void showListOrder(DataGridView dgv)
        {
            BAL_Order order = new BAL_Order();
            dgv.DataSource = order.showListOrder();
        }

        private void dgvListOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtId.Text = dgvListOrder.CurrentRow.Cells["Id"].Value.ToString();
            txtOrderDate.Text = dgvListOrder.CurrentRow.Cells["OrderDateTime"].Value.ToString();
            txtNote.Text = dgvListOrder.CurrentRow.Cells["Note"].Value.ToString();
            txtCustomerId.Text = dgvListOrder.CurrentRow.Cells["CustomerId"].Value.ToString();
            txtStatus.Text = dgvListOrder.CurrentRow.Cells["Status"].Value.ToString();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            showListOrder(dgvListOrder);
            txtOrderDate.Text = null ;
            txtNote.Text = null ;
            txtCustomerId.Text = null ;
            txtStatus.Text = null ;
        }
        //chua lam dc
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime orderDate = DateTime.Parse(txtOrderDate.Text);
            string note = txtNote.Text;
            int customerId = int.Parse(txtCustomerId.Text);
            string status = txtStatus.Text;
            string id = txtId.Text;
            
            
            BAL_Order _Order = new BAL_Order();
            BEL.Order order = new BEL.Order(id,orderDate, note, customerId, status);
            bool result = _Order.addOrder(order);
            if (result == true)
            {
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListOrder(dgvListOrder);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime orderDate = DateTime.Parse(txtOrderDate.Text);
            string note = txtNote.Text;
            int customerId = int.Parse(txtCustomerId.Text);
            string status = txtStatus.Text;
            string id = txtId.Text;
            BAL_Order _Order = new BAL_Order();
            BEL.Order order = new BEL.Order(id,orderDate, note, customerId, status);
            
            bool result = _Order.updateOrder(order);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListOrder(dgvListOrder);
            }
            else
            {
                MessageBox.Show("Đã sửa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BAL_Order _Order = new BAL_Order();
            bool reusult = _Order.deleteOrder(txtId.Text);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListOrder(dgvListOrder);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_Order order = new BAL_Order();
            dgvListOrder.DataSource = order.searchListOrder(int.Parse(txtSearch.Text));
            if (order.searchListOrder(int.Parse(txtSearch.Text)).Rows.Count > 0)
            {
                dgvListOrder.DataSource = order.searchListOrder(int.Parse(txtSearch.Text));
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

        private void btnCheck_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            string orderDate = txtOrderDate.Text;
            string note = txtNote.Text;
            int customerId = int.Parse(txtCustomerId.Text);
            string status = txtStatus.Text;
            string id = txtId.Text;



            Bill _newfrom = new Bill(orderDate, note, customerId, status, id);
            _newfrom.ShowDialog();
        }
    }
}
