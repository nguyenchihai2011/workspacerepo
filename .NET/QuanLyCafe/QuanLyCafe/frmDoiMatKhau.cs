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
    public partial class frmDoiMatKhau : Form
    {
        string uid;
        bool flag = false;
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMatKhauCu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ!");
                return;
            }
            if (txtMatKhauMoi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu mới!");
                return;
            }
            sql = "Select Password from tblTaiKhoan where Username='" + uid + "'";
            string matkhaucu = Functions.GetFieldValues(sql);

            if (txtMatKhauCu.Text == matkhaucu)
            {
                if (txtXacNhanMatKhau.Text != txtMatKhauMoi.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không chính xác!");
                    return;
                }
                try
                {
                    sql = "Update tblTaiKhoan Set Password=N'" + txtMatKhauMoi.Text + "' where Username='" + uid + "'";
                    Functions.RunSQL(sql);
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    flag = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public void SetUID(string uid)
        {
            this.uid = uid;
        }

        public bool GetFlag()
        {
            return flag;
        }
    }
}
