using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SANPHAM
{
    public partial class frmKhachhang : Form
    {
        public frmKhachhang()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Xulichucnang(true);
            ds = c.LayDuLieu("select * from khachhang where trangthai = 0");
            //  danhsach_datagridview(dgvDanhsach, "select * from nhanvien");
            loaddulieu_datagrid(dgvDanhSach, ds);
            hienthi_textbox(ds.Tables[0], vitri);
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
            txtmakh.ReadOnly = t;
           // txtmankh.BackColor = Color.Gray;
        }
        


        void hienthi_textbox(DataTable dt, int vt)
        {
            try
            {
                txtmakh.Text = dt.Rows[vt]["MAKH"].ToString();
                txtten.Text = dt.Rows[vt]["TENKH"].ToString();
                datNgaysinh.Text = dt.Rows[vt]["NGSINH"].ToString();
                txtdiachi.Text = dt.Rows[vt]["DCHI"].ToString();
                datNgaydangki.Text = dt.Rows[vt]["NGAYTAOTK"].ToString();
                txtsdt.Text = dt.Rows[vt]["SDT"].ToString();
                txtmail.Text = dt.Rows[vt]["DCMAIL"].ToString();
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
            }
              catch (Exception)
            {
                MessageBox.Show("Không có gì để hiển thị!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void btnthem_Click(object sender, EventArgs e)
        {
            xoatextbox();
            xulychucnang(false);
            xulytestbox(true);
            txtmakh.Text = phatsinh_1();//tự phát sinh mã
            cbotrangthai.SelectedIndex = 0;
            radNam.Enabled = true;
            radNu.Enabled = true;
            flag = 1;
        }

        string phatsinh_1()
        {
            string makh = "";
            DataSet dskh = c.LayDuLieu("select MAKH from KHACHHANG");
            if (dskh.Tables[0].Rows.Count <= 9) // tùy theo mình xử lý
            {
                makh = "KH0" + (dskh.Tables[0].Rows.Count+1).ToString();
            }
            else
                makh = ("KH"+dskh.Tables[0].Rows.Count + 1).ToString().Replace(" ", "");
            return makh;
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

        void xoatextbox()
        {
            txtten.Clear();
            txtmail.Clear();
            txtdiachi.Clear();
            txtsdt.Clear();
            datNgaydangki.Value = DateTime.Now;
            datNgaysinh.Value = DateTime.Now;
            radNam.Checked = false;
            radNu.Checked = false;
        }

        bool kiemtra()
        {
            DataSet ds = new DataSet();
            ds = c.LayDuLieu("select * from khachhang where sdt= '" + txtsdt.Text.ToString() + "'");
            if (System.Text.RegularExpressions.Regex.IsMatch(txtten.Text.ToString(), @"[^\w\s\d]") || txtten.Text.ToString() == "")
            {
                MessageBox.Show("Tên không chứa ký tự đặc biệt/số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xulychucnang(false);
                return true;

            }
            if (System.Text.RegularExpressions.Regex.IsMatch(txtdiachi.Text.ToString(), @"[^\w\s]") || txtdiachi.Text.ToString() == "")
            {
                MessageBox.Show("Địa chỉ không chứa ký tự đặc biệt/số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xulychucnang(false);
                return true;

            }
            DateTime ngayHienTai = DateTime.Now;
            DateTime ngaySinh = DateTime.ParseExact(datNgaysinh.Value.ToString("MM/dd/yyyy"), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime ngayDangky = DateTime.ParseExact(datNgaydangki.Value.ToString("MM/dd/yyyy"), "MM/dd/yyyy", CultureInfo.InvariantCulture);
            if (ngaySinh > ngayHienTai || ngayDangky > ngayHienTai)
            {
                // Ngày sinh lớn hơn ngày hiện tại
                MessageBox.Show("Ngày sinh/ Ngày đăng ký không được lớn hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xulychucnang(false);
                return true;
            }
            if (txtsdt.Text.Length != 10 || !System.Text.RegularExpressions.Regex.IsMatch(txtsdt.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("Nhập sai SĐT", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xulychucnang(false);
                return true;
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show("SĐT đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            string email = txtmail.Text;
            bool isValidEmail = Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            if (!isValidEmail)
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xulychucnang(false);
                return true;
            }

            if ( radNam.Checked == false && radNu.Checked == false )
            {
                MessageBox.Show("Chưa chọn giới tính ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xulychucnang(false);
                return true;
            }

            return false;


        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiemtra() == true)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại !", " Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                xulychucnang(true);
                string sql = "";
                string gt = "";
                string ngaysinh = datNgaysinh.Value.ToString("MM/dd/yyyy");
                string ngaydangki = datNgaydangki.Value.ToString("MM/dd/yyyy");

                if (radNam.Checked == true)
                    gt = radNam.Text;
                else
                    gt = radNu.Text;
                if (flag == 1)
                {
                    sql = "insert into khachhang values('" + txtmakh.Text + "',N'" + txtten.Text + "','" + ngaysinh + "',N'" + gt + "',N'" + txtdiachi.Text + "','" + txtsdt.Text + "','" + txtmail.Text + "','" + ngaydangki + "',0)";
                }
                if (flag == 2)
                {
                    sql = "update khachhang set tenkh=N'" + txtten.Text + "', ngsinh='" + ngaysinh + "',dchi=N'" + txtdiachi.Text + "', ngaytaotk='" + ngaydangki + "',sdt='" + txtsdt.Text + "',gioitinh =N'" + gt + "',dcmail='" + txtmail.Text + "',trangthai=" + cbotrangthai.SelectedIndex + " where makh='" + txtmakh.Text + "'";
                }
                if (flag == 3)
                {
                    sql = "update khachhang set trangthai= 1 where makh='" + txtmakh.Text + "'";
                }

                if (c.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    vitri = 0;
                    Form1_Load(sender, e);
                }
            }
            catch 
            {
                MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string makh = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                        string ten = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                        string ngsinh = dgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                        string gt = dgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                        string dchi = dgvDanhSach.CurrentRow.Cells[4].Value.ToString();
                        string sdt = dgvDanhSach.CurrentRow.Cells[5].Value.ToString();
                        string mail = dgvDanhSach.CurrentRow.Cells[6].Value.ToString();
                        string ngtaotk = dgvDanhSach.CurrentRow.Cells[7].Value.ToString();

                        string sql = "update khachhang set tenkh=N'" + ten + "', ngsinh='" + ngsinh + "', dchi=N'" + dchi + "', mail='" + mail + "', ngaytaotk='" + ngtaotk + "', sdt='" + sdt + "', gioitinh='" + gt + "' where makh='" + makh + "'";
                        if (c.capnhatdulieu(sql) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            vitri = 0;
                            Form1_Load(sender, e);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Đã có ỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            kg = MessageBox.Show("Bạn có muốn thoát không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kg == DialogResult.No)
                e.Cancel = true;
        }

        private void btnthoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
