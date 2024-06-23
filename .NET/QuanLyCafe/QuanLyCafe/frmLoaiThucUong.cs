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
    public partial class frmLoaiThucUong : Form
    {
        DataTable tblLoaiThucUong;
        
        public frmLoaiThucUong()
        {
            InitializeComponent();
        }

        private void frmLoaiThucUong_Load(object sender, EventArgs e)
        {
            txtMaLoaiThucUong.Enabled = false;
            btnLuu.Enabled = false;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            string sql = "Select * from tblLoaiThucUong";
            tblLoaiThucUong = Functions.GetDataToTable(sql);
            dgvLoaiThucUong.DataSource = tblLoaiThucUong;
            dgvLoaiThucUong.Columns[0].HeaderText = "Mã loại thức uống";
            dgvLoaiThucUong.Columns[1].HeaderText = "Tên loại thức uống";
            dgvLoaiThucUong.Columns[0].Width = 200;
            dgvLoaiThucUong.Columns[1].Width = 200;
            dgvLoaiThucUong.AllowUserToAddRows = false;
            dgvLoaiThucUong.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnSua.Enabled = false; 
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            ResetValue();
            txtMaLoaiThucUong.Enabled = true;
            txtMaLoaiThucUong.Focus();
        }

        private void ResetValue()
        {
            txtMaLoaiThucUong.Text = "";
            txtTenLoaiThucUong.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaLoaiThucUong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại thức uống!");
                return;
            }
            string check = "Select * from tblLoaiThucUong where MaLoaiThucUong=N'" + txtMaLoaiThucUong.Text + "'";
            if (Functions.CheckKey(check))
            {
                MessageBox.Show("Mã loại thức uống đã tồn tại!");
                return;
            }
            string sql = "Insert into tblLoaiThucUong Values(N'" + txtMaLoaiThucUong.Text + "', N'" + txtTenLoaiThucUong.Text + "')";
            Functions.RunSQL(sql);
            btnThem.Enabled = true;
            btnSua.Enabled = true; 
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            txtMaLoaiThucUong.Enabled = false;
            LoadDataGridView();
            ResetValue();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(dgvLoaiThucUong.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if(txtMaLoaiThucUong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn loại thức uống!");
                return;
            }
            if(txtTenLoaiThucUong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại thức uống!");
                return;
            }
            string sql = "Update tblLoaiThucUong SET MaLoaiThucUong=N'" + txtMaLoaiThucUong.Text + "'," +
                "TenLoaiThucUong=N'" + txtTenLoaiThucUong.Text + "' Where MaLoaiThucUong=N'" + txtMaLoaiThucUong.Text + "'";
            Functions.RunSQL(sql);
            ResetValue();
            LoadDataGridView();
        }

        private void dgvLoaiThucUong_Click(object sender, EventArgs e)
        {
            if (btnThem.Enabled ==  false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm mới!");
                return;
            }
            if(dgvLoaiThucUong.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            txtMaLoaiThucUong.Text = dgvLoaiThucUong.CurrentRow.Cells["MaLoaiThucUong"].Value.ToString();
            txtTenLoaiThucUong.Text = dgvLoaiThucUong.CurrentRow.Cells["TenLoaiThucUong"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLoaiThucUong.Rows.Count == 0)
            {
                MessageBox.Show("Dữ liệu rỗng!");
                return;
            }
            if (txtMaLoaiThucUong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn loại thức uống!");
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xoá?","Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "Delete tblLoaiThucUong Where MaLoaiThucUong=N'" + txtMaLoaiThucUong.Text + "'";
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
            txtMaLoaiThucUong.Enabled = false;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
