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
    public partial class frmmau : Form
    {
        public frmmau()
        {
            InitializeComponent();
        }

        clsquanlibanhang c = new clsquanlibanhang();
        DataSet ds = new DataSet();
        int vitri = 0;
        int flag = 0;
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
            txtmamau.ReadOnly = t;
            txtmamau.BackColor = Color.Gray;
        }

        Boolean kiemtra()
        {
            DataSet ds = new DataSet();
            ds = c.LayDuLieu("select * from mau where tenmau= N'" + txttenmau.Text.ToString() + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(txttenmau.Text.ToString(), @"[^\w\s\d]") || txttenmau.Text.ToString() == "")
                return true;
            return false;
        }
            public void btnthem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            xulytestbox(true);
            txtmamau.Text = phatsinh_1();//tự phát sinh mã\
            txttenmau.Text ="";
            cbotinhtrang.SelectedIndex = 0;
            flag = 1;
        }
        string phatsinh_1()
        {
            string masize = "";
            DataSet dssize = c.LayDuLieu("select mamau from mau");
            masize = "M" +(dssize.Tables[0].Rows.Count + 1).ToString();

            return masize;
        }
        void hienthi_textbox(DataTable dt, int vt)
        {
            try
            {
                txtmamau.Text = dt.Rows[vt]["MAMAU"].ToString();
                txttenmau.Text = dt.Rows[vt]["TENMAU"].ToString();
                string b = dt.Rows[vt]["TRANGTHAI"].ToString();
                if (b == "0")
                {
                    cbotinhtrang.SelectedIndex = 0;
                }
                else
                    cbotinhtrang.SelectedIndex = 1;
            }
            catch (Exception)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                string sql = "";
                string tenmau = txttenmau.Text.ToString();
                if (flag == 1)
                {
                    if (kiemtra() == true)
                    {
                        MessageBox.Show("Trùng tên màu hoặc chứa ký tự đặc biệt hoặc số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sql = "insert into mau values('" + txtmamau.Text + "',N'" +  txttenmau.Text   + "',0)";
                }
                if (flag == 2)
                {

                    if (kiemtra() == true)
                    {
                        MessageBox.Show("Trùng tên màu hoặc chứa ký tự đặc biệt hoặc số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sql = "update mau set tenmau= N'" + txttenmau.Text + "', trangthai=" + cbotinhtrang.SelectedIndex + " where mamau='" + txtmamau.Text + "'";
                }
                if (flag == 3)
                {
                    sql = "update mau set trangthai=1 where mamau='" + txtmamau.Text + "'";
                }

                if (c.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    vitri = 0;
                    frmMau_Load(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra !" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            xulychucnang(true);
        }

        Boolean f = false;
        private void frmMau_Load(object sender, EventArgs e)
        {
            xulychucnang(true);
            ds = c.LayDuLieu("select * from mau where trangthai = 0");
            //  danhsach_datagridview(dgvDanhsach, "select * from nhanvien");
            loaddulieu_datagrid(dgvDanhSach, ds);
            hienthi_textbox(ds.Tables[0], vitri);
            f = true;

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
                MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDanhSach_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            
                if (f)
                {
                if (e.ColumnIndex >= 1)
                {
                    int vt = dgvDanhSach.CurrentRow.Index;
                    string mamau = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tenmau = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string sql = "update mau set tenmau=N'" + tenmau + "' where mamau='" + mamau + "'";
                    try {
                        if (c.capnhatdulieu(sql) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            vitri = 0;
                            frmMau_Load(sender, e);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                }
        
        }


        private void frmmau_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
