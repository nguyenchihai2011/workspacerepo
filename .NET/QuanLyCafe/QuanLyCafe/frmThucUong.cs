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
using System.Data.SqlClient;

namespace QuanLyCafe
{
    public partial class frmThucUong : Form
    {
        DataTable tblThucUong;
        public frmThucUong()
        {
            InitializeComponent();
        }

        private void frmThucUong_Load(object sender, EventArgs e)
        {
            txtMaThucUong.Enabled = false;
            //cboMaLoaiThucUong.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql = "Select * from tblThucUong";
            tblThucUong = Functions.GetDataToTable(sql);
            dgvThucUong.DataSource = tblThucUong;
            dgvThucUong.AllowUserToAddRows = false;
            dgvThucUong.EditMode = DataGridViewEditMode.EditProgrammatically;
            string sqlFillCombo = "Select * from tblLoaiThucUong";
            Functions.FillCombo(sqlFillCombo, cboMaLoaiThucUong, "MaLoaiThucUong", "TenLoaiThucUong");
            cboMaLoaiThucUong.SelectedIndex = -1;
            ResetValue();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaThucUong.Enabled = true;
            cboMaLoaiThucUong.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            ResetValue();
            txtMaThucUong.Focus();
        }

        private void ResetValue()
        {
            txtMaThucUong.Text = "";
            cboMaLoaiThucUong.Text = "";
            txtTenThucUong.Text = "";
            txtDonGia.Text = "";
            txtMoTa.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaThucUong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã thức uống!");
                return;
            }
            string check = "Select * from tblThucUong where MaThucUong=N'" + txtMaThucUong.Text + "'";
            if (Functions.CheckKey(check))
            {
                MessageBox.Show("Mã thức uống đã tồn tại!");
                return;
            }
            string sql = "Insert into tblThucUong Values(N'" + txtMaThucUong.Text + "', N'" + cboMaLoaiThucUong.SelectedValue + "', " +
                "N'" + txtTenThucUong.Text + "', N'" + txtDonGia.Text + "', N'" + txtMoTa.Text + "')";
            Functions.RunSQL(sql);
  
            LoadDataGridView();

            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaThucUong.Enabled = false;
            cboMaLoaiThucUong.Enabled = false;
        }

        private void dgvThucUong_Click(object sender, EventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới!");
                return;
            }
            if(dgvThucUong.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }

            txtMaThucUong.Text = dgvThucUong.CurrentRow.Cells["MaThucUong"].Value.ToString();
            cboMaLoaiThucUong.Text = dgvThucUong.CurrentRow.Cells["MaLoaiThucUong"].Value.ToString();
            txtTenThucUong.Text = dgvThucUong.CurrentRow.Cells["TenThucUong"].Value.ToString();
            txtDonGia.Text = dgvThucUong.CurrentRow.Cells["DonGia"].Value.ToString();
            txtMoTa.Text = dgvThucUong.CurrentRow.Cells["MoTa"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgvThucUong.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if(txtMaThucUong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn thức uống!");
                return;
            }
            if(txtTenThucUong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên thức uống!");
                return;
            }
            string sql = "Update tblThucUong Set MaLoaiThucUong=N'" + cboMaLoaiThucUong.Text + "'," +
                "TenThucUong=N'" + txtTenThucUong.Text + "',DonGia=N'" + txtDonGia.Text + "', " +
                "MoTa=N'" + txtMoTa.Text + "' Where MaThucUong=N'" + txtMaThucUong.Text + "'";
            Functions.RunSQL(sql);
            ResetValue();
            LoadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgvThucUong.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if(txtMaThucUong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn thức uống!");
                return;
            }
            if(MessageBox.Show("Bạn có chắc muốn xoá?","Thông báo",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "Delete tblThucUong Where MaThucUong=N'" + txtMaThucUong.Text + "'";
                Functions.RunSQL(sql);
                ResetValue();
                LoadDataGridView();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaThucUong.Enabled = false;
            cboMaLoaiThucUong.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
