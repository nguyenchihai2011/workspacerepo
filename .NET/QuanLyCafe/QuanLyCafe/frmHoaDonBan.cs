using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;
using QuanLyCafe.Class;

namespace QuanLyCafe
{
    public partial class frmHoaDonBan : Form
    {
        string uid;
        DataTable tblCTHDB;
        public frmHoaDonBan()
        {
            InitializeComponent();
        }

        public void SetUID(string uid)
        {
            this.uid = uid;
        }


        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            btnThemHoaDon.Enabled = true;
            btnLuuHoaDon.Enabled = false;
            btnHuyHoaDon.Enabled = false;
            btnInHoaDon.Enabled = false;
            txtMaHDBan.ReadOnly = true;
            txtTenNhanVien.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            txtThanhTien.ReadOnly = true;
            txtTongTien.ReadOnly = true;
            txtTongTien.Text = "0";
            
            string sql = "Select MaNhanVien from tblTaiKhoan where Username='" + uid + "'";
            txtMaNhanVien.Text = Functions.GetFieldValues(sql);
            sql = "Select TenNhanVien from tblNhanVien where MaNhanVien='" + txtMaNhanVien.Text + "'";
            txtTenNhanVien.Text = Functions.GetFieldValues(sql);
            Functions.FillCombo("SELECT MaThucUong, TenThucUong FROM tblThucUong", cboTenThucUong, "TenThucUong", "TenThucUong");
            cboTenThucUong.SelectedIndex = -1;
            Functions.FillCombo("SELECT MaHoaDon FROM tblHoaDon", cboMaHoaDon, "MaHoaDon", "MaHoaDon");
            cboMaHoaDon.SelectedIndex = -1;
            //Hiển thị thông tin của một hóa đơn được gọi từ form tìm kiếm
            if (txtMaHDBan.Text != "")
            {
                LoadInfoHoaDon();
                btnHuyHoaDon.Enabled = true;
                btnInHoaDon.Enabled = true;
            }
            LoadDataGridView();
        }


        private void cboMaBan_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT * FROM tblBan where TrangThai = '" + false + "'", cboMaBan, "MaBan", "MaBan");
            cboMaBan.SelectedIndex = -1;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT a.MaThucUong, b.TenThucUong, a.SoLuong, b.DonGia, a.ThanhTien FROM tblChiTietHoaDon AS a, tblThucUong AS b WHERE a.MaHoaDon = N'" + txtMaHDBan.Text + "' AND a.MaThucUong=b.MaThucUong";
            tblCTHDB = Functions.GetDataToTable(sql);
            dgvHoaDonBan.DataSource = tblCTHDB;
            dgvHoaDonBan.Columns[0].HeaderText = "Mã thức uống";
            dgvHoaDonBan.Columns[1].HeaderText = "Tên thức uống";
            dgvHoaDonBan.Columns[2].HeaderText = "Số lượng";
            dgvHoaDonBan.Columns[3].HeaderText = "Đơn giá";
            dgvHoaDonBan.Columns[4].HeaderText = "Thành tiền";
            dgvHoaDonBan.Columns[0].Width = 80;
            dgvHoaDonBan.Columns[1].Width = 130;
            dgvHoaDonBan.Columns[2].Width = 80;
            dgvHoaDonBan.Columns[3].Width = 90;
            dgvHoaDonBan.Columns[4].Width = 90;
            dgvHoaDonBan.AllowUserToAddRows = false;
            dgvHoaDonBan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadInfoHoaDon()
        {
            string str;
            str = "SELECT NgayLapHoaDon FROM tblHoaDon WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'";
            dtpNgayBan.Text = Functions.GetFieldValues(str);
            str = "SELECT MaNhanVien FROM tblHoaDon WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'";
            txtMaNhanVien.Text = Functions.GetFieldValues(str);
            str = "SELECT TenNhanVien FROM tblNhanVien WHERE MaNhanVien = N'" + txtMaNhanVien.Text + "'";
            txtTenNhanVien.Text = Functions.GetFieldValues(str);
            str = "SELECT MaBan FROM tblHoaDon WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'";
            cboMaBan.Text = Functions.GetFieldValues(str);
            str = "SELECT MaLoaiBan FROM tblBan WHERE MaBan = N'" + cboMaBan.Text + "'";
            txtMaLoaiBan.Text = Functions.GetFieldValues(str);
            str = "SELECT TongTien FROM tblHoaDon WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'";
            txtTongTien.Text = Functions.GetFieldValues(str);
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(txtTongTien.Text));
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            btnHuyHoaDon.Enabled = false;
            btnLuuHoaDon.Enabled = true;
            btnInHoaDon.Enabled = false;
            btnThemHoaDon.Enabled = false;
            ResetValues();
            txtMaHDBan.Text = Functions.CreateKey("HDB");
            LoadDataGridView();
        }

        private void ResetValues()
        {
            txtMaHDBan.Text = "";
            dtpNgayBan.Text = DateTime.Now.ToShortDateString();
            cboMaBan.Text = "";
            txtTongTien.Text = "0";
            lblBangChu.Text = "Bằng chữ: ";
            txtMaThucUong.Text = "";
            cboTenThucUong.Text = "";
            txtDonGia.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "0";
        }


        private void cboMaBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboMaBan.Text == "")
            {
                txtMaLoaiBan.Text = "";
            }

            str = "Select MaLoaiBan from tblBan where MaBan=N'" + cboMaBan.SelectedValue + "'";
            txtMaLoaiBan.Text = Functions.GetFieldValues(str);
        }

        private void cboTenThucUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (cboTenThucUong.Text == "")
            {
                txtMaThucUong.Text = "";
                txtDonGia.Text = "";
            }

            str = "SELECT MaThucUong FROM tblThucUong WHERE TenThucUong =N'" + cboTenThucUong.SelectedValue + "'";
            txtMaThucUong.Text = Functions.GetFieldValues(str);
            str = "SELECT DonGia FROM tblThucUong WHERE TenThucUong =N'" + cboTenThucUong.SelectedValue + "'";
            txtDonGia.Text = Functions.GetFieldValues(str);
        }



        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg;
            if (txtSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(txtSoLuong.Text);
            if (txtDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(txtDonGia.Text);
            tt = sl * dg;
            txtThanhTien.Text = tt.ToString();
        }

        

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            string sql;
            double tong, Tongmoi;
            sql = "SELECT MaHoaDon FROM tblHoaDon WHERE MaHoaDon=N'" + txtMaHDBan.Text + "'";
            if (!Functions.CheckKey(sql))
            {

                if (cboMaBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn phải nhập bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboMaBan.Focus();
                    return;
                }
                sql = "INSERT INTO tblHoaDon(MaHoaDon, MaNhanVien, MaBan, NgayLapHoaDon, TongTien) VALUES (N'" + txtMaHDBan.Text.Trim() + "'," +
                    "N'" + txtMaNhanVien.Text + "',N'" + cboMaBan.SelectedValue + "','" + dtpNgayBan.Value + "'," + txtTongTien.Text + ")";
                Functions.RunSQL(sql);
                sql = "UPDATE tblBan SET TrangThai = '" + true + "' where MaBan = '" + cboMaBan.Text + "'";
                Functions.RunSQL(sql);
            }
            // Lưu thông tin của các mặt hàng
            if (txtMaThucUong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTenThucUong.Focus();
                return;
            }
            if ((txtSoLuong.Text.Trim().Length == 0) || (txtSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Text = "";
                txtSoLuong.Focus();
                return;
            }
            sql = "SELECT MaThucUong FROM tblChiTietHoaDon WHERE MaThucUong=N'" + txtMaThucUong.Text + "' AND MaHoaDon = N'" + txtMaHDBan.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cboTenThucUong.Focus();
                return;
            }

            sql = "INSERT INTO tblChiTietHoaDon(MaHoaDon,MaThucUong,SoLuong,ThanhTien) VALUES(N'" + txtMaHDBan.Text.Trim() + "'," +
                "N'" + txtMaThucUong.Text + "'," + txtSoLuong.Text + "," + txtThanhTien.Text + ")";
            Functions.RunSQL(sql);
            LoadDataGridView();


            // Cập nhật lại tổng tiền cho hóa đơn bán
            tong = Double.Parse(Functions.GetFieldValues("SELECT TongTien FROM tblHoaDon WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'"));
            Tongmoi = tong + Double.Parse(txtThanhTien.Text);
            sql = "UPDATE tblHoaDon SET TongTien =" + Tongmoi + " WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'";
            Functions.RunSQL(sql);
            txtTongTien.Text = Tongmoi.ToString();
            lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(Tongmoi.ToString()));
            ResetValuesHang();
            btnHuyHoaDon.Enabled = true;
            btnThemHoaDon.Enabled = true;
            btnInHoaDon.Enabled = true;
        }


        private void ResetValuesHang()
        {
            cboTenThucUong.Text = "";
            txtSoLuong.Text = "";
            txtThanhTien.Text = "0";
        }

        private void dgvHoaDonBan_DoubleClick(object sender, EventArgs e)
        {
            if (btnLuuHoaDon.Enabled == false) return;
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, tong, tongmoi;
            if (tblCTHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {

                MaHangxoa = dgvHoaDonBan.CurrentRow.Cells["MaThucUong"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dgvHoaDonBan.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dgvHoaDonBan.CurrentRow.Cells["ThanhTien"].Value.ToString());
                sql = "DELETE tblChiTietHoaDon WHERE MaHoaDon=N'" + txtMaHDBan.Text + "' AND MaThucUong = N'" + MaHangxoa + "'";
                Functions.RunSQL(sql);

                tong = Convert.ToDouble(Functions.GetFieldValues("SELECT TongTien FROM tblHoaDon WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE tblHoaDon SET TongTien =" + tongmoi + " WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'";
                Functions.RunSQL(sql);
                txtTongTien.Text = tongmoi.ToString();
                lblBangChu.Text = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tongmoi.ToString()));
                LoadDataGridView();
            }
        }


        private void btnHuyHoaDon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sql = "SELECT MaThucUong,SoLuong FROM tblChiTietHoaDon WHERE MaHoaDon = N'" + txtMaHDBan.Text + "'";
                DataTable tblHang = Functions.GetDataToTable(sql);

                sql = "DELETE tblChiTietHoaDon WHERE MaHoaDon=N'" + txtMaHDBan.Text + "'";
                Functions.RunSQL(sql);

                //Xóa hóa đơn
                sql = "DELETE tblHoaDon WHERE MaHoaDon=N'" + txtMaHDBan.Text + "'";
                Functions.RunSQL(sql);
                sql = "Update tblBan SET TrangThai = '" + false + "' where MaBan = '" + cboMaBan.Text + "'";
                Functions.RunSQL(sql);
                ResetValues();
                LoadDataGridView();
                btnHuyHoaDon.Enabled = false;
                btnInHoaDon.Enabled = false;
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Khởi động chương trình Excel
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook exBook; //Trong 1 chương trình Excel có nhiều Workbook
            COMExcel.Worksheet exSheet; //Trong 1 Workbook có nhiều Worksheet
            COMExcel.Range exRange;
            string sql;
            sql = "Update tblBan SET TrangThai = '" + false + "' where MaBan = '" + cboMaBan.Text + "'";
            Functions.RunSQL(sql);
            int hang = 0, cot = 0;
            DataTable tblThongtinHD, tblThongtinHang;
            exBook = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            exSheet = exBook.Worksheets[1];
            // Định dạng chung
            exRange = exSheet.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Đồ án CT246";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Đại học Cần Thơ - CTU";
            exRange.Range["C4:E4"].Font.Size = 16;
            exRange.Range["C4:E4"].Font.Bold = true;
            exRange.Range["C4:E4"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C4:E4"].MergeCells = true;
            exRange.Range["C4:E4"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C4:E4"].Value = "HÓA ĐƠN BÁN";
            // Biểu diễn thông tin chung của hóa đơn bán
            sql = "SELECT a.MaHoaDon, a.NgayLapHoaDon, a.TongTien, b.MaBan, c.TenNhanVien FROM tblHoaDon AS a, tblBan AS b, tblNhanVien AS c WHERE a.MaHoaDon = N'" + txtMaHDBan.Text + "' AND a.MaBan = b.MaBan AND a.MaNhanVien = c.MaNhanVien";
            tblThongtinHD = Functions.GetDataToTable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblThongtinHD.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Bàn:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblThongtinHD.Rows[0][3].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenThucUong, a.SoLuong, b.DonGia, a.ThanhTien " +
                  "FROM tblChiTietHoaDon AS a , tblThucUong AS b WHERE a.MaHoaDon = N'" +
                  txtMaHDBan.Text + "' AND a.MaThucUong = b.MaThucUong";
            tblThongtinHang = Functions.GetDataToTable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Thành tiền";
            for (hang = 0; hang < tblThongtinHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                exSheet.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblThongtinHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                    if (cot == 3) exSheet.Cells[cot + 2][hang + 12] = tblThongtinHang.Rows[hang][cot].ToString();
                }
            }
            exRange = exSheet.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = exSheet.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblThongtinHD.Rows[0][2].ToString();
            exRange = exSheet.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + Functions.ChuyenSoSangChuoi(Double.Parse(tblThongtinHD.Rows[0][2].ToString()));
            exRange = exSheet.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblThongtinHD.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Cần Thơ, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblThongtinHD.Rows[0][4];
            exSheet.Name = "Hóa đơn bán";
            exApp.Visible = true;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboMaHoaDon.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một mã hóa đơn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaHoaDon.Focus();
                return;
            }
            txtMaHDBan.Text = cboMaHoaDon.Text;
            LoadInfoHoaDon();
            LoadDataGridView();
            btnHuyHoaDon.Enabled = true;
            btnInHoaDon.Enabled = true;
            cboMaHoaDon.SelectedIndex = -1;
        }

        private void cboMaHoaDon_DropDown(object sender, EventArgs e)
        {
            Functions.FillCombo("SELECT MaHoaDon FROM tblHoaDon", cboMaHoaDon, "MaHoaDon", "MaHoaDon");
            cboMaHoaDon.SelectedIndex = -1;
        }

        private void frmHoaDonBan_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Xóa dữ liệu trong các điều khiển trước khi đóng Form
            ResetValues();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            btnThemHoaDon.Enabled = true;
            btnLuuHoaDon.Enabled = false;
            btnHuyHoaDon.Enabled=false;
            btnInHoaDon.Enabled=false;
            ResetValues();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else e.Handled = true;
        }


        public void FillMHD(string mhd)
        {
            cboMaHoaDon.Text = mhd;
        }

        private void dgvHoaDonBan_Click(object sender, EventArgs e)
        {
            txtMaThucUong.Text = dgvHoaDonBan.CurrentRow.Cells["MaThucUong"].Value.ToString();
            cboTenThucUong.Text = dgvHoaDonBan.CurrentRow.Cells["TenThucUong"].Value.ToString();
            txtDonGia.Text = dgvHoaDonBan.CurrentRow.Cells["DonGia"].Value.ToString();
            txtSoLuong.Text = dgvHoaDonBan.CurrentRow.Cells["SoLuong"].Value.ToString();
            txtThanhTien.Text = dgvHoaDonBan.CurrentRow.Cells["ThanhTien"].Value.ToString();
        }

        
    }
}


