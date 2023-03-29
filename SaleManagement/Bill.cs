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
    public partial class Bill : Form
    {
        private string orderDate ;
        private string note;
        private int customerId;
        private string status;
        private string id;

       
        public Bill()
        {
            InitializeComponent();
        }
        public Bill(string orderDate, string note, int customerId, string status, string id):this()
        {
          
            this.customerId = customerId;
            this.note = note;
            this.orderDate = orderDate;
            this.status = status;
            this.id = id;

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Bill_Load(object sender, EventArgs e)
        {
            BAL_Customer _Customer = new BAL_Customer();
            lblMaHD.Text = this.id.ToString();
            lblTenKhachHang.Text = _Customer.getNamebyIdCustomer(this.customerId.ToString());
            lblThoiGian.Text = this.orderDate.ToString();



            //BAL_OrderDetail orderDetail = new BAL_OrderDetail();
            //dgvDsGioHang.DataSource = orderDetail.searchOrderId(id);
            //if (orderDetail.searchOrderId(id).Rows.Count > 0)
            //{
            //    dgvDsGioHang.DataSource = orderDetail.searchOrderId(id);
            //}


            BAL_OrderDetail _OrderDetail = new BAL_OrderDetail();
            DataTable dsSanPham = _OrderDetail.searchOrderId(id);
            int tong = 0;
            for (int i = 0; i < dsSanPham.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = dsSanPham.Rows[i][1].ToString();
                item.SubItems.Add(dsSanPham.Rows[i][0].ToString());//Mã sản phẩm
                item.SubItems.Add(dsSanPham.Rows[i][1].ToString());//Tên sản phẩm
                item.SubItems.Add(dsSanPham.Rows[i][2].ToString());//Đơn giá
                //item.SubItems.Add(dsSanPham.Rows[i][3].ToString());//Tồn kho
                //item.SubItems.Add(dsSanPham.Rows[i][4].ToString());//Loại sản phẩm

                tong += (int.Parse(dsSanPham.Rows[i][2].ToString()) * int.Parse(dsSanPham.Rows[i][1].ToString()));

                listGioHang.Items.Add(item); //Thêm sản phẩm này vào list

            }
            lblTongTien.Text = string.Format("{0:0,0 vnđ}", tong);

        }
        }
}
