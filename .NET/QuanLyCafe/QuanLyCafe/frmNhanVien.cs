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
using QuanLyCafe.Class;
namespace QuanLyCafe
{
    public partial class frmNhanVien : Form
    {
        DataTable tblNhanVien;
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql = "Select * from tblNhanVien";
            tblNhanVien = Functions.GetDataToTable(sql);
            dgvNhanVien.DataSource = tblNhanVien;
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            ResetValue();
        }

        private void ResetValue()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            mtbSoDienThoai.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhân viên!");
                return;
            }
            string check = "Select * from tblNhanVien where MaNhanVien=N'" + txtMaNhanVien.Text + "'";
            if (Functions.CheckKey(check))
            {
                MessageBox.Show("Mã nhân viên đã tồn tại!");
                return;
            }
            string sql = "Insert into tblNhanVien Values(N'" + txtMaNhanVien.Text + "', N'" + txtTenNhanVien.Text + "'," +
                "N'" + txtEmail.Text + "', N'" + txtDiaChi.Text + "', N'" + mtbSoDienThoai.Text + "')";
            Functions.RunSQL(sql);

            txtMaNhanVien.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            LoadDataGridView();
            ResetValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên!");
                return;
            }
            if (txtTenNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên!");
                txtTenNhanVien.Focus();
                return;
            }
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập Email!");
                txtEmail.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ!");
                txtDiaChi.Focus();
                return;
            }
            if (mtbSoDienThoai.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại!");
                mtbSoDienThoai.Focus();
                return;
            }
            string sql = "Update tblNhanVien Set TenNhanVien=N'" + txtTenNhanVien.Text + "'," +
                "Email=N'" + txtEmail.Text + "', DiaChi=N'" + txtDiaChi.Text + "', SDT=N'" + mtbSoDienThoai.Text + "'" +
                "Where MaNhanVien=N'" + txtMaNhanVien.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới!");
                return;
            }
            if(dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            txtEmail.Text = dgvNhanVien.CurrentRow.Cells["Email"].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            mtbSoDienThoai.Text = dgvNhanVien.CurrentRow.Cells["SDT"].Value.ToString();      
            mtbSoDienThoai.Text = dgvNhanVien.CurrentRow.Cells["SDT"].Value.ToString();      
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn nhân viên!");
                return;
            }
            if(MessageBox.Show("Bạn có chắc muốn xoá?","Thông báo",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "Delete tblNhanVien Where MaNhanVien=N'" + txtMaNhanVien.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
            
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaNhanVien.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            ResetValue();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
