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
    public partial class LoaiSP : Form
    {
        public LoaiSP()
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
            txtmaloai.ReadOnly = t;
            txtmaloai.BackColor = Color.Gray;
        }


        public void btnthem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            xulytestbox(true);
            txtmaloai.Text = phatsinh_1();//tự phát sinh mã\
            txttenloai.Text = "";
            cbotinhtrang.SelectedIndex = 0;
            flag = 1;
        }
        string phatsinh_1()
        {
            string maloai = "";
            DataSet dsloai = c.LayDuLieu("select maloai from loaisp");
            maloai = "L" + (dsloai.Tables[0].Rows.Count + 1).ToString();

            return maloai;
        }
        void hienthi_textbox(DataTable dt, int vt)
        {
            try
            {
                txtmaloai.Text = dt.Rows[vt]["MALOAI"].ToString();
                txttenloai.Text = dt.Rows[vt]["TENLOAISP"].ToString();
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
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (flag == 1)
                {
                    sql = "insert into loaisp values('" + txtmaloai.Text + "',N'" + txttenloai.Text + "',0)";
                }
                if (flag == 2)
                {
                    sql = "update loaisp set tenloaisp= N'" + txttenloai.Text + "', trangthai=" + cbotinhtrang.SelectedIndex + " where maloai='" + txtmaloai.Text + "'";
                }
                if (flag == 3)
                {
                    sql = "update loaisp set trangthai=1 where maloai='" + txtmaloai.Text + "'";
                }

                if (c.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    vitri = 0;
                    LoaiSP_Load(sender, e);
                }
            }
            catch 
            {
                MessageBox.Show("Đã có lỗi xảy ra" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        Boolean f = false;
     
        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vitri = e.RowIndex;
                hienthi_textbox(ds.Tables[0], vitri);
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        string maloai = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                        string tenloai = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                        string sql = "update loaisp set tenloai=N'" + tenloai + "' where maloai='" + maloai + "'";
                        if (c.capnhatdulieu(sql) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            vitri = 0;
                            LoaiSP_Load(sender, e);
                        }
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Đã có lỗi xảy ra !" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txttenloai_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoaiSP_Load(object sender, EventArgs e)
        {
            xulychucnang(true);
            ds = c.LayDuLieu("select * from loaisp where trangthai = 0");
            //  danhsach_datagridview(dgvDanhsach, "select * from nhanvien");
            loaddulieu_datagrid(dgvDanhSach, ds);
            hienthi_textbox(ds.Tables[0], vitri);
            f = true;
        }
    }
}
