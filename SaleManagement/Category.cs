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
    public partial class Category : Form
    {
        public int CurrentSelectedId { get; set; }
        public Category()
        {
            InitializeComponent();
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            showListCategory(dgvListCategory);
        }
        private void showListCategory(DataGridView dgv)
        {
            BAL_Category category = new BAL_Category();
            dgv.DataSource = category.showListCategory();
        }
        private bool emptyStr(string str)
        {
            if (str.Trim() == "")
                return true;
            return false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string status = cboStatus.Text;
            int parentID = int.Parse(txtParentID.Text);




            BEL.Category category = new BEL.Category(name, status, parentID);
            category.Id = CurrentSelectedId;
            BAL_Category _Category = new BAL_Category();
            string reusult = _Category.updateCategory(category);
            if (emptyStr(txtName.Text))
            {
                MessageBox.Show("Mã loại không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (emptyStr(txtParentID.Text))
            {
                MessageBox.Show("Mã loại Parent không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (reusult == "parent_err")
            {
                MessageBox.Show("Mã loại Parent không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListCategory(dgvListCategory);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string status = cboStatus.Text;
            
            if (emptyStr(name))
            {
                MessageBox.Show("Tên loại sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
         

            BEL.Category category = new BEL.Category();
            category.Name = name;
            category.Status = status;
            if(txtParentID.Text == "")
            {
                category.ParentID = 0;
            }
            else
            {
                category.ParentID = int.Parse(txtParentID.Text);
            }
            BAL_Category _Category = new BAL_Category();
            string reusult = _Category.createCategory(category);
          

            if (reusult == "name_err")
            {
                MessageBox.Show("Tên loại sản phẩm đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (reusult == "parent_err")
            {
                MessageBox.Show("Mã loại Parent không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListCategory(dgvListCategory);
            }
        }

        private void dgvListCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
       
            CurrentSelectedId = (int)dgvListCategory.CurrentRow.Cells[0].Value;

            txtName.Text = dgvListCategory.CurrentRow.Cells["Name"].Value.ToString().Trim();
            txtParentID.Text = dgvListCategory.CurrentRow.Cells["ParentID"].Value.ToString().Trim();
            cboStatus.Text = dgvListCategory.CurrentRow.Cells["Status"].Value.ToString().Trim();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (CurrentSelectedId == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa.");
                return;
            }

            BAL_Category _Category = new BAL_Category();
            bool reusult = _Category.deleteCategory(CurrentSelectedId);
            if (reusult == true)
            {
                MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showListCategory(dgvListCategory);
            }
            else
            {
                MessageBox.Show("Đã xóa thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BAL_Category category = new BAL_Category();
            dgvListCategory.DataSource = category.searchCategory(txtSearch.Text);
            if (category.searchCategory(txtSearch.Text).Rows.Count > 0)
            {
                dgvListCategory.DataSource = category.searchCategory(txtSearch.Text);
            }
            else
            {
                MessageBox.Show("Không tìm thấy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtName.Text = null;
            cboStatus.Text = null;
            txtParentID.Text = null;
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

        private void dgvListCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
