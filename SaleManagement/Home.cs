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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products prd = new Products();
            prd.ShowDialog();
            this.Close();
        }

        private void productSerialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductSerial prdsrl = new ProductSerial();
            prdsrl.ShowDialog();
            this.Close();
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Category ctgr = new Category();
            ctgr.ShowDialog();
            this.Close();
        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Order ord = new Order();
            ord.ShowDialog();
            this.Close();
        }

        private void orderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderDetail orddt = new OrderDetail();
            orddt.ShowDialog();
            this.Close();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer ctm = new Customer();
            ctm.ShowDialog();
            this.Close();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employee emp = new Employee();
            emp.ShowDialog();
            this.Close();
        }

        private void importRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImportRequest imprq = new ImportRequest();
            imprq.ShowDialog();
            this.Close();
        }

        private void importRequestDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ImportRequestDetail imprqdt = new ImportRequestDetail();
            imprqdt.ShowDialog();
            this.Close();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Supplier supp = new Supplier();
            supp.ShowDialog();
            this.Close();
        }

        private void openDangNhapToolTripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Introduce introduce = new Introduce();
            introduce.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_in sign_In = new Sign_in();
            sign_In.ShowDialog();
            this.Close();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Store store = new Store();
            store.ShowDialog();
            this.Close();
        }

        private void statisticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
           Statistical statistical = new Statistical();
            statistical.ShowDialog();
            this.Close();
        }
    }
}
