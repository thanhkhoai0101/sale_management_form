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
    public partial class OrderDetail : Form
    {
        public int CurrentSelectedId { get; set; }
        public OrderDetail()
        {
            InitializeComponent();
        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {
            showListOrderDetail(dgvListOrderDetail);
        }
        private void showListOrderDetail(DataGridView dgv)
        {
            BAL_OrderDetail orderDetail = new BAL_OrderDetail();
            dgv.DataSource = orderDetail.showListOrderDetail();
        }

        private void dgvListOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectedId = (int)dgvListOrderDetail.CurrentRow.Cells[0].Value;

            txtOrderID.Text = dgvListOrderDetail.CurrentRow.Cells["OrderId"].Value.ToString();
            txtProductID.Text = dgvListOrderDetail.CurrentRow.Cells["ProductId"].Value.ToString();
            txtQuantity.Text = dgvListOrderDetail.CurrentRow.Cells["Quantity"].Value.ToString();
            txtSalePrice.Text = dgvListOrderDetail.CurrentRow.Cells["SalePrice"].Value.ToString();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtOrderID.Text = null;
            txtProductID.Text = null;
            txtQuantity.Text = null;
            txtSalePrice.Text = null;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string orderId = txtOrderID.Text;
            int productId = int.Parse(txtProductID.Text);
            int quantity = int.Parse(txtQuantity.Text);
            int sale = int.Parse(txtSalePrice.Text);
            BAL_OrderDetail _OrderDetail = new BAL_OrderDetail();
            BEL.OrderDetail orderDetail = new BEL.OrderDetail(orderId, productId, quantity, sale);
            bool resultAdd = _OrderDetail.addOrderDetail(orderDetail);
            if (resultAdd == true)
            {
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListOrderDetail(dgvListOrderDetail);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string orderId = txtOrderID.Text;
            int productId = int.Parse(txtProductID.Text);
            int quantity = int.Parse(txtQuantity.Text);
            int sale = int.Parse(txtSalePrice.Text);
            
            BAL_OrderDetail _OrderDetail = new BAL_OrderDetail();
            BEL.OrderDetail orderDetail = new BEL.OrderDetail(orderId, productId, quantity, sale);
            orderDetail.Id = CurrentSelectedId;
            bool result = _OrderDetail.updateOrderDetail(orderDetail);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListOrderDetail(dgvListOrderDetail);
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

            BAL_OrderDetail _OrderDetail = new BAL_OrderDetail();
            bool reusult = _OrderDetail.deleteOrderDetail(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListOrderDetail(dgvListOrderDetail);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_OrderDetail orderDetail = new BAL_OrderDetail();
            dgvListOrderDetail.DataSource = orderDetail.searchListOrderDetail(int.Parse(txtSearch.Text));
            if (orderDetail.searchListOrderDetail(int.Parse(txtSearch.Text)).Rows.Count > 0)
            {
                dgvListOrderDetail.DataSource = orderDetail.searchListOrderDetail(int.Parse(txtSearch.Text));
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
