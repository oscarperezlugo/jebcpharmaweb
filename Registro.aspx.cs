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
    public partial class Registro : System.Web.UI.Page
    {
        System.Guid GUID;
        protected void Page_Load(object sender, EventArgs e)
        {
            GUID = System.Guid.NewGuid();
        }        
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (Contraseña.Value.ToString() == Repetir.Value.ToString())
            {

                using (SqlConnection openCon = new SqlConnection("workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma"))
                {
                    string saveStaff = "INSERT into Clientes (Nombre, Apellido, Correo, Telefono, Direccion, FechaRegistro, Contrasena, iDCliente) VALUES (@Nombre, @Apellido, @Correo, @Telefono, @Direccion, @FechaRegistro, @Contrasena, @iDCliente)";

                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;
                        querySaveStaff.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre.Value.ToString();
                        querySaveStaff.Parameters.Add("@Apellido", SqlDbType.VarChar).Value = Apellido.Value.ToString();
                        querySaveStaff.Parameters.Add("@Correo", SqlDbType.VarChar).Value = Correo.Value.ToString();
                        querySaveStaff.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono.Value.ToString();
                        querySaveStaff.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Dirección.Value.ToString();
                        querySaveStaff.Parameters.Add("@FechaRegistro", SqlDbType.DateTime).Value = DateTime.Now;
                        querySaveStaff.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = Contraseña.Value.ToString();
                        querySaveStaff.Parameters.Add("@iDCliente", SqlDbType.UniqueIdentifier).Value = GUID;
                        try
                        {
                            openCon.Open();
                            querySaveStaff.ExecuteNonQuery();
                            openCon.Close();
                            string nombre = Nombre.Value.ToString();
                            string apellido = Apellido.Value.ToString();
                            string cliente = "" + nombre + " " + apellido + "";
                            HttpCookie clienteS = new HttpCookie("clienteC");
                            clienteS.Value = cliente;
                            clienteS.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(clienteS);
                            string idcliente = GUID.ToString();
                            HttpCookie idclienteS = new HttpCookie("idclienteC");
                            idclienteS.Value = idcliente;
                            idclienteS.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(idclienteS);
                            string correo = Correo.Value.ToString();
                            HttpCookie correoS = new HttpCookie("correoC");
                            correoS.Value = correo;
                            correoS.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(correoS);
                            string telefono = Telefono.Value.ToString();
                            HttpCookie telefonoS = new HttpCookie("telefonoC");
                            telefonoS.Value = telefono;
                            telefonoS.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(telefonoS);
                            string direccion = Dirección.Value.ToString();
                            HttpCookie direccionS = new HttpCookie("direccionC");
                            direccionS.Value = direccion;
                            direccionS.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(direccionS);
                            string row = "1";
                            HttpCookie rowS = new HttpCookie("rowC");
                            rowS.Value = row;
                            rowS.Expires = DateTime.Now.AddDays(30);
                            Response.Cookies.Add(rowS);
                            
                            Response.Write("<script>alert('BIENVENIDO A BODEGÓN PALADAR')</script>");
                            Response.Redirect("Default.aspx");
                        }
                        catch (SqlException ex)
                        {
                            Response.Write("Error" + ex);
                        }
                    }
                }

            }
            else
            {
                Response.Write("<script>alert('LAS CONTRASEÑAS NO COINCIDEN')</script>");
            }
        }
    }
}