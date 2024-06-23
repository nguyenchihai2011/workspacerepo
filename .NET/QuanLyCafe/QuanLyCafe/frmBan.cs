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
    public partial class frmBan : Form
    {
        DataTable tblBan;
        public frmBan()
        {
            InitializeComponent();
        }

        private void frmBan_Load(object sender, EventArgs e)
        {
            txtMaBan.Enabled = false;
            string sql = "Select * from tblLoaiBan";
            Functions.FillCombo(sql, cboMaLoaiBan, "MaLoaiBan", "TenLoaiBan");
            cboMaLoaiBan.SelectedIndex = -1;
            LoadDataGridView();
            btnLuu.Enabled = false;
        }

        private void LoadDataGridView()
        {
            string sql = "Select MaBan, MaLoaiBan from tblBan";
            tblBan = Functions.GetDataToTable(sql);
            dgvBan.DataSource = tblBan;
            dgvBan.AllowUserToAddRows = false;
            dgvBan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ResetValue();

            txtMaBan.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void ResetValue()
        {
            txtMaBan.Text = "";
            cboMaLoaiBan.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
            if(txtMaBan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã bàn");
                return;
            }
            string check = "Select * from tblBan where MaBan=N'" + txtMaBan.Text + "'";
            if (Functions.CheckKey(check))
            {
                MessageBox.Show("Mã bàn đã tồn tại!");
                return;
            }
            string sql = "Insert into tblBan Values(N'" + txtMaBan.Text + "', N'" + cboMaLoaiBan.SelectedValue + "', '" + false + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();

            txtMaBan.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            ResetValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvBan.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if(txtMaBan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bàn!");
                return;
            }
            string sql = "Update tblBan Set MaLoaiBan=N'" + cboMaLoaiBan.SelectedValue + "' Where MaBan=N'" + txtMaBan.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();
        }

        private void dgvBan_Click(object sender, EventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới!");
                return;
            }
            if(dgvBan.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            txtMaBan.Text = dgvBan.CurrentRow.Cells["MaBan"].Value.ToString();
            cboMaLoaiBan.Text = dgvBan.CurrentRow.Cells["MaLoaiBan"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvBan.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if (txtMaBan.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bàn!");
                return;
            }
            if(MessageBox.Show("Bạn có chắc muốn xoá?","Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "Delete tblBan Where MaBan=N'" + txtMaBan.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            ResetValue();
            txtMaBan.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
