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
    public partial class frmHoaDonBan : Form
    {
        public frmHoaDonBan()
        {
            InitializeComponent();
        }
        xuatExcel a = new xuatExcel();
        clsquanlibanhang c = new clsquanlibanhang();
        DataSet dsNhanvien = new DataSet();
        DataSet dsHoadonban = new DataSet();

        DataSet dsKhachhang = new DataSet();
        DataSet dsSanpham = new DataSet();
        DataSet dsCTHD = new DataSet();
        int vitri = 0;
        int flag = 0;

        void loaddulieu_datagrid(DataGridView d, string sql)
        {
            dsHoadonban = c.LayDuLieu(sql);
            d.DataSource = dsHoadonban.Tables[0];
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = e.RowIndex;
                hienthi_textbox(dsHoadonban.Tables[0], vitri);
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = e.RowIndex;
                hienthi_textbox(dsHoadonban.Tables[0], vitri);
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            txtmahd.Enabled = f;
            txtmakh.Enabled = f;

        }
        void hienthi_textbox(DataTable dt, int vt)
        {
            try
            {
                txtmahd.Text = dt.Rows[vt]["MAHD"].ToString();
                txtmakh.Text = dt.Rows[vt]["MAKH"].ToString();
                string makh = txtmakh.Text;
                txtmanv.Text = dt.Rows[vt]["MANV"].ToString();
                dsKhachhang = c.LayDuLieu("select * from khachhang where makh ='" + makh + "'");
                if (dsKhachhang.Tables[0].Rows.Count > 0)
                {
                    txtsdt.Text = dsKhachhang.Tables[0].Rows[0]["SDT"].ToString();
                }

                string manv = txtmanv.Text;
                datngaylap.Text = dt.Rows[vt]["NGAYLAPHD"].ToString();
                //  txtsdt.Text = dt.Rows[vt]["SDT"].ToString();
                locDuLieuCombobox(cbokh, dsKhachhang, "MAKH", "TENKH", makh);
                locDuLieuCombobox(cbonv, dsNhanvien, "MANV", "TENNV", manv);


                string trangthai = dt.Rows[vt]["TRANGTHAI"].ToString();
                if (trangthai == "0")
                {
                    cbotrangthai.SelectedIndex = 0;
                }
                else if (trangthai == "2")
                    cbotrangthai.SelectedIndex = 2;

                txttongsl.Text = dt.Rows[vt]["SOLUONG"].ToString();
                txttongtien.Text = dt.Rows[vt]["THANHTIEN"].ToString();

                txtchietkhau.Text = dt.Rows[vt]["CHIETKHAU"].ToString();
                load_CTHDBtheoMAHD(dt.Rows[vt]["MAHD"].ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void hienthi_textboxCTSP(DataTable dt, int vt)
        {
            try
            {
                txtmactsp.Text = dt.Rows[vt]["MACTSP"].ToString();
                txtsluong.Text = dt.Rows[vt]["SOLUONG"].ToString();
                string gia = dt.Rows[vt]["DONGIA"].ToString();
                string numberString = gia.Replace(".", "");
                txtgia.Text = numberString;
                string tenhinh = dt.Rows[vt]["anh"].ToString();
                string duongdan = Path.GetFullPath("anhcuahang") + @"\" + tenhinh;
                taoanh_tufileanh(picHinhDaiDien, duongdan);
                string input = txtmactsp.Text;
                string[] parts = input.Split('.');
                string masp = parts[0];
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
            catch (Exception)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        string phatsinh_1()
        {
            string mahdb = "HDB";
            DataSet ds = c.LayDuLieu("select MAHD from HOADONBAN");
            if (ds.Tables[0].Rows.Count < 9) // tùy theo mình xử lý
            {
                mahdb += ("0" + (ds.Tables[0].Rows.Count + 1).ToString()).Replace(" ", "");
            }
            else
                mahdb += (ds.Tables[0].Rows.Count + 1).ToString().Replace(" ", "");
            return mahdb;

        }
        Boolean f = false;
        Boolean timkhachhang()
        {
            DataSet ds = new DataSet();
            ds = c.LayDuLieu("select * from khachhang where SDT='" + txtsdt.Text + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtmakh.Text = ds.Tables[0].Rows[0]["MAKH"].ToString();
                cbokh.Text = ds.Tables[0].Rows[0]["TENKH"].ToString();
                return true;
            }
            return false;

        }
        void HienthiCombobox(ComboBox cbo, DataSet ds, string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = -1;
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
        private void btntim_Click(object sender, EventArgs e)
        {
            if (txtsdt.Text != "")
                if (!timkhachhang())
                    MessageBox.Show("Không tìm thấy SĐT !");
        }

        private void btnthemkh_Click(object sender, EventArgs e)
        {
            frmKhachhang a = new frmKhachhang();
            a.ShowDialog();
            txtmakh.Text = a.txtmakh.Text;
            txtsdt.Text = a.txtsdt.Text;
            cbokh.Text = a.txtten.Text;
        }


        private void frmHoaDonBan_Load(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = null;
            xulychucnang(true);
            loaddulieu_datagrid(dgvDanhSach, "select * from HOADONBAN where trangthai = 0 or trangthai = 2");
            dsNhanvien = c.LayDuLieu("select * from nhanvien");
            //    dsKhachhang = c.LayDuLieu("select * from khachhang");
            dsSanpham = c.LayDuLieu("select * from sanpham");
            hienthi_textbox(dsHoadonban.Tables[0], vitri);
            hienthi_textboxCTSP(dsCTHD.Tables[0], vitri);
        }

        void load_CTHDBtheoMAHD(string mahd)
        {
            string s = "select * from ct_hoadonban where mahd='" + mahd + "'";
            dsCTHD = c.LayDuLieu(s);
            dgvCTHD.DataSource = null;
            dgvCTHD.Columns.Clear();
            dgvCTHD.DataSource = dsCTHD.Tables[0];

        }
        void XoaDuLieu()
        {
            txttongsl.Clear();
            txtchietkhau.Clear();
            txttongtien.Clear();
            cbokh.SelectedIndex = -1;
            cbonv.SelectedIndex = -1;
            cbotensp.SelectedIndex = -1;
            txtmactsp.Clear();
            txtgia.Clear();
            txtsluong.Clear();
            txtmasp.Clear();
            txtsdt.Clear();
            txtmakh.Clear();
            txtmanv.Clear();
            txtgia.Clear();
            picHinhDaiDien.Image = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txttenhinh.Visible = true;
            txtmasp.Visible = true;
            txttensize.Visible = true;
            txttensize.Visible = true;
            txttonkho.Visible = true;
            txttenmau.Visible = true;

            btntim.Visible = true;
            btnthemkh.Visible = true;
            btnthemhd.Visible = true;
            txtmahd.ReadOnly = true;
            dgvDanhSach.DataSource = null;
            dgvCTHD.DataSource = null;
            XoaDuLieu();
            xulychucnang(false);
            xulytestbox(false);
            HienthiCombobox(cbonv, dsNhanvien, "TENNV", "MANV");
            HienthiCombobox(cbokh, dsKhachhang, "TENKH", "MAKH");
            HienthiCombobox(cbotensp, dsSanpham, "TENSP", "MASP");
            txtmahd.Text = phatsinh_1();//tự phát sinh mã
            TaoCotHoaDonBan();
            taocotCTHDB();
            flag = 1;
        }

        private void cbomasp_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (f)
            //{
            //    if (cbomasp.SelectedIndex != -1)
            //    {
            //        string masp = cbomasp.SelectedValue.ToString();
            //        dsSanpham = c.LayDuLieu("select * from sanpham where masp ='" + masp + "'");
            //        HienthiCombobox(cbotensp, dsSanpham, "TENSP", "MASP");
            //    }

            //}
        }

        private void cbotensp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbotensp.SelectedIndex != -1) // Kiểm tra nếu có sản phẩm được chọn
            {
                string tensp = cbotensp.SelectedValue.ToString();
                dsSanpham = c.LayDuLieu("select * from sanpham where tensp = N'" + tensp + "'");

                if (dsSanpham.Tables[0].Rows.Count > 0)
                {
                    txtmactsp.Text = dsSanpham.Tables[0].Rows[0]["MASP"].ToString();
                }
            }
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
                taoanh_tufileanh(picHinhDaiDien, duongdan);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (txtmactsp.Text != "")
                if (!timsanpham())
                    MessageBox.Show("Không tìm thấy  !");
                else
                    txtsluong.Text = "1";
        }

        void taoanh_tufileanh(PictureBox p, string filename)
        {
            Bitmap a = new Bitmap(filename);
            p.Image = a;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        void TaoCotHoaDonBan()
        {
            dgvDanhSach.Columns.Clear();
            dgvDanhSach.Columns.Add("MaHD", "Mã HD");
            dgvDanhSach.Columns.Add("MaNV", "Mã NV");
            dgvDanhSach.Columns.Add("MaKH", "Mã KH");
            dgvDanhSach.Columns.Add("NGAYLAPHD", "Ngày Lập");
            dgvDanhSach.Columns.Add("soluong", "Số lượng");
            dgvDanhSach.Columns.Add("chietkhau", "Chiết khấu");
            dgvDanhSach.Columns.Add("thanhtien", "Tổng tiền sau chiết khấu");
            dgvDanhSach.Columns.Add("trangthai", "Trạng thái");

        }
        private void btnthemhd_Click(object sender, EventArgs e)
        {
            btnthemsp.Visible = true;
            object[] d = new object[8];
            d[0] = txtmahd.Text;
            d[1] = cbonv.SelectedValue.ToString();
            d[2] = txtmakh.Text;
            d[3] = datngaylap.Text;
            d[4] = txttongsl.Text;
            d[5] = txtchietkhau.Text;
            d[6] = txttongtien.Text;
            d[7] = "0";
            dgvDanhSach.Rows.Add(d);
        }

        void taocotCTHDB()
        {
            dgvCTHD.Columns.Clear();
            dgvCTHD.Columns.Add("MaSP", "Mã SP");
            dgvCTHD.Columns.Add("MaCTSP", "Mã CTSP");
            dgvCTHD.Columns.Add("soluong", "Số lượng");
            dgvCTHD.Columns.Add("dongia", "Đơn giá");
            dgvCTHD.Columns.Add("khuyenmai", "Khuyến Mãi");
            dgvCTHD.Columns.Add("thanhtien", "Thành tiền");
            dgvCTHD.Columns.Add("anh", "Ảnh");
            dgvCTHD.Columns.Add("trangthai", "Trạng thái");
        }
        private void btnthemsp_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtsluong.Text) > int.Parse(txttonkho.Text))
            {
                MessageBox.Show("Sản phẩm tồn kho không đủ!Vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //object[] d = new object[8];
            //d[0] = txtmactsp.Text;
            //d[1] = txtsluong.Text;
            //d[2] = txtgia.Text;
            //d[3] = txttenhinh.Text;
            //d[4] = txtkm.Text;
            //int tongsp = (int.Parse(txtsluong.Text) * int.Parse(txtgia.Text)) - (int.Parse(txtkm.Text) * int.Parse(txtsluong.Text));
            //d[5] = tongsp;
            //d[6] = "0";
            //dgvCTHD.Rows.Add(d);

            //tongtien += tongsp;
            //tongsoluong += int.Parse(txtsluong.Text);
            //tongchietkhau += float.Parse(txtkm.Text);

            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(dgvCTHD);
            newRow.Cells[0].Value = txtmasp.Text;
            newRow.Cells[1].Value = txtmactsp.Text;
            newRow.Cells[2].Value = txtsluong.Text;
            newRow.Cells[3].Value = txtgia.Text;
            newRow.Cells[4].Value = txtkm.Text;
            int tongsp = (int.Parse(txtsluong.Text) * int.Parse(txtgia.Text)) - (int.Parse(txtkm.Text) * int.Parse(txtsluong.Text));
            newRow.Cells[5].Value = tongsp;
            newRow.Cells[6].Value = txttenhinh.Text;
            newRow.Cells[7].Value = "0";

            dgvCTHD.Rows.Add(newRow);

            float tongtien = 0;
            float tongchietkhau = 0;
            int tongsoluong = 0;


            for (int i = 0; i < dgvCTHD.Rows.Count; i++)
            {
                tongsoluong += Convert.ToInt32(dgvCTHD.Rows[i].Cells["soluong"].Value);
                tongchietkhau += Convert.ToInt32(dgvCTHD.Rows[i].Cells["khuyenmai"].Value);
                tongtien += Convert.ToInt32(dgvCTHD.Rows[i].Cells["thanhtien"].Value);
            }

            txttongsl.Text = tongsoluong.ToString();
            txtchietkhau.Text = tongchietkhau.ToString();
            txttongtien.Text = tongtien.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            flag = 3;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            flag = 2;

        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                txttenhinh.Visible = false;
                txtmasp.Visible = false;
                txttensize.Visible = false;
                txttensize.Visible = false;
                txttonkho.Visible = false;
                txttenmau.Visible = false;

                dgvDanhSach.Columns.Clear();
                xulychucnang(true);
                string sql = "";
                if (flag == 1)
                {
                    string mahd = txtmahd.Text;
                    string manv = cbonv.SelectedValue.ToString();
                    string makh = txtmakh.Text;
                    string ngaylap = datngaylap.Value.ToShortDateString();
                    string soluong = txttongsl.Text;
                    string thanhtien = txttongtien.Text;
                    string chietkhau = txtchietkhau.Text;
                    string trangthai = cbotrangthai.SelectedIndex.ToString();

                    sql = "insert into hoadonban values('" + mahd + "','" + manv + "','" + makh;
                    sql += "','" + ngaylap + "'," + soluong + "," + chietkhau + "," + thanhtien + ",'" + trangthai + "')";
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        string sqlCTHD = "";
                        for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
                        {
                            string masp = dgvCTHD.Rows[i].Cells[0].Value.ToString();
                            string mactsp = dgvCTHD.Rows[i].Cells[1].Value.ToString();
                            string soluongtheoctsp = dgvCTHD.Rows[i].Cells[2].Value.ToString();
                            string dongia = dgvCTHD.Rows[i].Cells[3].Value.ToString();
                            string khuyenmai = dgvCTHD.Rows[i].Cells[4].Value.ToString();
                            string thanhtientheoctsp = dgvCTHD.Rows[i].Cells[5].Value.ToString();
                            string hinh = dgvCTHD.Rows[i].Cells[6].Value.ToString();
                            string trangthai1 = "0";

                            sqlCTHD = "insert into CT_HOADONBAN values ('" + mahd + "','" + masp + "','" + mactsp + "'," + soluongtheoctsp + "," + dongia + "," + khuyenmai + "," + thanhtientheoctsp;
                            sqlCTHD += ",'" + hinh + "','" + trangthai1 + "')";

                            if (c.capnhatdulieu(sqlCTHD) > 0)
                            {
                                string sql1 = "update CT_SANPHAM set soluong= soluong-" + soluongtheoctsp + " where mactsp='" + mactsp + "'";
                                c.capnhatdulieu(sql1);
                                string sql2 = "update SANPHAM set soluong= soluong-" + soluongtheoctsp + "where masp='" + masp + "'";
                                c.capnhatdulieu(sql2);
                            }
                        }
                        MessageBox.Show("Cập nhật thành công");
                    }
                }
                if (flag == 2) // SỬA
                {
                    if (int.Parse(cbotrangthai.SelectedIndex.ToString()) == 2)
                    {
                        for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
                        {
                            string masp = dgvCTHD.Rows[i].Cells[1].Value.ToString();
                            string mactsp = dgvCTHD.Rows[i].Cells[2].Value.ToString();
                            string soluongtheoctsp = dgvCTHD.Rows[i].Cells[3].Value.ToString();
                        
                            string sql1 = "update CT_SANPHAM set soluong= soluong+" + soluongtheoctsp + " where mactsp='" + mactsp + "'";
                            c.capnhatdulieu(sql1);
                            string sql2 = "update SANPHAM set soluong= soluong+" + soluongtheoctsp + "where masp='" + masp + "'";
                            c.capnhatdulieu(sql2);

                            sql = "update hoadonban set trangthai=" + cbotrangthai.SelectedIndex.ToString() + " where mahd ='" + txtmahd.Text + "'";
                            if (c.capnhatdulieu(sql) > 0)
                            {
                                string sqlCTSP = "update ct_hoadonban set trangthai =2 where mahd ='" + txtmahd.Text + "'";
                                c.capnhatdulieu(sqlCTSP);
                                MessageBox.Show("Hoàn trả thành công");
                                vitri = 0;
                            }
                        }
                    }
                }
                if (flag == 3) // Xóa
                {
                   DialogResult result = MessageBox.Show("Bạn xác nhận muốn xóa", "Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                       
                        vitri = 0;
                        frmHoaDonBan_Load(sender, e);
                        flag = 0;
                        return;
                    }
                    else
                    {
                        for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
                        {
                            string masp = dgvCTHD.Rows[i].Cells[1].Value.ToString();
                            string mactsp = dgvCTHD.Rows[i].Cells[2].Value.ToString();
                            string soluongtheoctsp = dgvCTHD.Rows[i].Cells[3].Value.ToString();

                            string sql1 = "update CT_SANPHAM set soluong= soluong+" + soluongtheoctsp + " where mactsp='" + mactsp + "'";
                            c.capnhatdulieu(sql1);
                            string sql2 = "update SANPHAM set soluong= soluong+" + soluongtheoctsp + "where masp='" + masp + "'";
                            c.capnhatdulieu(sql2);
                        }

                        sql = "update hoadonban set trangthai= 1 where mahd='" + txtmahd.Text + "'";
                        if (c.capnhatdulieu(sql) > 0)
                        {
                            string sqlCTSP = "update ct_hoadonban set trangthai = 1 where mahd ='" + txtmahd.Text + "'";
                            c.capnhatdulieu(sqlCTSP);
                            MessageBox.Show("Xóa thành công");
                            vitri = 0;
                        }
                    }
                }
                vitri = 0;
                frmHoaDonBan_Load(sender, e);
                flag = 0;
            }
            catch
            {
                MessageBox.Show("Lưu không thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvCTHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienthi_textboxCTSP(dsCTHD.Tables[0], vitri);
        }

        private void dgvCTHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            vitri = e.RowIndex;
            hienthi_textboxCTSP(dsCTHD.Tables[0], vitri);
        }

        private void dgvCTHD_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (flag == 1)
            {
                int tongsoluong = 0;
                int tongchietkhau = 0;
                int tongtien = 0;
                foreach (DataGridViewRow row in dgvCTHD.Rows)
                {
                    int quantity = 0;
                    int km = 0;
                    int tong = 0;
                    if (row.Cells["soluong"].Value != null)
                    {
                        quantity = Convert.ToInt32(row.Cells["soluong"].Value);
                        tongsoluong += quantity;
                    }
                    if (row.Cells["khuyenmai"].Value != null)
                    {
                        km = Convert.ToInt32(row.Cells["khuyenmai"].Value);
                        tongchietkhau += km;
                    }

                    if (row.Cells["thanhtien"].Value != null)
                    {
                        tong = Convert.ToInt32(row.Cells["thanhtien"].Value);
                        tongtien += tong;
                    }
                }

                // Cập nhật giá trị tổng số lượng vào TextBox
                txttongsl.Text = tongsoluong.ToString();
                txtkm.Text = tongchietkhau.ToString();
                txttongtien.Text = tongtien.ToString();
            }
        }

        private void dgvCTHD_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (f)
            //{
            //    if(flag == 2 ) //SỬA
            //    {
            //        if(e.ColumnIndex == 6)
            //        {

            //            int tongsoluong = 0;
            //            int tongchietkhau = 0;
            //            int tongtien = 0;
            //            for (int i = 0; i < dgvCTHD.Rows.Count - 1; i++)
            //            {
            //                 tongsoluong += int.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString());
            //                tongchietkhau += int.Parse(dgvCTHD.Rows[i].Cells[5].Value.ToString());
            //                dgvCTHD.Rows[i].Cells[6].Value = (int.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvCTHD.Rows[i].Cells[4].Value.ToString()) - (int.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvCTHD.Rows[i].Cells[5].Value.ToString()))); ;
            //                 tongtien += (int.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvCTHD.Rows[i].Cells[4].Value.ToString()) - (int.Parse(dgvCTHD.Rows[i].Cells[3].Value.ToString()) * int.Parse(dgvCTHD.Rows[i].Cells[5].Value.ToString())));
            //            }
            //            txttongsl.Text = tongsoluong.ToString();
            //            txtkm.Text = tongchietkhau.ToString();
            //            txttongtien.Text = tongtien.ToString();
            //        }
            //    }    
            //}   
        }

        private void dgvCTHD_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //   if (f)
                {
                    if (flag == 2)
                        if (e.ColumnIndex == dgvCTHD.Columns["SOLUONG"].Index)
                        {
                            int slcu = 0;
                            int dongia = 0;
                            int km = 0;
                            int thanhtien = 0;
                            DataSet dsCTSP = new DataSet();
                            dsCTSP = c.LayDuLieu("select * from CT_HOADONBAN where mahd='" + txtmahd.Text + "' and mactsp='" + txtmactsp.Text + "'");
                            if (dsCTSP.Tables[0].Rows.Count > 0)
                                slcu = int.Parse(dsCTSP.Tables[0].Rows[0]["SOLUONG"].ToString());

                            int slmoi = 0;
                            if (int.TryParse(dgvCTHD.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out slmoi))
                            {
                                dongia = int.Parse(dsCTSP.Tables[0].Rows[0]["DONGIA"].ToString().Replace(".", ""));
                                km = int.Parse(dsCTSP.Tables[0].Rows[0]["CHIETKHAU"].ToString().Replace(".", ""));
                                thanhtien = (dongia * slmoi) - (dongia * km);
                                dgvCTHD.Rows[e.RowIndex].Cells["THANHTIEN"].Value = thanhtien;
                                if (slmoi > slcu)
                                {
                                    int difference = slmoi - slcu;
                                    // Cộng thêm vào cơ sở dữ liệu: UPDATE TableName SET Quantity = Quantity + difference WHERE ID = ...;
                                    string sql = "update CT_HOADONBAN set soluong+=" + difference + "where mahd ='" + txtmahd.Text + "' and mactsp='" + txtmactsp.Text + "'";
                                    c.capnhatdulieu(sql);
                                    string sql3 = "update SANPHAM set soluong +=" + difference + "where masp ='" + txtmasp.Text + "'";
                                    c.capnhatdulieu(sql3);
                                    string sql4 = "update ct_sanpham set soluong = soluong +" + difference + " where mactsp ='" + txtmactsp.Text + "'";
                                    c.capnhatdulieu(sql4);
                                }
                                else if (slmoi < slcu)
                                {
                                    int difference = slcu - slmoi;
                                    // Trừ đi khỏi cơ sở dữ liệu: UPDATE TableName SET Quantity = Quantity - difference WHERE ID = ...;
                                    string sql = "update CT_HOADONBAN set soluong-=" + difference + "where mahd ='" + txtmahd.Text + "' and mactsp='" + txtmactsp.Text + "'";
                                    c.capnhatdulieu(sql);
                                    string sql3 = "update SANPHAM set soluong -=" + difference + "where masp ='" + txtmasp.Text + "'";
                                    c.capnhatdulieu(sql3);
                                    string sql4 = "update ct_sanpham set soluong = soluong -" + difference + " where mactsp ='" + txtmactsp.Text + "'";
                                    c.capnhatdulieu(sql4);
                                }
                            }
                            int tongsoluong = 0;
                            int tongchietkhau = 0;
                            int tongtien = 0;
                            foreach (DataGridViewRow row in dgvCTHD.Rows)
                            {
                                if (row.Cells["SOLUONG"].Value != null)
                                {
                                    int quantity = Convert.ToInt32(row.Cells["SOLUONG"].Value);
                                    tongsoluong += quantity;
                                }
                                if (row.Cells["CHIETKHAU"].Value != null)
                                {
                                    int km1 = Convert.ToInt32(row.Cells["CHIETKHAU"].Value);
                                    tongchietkhau += km1;
                                }

                                if (row.Cells["THANHTIEN"].Value != null)
                                {
                                    int tong = Convert.ToInt32(row.Cells["THANHTIEN"].Value);
                                    tongtien += tong;
                                }
                            }

                            // Cập nhật giá trị tổng số lượng vào TextBox
                            txttongsl.Text = tongsoluong.ToString();
                            txtchietkhau.Text = tongchietkhau.ToString();
                            txttongtien.Text = tongtien.ToString();
                            string sql2 = "update HOADONBAN set soluong=" + txttongsl.Text + ",chietkhau =" + txtchietkhau.Text + ", thanhtien = " + txttongtien.Text + "where mahd ='" + txtmahd.Text + "'";
                            c.capnhatdulieu(sql2);
                        }
                }
                MessageBox.Show("Cập nhật thành công");
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void HDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kg = new DialogResult();
            kg = MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kg == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtgia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Nhập sai dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnxuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();


            saveFileDialog1.Filter = "Excel Files|*.xlsx";
            saveFileDialog1.Title = "Chọn nơi lưu trữ và đặt tên tệp Excel";
            saveFileDialog1.FileName = "MyExcelFile.xlsx"; // Tên mặc định cho tệp lưu

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                a.ToExcel(dgvDanhSach, saveFileDialog1.FileName);
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void cbonv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f)
            {
                if (cbonv.SelectedIndex != -1)
                {
                    string manv = cbonv.SelectedValue.ToString();
                    txtmanv.Text = manv;

                }
            }
        }
    }
}
    

        

