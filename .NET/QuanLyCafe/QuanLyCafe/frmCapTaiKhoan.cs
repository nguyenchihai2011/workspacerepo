using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCafe.Class;

namespace QuanLyCafe
{
    public partial class frmCapTaiKhoan : Form
    {
        string uid;
        public frmCapTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnCapTaiKhoan_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtUid.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản!");
                return;
            }
            if (txtPwd.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu!");
                return;
            }
            if (txtCheckPass.Text != txtPwd.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không chính xác!");
                return;
            }
            if (cboNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên!");
                return;
            }
            sql = "Select * from tblTaiKhoan where Username='" + txtUid.Text + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại!");
                return;
            }
            try
            {
                sql = "Insert into tblTaiKhoan Values(N'" + txtUid.Text + "', N'" + txtPwd.Text + "'," +
                "N'" + cboNhanVien.Text + "', '" + false + "')";
                Functions.RunSQL(sql);
                MessageBox.Show("Cấp tài khoản thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cấp tài khoản thất bại!");
                MessageBox.Show(ex.Message);
            }



        }

        private void ResetValues()
        {
            txtUid.Text = "";
            txtPwd.Text = "";
            txtCheckPass.Text = "";
            cboNhanVien.Text = "";
        }

        private void frmCapTaiKhoan_Load(object sender, EventArgs e)
        {
        }



        public void SetUID(string uid)
        {
            this.uid = uid;
        }

        private void cboNhanVien_DropDown(object sender, EventArgs e)
        {
            string sql = "Select MaNhanVien from tblNhanVien EXCEPT Select MaNhanVien from tblTaiKhoan";
            Functions.FillCombo(sql, cboNhanVien, "MaNhanVien", "TenNhanVien");
        }
    }
}
