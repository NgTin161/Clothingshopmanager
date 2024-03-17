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
    public partial class frmTimkiem : Form
    {
        public frmTimkiem()
        {
            InitializeComponent();
        }
        clsquanlibanhang c = new clsquanlibanhang();
        DataSet dsLoaisp = new DataSet();
        DataSet dsSanPham = new DataSet();
        Boolean f = false;
        void HienthiCombobox(ComboBox cbo, DataSet ds,string ten, string ma)
        {
            cbo.DataSource = ds.Tables[0];
            cbo.DisplayMember = ten;
            cbo.ValueMember = ma;
            cbo.SelectedIndex = -1;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dsLoaisp = c.LayDuLieu("select * from loaisp");
            HienthiCombobox(cboLoaisp, dsLoaisp,"TENLOAISP", "MALOAI");
            f = true;
        }

        private void cboLoaisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(f)
                if(cboLoaisp.SelectedIndex != -1)
                {
                    string maloai = cboLoaisp.SelectedValue.ToString();
                    string sql = "select * from sanpham where maloai='" + maloai + "'";
                    dsSanPham = c.LayDuLieu(sql);
                    dgvDanhSach.DataSource = dsSanPham.Tables[0];
                }    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
