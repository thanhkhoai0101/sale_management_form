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
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //string id = dgvListSupplier.CurrentRow.Cells["Id"].Value.ToString();
            //int Id = int.Parse(id);
            //BAL_Supplier _Supplier = new BAL_Supplier();
            //bool resultAdd = _Supplier.deleteSupplier(Id);
        }
    }
}
