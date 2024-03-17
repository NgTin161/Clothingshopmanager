using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace SANPHAM
{
    public partial class frmSize : Form
    {
        public frmSize()
        {
            InitializeComponent();
        }
    clsquanlibanhang c = new clsquanlibanhang();
    DataSet dsSize = new DataSet(); 
    public ArrayList dschonsize = new ArrayList();

        private void frmSize_Load(object sender, EventArgs e)
        {
            dsSize = c.LayDuLieu("select * from size where trangthai = 0");
            for (int i = 0; i < dsSize.Tables[0].Rows.Count; i++)
            {
                CheckBox chk = new CheckBox();
                chk.Name = dsSize.Tables[0].Rows[i]["MASIZE"].ToString();
                chk.Text = dsSize.Tables[0].Rows[i]["TENSIZE"].ToString();
                flpSize.Controls.Add(chk);
            }
        }

        private void btnchon_Click(object sender, EventArgs e)
        {
            foreach(CheckBox chk in flpSize.Controls)
                if(chk.Checked)
                    dschonsize.Add(chk);
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            frmkichthuoc a = new frmkichthuoc();
            a.ShowDialog(); 
        }

        private void flpSize_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
