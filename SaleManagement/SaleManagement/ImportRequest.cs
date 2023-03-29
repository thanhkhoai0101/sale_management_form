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
        public ImportRequest()
        {
            InitializeComponent();
        }

        private void ImportRequest_Load(object sender, EventArgs e)
        {
            showListImportRequeste(dgvListImportRequest);
        }
        private void showListImportRequeste(DataGridView dgv)
        {
            BAL_ImportRequest import = new BAL_ImportRequest();
            dgv.DataSource = import.showListImportRequest();
        }

        private void dgvListImportRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            

        }
    }
}
