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
    public partial class frmQuanLyQuyen : Form
    {
        public frmQuanLyQuyen()
        {
            InitializeComponent();
        }



        private void frmQuanLyQuyen_Load(object sender, EventArgs e)
        {
             
        }

        private void cboChucNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (cboChucNang.Text == "Cấp quyền")
            {
                sql = "Select * from tblTaiKhoan where Privilege='" + false + "' and Username != '" + "admin" + "'";
            }
            else
            {
                sql = "Select * from tblTaiKhoan where Privilege='" + true + "' and Username != '" + "admin" + "'";
            }
            Functions.FillCombo(sql, cboUsername, "Username", "Username");
            cboUsername.SelectedIndex = -1;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string sql;
            if (cboChucNang.Text == "Cấp quyền")
            {
                sql = "Update tblTaiKhoan SET Privilege='" + true + "' where Username=N'" + cboUsername.Text + "'";
            }
            else
            {
                sql = "Update tblTaiKhoan SET Privilege='" + false + "' where Username=N'" + cboUsername.Text + "'";
            }
            try
            {
                Functions.RunSQL(sql);
                MessageBox.Show("Cập nhật quyền thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            frmQuanLyQuyen_Load(sender, e);
            ResetValues();

                
        }

        private void ResetValues()
        {
            cboChucNang.Text = "";
            cboUsername.Text = "";
            txtTenNhanVien.Text = "";
        }

        private void cboUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboUsername.Text == "")
            {
                txtTenNhanVien.Text = "";
            }
            string sql = "Select MaNhanVien from tblTaiKhoan where Username='" + cboUsername.SelectedValue + "'";
            txtTenNhanVien.Text = Functions.GetFieldValues(sql);
        }
    }
}
