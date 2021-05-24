using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaVirtual.Conexion;

namespace TiendaVirtual
{
    public partial class Categorias : Page
    {
        string search;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Producto", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);            
            search = Request.Cookies["categ"].Value;
            if (search != null)
            {
                DataTable dtResult = dt.Select("Categoria LIKE '%" + search + "%'").CopyToDataTable();
                if (dtResult != null)
                {
                    ListView1.DataSource = dtResult;
                }
                else
                {
                    Response.Write("<script>alert('En estos Momentos no se encuentra Disponible')</script>");
                    ListView1.DataSource = dtResult;
                }
                    
            }
            else
            {

                ListView1.DataSource = dt;

            }
            ListView1.DataBind();


        }







    }
}