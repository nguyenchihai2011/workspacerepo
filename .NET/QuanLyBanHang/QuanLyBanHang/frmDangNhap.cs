using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmDangNhap : Form
    {
        string uid;
        DataTable tblDangNhap;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            ControlBox = false;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "Select * from tblTaiKhoan where Username=N'" + txtUid.Text + "' and Password=N'" + txtPwd.Text + "'";
                tblDangNhap = Functions.GetDataToTable(sql);
                if (tblDangNhap.Rows.Count == 1)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                    uid = tblDangNhap.Rows[0]["Username"].ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!");
                    txtUid.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        public string GetUID()
        {
            return uid;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F4))
            {
                return true; 
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
