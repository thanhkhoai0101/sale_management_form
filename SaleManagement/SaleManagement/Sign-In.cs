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
    public partial class Sign_In : Form
    {
        public Sign_In()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            BAL_Employee employee = new BAL_Employee();
            string resulf = employee.checkAccount(txtUser.Text, txtPassword.Text);
            if (resulf == "Tên tài khoản không hợp lệ!")
            {
                MessageBox.Show(resulf, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(resulf == "Mật khẩu không đúng!")
            {
                MessageBox.Show(resulf, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult kq = MessageBox.Show(resulf, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
}
