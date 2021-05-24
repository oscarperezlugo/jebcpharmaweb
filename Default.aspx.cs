using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TiendaVirtual.Conexion;
using TiendaVirtual.Modelos;
using static TiendaVirtual.Modelos.modelos;

namespace TiendaVirtual
{
    public partial class Default : Page
    {
        DataTable DET;        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma");
            SqlDataAdapter sda = new SqlDataAdapter("select * from Producto", con);
            DataTable dt = new DataTable();
            DET = dt;
            sda.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();
           
        }                
    }
}