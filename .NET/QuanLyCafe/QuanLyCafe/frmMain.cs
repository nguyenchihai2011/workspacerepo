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
    public partial class frmMain : Form
    {
        string uid;

        public frmMain()
        {
            InitializeComponent();
        }


        public string GetUID()
        {
            return uid;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Functions.Connect();
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            uid = frm.GetUID();
        }


        private void mnuCapTaiKhoan_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmCapTaiKhoan frm = new frmCapTaiKhoan();
                frm.Show();
                frm.SetUID(uid);
            }
            else
            {
                MessageBox.Show("Bạn không có quyền cấp tài khoản!");
            }
        } 

        private void mnuQuanLyQuyenTaiKhoan_Click(object sender, EventArgs e)
        {
            if (uid == "admin")
            {
                frmQuanLyQuyen frm = new frmQuanLyQuyen();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền cấp quyền tài khoản!");
            }
        }

        private void mnuDoiMatKhau_Click_1(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.SetUID(uid);
            frm.ShowDialog();
            if (frm.GetFlag() == true)
            {
                frmMain_Load(sender, e);
            }
        }

        private void mnuDangXuat_Click_1(object sender, EventArgs e)
        {
            frmMain_Load(sender, e);
        }

        private void mnuThucUong_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmThucUong frm = new frmThucUong();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục thức uống!");
            }
        }

        private void mnuLoaiThucUong_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmLoaiThucUong frm = new frmLoaiThucUong();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục loại thức uống!");
            }
        }

        private void mnuBan_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmBan frm = new frmBan();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục bàn!");
            }
        }

        private void mnuLoaiBan_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmLoaiBan frm = new frmLoaiBan();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục loại bàn!");
            }
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmNhanVien frm = new frmNhanVien();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục nhân viên!");
            }
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan();
            frm.SetUID(uid);
            frm.ShowDialog();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan();
            frm.SetUID(uid);
            frm.ShowDialog();

        }

        private void mnuTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            frmTimHoaDon frm = new frmTimHoaDon();
            frm.ShowDialog();
        }

        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            frmTKDoanhThuThang frm = new frmTKDoanhThuThang();
            frm.ShowDialog();
        }
    }
}
