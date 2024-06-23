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
using System.Text.RegularExpressions;
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmDMLoaiHang : Form
    {
        DataTable tblLoaiHang;
        public frmDMLoaiHang()
        {
            InitializeComponent();
        }

        private void frmDMLoaiHang_Load(object sender, EventArgs e)
        {
            txtMaLoaiHang.Enabled = false;
            btnLuu.Enabled = false;
            btnBoQua.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT MaLoaiHang, TenLoaiHang FROM tblLoaiHang";
            tblLoaiHang = Functions.GetDataToTable(sql);
            dgvLoaiHang.DataSource = tblLoaiHang;
            dgvLoaiHang.Columns[0].HeaderText = "Mã loại hàng";
            dgvLoaiHang.Columns[1].HeaderText = "Tên loại hàng";
            dgvLoaiHang.Columns[0].Width = 100;
            dgvLoaiHang.Columns[1].Width = 300;
            dgvLoaiHang.AllowUserToAddRows = false;
            dgvLoaiHang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvLoaiHang_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế dộ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiHang.Focus();
                return;
            }

            if (tblLoaiHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            txtMaLoaiHang.Text = dgvLoaiHang.CurrentRow.Cells["MaLoaiHang"].Value.ToString();
            txtTenLoaiHang.Text = dgvLoaiHang.CurrentRow.Cells["TenLoaiHang"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnBoQua.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoQua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            ResetValue();
            txtMaLoaiHang.Enabled = true;
            txtMaLoaiHang.Focus();
        }

        private void ResetValue()
        {
            txtMaLoaiHang.Text = "";
            txtTenLoaiHang.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(!Regex.IsMatch(txtMaLoaiHang.Text, "^LH-[0-9]{4}"))
            {
                MessageBox.Show("Mã loại hàng không đúng định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLoaiHang.Focus();
                return;
            }

            if (txtTenLoaiHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenLoaiHang.Focus();
                return;
            }

            sql = "Select MaLoaiHang From tblLoaiHang where MaLoaiHang=N'" + txtMaLoaiHang.Text.Trim() + "'";

            if(Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã loại hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiHang.Focus();
                return;
            }
            sql = "INSERT INTO tblLoaiHang VALUES(N'" + txtMaLoaiHang.Text + "',N'" + txtTenLoaiHang.Text + "')";
            Functions.RunSQL(sql);
            LoadDataGridView(); 
            ResetValue();
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnBoQua.Enabled = false;
            btnLuu.Enabled = false;
            txtMaLoaiHang.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if(tblLoaiHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu được lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(txtTenLoaiHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(txtTenLoaiHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sql = "UPDATE tblLoaiHang SET TenLoaiHang=N'" + txtTenLoaiHang.Text.ToString() + "' WHERE MaLoaiHang=N'" + txtMaLoaiHang.Text.ToString() + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnBoQua.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtMaLoaiHang.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;

            if(tblLoaiHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu được lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if(txtTenLoaiHang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xoá sản phẩm?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblLoaiHang WHERE MaLoaiHang=N'" + txtMaLoaiHang.Text + "' ";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
