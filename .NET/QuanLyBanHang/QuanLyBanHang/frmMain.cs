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

        private void mnuQuanLyQuyen_Click(object sender, EventArgs e)
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


        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.SetUID(uid);
            frm.ShowDialog();
            if (frm.GetFlag() == true)
            {
                frmMain_Load(sender, e);
            }

        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            frmMain_Load(sender, e);
        }

        private void mnuLoaiHang_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmDMLoaiHang frm = new frmDMLoaiHang();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục loại hàng!");
            }
            
        }


        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmDMHangHoa frm = new frmDMHangHoa();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục hàng hoá!");
            }
            
        }


        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmDMNhanVien frm = new frmDMNhanVien();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục nhân viên!");
            }
            
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            string sql = "Select Privilege from tblTaiKhoan where Username='" + uid + "'";
            bool privilege = Convert.ToBoolean(Functions.GetFieldValues(sql));
            if (privilege == true)
            {
                frmDMKhachHang frm = new frmDMKhachHang();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập danh mục khách hàng!");
            }
            
        }

        private void mnuHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDonBan frm = new frmHoaDonBan();
            frm.SetUID(uid);
            frm.ShowDialog();
        }



        private void mnuTimKiemHoaDon_Click_1(object sender, EventArgs e)
        {
            frmTimHDBan frm = new frmTimHDBan();
            frm.ShowDialog();
        }


        private void mnuThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThuThang frm = new frmThongKeDoanhThuThang();
            frm.ShowDialog();
        }



        private void mnuGoiY_Click(object sender, EventArgs e)
        {
            frmGoiYMuaHang frm = new frmGoiYMuaHang();
            frm.ShowDialog();
        }

        
    }
}
