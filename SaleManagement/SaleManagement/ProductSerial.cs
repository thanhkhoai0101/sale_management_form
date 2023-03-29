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
            bool resultAdd = _ProductSerial.addProductSerial(productSerial);
            if (resultAdd == true)
            {
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListProductSerial(dgvListProductSerial);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
