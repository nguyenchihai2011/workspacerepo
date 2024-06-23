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
    public partial class frmLoaiBan : Form
    {
        DataTable tblLoaiBan;
        public frmLoaiBan()
        {
            InitializeComponent();
        }

        private void frmLoaiBan_Load(object sender, EventArgs e)
        {
            txtMaLoaiBan.Enabled = false;
            LoadDataGridView();

            btnLuu.Enabled = false;
        }

        private void LoadDataGridView()
        {
            string sql = "Select * from tblLoaiBan";
            tblLoaiBan = Functions.GetDataToTable(sql);
            dgvLoaiBan.DataSource = tblLoaiBan;
            dgvLoaiBan.AllowUserToAddRows = false;
            dgvLoaiBan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMaLoaiBan.Enabled = true;
            txtMaLoaiBan.Focus();
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void ResetValue()
        {
            txtMaLoaiBan.Text = "";
            txtTenLoaiBan.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaLoaiBan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại bàn!");
                return;
            }
            string check = "Select * from tblLoaiBan where MaLoaiBan=N'" + txtMaLoaiBan.Text + "'";
            if (Functions.CheckKey(check))
            {
                MessageBox.Show("Mã loại bàn đã tồn tại!");
                return;
            }
            string sql = "Insert into tblLoaiBan Values(N'" + txtMaLoaiBan.Text + "', N'" + txtTenLoaiBan.Text + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            txtMaLoaiBan.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            ResetValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgvLoaiBan.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if(txtMaLoaiBan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chua chọn loại bàn!");
                return;
            }
            if(txtTenLoaiBan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại bàn!");
                return;
            }
            string sql = "Update tblLoaiBan Set MaLoaiBan=N'" + txtMaLoaiBan.Text + "', TenLoaiBan=N'" + txtTenLoaiBan.Text + "'" +
                "Where MaLoaiBan=N'" + txtMaLoaiBan.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void dgvLoaiBan_Click(object sender, EventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới!");
                return;
            }
            if(dgvLoaiBan.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            txtMaLoaiBan.Text = dgvLoaiBan.CurrentRow.Cells["MaLoaiBan"].Value.ToString();
            txtTenLoaiBan.Text = dgvLoaiBan.CurrentRow.Cells["TenLoaiBan"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(dgvLoaiBan.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
            }
            if(txtMaLoaiBan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn loại bàn!");
                return;
            }
            if(MessageBox.Show("Bạn có chắc muốn xoá?","Thông báo",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "Delete tblLoaiBan Where MaLoaiBan=N'" + txtMaLoaiBan.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMaLoaiBan.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
