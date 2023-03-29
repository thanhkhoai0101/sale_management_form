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
    public partial class ProductSerial : Form
    {
        public int CurrentSelectedId { get; set; }
        public ProductSerial()
        {
            InitializeComponent();
        }

        private void ProductSerial_Load(object sender, EventArgs e)
        {
            showListProductSerial(dgvListProductSerial);
        }
        private void showListProductSerial(DataGridView dgv)
        {
            BAL_ProductSerial productSerial = new BAL_ProductSerial();
            dgv.DataSource = productSerial.showListProductSerial();
        }

        private void dgvListProductSerial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectedId = (int)dgvListProductSerial.CurrentRow.Cells[0].Value;

            txtProductID.Text = dgvListProductSerial.CurrentRow.Cells["ProductId"].Value.ToString();
            txtSerial.Text = dgvListProductSerial.CurrentRow.Cells["Serial"].Value.ToString();
            txtStockQuantity.Text = dgvListProductSerial.CurrentRow.Cells["StockQuantity"].Value.ToString();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtProductID.Text = null;
            txtSerial.Text = null;
            txtStockQuantity.Text = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(txtProductID.Text);
            string serial = txtSerial.Text;
            int stockQuantity = int.Parse(txtStockQuantity.Text);
            BAL_ProductSerial _ProductSerial = new BAL_ProductSerial();
            BEL.ProductSerial productSerial = new BEL.ProductSerial(productId, serial, stockQuantity);
            string resultAdd = _ProductSerial.addProductSerial(productSerial);
            if (resultAdd == "Đã thêm thành công!")
            {
                MessageBox.Show(resultAdd, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListProductSerial(dgvListProductSerial);
            }
            else
            {
                MessageBox.Show(resultAdd, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(txtProductID.Text);
            string serial = txtSerial.Text;
            int stockQuantity = int.Parse(txtStockQuantity.Text);
            BAL_ProductSerial _ProductSerial = new BAL_ProductSerial();
            BEL.ProductSerial productSerial = new BEL.ProductSerial(productId, serial, stockQuantity);
            productSerial.Id = CurrentSelectedId;
            bool result = _ProductSerial.updateProductSerial(productSerial);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListProductSerial(dgvListProductSerial);
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

            BAL_ProductSerial _ProductSerial = new BAL_ProductSerial();
            bool reusult = _ProductSerial.deleteProductSerial(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListProductSerial(dgvListProductSerial);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_ProductSerial productSerial = new BAL_ProductSerial();
            dgvListProductSerial.DataSource = productSerial.searchListProductSerial(int.Parse(txtSearch.Text));
            if (productSerial.searchListProductSerial(int.Parse(txtSearch.Text)).Rows.Count > 0)
            {
                dgvListProductSerial.DataSource = productSerial.searchListProductSerial(int.Parse(txtSearch.Text));
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
