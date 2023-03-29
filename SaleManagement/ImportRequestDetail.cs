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
        public int CurrentSelectedId { get; set; }
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
            CurrentSelectedId = (int)dgvListImportRequestDetail.CurrentRow.Cells[0].Value;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int importRequestId = int.Parse(txtImportRequestID.Text);
            int productId = int.Parse(txtProductID.Text);
            int quantity = int.Parse(txtQuantity.Text);
            string serial = txtSerial.Text;
            BAL_ImportRequestDetail _ImportRequestDetail = new BAL_ImportRequestDetail();
            BEL.ImportRequestDetail importRequestDetail = new BEL.ImportRequestDetail(importRequestId, productId, quantity, serial);
            importRequestDetail.Id = CurrentSelectedId;
            bool result = _ImportRequestDetail.updateImportRequestDetail(importRequestDetail);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListImportRequestDetail(dgvListImportRequestDetail);
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

            BAL_ImportRequestDetail _ImportRequestDetail = new BAL_ImportRequestDetail();
            bool reusult = _ImportRequestDetail.deleteImportRequestDetail(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListImportRequestDetail(dgvListImportRequestDetail);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_ImportRequestDetail importRequestDetail = new BAL_ImportRequestDetail();
            dgvListImportRequestDetail.DataSource = importRequestDetail.searchListImportRequestDetail(int.Parse(txtSearch.Text));
            if (importRequestDetail.searchListImportRequestDetail(int.Parse(txtSearch.Text)).Rows.Count > 0)
            {
                dgvListImportRequestDetail.DataSource = importRequestDetail.searchListImportRequestDetail(int.Parse(txtSearch.Text));
            }
            else
            {
                MessageBox.Show("Không tìm thấy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
