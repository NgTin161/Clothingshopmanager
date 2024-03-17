
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SANPHAM
{
    public partial class frmHoaDonNhap : Form
    {
        public frmHoaDonNhap()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grbThongTin1_Enter(object sender, EventArgs e)
        {

        }
        clsquanlibanhang c = new clsquanlibanhang();
        DataSet ds = new DataSet();
        DataSet dshoadonnhap = new DataSet();
        DataSet dsnhanvien = new DataSet();
        DataSet dssanpham = new DataSet();
        DataSet ctsanpham = new DataSet();
        DataSet dsncc = new DataSet();
        DataSet dsmau = new DataSet();
        DataSet dscthdn = new DataSet();

        int vitri = 0;
        int vitri_HDN = 0;
        Boolean f = false;

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            vitri_HDN = e.RowIndex;
            hienthitextbox(dshoadonnhap.Tables[0], vitri);
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            int i;
            i = dgvDanhSach.CurrentRow.Index;
            cbotinhtrang.SelectedItem = dgvDanhSach.Rows[i].Cells[7].Value.ToString();

            hienthitextbox(dshoadonnhap.Tables[0], vitri);

        }
        string phatsinh()
        {
            string mahd = "";
            DataSet ds = c.LayDuLieu("SELECT MAHD FROM HOADONNHAP");
            if (ds.Tables[0].Rows.Count < 150)
            {
                mahd = ("HD" + (ds.Tables[0].Rows.Count + 1).ToString()).Replace(" ", "");
            }
            else
                mahd = ("HD" + ds.Tables[0].Rows.Count + 1).ToString().Replace(" ", "");
            return mahd;

        }
        void loaddulieu_datagrid(DataGridView d, string sql)
        {
            dshoadonnhap = c.LayDuLieu(sql);
            d.DataSource = dshoadonnhap.Tables[0];
        }
        private void txtmahd_TextChanged(object sender, EventArgs e)
        {

        }
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
        void HienthiCombobox(ComboBox cbo, DataSet ds, string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = -1;
        }

        void xulychucnang(Boolean t)
        {
            btnThem.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnLuu.Enabled = !t;
        }

        void xulytestbox(Boolean t)
        {
            lblck.Enabled = false;
            txttongsoluong.Enabled = false;
            txttongtien.Enabled = false;
            txttongsoluong.Clear();
            txttongtien.Clear();

        }
        void hienthitextbox(DataTable dt, int vt)
        {

            txttongtien.Text = dt.Rows[vt]["THANHTIEN"].ToString();
            txttongsoluong.Text = dt.Rows[vt]["SOLUONG"].ToString();
            txtmahd.Text = dt.Rows[vt]["MAHD"].ToString();
            string manv, mancc;
            manv = dt.Rows[vt]["MANV"].ToString();
            mancc = dt.Rows[vt]["MANCC"].ToString();
            txtma.Text = manv;
            txtmancc.Text = mancc;
            locDuLieuCombobox(cbotennv, dsnhanvien, "MANV", "TENNV", manv);
            locDuLieuCombobox(cboncc, dsncc, "MANCC", "TENNCC", mancc);
            string masp;
            //masp = dt.Rows[vt]["MASP"].ToString();
           // locDuLieuCombobox(cbotensp, dssanpham, "MASP", "TEN", masp);
            cbotinhtrang.SelectedIndex = 0;
            dtpngaylap.Text = dt.Rows[vt]["NGAYLAPHD"].ToString();
            load_CTHDBtheoMAHD(dt.Rows[vt]["MAHD"].ToString());
        }
        void load_CTHDBtheoMAHD(string mahd)
        {
            string s = "select * from ct_hoadonnhap where mahd='" + mahd + "'";
            dscthdn = c.LayDuLieu(s);
            dgvcthdn.DataSource = null;
            dgvcthdn.Columns.Clear();
            dgvcthdn.DataSource = dscthdn.Tables[0];

        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            xulytestbox(false);
            txtmahd.Text = phatsinh();
            xulychucnang(false);
            cbotinhtrang.SelectedIndex = 0;
            HienthiCombobox(cbotensp, dssanpham, "TENSP", "MASP");
            HienthiCombobox(cbotennv, dsnhanvien, "TEN", "MANV");
            HienthiCombobox(cboncc, dsncc, "TENNCC", "MANCC");
            HienthiCombobox(cbomau, dsmau, "TENMAU", "MAMAU");

            TaoCotHDN_Them();
            //TaoCotCTHDN();
            flag = 1;
        }

        private void txtdongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void lblck_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
            string sql = "";
            if (flag == 1)//THÊM
            {
                lblck.Text = "-0.3";
                string mahd = txtmahd.Text;
                string tensp = cbotensp.SelectedValue.ToString();
                string mancc = cboncc.SelectedValue.ToString().Trim();
                string soluong = txttongsoluong.Text;
                string tennv = cbotennv.SelectedValue.ToString();
                string ngayvaolam = dtpngaylap.Value.ToString("MM/dd/yyyy");
                string tongtien = txttongtien.Text;
                string chietkhau = lblck.Text;
                string trangthai = cbotinhtrang.SelectedIndex.ToString();
                sql = "insert into HOADONNHAP values('" + mahd + "','" + tennv + "','" + mancc + "','" + ngayvaolam + "','" + soluong;
                sql += "','" + tongtien + "','" + chietkhau + "','" + trangthai + "','" + tensp + "')";
                if (c.capnhatdulieu(sql) > 0)
                {
                    string sqlCTSP = "";
                    for (int i = 0; i < dgvcthdn.Rows.Count - 1; i++)
                    {

                        string mactsp = dgvcthdn.Rows[i].Cells[0].Value.ToString();
                        string hd = dgvcthdn.Rows[i].Cells[1].Value.ToString();
                        string sp = dgvcthdn.Rows[i].Cells[2].Value.ToString();
                        string ncc = dgvcthdn.Rows[i].Cells[3].Value.ToString();
                        string sluong = dgvcthdn.Rows[i].Cells[4].Value.ToString();
                        string dgia = dgvcthdn.Rows[i].Cells[5].Value.ToString();
                        string trangthai1 = "0";
                        string macthdn1 = "";
                        string macthdn2 = "";
                        sqlCTSP = "insert into CT_HOADONNHAP values('" + hd + "','" + sp + "','" + ncc + "','" + mactsp;
                        sqlCTSP += "'," + sluong + "," + dgia + ",0)";
                        macthdn2 = "UPDATE CT_SANPHAM SET SOLUONG+= " + sluong + "WHERE MACTSP = '" + mactsp + "'AND MASP='" + sp + "'";
                        macthdn1 = "UPDATE SANPHAM SET SOLUONG+= " + sluong + "WHERE MASP = '" + sp + "'";

                        //  string thanhtien = "";
                        //thanhtien = "UPDATE HOADONNHAP SET THANHTIEN+= " + dgia + " WHERE MAHD = '" + hd + "'";
                        c.capnhatdulieu(macthdn1);
                        c.capnhatdulieu(macthdn2);
                        //  c.capnhatdulieu(thanhtien);
                        if (c.capnhatdulieu(sqlCTSP) > 0)
                        {
                            MessageBox.Show("cập nhật thành công", "thông báo");
                        }

                    }
                    MessageBox.Show("Cập nhật thành công");

                }
            }
            if (flag == 3)//XÓA
            {
                sql = "update hoadonnhap set trangthai= 1 where mahd='" + txtmahd.Text + "'";
                c.capnhatdulieu(sql);
                if (c.capnhatdulieu(sql) > 0)
                {
                    string sqlCTSP = "update CT_HOADONNHAP set trangthai = 1 where mahd ='" + txtmahd.Text + "'";

                    MessageBox.Show("Xóa thành công");



                }


            }
            frmHoaDonNhap_Load(sender, e);
            flag = 0;

        }
        void TaoCotCTHDN()
        {

            dgvDanhSach.Columns.Clear();
            dgvcthdn.DataSource = null;
            dgvcthdn.Columns.Add("MACTSP", "mã CTSP");
            dgvcthdn.Columns.Add("MAHD", "mã hóa đơn");
            dgvcthdn.Columns.Add("MASP", "mã sản phẩm");
            dgvcthdn.Columns.Add("MANCC", "mã nhà cung cấp ");
            dgvcthdn.Columns.Add("SOLUONG", "số lượng");
            dgvcthdn.Columns.Add("THANHTIEN", "Giá");
        }
        void TaoCotHDN_Them()
        {
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.DataSource = null;
            dgvDanhSach.Columns.Add("MAHD", "Mã HĐ");
            dgvDanhSach.Columns.Add("MANV", "Mã NV");
            dgvDanhSach.Columns.Add("MANCC", "Mã NCC");
            dgvDanhSach.Columns.Add("TRANGTHAI", "Trạng Thái");
            dgvDanhSach.Columns.Add("NGAYLAPHD", "Ngày Lập");
            dgvDanhSach.Columns.Add("MASP", "Mã SP");


        }
        void TaoCotHDN()
        {
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.DataSource = null;
            dgvDanhSach.Columns.Add("MAHD", "Mã HĐ");
            dgvDanhSach.Columns.Add("MANV", "Mã NV");
            dgvDanhSach.Columns.Add("MANCC", "Mã NCC");
            dgvDanhSach.Columns.Add("TRANGTHAI", "Trạng Thái");
            dgvDanhSach.Columns.Add("NGAYLAPHD", "Ngày Lập");
            dgvDanhSach.Columns.Add("THANHTIEN", "Giá");
            dgvDanhSach.Columns.Add("SOLUONG", "Số Lượng");
            dgvDanhSach.Columns.Add("CHIETKHAU", "Chiết Khấu");
            dgvDanhSach.Columns.Add("MASP", "Mã SP");

        }

        private void lbldiachi_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không ? ", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (kq == DialogResult.OK)
            {
                this.Close();
            }

        }

        private void frmHoaDonNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có muốn thoát không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (kq == DialogResult.No)
                e.Cancel = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult kq = MessageBox.Show("Bạn muốn xóa ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (kq == DialogResult.Yes)
            {
                flag = 3;
                xulychucnang(false);
            }

        }
        int flag = 0;
        private void btnSua_Click(object sender, EventArgs e)
        {
            txtmactsp.Visible = true;
            loaddulieu_datagrid(dgvcthdn, "select * from ct_hoadonnhap where mahd='" + txtmahd.Text + "'");
            xulytestbox(false);
            xulychucnang(false);
            cbotinhtrang.SelectedIndex = 0;
            HienthiCombobox(cbotensp, dssanpham, "TENSP", "MASP");
            HienthiCombobox(cbotennv, dsnhanvien, "TEN", "MANV");
            HienthiCombobox(cboncc, dsncc, "TENNCC", "MANCC");
            HienthiCombobox(cbomau, dsmau, "TENMAU", "MAMAU");
            flag = 2;
        }

        private void frmHoaDonNhap_Load(object sender, EventArgs e)
        {
            xulychucnang(true);
            xulytestbox(true);
            loaddulieu_datagrid(dgvDanhSach, "select * from hoadonnhap where TRANGTHAI=0");
            dsnhanvien = c.LayDuLieu("select * from nhanvien");
            dssanpham = c.LayDuLieu("select * from sanpham");
            dsncc = c.LayDuLieu("select * from nhacungcap");
            dsmau = c.LayDuLieu("select * from mau");
            hienthitextbox(dshoadonnhap.Tables[0], vitri);
            hienthi_textboxCTHD(dscthdn.Tables[0], vitri);
            f = true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txttongtien_TextChanged(object sender, EventArgs e)
        {

        }




        private void grbThongTin2_Enter(object sender, EventArgs e)
        {

        }

        private void btnanh_Click(object sender, EventArgs e)
        {
            //OpenFileDialog o = new OpenFileDialog();
            //o.InitialDirectory = Path.GetFullPath("anhcuahang") + @"\";
            //o.ShowDialog();
            //string tenfile = o.FileName;
            //string[] tenhinh = tenfile.Split('\\');
            //txttenhinh.Text = tenhinh[8];
            //taoanh_tufileanh(picHinhDaiDien, tenfile);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        // Khởi tạo vitri với giá trị mặc định -1

        private void dgvcthdn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = e.RowIndex;
                hienthi_textboxCTHD(dscthdn.Tables[0], vitri);
            }
            catch (IndexOutOfRangeException ex)
            {
                // Xử lý hoặc bỏ qua lỗi
            }
        }

        private void dgvcthdn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = e.RowIndex;
                hienthi_textboxCTHD(dscthdn.Tables[0], vitri);
            }
            catch (IndexOutOfRangeException ex)
            {
                // Xử lý hoặc bỏ qua lỗi
            }
        }

        void hienthi_textboxCTHD(DataTable dt, int vt)
        {
            txtmactsp.Text = dt.Rows[vt]["MACTSP"].ToString();
            txtsluong.Text = dt.Rows[vt]["SOLUONG"].ToString();
            string gia = dt.Rows[vt]["DONGIA"].ToString();
            string numberString = gia.Replace(".", "");
            txtgia.Text = numberString;
            DataSet ds2 = new DataSet();
            ds2 = c.LayDuLieu("select * from ct_sanpham where mactsp='" + txtmactsp.Text + "'");
            string tenhinh = ds2.Tables[0].Rows[0]["anh"].ToString();
            string duongdan = Path.GetFullPath("anhcuahang") + @"\" + tenhinh;
            taoanh_tufileanh(picHinh, duongdan);
            string input = txtmactsp.Text;
            string[] parts = input.Split('.');
            string masp = parts[0];
            locDuLieuCombobox(cbomau, dsmau, "MAMAU", "TENMAU", parts[1]);

            DataSet dsSize = new DataSet();
            dsSize = c.LayDuLieu("select * from size where masize = '" + parts[2] + "'");
            if (dsSize.Tables[0].Rows.Count > 0)
                txttensize.Text = dsSize.Tables[0].Rows[0]["TENSIZE"].ToString();
            DataSet ds = new DataSet();
            ds = c.LayDuLieu("select * from sanpham where masp='" + masp + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //  txtmasp.text = masp;
                cbotensp.Text = ds.Tables[0].Rows[0]["tensp"].ToString();
                //    txtgia.text = ds.tables[0].rows[0]["giabanle"].tostring();
                //   string tenhinh = ds.tables[0].rows[0]["anh"].tostring();
                //   string duongdan = path.getfullpath("anhcuahang") + @"\" + tenhinh;
                //    txttenhinh.text = tenhinh;
                //  taoanh_tufileanh(pichinhdaidien, duongdan);
            }

        }
        private void txttongsoluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnthem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbotensp.SelectedIndex == -1 || cboncc.SelectedIndex == -1 || cbotennv.SelectedIndex == -1)
                {
                    MessageBox.Show("Bạn chưa nhập đủ dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    btnthemctsp.Visible = true;
                    object[] d = new object[10];
                    d[0] = txtmahd.Text;
                    d[1] = cbotennv.SelectedValue.ToString();
                    d[2] = cboncc.SelectedValue.ToString();
                    d[3] = cbotinhtrang.SelectedItem == "Hoạt động" ? 1 : 0;
                    d[4] = dtpngaylap.Value.ToString("MM/dd/yyyy");
                    d[5] = txttongtien.Text;
                    d[6] = txttongsoluong.Text;
                    d[7] = lblck.Text;
                    d[8] = cbotensp.SelectedValue.ToString();
                    dgvDanhSach.Rows.Add(d);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
            }


        }

        private void btnthemctsp_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmHoaDonNhap_Load(sender, e);
            loaddulieu_datagrid(dgvDanhSach, "SELECT * FROM HOADONNHAP WHERE TRANGTHAI=0");
            cboncc.SelectedIndex = -1;
            cbotennv.SelectedIndex = -1;
            cbotensp.SelectedIndex = -1;
            txttongtien.Clear();
            txttongsoluong.Clear();
            cbomau.SelectedIndex = -1;
            flpSize.Controls.Clear();
            txtgia.Clear();
            txtsluong.Clear();
            xulychucnang(true);
            btnthemctsp.Enabled = true;

        }

        private void cboncc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f)
            {
                if (cboncc.SelectedIndex != -1)
                {
                    string mancc = cboncc.SelectedValue.ToString();
                    dssanpham = c.LayDuLieu("select * from sanpham where mancc ='" + mancc + "'");
                    HienthiCombobox(cbotensp, dssanpham, "TENSP", "MASP");
                }

            }
        }


        private void dgvcthdn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (flag == 2)
            {
                int slcu = 0;
                DataSet dsCTSP = new DataSet();
                dsCTSP = c.LayDuLieu("select * from CT_HOADONNHAP where mahd='" + txtmahd.Text + "' and mactsp='" + txtmactsp.Text + "'");
                if (dsCTSP.Tables[0].Rows.Count > 0)
                    slcu = int.Parse(dsCTSP.Tables[0].Rows[0]["SOLUONG"].ToString());


                int slmoi = 0;
                if (int.TryParse(dgvcthdn.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out slmoi))
                {
                    DataGridViewRow selectedRow = dgvcthdn.Rows[e.RowIndex];
                    string maSP = selectedRow.Cells[1].Value.ToString();
                    if (slmoi > slcu)
                    {
                        int difference = slmoi - slcu;
                        string sql = "update CT_HOADONNHAP set soluong+=" + difference + "where mahd ='" + txtmahd.Text + "' and mactsp='" + txtmactsp.Text + "'";
                        c.capnhatdulieu(sql);
                        string sql3 = "update SANPHAM set soluong +=" + difference + "where masp ='" + maSP + "'";
                        c.capnhatdulieu(sql3);
                        string sql4 = "update ct_sanpham set soluong = soluong +" + difference + " where mactsp ='" + txtmactsp.Text + "'";
                        c.capnhatdulieu(sql4);
                    }
                    else if (slmoi < slcu)
                    {
                        int difference = slcu - slmoi;
                        string sql = "update CT_HOADONNHAP set soluong-=" + difference + "where mahd ='" + txtmahd.Text + "' and mactsp='" + txtmactsp.Text + "'";
                        c.capnhatdulieu(sql);
                        string sql3 = "update SANPHAM set soluong -=" + difference + "where masp ='" + maSP + "'";
                        c.capnhatdulieu(sql3);
                        string sql4 = "update ct_sanpham set soluong = soluong -" + difference + " where mactsp ='" + txtmactsp.Text + "'";
                        c.capnhatdulieu(sql4);
                    }

                    int tongtien = 0;
                    int sl = 0;
                    foreach (DataGridViewRow row in dgvcthdn.Rows)
                    {
                        if (row.Cells["SOLUONG"].Value != null)
                        {
                            int quantity = Convert.ToInt32(row.Cells["SOLUONG"].Value);
                            sl += quantity;
                        }


                        if (row.Cells["DONGIA"].Value != null)
                        {

                            int tong = Convert.ToInt32(row.Cells["DONGIA"].Value);
                            int sl1 = Convert.ToInt32(row.Cells["SOLUONG"].Value);
                            tongtien += tong * sl1;
                        }
                    }
                    string sql2 = "update HOADONNHAP set soluong=" + sl + ", thanhtien = " + tongtien + "where mahd ='" + txtmahd.Text + "'";
                    c.capnhatdulieu(sql2);

                    txtmactsp.Visible = false;
                }


            }
        }

        private void txtsluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void txttongtien_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void lblck_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }
        Boolean timsanpham()
        {

            string input = txtmactsp.Text;
            DataSet dsCTSP = new DataSet();
            dsCTSP = c.LayDuLieu("select * from ct_sanpham where mactsp = '" + input + "'");
            if (dsCTSP.Tables[0].Rows.Count > 0)
            {
                CTSP();
                string gia = dsCTSP.Tables[0].Rows[0]["GIABAN"].ToString();
                string numberString = gia.Replace(".", "");
                txtgia.Text = numberString;
                txttonkho.Text = dsCTSP.Tables[0].Rows[0]["SOLUONG"].ToString();
                return true;
            }
            return false;

        }

        void CTSP()
        {
            string input = txtmactsp.Text;
            string[] parts = input.Split('.');
            string masp = parts[0];
            string mamau = parts[1];
            string masize = parts[2];
            DataSet ds = new DataSet();
            DataSet dsMau = new DataSet();
            DataSet dsSize = new DataSet();
            ds = c.LayDuLieu("select * from sanpham where masp='" + masp + "'");
            dsMau = c.LayDuLieu("select * from mau where mamau='" + mamau + "'");
            dsSize = c.LayDuLieu("select * from size where masize = '" + masize + "'");
            if (dsMau.Tables[0].Rows.Count > 0)
                txttenmau.Text = dsMau.Tables[0].Rows[0]["TENMAU"].ToString();
            if (dsSize.Tables[0].Rows.Count > 0)
                txttensize.Text = dsSize.Tables[0].Rows[0]["TENSIZE"].ToString();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtmasp.Text = masp;
                cbotensp.Text = ds.Tables[0].Rows[0]["TENSP"].ToString();
                //      txtgia.Text = ds.Tables[0].Rows[0]["GIABANLE"].ToString();
                string tenhinh = ds.Tables[0].Rows[0]["ANH"].ToString();
                string duongdan = Path.GetFullPath("anhcuahang") + @"\" + tenhinh;
                txttenhinh.Text = tenhinh;
                taoanh_tufileanh(picHinh, duongdan);
            }
        }
        void taoanh_tufileanh(PictureBox p, string filename)
        {
            using (Bitmap a = new Bitmap(filename))
            {
                p.Image = new Bitmap(a);
                p.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void cbotennv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f)
            {
                if (cbotennv.SelectedIndex != -1)
                {
                    string manv = cbotennv.SelectedValue.ToString();
                    txtmanv.Text = manv;
                  
                }

            }
        }
    }
}

