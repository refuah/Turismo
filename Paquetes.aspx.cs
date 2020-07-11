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
    public partial class Paquetes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistro_Click(object sender, EventArgs e)
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("insert into TBL_PAQUETE (ID_Paquete,NOM_Paquete,DET_Paquete,PRE_Paquete) values ('" + txtidPaque.Text + "','" + txtnomPa.Text + "','" + txtdetPaq.Text + "','" + txtprePaq.Text + "')", con);
            con.Open();
            ordenSQL.ExecuteNonQuery();
            con.Close();


            DataTable Mytable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_PAQUETE", con);
            da.Fill(Mytable);
            GridView3.DataSource = Mytable.DefaultView;
            GridView3.DataBind();
        }

        protected void btnBuscarPa_Click(object sender, EventArgs e)
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("select * from TBL_PAQUETE where ID_Paquete='" + txtidPaque.Text + "'", con);
            con.Open();

            SqlDataReader dr = ordenSQL.ExecuteReader();
            if (dr.Read())
            {
                txtnomPa.Text = dr.GetString(1);
                txtdetPaq.Text = dr.GetString(2);
                txtprePaq.Text = dr.GetString(3);

            }

            con.Close();
            dr.Dispose();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("update TBL_PAQUETE set  NOM_Paquete='" + txtnomPa + "' where ID_Paquete='" + txtidPaque.Text + "'", con);

            con.Open();
            ordenSQL.ExecuteNonQuery();
            con.Close();

            DataTable Mytable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_PAQUETE", con);
            da.Fill(Mytable);
            GridView3.DataSource = Mytable.DefaultView;
            GridView3.DataBind();
        }
    }
}