using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Turismo
{
    public partial class Restaurante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtadiRes_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnregistro_Click(object sender, EventArgs e)
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("insert into TBL_RESTAURANTE (ID_Restaurante,NOM_Restaurante,DIR_Restaurante,DET_Restaurante) values ('" + txtidRes.Text + "','" + txtnomRes.Text + "','" + txtdirRes.Text + "','" + txtdetaRes.Text + "')", con);
            con.Open();
            ordenSQL.ExecuteNonQuery();
            con.Close();


            DataTable Mytable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_RESTAURANTE", con);
            da.Fill(Mytable);
            GridView2.DataSource = Mytable.DefaultView;
            GridView2.DataBind();
        }

        protected void btnbuscarRes_Click(object sender, EventArgs e)
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("select * from TBL_Restaurante where ID_Restaurante='" + txtidRes.Text + "'", con);
            con.Open();

            SqlDataReader dr = ordenSQL.ExecuteReader();
            if (dr.Read())
            {
                txtnomRes.Text = dr.GetString(1);
                txtdirRes.Text = dr.GetString(2);
                txtdetaRes.Text = dr.GetString(3);

            }

            con.Close();
            dr.Dispose();
        }

        protected void btnactualiRes_Click(object sender, EventArgs e)
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("update TBL_Restaurante set  NOM_Restaurante='" + txtnomRes.Text + "' where ID_Restaurante='" + txtidRes.Text + "'", con);


            con.Open();
            ordenSQL.ExecuteNonQuery();
            con.Close();



            DataTable Mytable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_Restaurante", con);
            da.Fill(Mytable);
            GridView2.DataSource = Mytable.DefaultView;
            GridView2.DataBind();
        }
    }
}