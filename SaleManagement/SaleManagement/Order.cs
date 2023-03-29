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
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            showListOrder(dgvListOrder);
        }
        private void showListOrder(DataGridView dgv)
        {
            BAL_Order order = new BAL_Order();
            dgv.DataSource = order.showListOrder();
        }

        private void dgvListOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOrderDate.Text = dgvListOrder.CurrentRow.Cells["OrderDateTime"].Value.ToString();
            txtNote.Text = dgvListOrder.CurrentRow.Cells["Note"].Value.ToString();
            txtCustomerId.Text = dgvListOrder.CurrentRow.Cells["CustomerId"].Value.ToString();
            txtStatus.Text = dgvListOrder.CurrentRow.Cells["Status"].Value.ToString();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            txtOrderDate.Text = null ;
            txtNote.Text = null ;
            txtCustomerId.Text = null ;
            txtStatus.Text = null ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
