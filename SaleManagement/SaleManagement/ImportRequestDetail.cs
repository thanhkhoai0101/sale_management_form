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
    public partial class ImportRequestDetail : Form
    {
        public ImportRequestDetail()
        {
            InitializeComponent();
        }

        private void ImportRequestDetail_Load(object sender, EventArgs e)
        {
            showListImportRequestDetail(dgvListImportRequestDetail);
        }
        private void showListImportRequestDetail(DataGridView dgv)
        {
            BAL_ImportRequestDetail importRequestDetail = new BAL_ImportRequestDetail();
            dgv.DataSource = importRequestDetail.showListImportRequestDetail();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtImportRequestID.Text = null;
            txtProductID.Text = null;
            txtQuantity.Text = null;
            txtSerial.Text = null;
        }

        private void dgvListImportRequestDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtImportRequestID.Text = dgvListImportRequestDetail.CurrentRow.Cells["ImportRequestId"].Value.ToString();
            txtProductID.Text = dgvListImportRequestDetail.CurrentRow.Cells["ProductId"].Value.ToString();
            txtQuantity.Text = dgvListImportRequestDetail.CurrentRow.Cells["Quantity"].Value.ToString();
            txtSerial.Text = dgvListImportRequestDetail.CurrentRow.Cells["Serial"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int importRequestId = int.Parse(txtImportRequestID.Text);
            int productId = int.Parse(txtProductID.Text);
            int quantity = int.Parse(txtQuantity.Text);
            string serial = txtSerial.Text;

            BAL_ImportRequestDetail _ImportRequestDetail = new BAL_ImportRequestDetail();
            BEL.ImportRequestDetail importRequestDetail=new BEL.ImportRequestDetail(importRequestId, productId, quantity, serial);
            bool resultAdd = _ImportRequestDetail.addImportRequestDetail(importRequestDetail);
            if (resultAdd == true)
            {
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListImportRequestDetail(dgvListImportRequestDetail);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
