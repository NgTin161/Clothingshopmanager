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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {

        }

        clsquanlibanhang c = new clsquanlibanhang();
        DataSet dsNCC = new DataSet();
        DataSet dsLoaiSP = new DataSet();

        int flag = 0;
        int vitri = 0;
        void loaddulieu_datagrid(DataGridView d, DataSet ds)
        {
            d.DataSource = ds.Tables[0];
        }
        void xulychucnang(Boolean t)
        {
            btnthem.Enabled = t;
            btnsua.Enabled = t;
            btnxoa.Enabled = t;
            btnluu.Enabled = !t;
        }
        void xulytestbox(Boolean t)
        {
            txtmancc.ReadOnly = t;
            txtmancc.BackColor = Color.Gray;
        }




        void hienthi_textbox(DataTable dt, int vt)
        {
            txtmancc.Text = dt.Rows[vt]["MANCC"].ToString();
            txttenncc.Text = dt.Rows[vt]["TENNCC"].ToString();
            txtSDT.Text = dt.Rows[vt]["SDT"].ToString();
            txttaikhoan.Text = dt.Rows[vt]["TAIKHOAN"].ToString();
            //     txtdiachi.Text = dt.Rows[vt]["DIACHI"].ToString();
            txttenNH.Text = dt.Rows[vt]["TENNH"].ToString();
            txtlink.Text = dt.Rows[vt]["LINK"].ToString();
            txtmail.Text = dt.Rows[vt]["DCMAIL"].ToString();
            string mancc = dt.Rows[vt]["MANCC"].ToString();
            string loaisp;
            //  loaisp = dt.Rows[vt]["MALOAI"].ToString();
            //   locDuLieuCombobox(cboloaisp, dsLoaiSP, "MALOAI", "TENLOAI", loaisp);
            cbotinhtrang.SelectedIndex = 0;
            hienthi_combobox(cboloaisp, dsLoaiSP, "TENLOAISP", "MALOAI");
            ////loại sản phẩm
            //dvLoaisp.Table = dsLoaiSP.Tables[0];
            //dvLoaisp.RowFilter = "maloai = '" + maloai + "'";
            //cboloaisp.DataSource = dvLoaisp;
            //cboloaisp.DisplayMember = "tenloai";
            //cboloaisp.ValueMember = "maloai";


        }

        void hienthi_combobox(ComboBox cbo, DataSet ds, string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = -1;
        }

        void locDuLieuCombobox(DataSet ds, ComboBox cbo, string ten, string ma, string giatrima)
        {
            //loại sản phẩm
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + "  ='" + giatrima + "'";
            cbo.DataSource = dv;
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienthi_textbox(dsNCC.Tables[0], vitri);
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            string sql = "";
            if (flag == 1)
            {
                sql = "insert into nhacungcap values('" + txtmancc.Text + "','" + txttenncc.Text + "',0)";
            }
            if (flag == 2)
            {
                sql = "update nhacungcap set tenncc='" + txttenncc.Text + "', trangthai=" + cbotinhtrang.SelectedIndex + " where mancc='" + txtmancc.Text + "'";
            }
            if (flag == 3)
            {
                sql = "update nhacungcap set trangthai= 1 where mancc ='" + txtmancc.Text + "'";
            }

            if (c.capnhatdulieu(sql) > 0)
            {
                MessageBox.Show("Cập nhật thành công");
                vitri = 0;
                frmNhaCungCap_Load(sender, e);
            }
        }


        private void btnthoat_Click(object sender, EventArgs e)
        {

        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
        }

        Boolean f = false;
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            xulytestbox(true);
            xulychucnang(true);
            dsNCC = c.LayDuLieu("select * from nhacungcap where trangthai = 0");
            //  danhsach_datagridview(dgvDanhsach, "select * from nhanvien");
            dsLoaiSP = c.LayDuLieu("select * from loaisp ");
            loaddulieu_datagrid(dgvDanhSach, dsNCC);
            //            hienthi_textbox(dsNCC.Tables[0], vitri);

            hienthi_textbox(dsNCC.Tables[0], vitri);
            f = true;

        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienthi_textbox(dsNCC.Tables[0], vitri);
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string mancc = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenncc = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string sql = "update NHACUNGCAP set tenncc= N'" + tenncc + "' where masize='" + mancc + "'";
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        vitri = 0;
                        frmNhaCungCap_Load(sender, e);

                    }
                }
            }
        }

        private void frmsize_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kg = new DialogResult();
            kg = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kg == DialogResult.No)
                e.Cancel = true;
        }


        private void grbThongTin1_Enter(object sender, EventArgs e)
        {

        }
        void TAOCOTDANHSACH()
        {
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.DataSource = null;
            dgvDanhSach.Columns.Add("MANCC", "Mã NCC");
            dgvDanhSach.Columns.Add("TENNCC", "TÊN NCC");
            dgvDanhSach.Columns.Add("SDT", "SDT");
            dgvDanhSach.Columns.Add("TAIKHOANG", "TÀI KHOẢNG");
            dgvDanhSach.Columns.Add("TENNH", "TÊN NH");
            dgvDanhSach.Columns.Add("LINK", "LINK FIND");
            dgvDanhSach.Columns.Add("DCMAIL", "EMAIL");
            dgvDanhSach.Columns.Add("LOAISP", "LOẠI SP");
            dgvDanhSach.Columns.Add("TRANGTHAI", "TRẠNG THÁI");

        }
        DataSet dsloaisp = new DataSet();
        void locDuLieuCombobox(ComboBox cbo, DataSet ds, string ma, string ten, string giatrima)
        {
            //loại sản phẩm
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + "='" + giatrima + "'";
            cbo.DataSource = dv;
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
        }
        private void btnluu_Click_1(object sender, EventArgs e)
        {
            xulychucnang(true);
            string sql = "";
            try
            {
                if (flag == 1)//THÊM
                {
                    string mancc = txtmancc.Text;
                    string tenncc = txttenncc.Text;
                    string sdt = txtSDT.Text;
                    string taikhoang = txttaikhoan.Text;
                    string tennh = txttenNH.Text;
                    string link = txtlink.Text;
                    string dchi = txtmail.Text;
                    string loaisp = cboloaisp.SelectedValue.ToString();
                    string trangthai = cbotinhtrang.SelectedIndex.ToString();
                    sql = "insert into NHACUNGCAP values('" + mancc + "','" + tenncc + "','" + sdt + "','" + taikhoang + "','" + tennh + "','" + link + "','" + dchi + "','" + loaisp + "','" + trangthai + "')";
                }
                if (flag == 2)
                {
                    sql = "update nhacungcap set tenncc='" + txttenncc.Text + "' ,sdt='" + txtSDT.Text + "', taikhoan ='" + txttaikhoan.Text + "', tennh ='" + txttenNH.Text + "', link='" + txtlink.Text + "', dcmail ='" + txtmail.Text + "', loaisp ='" + cboloaisp.SelectedValue.ToString() + "' , trangthai=" + cbotinhtrang.SelectedIndex + " where mancc='" + txtmancc.Text + "'";
                }
                if (flag == 3)
                {
                    sql = "update nhacungcap set trangthai= 1 where mancc ='" + txtmancc.Text + "'";
                }

                if (c.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    vitri = 0;
                    frmNhaCungCap_Load(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string phatsinh()
        {
            string mancc = "";
            DataSet ds = c.LayDuLieu("SELECT MANCC FROM NHACUNGCAP");
            if (ds.Tables[0].Rows.Count < 150)
            {
                mancc = ("NCC" + (ds.Tables[0].Rows.Count + 1).ToString()).Replace(" ", "");
            }
            else
                mancc = ("NCC" + ds.Tables[0].Rows.Count + 1).ToString().Replace(" ", "");
            return mancc;

        }

        private void cboloaisp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnthem_Click_2(object sender, EventArgs e)
        {

            xulychucnang(false);
            xulytestbox(true);
            txtmancc.Text = phatsinh();//tự phát sinh mã
            cbotinhtrang.SelectedIndex = 0;
            //    TAOCOTDANHSACH();
            flag = 1;
        }

        private void btnxoa_Click_1(object sender, EventArgs e)
        {
            xulychucnang(false);
            flag = 3;
        }

        private void btnsua_Click_1(object sender, EventArgs e)
        {
            xulychucnang(false);
            flag = 2;
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void txtmancc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnthoat_Click_2(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (kq == DialogResult.OK)
            {
                this.Close();
            }
            xulychucnang(false);
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }


    }
}

