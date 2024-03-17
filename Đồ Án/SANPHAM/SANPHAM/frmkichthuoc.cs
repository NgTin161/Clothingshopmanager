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
    public partial class frmkichthuoc : Form
    {
        public frmkichthuoc()
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
            txtmasize.ReadOnly = t;
            txtmasize.BackColor = Color.Gray;
        }

  
        private void btnthem_Click(object sender, EventArgs e)
        {
            xulychucnang(false);
            xulytestbox(true);
            txtmasize.Text = phatsinh_1();//tự phát sinh mã
            cbotinhtrang.SelectedIndex = 0;
            flag = 1;
        }
        string phatsinh_1()
        {
            
            DataSet dssize = c.LayDuLieu("select masize from size");
            string masize = "S" + (dssize.Tables[0].Rows.Count + 1).ToString();

            return masize;
        }
        void hienthi_textbox(DataTable dt, int vt)
        {
            try
            {
                txtmasize.Text = dt.Rows[vt]["MASIZE"].ToString();
                txttensize.Text = dt.Rows[vt]["TENSIZE"].ToString();
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

        Boolean kiemtra()
        {
            DataSet ds = new DataSet();
            ds = c.LayDuLieu("select * from size where tensize= N'" + txttensize.Text.ToString() + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(txttensize.Text, @"[^\w\s]") || txttensize.Text == "" || System.Text.RegularExpressions.Regex.IsMatch(txttensize.Text, @"\d"))
                return true;
            return false;
        }
        private void btnluu_Click(object sender, EventArgs e)
        {
            try
            {
                xulychucnang(true);
                string sql = "";
                if (flag == 1)
                {
                    if (kiemtra() == true)
                    {
                        MessageBox.Show("Trùng tên size hoặc chứa ký tự đặc biệt hoặc số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sql = "insert into size values('" + txtmasize.Text + "','" + txttensize.Text + "','"+ cbotinhtrang.SelectedIndex.ToString()+ "')";
                }
                if (flag == 2)
                {
                    if (kiemtra() == true)
                    {
                        MessageBox.Show("Trùng tên size hoặc chứa ký tự đặc biệt hoặc số !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    sql = "update size set tensize='" + txttensize.Text + "', trangthai=" + cbotinhtrang.SelectedIndex.ToString() + " where masize='" + txtmasize.Text + "'";
                }
                if (flag == 3)
                {
                    sql = "update size set trangthai=1 where masize='" + txtmasize.Text + "'";
                }

                if (c.capnhatdulieu(sql) > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    vitri = 0;
                    frmSize_Load(sender, e);
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra ! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void frmSize_Load(object sender, EventArgs e)
        {
            xulychucnang(true);
            ds = c.LayDuLieu("select * from size x");
            //  danhsach_datagridview(dgvDanhsach, "select * from nhanvien");
            loaddulieu_datagrid(dgvDanhSach, ds);
            hienthi_textbox(ds.Tables[0], vitri);
            f= true;

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
                    string masize = dgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                    string tensize = dgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                    string sql = "update size set tensize= N'" + tensize + "' where masize='" + masize + "'";
                    try
                    {
                        if (c.capnhatdulieu(sql) > 0)
                        {
                            MessageBox.Show("Cập nhật thành công");
                            vitri = 0;
                            frmSize_Load(sender, e);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Đã có lỗi xảy ra!" ,"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       

        
    }
}
