using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVirtual
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string connectionString = "workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma";
            string query = "SELECT Nombre, Apellido, iDCliente, Correo, Telefono, Direccion, Row FROM Clientes WHERE Correo=@Correo AND Contrasena=@Contrasena;";

            
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                
                cmd.Parameters.Add("@Correo", SqlDbType.VarChar, 50).Value = Correo.Value.ToString();
                cmd.Parameters.Add("@Contrasena", SqlDbType.VarChar, 50).Value = Contrasena.Value.ToString();

                
                con.Open();

                
                using (SqlDataReader dr = cmd.ExecuteReader())
                {                     
                    if (dr.Read())
                    {                        
                        string nombre = dr.GetFieldValue<string>(0);
                        string apellido = dr.GetFieldValue<string>(1);
                        string cliente = ""+nombre+" "+apellido+"";
                        HttpCookie clienteS = new HttpCookie("clienteC");
                        clienteS.Value = cliente;
                        clienteS.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(clienteS);
                        string idcliente = dr.GetFieldValue<Guid>(2).ToString();
                        HttpCookie idclienteS = new HttpCookie("idclienteC");
                        idclienteS.Value = idcliente;
                        idclienteS.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(idclienteS);
                        string correo = dr.GetFieldValue<string>(3).ToString();
                        HttpCookie correoS = new HttpCookie("correoC");
                        correoS.Value = correo;
                        correoS.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(correoS);
                        string telefono = dr.GetFieldValue<string>(4).ToString();
                        HttpCookie telefonoS = new HttpCookie("telefonoC");
                        telefonoS.Value = telefono;
                        telefonoS.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(telefonoS);
                        string direccion = dr.GetFieldValue<string>(5).ToString();
                        HttpCookie direccionS = new HttpCookie("direccionC");
                        direccionS.Value = direccion;
                        direccionS.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(direccionS);
                        string row = dr.GetFieldValue<Int32>(6).ToString();
                        HttpCookie rowS = new HttpCookie("rowC");
                        rowS.Value = row;
                        rowS.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(rowS);
                        Response.Redirect("Default.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Usuario y Contraseña incorrectos')</script>");
                        
                    }

                    dr.Close();
                }

                con.Close();
            }
        }
    }
}