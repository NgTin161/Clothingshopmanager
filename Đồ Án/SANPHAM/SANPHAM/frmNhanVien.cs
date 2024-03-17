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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        clsquanlibanhang c = new clsquanlibanhang();
        DataSet ds = new DataSet();
        int vitri = 0;
        int flag = 0;
        Boolean f = false;
      

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
            txtmanv.ReadOnly = t;
            txtmanv.BackColor = Color.Gray;
            txttenhinh.ReadOnly = true;
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            Xulichucnang(true);
            xulytestbox(true);
            ds = c.LayDuLieu("select * from nhanvien where trangthai = 0");
            //  danhsach_datagridview(dgvDanhsach, "select * from nhanvien");
            loaddulieu_datagrid(dgvDanhSach, ds);
            hienthi_textbox(ds.Tables[0], vitri);
           
        }
        void taoanh_tufileanh(PictureBox p, string filename)
        {
            Bitmap a = new Bitmap(filename);
            p.Image = a;
            p.SizeMode = PictureBoxSizeMode.StretchImage;
        }



        void hienthi_textbox(DataTable dt, int vt)
        {
            try
            {
                txtmanv.Text = dt.Rows[vt]["MANV"].ToString();
                txtten.Text = dt.Rows[vt]["TENNV"].ToString();
                datNgaysinh.Text = dt.Rows[vt]["NGSINH"].ToString();
                txtdiachi.Text = dt.Rows[vt]["DCHI"].ToString();
                datNgayvaolam.Text = dt.Rows[vt]["NGVAOLAM"].ToString();
                txtsdt.Text = dt.Rows[vt]["SDT"].ToString();
                cboluong.Text = dt.Rows[vt]["LUONG"].ToString();
                string a = dt.Rows[vt]["GIOITINH"].ToString();
                if (a == "Nam")
                {
                    radNam.Checked = true;
                    radNu.Enabled = false;
                }
                else
                {
                    radNam.Enabled = false;
                    radNu.Checked = true;
                }
                //   cboluong.Text = dt.Rows[vt]["luong"].ToString();
                string b = dt.Rows[vt]["TRANGTHAI"].ToString();
                if (b == "0")
                {
                    cbotrangthai.SelectedIndex = 0;
                }
                else
                    cbotrangthai.SelectedIndex = 1;

                string tenhinh = dt.Rows[vt]["ANH"].ToString();
                string duongdan = Path.GetFullPath("anhnhanvien") + @"\" + tenhinh;
                taoanh_tufileanh(picHinhDaiDien, duongdan);
            }
            catch (Exception)
            {
                MessageBox.Show("Không có dữ liệu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //   txtten.Text = ds.Tables[0].Rows[vt]["HoTenNV"].ToString();
            //  txtmanv.Text = ds.Tables[0].Rows[vt]["MaNV"].ToString();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = e.RowIndex;
                hienthi_textbox(ds.Tables[0], vitri);
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu !","Chú ý",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        void danhsach_datagridview(DataGridView d, string sql)
        {
            DataSet ds = c.LayDuLieu(sql);
            d.DataSource = ds.Tables[0];
        }


        void Xulichucnang(bool t)
        {
            btnthem.Enabled = t;
            btnxoa.Enabled = t;
            btnsua.Enabled = t;
            btnluu.Enabled = !t;
        }

        void Clear()
        {
            txtdiachi.Text = "";
            txtsdt.Text = "";
            txtten.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            cboluong.Text = string.Empty;
            datNgaysinh.Value = DateTime.Now;
            datNgayvaolam.Value = DateTime.Now;
            picHinhDaiDien.Image = null;
        }


        private void btnthem_Click(object sender, EventArgs e)
        {
            btnLoadhinh.Visible = true;
            xulychucnang(false);
            xulytestbox(true);
            txtmanv.Text = phatsinh_1();//tự phát sinh mã
            Clear();
            cbotrangthai.SelectedIndex = 0;
            radNam.Enabled = true;
            radNu.Enabled = true;
            flag = 1;
        }

        string phatsinh_1()
        {
            string manv = "NV";
            DataSet ds = c.LayDuLieu("select MANV from NHANVIEN");
            if (ds.Tables[0].Rows.Count < 9) // tùy theo mình xử lý
            {
                manv += ("0" + (ds.Tables[0].Rows.Count + 1).ToString()).Replace(" ", "");
            }
            else
                manv= (ds.Tables[0].Rows.Count + 1).ToString().Replace(" ", "");
            return manv;

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
            radNam.Enabled = true;
            radNu.Enabled = true;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                xulychucnang(true);
                string sql = "";
                string gt = "";
                string luong = cboluong.SelectedItem != null ? cboluong.SelectedItem.ToString() : string.Empty;
                string ngaysinh = datNgaysinh.Value.ToString("MM/dd/yyyy");
                string ngayvaolam = datNgayvaolam.Value.ToString("MM/dd/yyyy");

                if (radNam.Checked == true)
                    gt = radNam.Text;
                else
                    gt = radNu.Text;
                if (flag == 1)
                {
                    sql = "insert into nhanvien values('" + txttenhinh.Text + "','" + txtmanv.Text + "',N'" + txtten.Text + "','" + ngaysinh + "',N'" + txtdiachi.Text + "','" + ngayvaolam + "','" + txtsdt.Text + "','" + gt + "','" + luong + "',0)";
                }
                if (flag == 2)
                {
                    sql = "update nhanvien set anh='" + txttenhinh.Text + "',tennv=N'" + txtten.Text + "', ngsinh='" + ngaysinh + "', dchi=N'" + txtdiachi.Text + "', ngvaolam='" + ngayvaolam + "', sdt='" + txtsdt.Text + "' gioitinh ='" + gt + "', luong ='" + luong + "', trangthai=" + cbotrangthai.SelectedIndex + " where manv='" + txtmanv.Text + "'";
                }
                if (flag == 3)
                {
                    sql = "update nhanvien set trangthai=1 where manv='" + txtmanv.Text + "'";
                }

                if (c.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    vitri = 0;
                    frmNhanVien_Load(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Lưu không thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
            vitri = e.RowIndex;
            hienthi_textbox(ds.Tables[0], vitri);
             }
            catch
            {
                MessageBox.Show("Không có dữ liệu !", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (f)
                {
                    if (e.ColumnIndex >= 1)
                    {
                        int vt = dgvDanhSach.CurrentRow.Index;
                        string anh = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                        string manv = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                        string tennv = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                        string ngsinh = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                        string dchi = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                        string ngvaolam = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                        string sdt = dgvDanhSach.CurrentRow.Cells[6].Value.ToString();
                        string gt = dgvDanhSach.CurrentRow.Cells[7].Value.ToString();
                        string luong = dgvDanhSach.CurrentRow.Cells[8].Value.ToString();

                        string sql = "update nhanvien set anh='" + anh + "', tennv=N'" + tennv + "', ngsinh='" + ngsinh + "', dchi=N'" + dchi + "', ngvaolam='" + ngvaolam + "' , sdt='" + sdt + "', gioitinh='" + gt + "' , luong='" + luong + "' where manv='" + manv + "'";
                        if (c.capnhatdulieu(sql) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            vitri = 0;
                            frmNhanVien_Load(sender, e);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lưu không thành công!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void frmsize_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult kg = new DialogResult();
            kg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kg == DialogResult.No)
                e.Cancel = true;
        }

        private void btnthoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboluong_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnLoadhinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "Tệp hình ảnh|*.jpg;*.jpeg;*.png;*.gif;*.bmp"; // Chỉ chấp nhận các định dạng hình ảnh phổ biến
            if (o.ShowDialog() == DialogResult.OK)
            {
                string tenfile = o.FileName;
             
                string thuMucDich = Path.Combine(Path.GetFullPath("anhnhanvien"), txtmanv.Text.ToString() + Path.GetExtension(tenfile)); // Đường dẫn thư mục đích

                // Sao chép tệp vào thư mục đích
                File.Copy(tenfile, thuMucDich);

                txttenhinh.Text = txtmanv.Text.ToString() + Path.GetExtension(tenfile);
                taoanh_tufileanh(picHinhDaiDien, thuMucDich);
            }
        }



    private void txttenhinh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
