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
    public partial class Supplier : Form
    {
        public int CurrentSelectedId { get; set; }
        public Supplier()
        {
            InitializeComponent();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            showListSupplier(dgvListSupplier);
        }
        private void showListSupplier(DataGridView dgv)
        {
            BAL_Supplier supplier = new BAL_Supplier();
            dgv.DataSource = supplier.showListSupplier();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtName.Text = null;
            txtAddress.Text = null;
            txtStatus.Text = null;
        }

        private void dgvListSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrentSelectedId = (int)dgvListSupplier.CurrentRow.Cells[0].Value;

            txtName.Text = dgvListSupplier.CurrentRow.Cells["Name"].Value.ToString();
            txtAddress.Text = dgvListSupplier.CurrentRow.Cells["Address"].Value.ToString();
            txtStatus.Text = dgvListSupplier.CurrentRow.Cells["Status"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name=txtName.Text;
            string address=txtAddress.Text;
            string status=txtStatus.Text;
            BAL_Supplier _Supplier=new BAL_Supplier();
            BEL.Supplier supplier= new BEL.Supplier(name,address,status);
            bool resultAdd= _Supplier.addSupplier(supplier);
            if (resultAdd == true)
            {
                MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListSupplier(dgvListSupplier);
            }
            else
            {
                MessageBox.Show("Đã thêm thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string address = txtAddress.Text;
            string status = txtStatus.Text;
            BAL_Supplier _Supplier = new BAL_Supplier();
            BEL.Supplier supplier = new BEL.Supplier(name, address, status);
            supplier.Id = CurrentSelectedId;
            bool result=_Supplier.updateSupplier(supplier);
            if (result == true)
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListSupplier(dgvListSupplier);
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

            BAL_Supplier _Supplier = new BAL_Supplier();
            bool reusult = _Supplier.deleteSupplier(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListSupplier(dgvListSupplier);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_Supplier supplier = new BAL_Supplier();
            dgvListSupplier.DataSource = supplier.searchListSupplier(txtSearch.Text);
            if (supplier.searchListSupplier(txtSearch.Text).Rows.Count > 0)
            {
                dgvListSupplier.DataSource = supplier.searchListSupplier(txtSearch.Text);
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
