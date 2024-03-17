using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SANPHAM
{
    public partial class sanpham : Form
    {
        public sanpham()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();
        DataSet ds = new DataSet();
        void danhsach_Datagirdview(DataGridView d, string sql)
        {

            ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }
        private void lblMaSanPham_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblHinhAnh_Click(object sender, EventArgs e)
        {

        }

        private void txtmaSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttenSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttenNCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaLoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGiaLe_TextChanged(object sender, EventArgs e)
        {

        }

        private void grbChonGia_Enter(object sender, EventArgs e)
        {

        }

        private void grbThemAnh_Enter(object sender, EventArgs e)
        {

        }

        private void txtmaSP_Click(object sender, EventArgs e)
        {

        }

        private void grbThongTin2_Enter(object sender, EventArgs e)
        {

        }

        private void grbThongTin1_Enter(object sender, EventArgs e)
        {

        }

        private void lblTrangThai_Click(object sender, EventArgs e)
        {

        }

        private void txtGiaLe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void radAo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }
        void xukychucnang(bool t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không ? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (kq == DialogResult.No)
                     e.Cancel = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xukychucnang(false);
            xulytestbox(false);
            cbotrangthai.SelectedIndex = 0;
            txtmaSP.Text = phatsinh();
        }
        void xulytestbox(Boolean t)
        {
            txtmaSP.ReadOnly = t;
        }
        string phatsinh()
        {
            string masize = "";
            masize = "M0" + (ds.Tables[0].Rows.Count + 1).ToString();//phat sinh mã trong dataset

            return masize;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            xulytestbox(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulytestbox(false);

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            xukychucnang(true);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xukychucnang(true);
            xulytestbox(true);
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            xukychucnang(true);
            danhsach_Datagirdview(dgvDanhSach, "select * from sanpham");
            loaddulieu_datagrid(dgvDanhSach, ds);
        }
        void loaddulieu_datagrid(DataGridView d, DataSet ds)
        {
            d.DataSource = ds.Tables[0];
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int vitri = 0;

        void hien_click(DataSet d,int vt)
        {
            txtmaSP.Text = ds.Tables[0].Rows[vt]["masp"].ToString();
            txttenNCC.Text = ds.Tables[0].Rows[vt]["tenncc"].ToString();
            txttenSP.Text = ds.Tables[0].Rows[vt]["tensp"].ToString();
            txtSoLuong.Text = ds.Tables[0].Rows[vt]["soluong"].ToString();
            txtMoTa.Text = ds.Tables[0].Rows[vt]["mota"].ToString();
            txtMaLoai.Text = ds.Tables[0].Rows[vt]["maloai"].ToString();
            txtGiaLe.Text = ds.Tables[0].Rows[vt]["giale"].ToString();
            lbldvt.Text = ds.Tables[0].Rows[vt]["dvtinh"].ToString();

        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hien_click(ds, vitri);
        }

        private void lblSoLuong_Click(object sender, EventArgs e)
        {

        }
    }
}
