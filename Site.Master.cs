using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["clienteC"] != null) 
            {
                nombrecliente.Text = "Bienvenido: "+ Request.Cookies["clienteC"].Value + "";
                Label1.Text = "Email: "+Request.Cookies["correoC"].Value+"";
                Label2.Text = "Telefono: "+Request.Cookies["telefonoC"].Value+"";
                Label3.Text = "Dirección: "+Request.Cookies["direccionC"].Value+"";                
            }
            else
            {
                nombrecliente.Text = "Bienvenido";
                Label1.Text = "";
                Label2.Text = "";
                Label3.Text = "";
            }
            SqlConnection con = new SqlConnection("workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma");
            SqlDataAdapter sda = new SqlDataAdapter("select Categoria from Categorias", con);
            DataTable dt = new DataTable();            
            sda.Fill(dt);
            ListViewCat.DataSource = dt;
            ListViewCat.DataBind();


        }
        protected void botonladilla(object sender, EventArgs e)
        {
            Response.Redirect("Bolivares.aspx");
        }




    }
}