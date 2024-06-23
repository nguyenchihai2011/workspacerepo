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
    public partial class frmTKDoanhThuThang : Form
    {
        DataTable tblThongKe;

        public frmTKDoanhThuThang()
        {
            InitializeComponent();
        }

        private void frmTKDoanhThuThang_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvThongKe.DataSource = null;
        }

        private void ResetValues()
        {
            txtThang.Text = "";
            txtNam.Text = "";
            txtTongDoanhThu.Text = "0";
        }

        private void LoadDataGridView()
        {
            dgvThongKe.Columns[0].HeaderText = "Mã hoá đơn bán";
            dgvThongKe.Columns[1].HeaderText = "Ngày bán";
            dgvThongKe.Columns[2].HeaderText = "Tổng tiền";
            dgvThongKe.Columns[0].Width = 180;
            dgvThongKe.Columns[1].Width = 90;
            dgvThongKe.Columns[2].Width = 90;
            dgvThongKe.AllowUserToAddRows = false;
            dgvThongKe.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string sql = "Select MaHoaDon, NgayLapHoaDon, TongTien from tblHoaDon where 1=1";
            if (txtThang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tháng thống kê!");
                return;
            }
            if (txtNam.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm thống kê!");
                return;
            }
            sql += " AND MONTH(NgayLapHoaDon) like N'%" + txtThang.Text + "%'";
            sql += " AND YEAR(NgayLapHoaDon) like N'%" + txtNam.Text + "%'";
            tblThongKe = Functions.GetDataToTable(sql);

            if (tblThongKe.Rows.Count == 0)
            {
                MessageBox.Show("Không có hoá đơn được bán trong tháng " + txtThang.Text + " năm " + txtNam.Text);
                return;
            }
            string doanhthu = "Select SUM(TongTien) from tblHoaDon where 1=1";
            doanhthu += " AND MONTH(NgayLapHoaDon) like N'%" + txtThang.Text + "%'";
            doanhthu += " AND YEAR(NgayLapHoaDon) like N'%" + txtNam.Text + "%'";

            dgvThongKe.DataSource = tblThongKe;
            txtTongDoanhThu.Text = Functions.GetFieldValues(doanhthu);
            LoadDataGridView();
        }

        private void dgvThongKe_DoubleClick(object sender, EventArgs e)
        {
            string mahd;
            if (MessageBox.Show("Bạn có muốn hiển thị thông tin chi tiết?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mahd = dgvThongKe.CurrentRow.Cells["MaHoaDon"].Value.ToString();
                frmHoaDonBan frm = new frmHoaDonBan();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.Size = new Size(1000, 600);
                frm.Show();
                frm.FillMHD(mahd);

            }
        }

    }
}
