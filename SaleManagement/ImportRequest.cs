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
    public partial class ImportRequest : Form
    {
        public int CurrentSelectedId { get; set; }
        public ImportRequest()
        {
            InitializeComponent();
        }

        private void ImportRequest_Load(object sender, EventArgs e)
        {
            showListImportRequest(dgvListImportRequest);
        }
        private void showListImportRequest(DataGridView dgv)
        {
            BAL_ImportRequest import = new BAL_ImportRequest();
            dgv.DataSource = import.showListImportRequest();
        }

        private void dgvListImportRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectedId = (int)dgvListImportRequest.CurrentRow.Cells[0].Value;

            txtImportDate.Text = dgvListImportRequest.CurrentRow.Cells["ImportDate"].Value.ToString();
            txtNote.Text = dgvListImportRequest.CurrentRow.Cells["Note"].Value.ToString();
            txtStatus.Text = dgvListImportRequest.CurrentRow.Cells["Status"].Value.ToString();
            txtSupplierID.Text = dgvListImportRequest.CurrentRow.Cells["SupplierId"].Value.ToString();
            txtEmployeeID.Text = dgvListImportRequest.CurrentRow.Cells["EmployeeId"].Value.ToString();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtImportDate.Text = null;
            txtNote.Text = null;
            txtStatus.Text = null;
            txtSupplierID.Text = null;
            txtEmployeeID.Text = null;
        }
      

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime importDate = DateTime.Parse(txtImportDate.Text);
            string note = txtNote.Text;
            string status = txtStatus.Text;
            int supplierId = int.Parse(txtSupplierID.Text);
            int employeeId = int.Parse(txtEmployeeID.Text);
            BAL_ImportRequest _ImportRequest = new BAL_ImportRequest();
            BEL.ImportRequest importRequest = new BEL.ImportRequest(importDate, note, status, supplierId, employeeId);
            bool result = _ImportRequest.addImportRequest(importRequest);
            if(result== true)
            {
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListImportRequest(dgvListImportRequest);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
   
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DateTime importDate = DateTime.Parse(txtImportDate.Text);
            string note = txtNote.Text;
            string status = txtStatus.Text;
            int supplierId=int.Parse(txtSupplierID.Text);
            int employeeId=int.Parse(txtEmployeeID.Text);
            BAL_ImportRequest _ImportRequest = new BAL_ImportRequest();
            BEL.ImportRequest importRequest = new BEL.ImportRequest(importDate, note, status, supplierId, employeeId);
            importRequest.Id = CurrentSelectedId;
            bool result = _ImportRequest.updateImportRequest(importRequest);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListImportRequest(dgvListImportRequest);
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

            BAL_ImportRequest _ImportRequest = new BAL_ImportRequest();
            bool reusult = _ImportRequest.deleteImportRequest(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListImportRequest(dgvListImportRequest);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            BAL_ImportRequest importRequest = new BAL_ImportRequest();
            dgvListImportRequest.DataSource = importRequest.searchListImportRequest(int.Parse(txtSearch.Text));
            if (importRequest.searchListImportRequest(int.Parse(txtSearch.Text)).Rows.Count > 0)
            {
                dgvListImportRequest.DataSource = importRequest.searchListImportRequest(int.Parse(txtSearch.Text));
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
