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
using QuanLyBanHang.Class;

namespace QuanLyBanHang
{
    public partial class frmGoiYMuaHang : Form
    {
        DataTable tblGoiYMuaHang;
        public frmGoiYMuaHang()
        {
            InitializeComponent();
        }

        private void frmGoiYMuaHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgvGoiY.DataSource = null;
        }

        private void ResetValues()
        {
            txtTien.Text = "";
            txtTien.Focus();
        }

        private void LoadDataGridView()
        {
            dgvGoiY.Columns[0].HeaderText = "Mã hàng";
            dgvGoiY.Columns[1].HeaderText = "Tên hàng";
            dgvGoiY.Columns[2].HeaderText = "Loại hàng";
            dgvGoiY.Columns[3].Visible = false;
            dgvGoiY.Columns[4].Visible = false;
            dgvGoiY.Columns[5].HeaderText = "Đơn giá bán";
            dgvGoiY.Columns[6].HeaderText = "Calo";
            dgvGoiY.Columns[7].Visible = false;
            dgvGoiY.Columns[8].HeaderText = "Ghi chú";
            dgvGoiY.Columns[9].HeaderText = "Số lượng";
            dgvGoiY.Columns[10].Visible = false;
            dgvGoiY.Columns[0].Width = 80;
            dgvGoiY.Columns[1].Width = 140;
            dgvGoiY.Columns[2].Width = 80;
            dgvGoiY.Columns[5].Width = 100;
            dgvGoiY.Columns[6].Width = 100;
            dgvGoiY.Columns[8].Width = 300;
            dgvGoiY.Columns[9].Width = 100;
            dgvGoiY.AllowUserToAddRows = false;
            dgvGoiY.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btnTimLai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgvGoiY.DataSource = null;
        }

        private void txtTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM tblHang ORDER BY DonGia DESC";
            tblGoiYMuaHang = Functions.GetDataToTable(sql);
            int soluongdovatluutru = tblGoiYMuaHang.Rows.Count;
            float sotienkhachco = float.Parse(txtTien.Text.ToString());
            float CT;
            float TGT;
            float sotienconlai;
            float GLNTT;
            int[] x = new int[100];
            Tao_Nut_Goc(sotienkhachco, out sotienconlai, out CT, out GLNTT, out TGT, float.Parse(tblGoiYMuaHang.Rows[0][10].ToString()));
            Nhanh_Can(0, ref TGT, ref CT, ref sotienconlai, ref GLNTT, x, soluongdovatluutru);
            dgvGoiY.DataSource = tblGoiYMuaHang;
            LoadDataGridView();


        }

        private void Tao_Nut_Goc(float sotienkhachco, out float sotienconlai, out float CT, out float GLNTT, out float TGT, float DG_Max)
        {
            TGT = 0.0f;
            sotienconlai = sotienkhachco;
            CT = sotienconlai * DG_Max;  
            GLNTT = 0.0f;
        }

        private int min(int a, int b)
        {
            return a < b ? a : b;
        }

        private void Cap_Nhat_GLNTT(float TGT, ref float GLNTT, int[] x, int n)
        {
            int i;
            if (GLNTT < TGT)
            {
                GLNTT = TGT;
                for (i = 0; i < n; i++)
                    //tblGoiYMuaHang.Rows[i][9] = x[i];
                    tblGoiYMuaHang.Rows[i]["PhuongAn"] = x[i];
            }
        }


        private void Nhanh_Can(int i, ref float TGT, ref float CT, ref float sotienconlai, ref float GLNTT, int[] x, int n)
        {
            int j;  
            int yk;
            yk = min(int.Parse(tblGoiYMuaHang.Rows[i][3].ToString()), (int)sotienconlai / int.Parse(tblGoiYMuaHang.Rows[i][5].ToString()));
            for (j = yk; j >= 0; j--)
            {   
                TGT = TGT + j * float.Parse(tblGoiYMuaHang.Rows[i]["Calo"].ToString());
                sotienconlai = sotienconlai - (j * float.Parse(tblGoiYMuaHang.Rows[i]["DonGiaBan"].ToString()));
                if (i == n - 1) CT = TGT;
                else CT = TGT + sotienconlai * float.Parse(tblGoiYMuaHang.Rows[i+1]["DonGia"].ToString());

                if (CT > GLNTT)
                {                   
                    x[i] = j;
                    if ((i == n - 1) || (sotienconlai == 0))     
                        Cap_Nhat_GLNTT(TGT, ref GLNTT, x , n);
                    else
                        Nhanh_Can(i + 1,ref TGT,ref CT,ref sotienconlai,ref GLNTT, x , n); 
                }
                
                x[i] = 0;
                TGT = TGT - j * float.Parse(tblGoiYMuaHang.Rows[i]["Calo"].ToString());
                sotienconlai = sotienconlai + j * float.Parse(tblGoiYMuaHang.Rows[i]["DonGiaBan"].ToString());      
            }
        }
    }
}
