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
    public partial class Products : Form
    {
        public int CurrentSelectedId { get; set; }
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            showListProdcut(dgvListProducts);
        }
        private void showListProdcut(DataGridView dgv)
        {
            BAL_Product product = new BAL_Product();
            dgv.DataSource = product.showListProduct();
        }

        private void dgvListProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectedId = (int)dgvListProducts.CurrentRow.Cells[0].Value;

            txtName.Text = dgvListProducts.CurrentRow.Cells["Name"].Value.ToString();
            txtSalePrice.Text = dgvListProducts.CurrentRow.Cells["SalePrice"].Value.ToString();
            txtStockQuantity.Text = dgvListProducts.CurrentRow.Cells["StockQuantity"].Value.ToString();
            txtCategoryID.Text = dgvListProducts.CurrentRow.Cells["CategoryId"].Value.ToString();
            txtType.Text = dgvListProducts.CurrentRow.Cells["Type"].Value.ToString();
            txtImage.Text = dgvListProducts.CurrentRow.Cells["Image"].Value.ToString();
            picImage.Image = Image.FromFile(dgvListProducts.CurrentRow.Cells["Image"].Value.ToString());

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            showListProdcut(dgvListProducts);
            txtName.Text = null;
            txtSalePrice.Text = null;
            txtStockQuantity.Text = null;
            txtCategoryID.Text = null;
            txtType.Text = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int sale = int.Parse(txtSalePrice.Text);
            int stockQuantity = int.Parse(txtStockQuantity.Text);
            int categoryId = int.Parse(txtCategoryID.Text);
            string type = txtType.Text;
            string image = txtImage.Text;
            BAL_Product _Product = new BAL_Product();
            BEL.Product product = new BEL.Product(name, sale, stockQuantity, categoryId, type, image);
            bool resultAdd = _Product.addProduct(product);
            if (_Product.checkName(name))
            {
                MessageBox.Show("Tên sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (resultAdd == true)
            {
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListProdcut(dgvListProducts);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int sale = int.Parse(txtSalePrice.Text);
            int stockQuantity = int.Parse(txtStockQuantity.Text);
            int categoryId = int.Parse(txtCategoryID.Text);
            string type=txtType.Text;
            string image = txtImage.Text;
            BAL_Product _Product = new BAL_Product();
            BEL.Product product = new BEL.Product(name, sale, stockQuantity, categoryId, type,image);
            product.Id = CurrentSelectedId;
            bool result = _Product.updateProduct(product);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListProdcut(dgvListProducts);
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

            BAL_Product _Product = new BAL_Product();
            bool reusult = _Product.deleteProduct(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListProdcut(dgvListProducts);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_Product product = new BAL_Product();
            dgvListProducts.DataSource = product.searchListProduct(txtSearch.Text);
            if (product.searchListProduct(txtSearch.Text).Rows.Count > 0)
            {
                dgvListProducts.DataSource = product.searchListProduct(txtSearch.Text);
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
