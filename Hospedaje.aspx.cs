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
    public partial class Hospedaje : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregistro_Click(object sender, EventArgs e)
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("insert into TBL_HOSPEDAJE (ID_Hospedaje,NOM_Hospedaje,DIR_Hospedaje,DET_Hospedaje) values ('" + txtidHos.Text + "','" + txtnomHos.Text + "','" + txtdirHos.Text + "','" + txtdetaHos.Text + "')", con);
            con.Open();
            ordenSQL.ExecuteNonQuery();
            con.Close();


            DataTable Mytable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_Hospedaje", con);
            da.Fill(Mytable);
            GridView1.DataSource = Mytable.DefaultView;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)// es boton buscar//
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("select * from TBL_HOSPEDAJE where ID_Hospedaje='" + txtidHos.Text + "'", con);
            con.Open();

            SqlDataReader dr = ordenSQL.ExecuteReader(); 
            if (dr.Read())
            {
                txtnomHos.Text = dr.GetString(1);
                txtdirHos.Text = dr.GetString(2);
                txtdetaHos.Text = dr.GetString(3);

            }

            con.Close();
            dr.Dispose();
        }

        protected void btnActualizarHos_Click(object sender, EventArgs e)
        {
            string StringConDB = "Data Source=.;Initial Catalog=BDTURISMO;Persist Security Info=True;User ID=sa;Password=12345";
            SqlConnection con = new SqlConnection(StringConDB);
            SqlCommand ordenSQL;
            ordenSQL = new SqlCommand("update TBL_Hospedaje set  NOM_Hospedaje='" + txtnomHos.Text +  "' where ID_Hospedaje='" + txtidHos.Text + "'", con);
            
            
            con.Open();
            ordenSQL.ExecuteNonQuery();
            con.Close();



            DataTable Mytable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_Hospedaje", con);
            da.Fill(Mytable);
            GridView1.DataSource = Mytable.DefaultView;
            GridView1.DataBind();

        }
    }
}