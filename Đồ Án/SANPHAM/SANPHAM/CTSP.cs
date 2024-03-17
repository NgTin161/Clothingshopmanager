using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SANPHAM
{
    public partial class CTSP : Form
    {
        public CTSP()
        {
            InitializeComponent();
        }

        clsquanlibanhang c = new clsquanlibanhang();
        DataSet dsLoaisp = new DataSet();
        DataSet dsSanPham = new DataSet();
        DataSet dsNhacungcap = new DataSet();
        DataSet dsCTSP = new DataSet();
        DataSet dsMau = new DataSet();
        DataSet dsSize = new DataSet();

        int vitri = 0;
        int flag = 0;

        Boolean f = false;


        void loaddulieu_datagrid(DataGridView d, string sql)
        {
            dsSanPham = c.LayDuLieu(sql);
            d.DataSource = dsSanPham.Tables[0];
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
           txtmasp.ReadOnly= t;
            txttensp.ReadOnly = t;
            txtmasp.Enabled = false; 
            lblmamau.Enabled = !t;
            cbomau.Enabled = !t;
        
        }

        void XoaDuLieu()
        {
            cboloaisp.SelectedIndex = -1;
            cboncc.SelectedIndex = -1;  
            txtmasp.Clear();
            txttensp.Clear();
            txtsoluong.Clear();
            txtgianhap.Clear();
            txtgiadangbai.Clear();
            txtgiaban.Clear();
            txtgia1.Clear();
            rchmota.Clear();
            picHinhDaiDien.Image = null;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            txtsoluong.ReadOnly = true;
            dgvDanhSach.DataSource = null;
            dgvCTSP.DataSource = null;
            XoaDuLieu();
            xulychucnang(false);
            xulytestbox(false);
            //HienthiCombobox(cboncc,dsNhacungcap,"TENNCC","MANCC");
            HienthiCombobox(cboloaisp, dsLoaisp, "TENLOAISP", "MALOAI");
            HienthiCombobox(cbomau, dsMau, "TENMAU", "MAMAU");
            txtmasp.Text = phatsinh_1();//tự phát sinh mã
            // cbotinhtrang.SelectedIndex = 0;
          //  cboloaisp_SelectedIndexChanged(sender, e);
            //cboncc_SelectedIndexChanged(sender, e);
            TaoCotCTSP();
            TaoCotSP();
            flag = 1;
        }
        string phatsinh_1()
        {
                string masp = "SP";
                DataSet ds = c.LayDuLieu("select MASP from SANPHAM");
                if (ds.Tables[0].Rows.Count < 9) // tùy theo mình xử lý
                {
                    masp += ("0" + (ds.Tables[0].Rows.Count + 1).ToString()).Replace(" ", "");
                }
                else
                    masp += (ds.Tables[0].Rows.Count + 1).ToString().Replace(" ", "");
                return masp;
           
        }
        void hienthi_textbox(DataTable dt, int vt)
        {
            try
            {
                txtmasp.Text = dt.Rows[vt]["MASP"].ToString();
                txttensp.Text = dt.Rows[vt]["TENSP"].ToString();
                txtgianhap.Text = dt.Rows[vt]["GIANHAP"].ToString();
                txtgiaban.Text = dt.Rows[vt]["GIABANLE"].ToString();
                txtgiadangbai.Text = dt.Rows[vt]["GIADANGBAI"].ToString();
                txtgia1.Text = dt.Rows[vt]["GIASI1"].ToString();
                txtgia2.Text = dt.Rows[vt]["GIASI2"].ToString();
                txtsoluong.Text = dt.Rows[vt]["SOLUONG"].ToString();
                rchmota.Text = dt.Rows[vt]["MOTA"].ToString();
                cboncc.Text = dt.Rows[vt]["MANCC"].ToString();
                cboncc.Text = dt.Rows[vt]["MALOAI"].ToString();

                string mancc, maloai;
                mancc = dt.Rows[vt]["MANCC"].ToString();
                maloai = dt.Rows[vt]["MALOAI"].ToString();
                
                //locDuLieuCombobox(cboncc, dsNhacungcap, "MANCC", "TENNCC", mancc);
                //locDuLieuCombobox(cboloaisp, dsLoaisp, "MALOAI", "TENLOAISP", maloai);


                string tenhinh = dt.Rows[vt]["ANH"].ToString();
                string duongdan = Path.GetFullPath("anhcuahang") + @"\" + tenhinh;
                taoanh_tufileanh(picHinhDaiDien, duongdan);


                load_CTSPtheoMASP(dt.Rows[vt]["masp"].ToString());
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

        }
        void HienthiCombobox(ComboBox cbo, DataSet ds, string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = -1;
        }

        void locDuLieuCombobox(ComboBox cbo,DataSet ds, string ma,string ten,string giatrima)
        {
            //loại sản phẩm
            DataView dv = new DataView();
            dv.Table = ds.Tables[0];
            dv.RowFilter = ma + "='" + giatrima +"'";
            cbo.DataSource = dv;
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
        }
 
        private void btnxoa_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            flag = 3;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            flag = 2;

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                xulychucnang(true);
                dgvDanhSach.Columns.Clear();
                string sql = "";
                if (flag == 1)
                {
                    string masp = txtmasp.Text;
                    string tensp = txttensp.Text;
                    string maloai = cboloaisp.SelectedValue.ToString();
                    string mancc = cboncc.SelectedValue.ToString().Trim();
                    string soluong = txtsoluong.Text;
                    string dvt = txtdvt.Text;
                    string gianhap = txtgianhap.Text;
                    string giaban = txtgiaban.Text;
                    string giadangbai = txtgiadangbai.Text;
                    string giasi1 = txtgia1.Text;
                    string giasi2 = txtgia2.Text;


                    string mahinh = txttenhinh.Text;
                    string mota = rchmota.Text;



                    sql = "insert into sanpham values('" + mahinh + "','" + masp + "','" + maloai;
                    sql += "','" + mancc + "',N'" + tensp + "','" + mota + "',N'" + dvt + "'," + soluong;
                    sql += "," + gianhap + "," + giaban + "," + giadangbai + "," + giasi1 + "," + giasi2 + ",0)";
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        string sqlCTSP = "";
                        for (int i = 0; i < dgvCTSP.Rows.Count - 1; i++)
                        {
                            string mactsp = dgvCTSP.Rows[i].Cells[0].Value.ToString();
                            //  string masp = dgvCTSP.Rows[i].Cells[1].Value.ToString();
                            string mamau = dgvCTSP.Rows[i].Cells[2].Value.ToString();
                            string masize = dgvCTSP.Rows[i].Cells[3].Value.ToString();
                            string soluongtheosize = dgvCTSP.Rows[i].Cells[4].Value.ToString();
                            string giabantungsize = dgvCTSP.Rows[i].Cells[5].Value.ToString();
                            string hinh = dgvCTSP.Rows[i].Cells[6].Value.ToString();
                            string ghichu = dgvCTSP.Rows[i].Cells[7].Value.ToString();
                            string trangthai = "0";

                            //ctsanpham
                            sqlCTSP = "insert into CT_sanpham values ('" + mactsp + "','" + masp + "','" + masize + "','" + mamau + "','" + ghichu + "'," + giabantungsize + "," + soluongtheosize;
                            sqlCTSP += ",'" + hinh + "','" + trangthai + "')";
                            c.capnhatdulieu(sqlCTSP);
                        }
                        MessageBox.Show("Cập nhật thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                if (flag == 2)
                {
                    int TONGSL = 0;
                    string sqlCTSP = "";
                    string masp = "";
                    for (int i = 0; i < dgvCTSP.Rows.Count - 1; i++)
                    {
                        string mactsp = dgvCTSP.Rows[i].Cells[0].Value.ToString();
                        string soluong = dgvCTSP.Rows[i].Cells[6].Value.ToString();
                        string trangthai = dgvCTSP.Rows[i].Cells[8].Value.ToString();
                        TONGSL += int.Parse(soluong);
                        masp = dgvCTSP.Rows[i].Cells[1].Value.ToString();

                        sqlCTSP = "update ct_sanpham set soluong='" + soluong + "', trangthai=" + trangthai + " where mactsp='" + mactsp + "'";
                        c.capnhatdulieu(sqlCTSP);
                    }
                    sql = "update sanpham set soluong='" + TONGSL + "'where masp='" + masp + "'";
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (flag == 3)
                {
                    sql = "update sanpham set trangthai= 1 where masp='" + txtmasp.Text + "'";
                    if (c.capnhatdulieu(sql) > 0)
                    {
                        for (int i = 0; i < dgvCTSP.Rows.Count - 1; i++)
                        {
                            string mactsp = dgvCTSP.Rows[i].Cells[0].Value.ToString();
                            string sqlCTSP = "update ct_sanpham set trangthai = 1 where masp ='" + mactsp + "'";
                            c.capnhatdulieu(sqlCTSP);
                        }
                        MessageBox.Show("Xóa thành công");
                        vitri = 0;


                    }
                }
                vitri = 0;
                frmCTSP_Load(sender, e);
                flag = 0;
            }
            catch
            {
                MessageBox.Show("Lưu thất bại !","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
        }

   
        private void frmCTSP_Load(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = null;      
            xulychucnang(true);
            loaddulieu_datagrid(dgvDanhSach,"select * from sanpham where trangthai = 0");
        //    dsSanPham = c.LayDuLieu("select * from sanpham ");
            dsLoaisp = c.LayDuLieu("select * from loaisp");
            dsNhacungcap = c.LayDuLieu("select * from nhacungcap");
            dsMau = c.LayDuLieu("select * from mau");
            dsSize = c.LayDuLieu("select * from size");
            //  danhsach_datagridview(dgvDanhsach, "select * from nhanvien");
  
          //  HienthiCombobox(cboncc, dsNhacungcap, "mancc", "tenncc");
           
            hienthi_textbox(dsSanPham.Tables[0], vitri);
            f = true;

        }



        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (f)
            {
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string masize = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tensize = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string sql = "update size set tensize= N'" + tensize + "' where masize='" + masize + "'";
                    try
                    {
                        if (c.capnhatdulieu(sql) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            vitri = 0;
                            frmCTSP_Load(sender, e);
                        }
                    }
                    catch 
                    {
                        MessageBox.Show("Đã có lỗi xảy ra" , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnthoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        void taoanh_tufileanh(PictureBox p,string filename)
        {
            Bitmap a = new Bitmap(filename);
            p.Image = a;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void btnLoadhinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Tệp hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Chỉ chấp nhận các định dạng hình ảnh phổ biến
            if (o.ShowDialog() == DialogResult.OK)
            {
                string tenfile = o.FileName; // Lấy đường dẫn tệp hình ảnh đã chọn

                string thuMucDich = Path.Combine(Path.GetFullPath("anhcuahang"), txtmasp.Text.ToString() + Path.GetExtension(tenfile));
               
                File.Copy(tenfile, thuMucDich);

                taoanh_tufileanh(picHinhDaiDien, thuMucDich);
                txttenhinh.Text = txtmasp.Text.ToString() + Path.GetExtension(tenfile);
                btnthemsanpham.Visible = true;
            }
        }

        void load_CTSPtheoMASP(string masp)
        {
            string s = "select * from ct_sanpham where masp='" + masp + "'";
            dsCTSP = c.LayDuLieu(s);
            dgvCTSP.DataSource = null;
            dgvCTSP.Columns.Clear();
            dgvCTSP.DataSource = dsCTSP.Tables[0];
        }

        //private void cboncc_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //   if (f)
        //    {
        //        if (cboncc.SelectedIndex != -1)
        //        {
        //            string mancc = cboncc.SelectedValue.ToString();
        //            string masp = "";
        //            string sql = "select masp from sanpham where mancc='"+ mancc+"'";
        //            DataSet ds = c.LayDuLieu(sql);
        //            if (ds.Tables[0].Rows.Count < 9) // tùy theo mình xử lý
        //            {
        //                masp = (mancc +"0" + (ds.Tables[0].Rows.Count + 1).ToString()).Replace(" ","");
        //            }
        //            else
        //                masp = (mancc+(ds.Tables[0].Rows.Count + 1).ToString()).Replace(" ", "");
        //            txtmasp.Text = masp;
        //        }
        //    }

        //}

        private void cboloaisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f)
            {
                if (cboloaisp.SelectedIndex != -1)
                {
                    string maloai = cboloaisp.SelectedValue.ToString();
                    dsNhacungcap = c.LayDuLieu("select * from nhacungcap where loaisp ='" + maloai + "'");
                    HienthiCombobox(cboncc, dsNhacungcap, "TENNCC", "MANCC");
                }

            }
        }
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = e.RowIndex;
                hienthi_textbox(dsSanPham.Tables[0], vitri);
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = e.RowIndex;
                hienthi_textbox(dsSanPham.Tables[0], vitri);
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtgianhap_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Enter)
            {
                float gianhap = int.Parse(txtgianhap.Text);
                txtgiaban.Text = (gianhap * 2).ToString();
                txtgiadangbai.Text = (gianhap * 2.5).ToString();
                txtgia1.Text = (gianhap * 1.5).ToString();
                txtgia2.Text = (gianhap * 1.75).ToString();
            }    
        }

        private void btnThemSize_Click(object sender, EventArgs e)
        {
            frmSize f = new frmSize();
            if (f.ShowDialog() == DialogResult.OK)
            {
                flpSize.Controls.Clear();   
                foreach(CheckBox chk in f.dschonsize)
                {
                    flpSize.Controls.Add(chk);  
                }    
            }
        }

        void TaoCotCTSP()
        {
            dgvCTSP.Columns.Clear();
            dgvCTSP.Columns.Add("MaCTSP", "Mã CTSP");
            dgvCTSP.Columns.Add("MaSP", "Mã sản phẩm");
            dgvCTSP.Columns.Add("Mamau", "Mã màu");
            dgvCTSP.Columns.Add("Masize", "Size");
            dgvCTSP.Columns.Add("soluong", "Số lượng");
            dgvCTSP.Columns.Add("giaban", "Giá bán");
            dgvCTSP.Columns.Add("hinh", "Hình theo mẫu");
            dgvCTSP.Columns.Add("ghichu", "Ghi chú");

        }

        void TaoCotSP()
        {
            dgvDanhSach.Columns.Clear();
       //     dgvDanhSach.DataSource = null;
            dgvDanhSach.Columns.Add("Masp", "mã sản phẩm");
            dgvDanhSach.Columns.Add("tensp","tên sản phẩm");
            dgvDanhSach.Columns.Add("Maloai", "Mã loại");
            dgvDanhSach.Columns.Add("Mancc", "Mã NCC");
          
        }

        string mactsp = "";
        int soluongtheoctsp = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (cboloaisp.SelectedIndex == -1 || cboncc.SelectedIndex == -1 || string.IsNullOrEmpty(txttensp.Text) || string.IsNullOrEmpty(txtgianhap.Text) 
                || string.IsNullOrEmpty(txtdvt.Text) || string.IsNullOrEmpty(txtsoluongtheosize.Text)  )
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu!" ,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            object[] d = new object[8];
            object ctsp;
            float giabansize = 0;
            int tongsoluong = 0;
            giabansize = float.Parse(txtgiaban.Text);
                foreach (CheckBox c in flpSize.Controls)
            {
                d[0] = (txtmasp.Text + "." + cbomau.SelectedValue.ToString() + "." + c.Name).Replace(" ", ""); // mã chi tiết sản phẩm
         
                d[1] = txtmasp.Text;
                d[2] = cbomau.SelectedValue.ToString();
                d[3] = c.Name;
                d[4] = txtsoluongtheosize.Text;
                if (txtgialech.Text == "")
                    d[5] = txtgiaban.Text;
                else
                {
                    giabansize += float.Parse(txtgiaban.Text);
                    d[5] = giabansize.ToString();
                }
                d[6] = txttenhinh.Text;
                d[7] = "";

                //for (int i = 0; i < dgvCTSP.Rows.Count; i++)
                //{
                //    if (a == dgvCTSP.Rows[i].Cells["MaCTSP"].Value.ToString())
                //    {
                //        soluongtheoctsp = Convert.ToInt32(txtsoluongtheosize.Text);
                //        mactsp = d[0].ToString();
                //        co = 1;
                //        break;
                //    }    
                //}
                //if (co == 1)
                //{
                //    foreach (DataGridViewRow row in dgvCTSP.Rows)
                //    {
                //        if (mactsp == row.Cells["MaCTSP"].Value.ToString())
                //            row.Cells["MaCTSP"].Value = soluongtheoctsp + row.Cells["soluong"].Value.ToString();
                //        break;
                //    }
                //}
                tongsoluong += int.Parse(txtsoluongtheosize.Text);
                txtsoluong.Text = tongsoluong.ToString();
                dgvCTSP.Rows.Add(d);

            }
            int sum = 0;
            for (int i = 0; i < dgvCTSP.Rows.Count; i++)
            {
                sum += Convert.ToInt32(dgvCTSP.Rows[i].Cells["soluong"].Value);
            }
            txtsoluong.Text = sum.ToString();

        }

        private void btnthemsanpham_Click(object sender, EventArgs e)
        {
            btnthemctsp.Visible = true;
            object[] d = new object[8];
            d[0] = txtmasp.Text;
            d[1] = txttensp.Text;
            d[2]  = cboloaisp.SelectedValue.ToString();
            d[3] = cboncc.SelectedValue.ToString();
        //    d[4]
            dgvDanhSach.Rows.Add(d);
        }

        private void dgvCTSP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (f)
                {
                    if (flag == 1)//THEM
                    {
                        if (e.ColumnIndex == 4)
                        {
                            int TONGSL = 0;
                            for (int i = 0; i < dgvCTSP.Rows.Count - 1; i++)
                            {
                                TONGSL += int.Parse(dgvCTSP.Rows[i].Cells[4].Value.ToString());
                            }
                            txtsoluong.Text = TONGSL.ToString();
                        }
                        if (e.ColumnIndex == 7)
                        {
                            int vt = dgvCTSP.CurrentRow.Index;
                            string ghichu = dgvCTSP.CurrentRow.Cells[7].Value.ToString();
                            string sql = "update CT_sanpham set ghichu= N'" + ghichu + "' where mactsp='" + dgvCTSP.Rows[vt].Cells["MACTSP"].Value.ToString() + "'";
                            if (c.capnhatdulieu(sql) > 0)
                            {
                                MessageBox.Show("Cập nhật thành công");
                                vitri = 0;

                            }

                        }
                    }
                    if (flag == 2)//SUA
                    {
                        if (e.ColumnIndex == 4)
                        {
                            int TONGSL = 0;
                            string masp = "";
                            for (int i = 0; i < dgvCTSP.Rows.Count - 1; i++)
                            {
                                TONGSL += int.Parse(dgvCTSP.Rows[i].Cells[6].Value.ToString());
                                masp = dgvCTSP.Rows[i].Cells[1].Value.ToString();
                            }
                            txtsoluong.Text = TONGSL.ToString();

                        }
                        if (e.ColumnIndex == 7)
                        {
                            int vt = dgvCTSP.CurrentRow.Index;
                            string ghichu = dgvCTSP.CurrentRow.Cells[7].Value.ToString();
                            string sql = "update CT_sanpham set ghichu= N'" + ghichu + "' where mactsp='" + dgvCTSP.Rows[vt].Cells["MACTSP"].Value.ToString() + "'";
                            if (c.capnhatdulieu(sql) > 0)
                            {
                                MessageBox.Show("Cập nhật thành công");
                                vitri = 0;

                            }

                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtgianhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true;
                MessageBox.Show("Nhập sai dữ liệu","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmmau a = new frmmau();
            a.btnthem_Click(sender, e);
            a.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
