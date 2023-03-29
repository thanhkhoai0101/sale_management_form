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
    public partial class Statistical : Form
    {
        public Statistical()
        {
            InitializeComponent();
        }

        private void btnThongKeSP_Click(object sender, EventArgs e)
        {
            chart2.Hide();
            chart1.Show();
            BAL_Category category = new BAL_Category();
            chart1.DataSource = category.bieuDoLoaiSanPham();
            chart1.Series["Loai"].XValueMember = "Name";
            chart1.Series["Loai"].YValueMembers = "San pham ton kho";
            chart1.Titles.Add("Sản Phẩm Tồn Kho");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
        }

        private void btnSPBanChay_Click(object sender, EventArgs e)
        {
            chart1.Hide();
            chart2.Show();
            BAL_OrderDetail orderDetail = new BAL_OrderDetail();
            chart2.DataSource = orderDetail.bieuDoSanPhamBanDuoc();
            chart2.Series["product"].XValueMember = "Name";
            chart2.Series["product"].YValueMembers = "tong";
            chart2.Titles.Add("Sản Phẩm Bán Được");
            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
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
