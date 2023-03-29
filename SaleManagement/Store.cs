using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BAL;
using BEL;
namespace SaleManagement
{
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
        }

        private void BanHang_Load(object sender, EventArgs e)
        {
            HienDanhSachSanPham();
        }
        private SqlConnection Conn = new SqlConnection(@"Data Source =DESKTOP-M2GUH4I;Initial Catalog = sale_management;Integrated Security=True;MultipleActiveResultSets=true;");
        private void HienDanhSachSanPham()
        {
            DataTable dsSanPham = new DataTable();
            string sql = "SELECT ID, Name, SalePrice, StockQuantity, CategoryId, Image FROM Product";
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();
            SqlCommand Cmd = new SqlCommand(sql, Conn);
            SqlDataReader rd = Cmd.ExecuteReader();
            dsSanPham.Load(rd);

            ImageList list = new ImageList();
            list.ImageSize = new Size(90, 90); 
         
            for (int i = 0; i < dsSanPham.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dsSanPham.Rows[i][1].ToString();
                item.SubItems.Add(dsSanPham.Rows[i][0].ToString());
                item.SubItems.Add(dsSanPham.Rows[i][1].ToString());
                item.SubItems.Add(dsSanPham.Rows[i][2].ToString());
                item.SubItems.Add(dsSanPham.Rows[i][3].ToString());
                item.SubItems.Add(dsSanPham.Rows[i][4].ToString());
                
                string img = dsSanPham.Rows[i][5].ToString();
                list.Images.Add(Image.FromFile(img));
                item.ImageIndex = i;
                listSanPham.Items.Add(item); 
            }
            listSanPham.LargeImageList = list;
        }
        private Random random = new Random();
     
        public string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void txtMa_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void listSanPham_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem SelectedItem = listSanPham.SelectedItems[0];
            txtMa.Text = SelectedItem.SubItems[1].Text;
            txtTen.Text = SelectedItem.SubItems[2].Text;
            txtGia.Text = SelectedItem.SubItems[3].Text;
            txtTonKho.Text = SelectedItem.SubItems[4].Text;
            cboLoaiSp.Text = SelectedItem.SubItems[5].Text;
        }

        private void listSanPham_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int SoLuong = 1;
        
            ListViewItem item = new ListViewItem();
            item.Text = txtMa.Text;
            item.SubItems.Add(txtTen.Text);
            item.SubItems.Add(SoLuong.ToString());
            item.SubItems.Add(txtGia.Text);
            item.SubItems.Add(cboLoaiSp.Text);

         
            foreach (ListViewItem it in listGioHang.Items)
            {
                if (it.Text == item.Text)
                {
                    SoLuong += int.Parse(it.SubItems[2].Text);
                    it.SubItems[2].Text = SoLuong.ToString();
                    return;
                }
            }
       
            listGioHang.Items.Add(item); 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListViewItem SelectedItem = listGioHang.SelectedItems[0];
            DialogResult dialog = MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                listGioHang.Items.Remove(SelectedItem);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            if(txtEmailCustomer.Text == "")
            {
                MessageBox.Show("Xin vui lòng nhập email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BAL_Customer _Customer = new BAL_Customer();
                string mahd = RandomString(3);
                DateTime ngaylap = DateTime.Now;
                int customerId = int.Parse(_Customer.getIDbyEmailCustomer(txtEmailCustomer.Text));
                string note = txtNote.Text;
                string status = "DRAFF";

                BAL_Order _Order = new BAL_Order();
                BEL.Order order = new BEL.Order(mahd, ngaylap, note, customerId, status);
                bool addOrder = _Order.addOrder(order);

                if (addOrder == true)
                {
                    MessageBox.Show("Đã thanh toán thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Order.showListOrder();
                }

                bool resultAdd = false;
                foreach (ListViewItem it in listGioHang.Items)
                {
                    int masp = int.Parse(it.SubItems[0].Text);
                    int soluong = int.Parse(it.SubItems[2].Text);
                    int gia = int.Parse(it.SubItems[3].Text);
                    string orderID = mahd;


                    BAL_OrderDetail _orderDetail = new BAL_OrderDetail();
                    BEL.OrderDetail orderDetail = new BEL.OrderDetail(orderID, masp, soluong, gia);

                    resultAdd = _orderDetail.addOrderDetail(orderDetail);
                    if (resultAdd == true)
                    {
                        _orderDetail.showListOrderDetail();
                    }

                }
                if (addOrder == true && resultAdd == true)
                {
                    DialogResult kq = MessageBox.Show("Bạn có muốn xem hóa đơn không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (kq == DialogResult.Yes)
                    {
                        this.Hide();
                        Order order1 = new Order();
                        order1.ShowDialog();
                        this.Close();
                    }
                }
            }


        }

        private void listGioHang_SelectedIndexChanged(object sender, EventArgs e)
        {

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
