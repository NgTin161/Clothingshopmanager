using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SANPHAM
{
    internal class clsquanlibanhang
    {
        SqlConnection con = new SqlConnection();

        void ketnoi()
        {
            con.ConnectionString = @"Data source=TINNGUYEN\MSSQLSERVER01;Initial Catalog=QLBH_BANQUANAO2;integrated Security=True";
            if (con.State == ConnectionState.Closed)
                con.Open();
        }

        void dongketnoi()
        {
            con.Close();
        }

        public DataSet LayDuLieu(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql,con);
            da.Fill(ds);

            return ds;
        }

        public clsquanlibanhang()
        {
            ketnoi();
        }

        public int capnhatdulieu(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            return cmd.ExecuteNonQuery();
        }
    }
}
