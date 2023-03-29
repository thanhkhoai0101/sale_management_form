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
            txtName.Text = dgvListProducts.CurrentRow.Cells["Name"].Value.ToString();
            txtSalePrice.Text = dgvListProducts.CurrentRow.Cells["SalePrice"].Value.ToString();
            txtStockQuantity.Text = dgvListProducts.CurrentRow.Cells["StockQuantity"].Value.ToString();
            txtCategoryID.Text = dgvListProducts.CurrentRow.Cells["CategoryId"].Value.ToString();
            txtType.Text = dgvListProducts.CurrentRow.Cells["Type"].Value.ToString();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
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
            BAL_Product _Product = new BAL_Product();
            BEL.Product product = new BEL.Product(name, sale, stockQuantity, categoryId, type);
            bool resultAdd = _Product.addProduct(product);
            if (resultAdd == true)
            {
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListProdcut(dgvListProducts);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
