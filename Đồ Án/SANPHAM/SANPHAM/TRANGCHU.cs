using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SANPHAM
{
    public partial class TRANGCHU : Form
    {
        public TRANGCHU()
        {
            InitializeComponent();
            chinhsua();
        }
        clsquanlibanhang c = new clsquanlibanhang();
        DataSet dsLoaisp = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        private void chinhsua()
        {
            pnl1.Visible = false;
            pnl2.Visible = false;
        }
        private void hidepanel()
        {
            if (pnl1.Visible == true)
                pnl1.Visible = false;
            if (pnl2.Visible == true)
                pnl2.Visible = false;
        }
        private void show(Panel a)
        {
            if (a.Visible == false)
            {
                hidepanel();
                a.Visible = true;
            }
            else
            {
                a.Visible = false;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void pnl2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void btnmau_Click(object sender, EventArgs e)
        {
            hidepanel();
        }
        private void btnsp_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void btnctsp_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void btnsize_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void btnHinhanh_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void TRANGCHU_Load(object sender, EventArgs e)
        {
            dsLoaisp = c.LayDuLieu("select * from loaisp");
            dsSanPham = c.LayDuLieu("select * from sanpham");
            //      HienthiCombobox(cboLoaiSP, dsLoaisp, "TENLOAISP", "MALOAI");
            f = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }



        private void btnhd_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void btnhdnhap_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void btnhdban_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void btnCTHDN_Click(object sender, EventArgs e)
        {

        }

        private void btnCTHDB_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            hidepanel();
        }

        private void btnctsp_Click_1(object sender, EventArgs e)
        {
            CTSP a = new CTSP();
            a.ShowDialog();
        }

        //private void btnHinhanh_Click_1(object sender, EventArgs e)
        //{
        //    HinhAnh a = new HinhAnh();
        //    a.ShowDialog();
        //}

        private void btnloaisp_Click(object sender, EventArgs e)
        {
            LoaiSP a = new LoaiSP();
            a.ShowDialog();
        }

        private void btnsize_Click_1(object sender, EventArgs e)
        {

            frmkichthuoc a = new frmkichthuoc();
            a.ShowDialog();
        }

        private void btnmau_Click_1(object sender, EventArgs e)
        {

            frmmau a = new frmmau();
            a.ShowDialog();
        }

        private void btnsp_Click_1(object sender, EventArgs e)
        {

            sanpham a = new sanpham();
            a.ShowDialog();
        }



        private void btnCTHDB_Click_1(object sender, EventArgs e)
        {
            frmHoaDonBan a = new frmHoaDonBan();
            a.ShowDialog();
        }

        private void btnCTHDN_Click_1(object sender, EventArgs e)
        {
            frmHoaDonNhap a = new frmHoaDonNhap();
            a.ShowDialog();
        }

        //private void btnhdban_Click_1(object sender, EventArgs e)
        //{
        //    HoaDonBan a = new HoaDonBan();
        //    a.ShowDialog();
        //}

        //private void btnhdnhap_Click_1(object sender, EventArgs e)
        //{
        //    HoaDonNhap a = new HoaDonNhap();
        //    a.ShowDialog();
        //}

        //private void btnhd_Click_1(object sender, EventArgs e)
        //{
        //    HinhAnh a = new HinhAnh();
        //    a.ShowDialog();
        //}

        private void btnSanPham_Click_1(object sender, EventArgs e)
        {
            show(pnl1);
        }

        private void btnHoaDon_Click_1(object sender, EventArgs e)
        {
            show(pnl2);
        }



        private void btnTim_Click(object sender, EventArgs e)
        {


        }
        void HienthiCombobox(ComboBox cbo, DataSet ds, string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = -1;
        }

        private void cboLoaiSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiSP.SelectedIndex != -1)
            {
                dgvDanhSach.Visible = true;
                string maloai = cboLoaiSP.SelectedValue.ToString();
                string sql = "select * from sanpham where maloai='" + maloai + "'";
                dsSanPham = c.LayDuLieu(sql);
                dgvDanhSach.DataSource = dsSanPham.Tables[0];
            }
        }


        private void cboTimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f)
            {
                if (cboTimkiem.SelectedIndex == 0)
                {
                    cboLoaiSP.Visible = true;
                    HienthiCombobox(cboLoaiSP, dsLoaisp, "TENLOAISP", "MALOAI");
                }
                if (cboTimkiem.SelectedIndex == 1 || cboTimkiem.SelectedIndex == 2)
                {
                    label3.Visible = false;
                    cboTimkiem.Visible = false;
                    txtTim.Visible = true;
                    cboLoaiSP.Visible = false;
                }
                if (cboTimkiem.SelectedIndex == 3)
                {
                    label4.Visible = true;
                    label5.Visible = true;
                    txtgia1.Visible = true;
                    txtgia2.Visible = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = null;
            txtTim.Focus();
            panel1.Visible = false;
            dgvDanhSach.Visible = true;
            string sql = "";
            if (cboTimkiem.SelectedIndex == 1)
            {
                string keyword = txtTim.Text.Trim();
                sql = "SELECT * FROM sanpham WHERE TENSP LIKE '%" + keyword + "%'";
            }
            if (cboTimkiem.SelectedIndex == 2)
            {
                string keyword = txtTim.Text.Trim();
                sql = "SELECT * FROM sanpham WHERE MASP LIKE '%" + keyword + "%'";
            }

            dsSanPham = c.LayDuLieu(sql);
            dgvDanhSach.DataSource = dsSanPham.Tables[0];

        }

        private void txtgia2_TextChanged(object sender, EventArgs e)
        {
            //if (int.Parse(txtgia1.Text) > int.Parse(txtgia2.Text))
            //    MessageBox.Show("Sai dữ liệu nhập", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            dgvDanhSach.DataSource = null;
            panel1.Visible = false;
            dgvDanhSach.Visible = true;
            string sql = "";
            string gia1 = txtgia1.Text;
            string gia2 = txtgia2.Text;
            if (gia1 == "")
                sql = "SELECT * FROM SANPHAM WHERE GIABANLE <= " + gia2 + "";
            else if (gia2 == "")
                sql = "SELECT * FROM SANPHAM WHERE GIABANLE >= " + gia1 + "";
            else
                sql = "SELECT * FROM SANPHAM WHERE GIABANLE >=" + gia1 + " AND GIABANLE <= " + gia2 + "";
            dsSanPham = c.LayDuLieu(sql);
            dgvDanhSach.DataSource = dsSanPham.Tables[0];
        }

        private void btnhdnhap_Click_1(object sender, EventArgs e)
        {
            frmHoaDonNhap a = new frmHoaDonNhap();
            a.ShowDialog();
        }

        private void btnhdban_Click_1(object sender, EventArgs e)
        {
            frmHoaDonBan a = new frmHoaDonBan();
            a.ShowDialog();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachhang a = new frmKhachhang();
            a.ShowDialog();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            frmNhanVien a = new frmNhanVien();
            a.ShowDialog();
        }

        private void btnquaylai_Click(object sender, EventArgs e)
        {
            txtTim.Visible = false;
            label3.Visible = true;
            cboTimkiem.Visible = true;
            txtgia1.Visible = false;
            txtgia2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNhanVien a = new frmNhanVien();
            a.ShowDialog();
        }

        private void txtgia1_TextChanged(object sender, EventArgs e)
        {

        }

     
    }
}