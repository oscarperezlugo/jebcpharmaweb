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
    public partial class Cierre : System.Web.UI.Page
    {
        Guid VENTA;
        string CORREO;
        string TELEFONO;
        protected void Page_Load(object sender, EventArgs e)
        {            
            clientefactura.Text = Request.Cookies["clienteC"].Value;
            clientedireccion.Text = Request.Cookies["direccionC"].Value;
            CORREO = Request.Cookies["correoC"].Value;
            TELEFONO = Request.Cookies["telefonoC"].Value;
            string trasnf = Request.Cookies["venta"].Value;
            VENTA = Guid.Parse(trasnf);
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            string tipoventa;
            string metodoventa;
            string direcciondespacho;
            string correofinal;
            string telefonofinal;
            bool encaminador;
            string transaccion;            
            if (check.Checked == true)
            {
                tipoventa = "DELIVERY";
            }
            else
            {
                tipoventa = "PICK UP";
            }
            if (pagomivil1.Checked == true)
            {
                metodoventa = "PAGO MOVIL";
                transaccion = Text4.Value;
            }
            else
            {
                if (zelle1.Checked)
                {
                    metodoventa = "ZELLE";
                    transaccion = Text4.Value;
                }
                else
                {
                    if(paypal1.Checked == true)
                    {
                        metodoventa = "PAYPAL";
                        transaccion = Text4.Value;
                    }
                    else
                    {
                        if(efectivo1.Checked == true)
                        {
                            metodoventa = "EFECTIVO";
                            transaccion = "EFECTIVO";
                        }
                        else
                        {
                            if (pagomovil2.Checked == true)
                            {
                                metodoventa = "PAGO MOVIL";
                                transaccion = Text6.Value;
                            }
                            else
                            {
                                if (paypal2.Checked == true)
                                {
                                    metodoventa = "PAYPAL";
                                    transaccion = Text6.Value;
                                }
                                else
                                {
                                    if (zelle2.Checked == true)
                                    {
                                        metodoventa = "ZELLE";
                                        transaccion = Text6.Value;
                                    }
                                    else
                                    {
                                        if (efectivo2.Checked == true)
                                        {
                                            metodoventa = "EFECTIVO";
                                            transaccion = "EFECTIVO";
                                        } 
                                        else
                                        {
                                            metodoventa = null;
                                            transaccion = null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (sidel.Checked == true)
            {
                direcciondespacho = clientedireccion.Text;
            }
            else
            {
                direcciondespacho = nuevadireccion.Value;
            }
            if (efectivo1.Checked == true ^ efectivo2.Checked == true)
            {
                correofinal = CORREO;
                telefonofinal = TELEFONO;
                encaminador = true;
            }
            else
            {
                if (check.Checked == true && efectivo1.Checked == false)
                {
                    correofinal = Text2.Value;
                    telefonofinal = Text8.Value;
                }
                else
                {
                    if (pickup.Checked == true && efectivo2.Checked == false) 
                    {
                        correofinal = Text5.Value;
                        telefonofinal = Text7.Value;
                    }
                    else
                    {
                        correofinal = CORREO;
                        telefonofinal = TELEFONO;
                    }
                }
                encaminador = false;
                
            }
            if (direcciondespacho != null && metodoventa != null && tipoventa != null && encaminador == true)
            {
                using (SqlConnection openCon = new SqlConnection("workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma"))
                {

                    string saveStaff = "UPDATE Cabecera SET TipoVenta = @TipoVenta, Metodo = @Metodo, Direccion = @Direccion, Status = @Status WHERE iDVenta = @iDVenta";
                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;
                        querySaveStaff.Parameters.Add("@TipoVenta", SqlDbType.VarChar).Value = tipoventa;
                        querySaveStaff.Parameters.Add("@Metodo", SqlDbType.VarChar).Value = metodoventa;
                        querySaveStaff.Parameters.Add("@iDVenta", SqlDbType.UniqueIdentifier).Value = VENTA;
                        querySaveStaff.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = direcciondespacho;
                        querySaveStaff.Parameters.Add("@Status", SqlDbType.VarChar).Value = "PAGO POR VERIFICAR";
                        try
                        {
                            openCon.Open();
                            querySaveStaff.ExecuteNonQuery();
                            openCon.Close();
                        }
                        catch (SqlException ex)
                        {
                        }
                    }

                }
                using (SqlConnection openCon = new SqlConnection("workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma"))
                {

                    string saveStaff = "INSERT INTO Pagos(iDVenta, Metodo, Correo) VALUES (@iDVenta, @Metodo, @Correo)";
                    using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                    {
                        querySaveStaff.Connection = openCon;
                        querySaveStaff.Parameters.Add("@Correo", SqlDbType.VarChar).Value = ""+correofinal +" "+ telefonofinal+"";
                        querySaveStaff.Parameters.Add("@Metodo", SqlDbType.VarChar).Value = ""+metodoventa+" "+transaccion+"";
                        querySaveStaff.Parameters.Add("@iDVenta", SqlDbType.UniqueIdentifier).Value = VENTA;                        
                        try
                        {
                            openCon.Open();
                            querySaveStaff.ExecuteNonQuery();
                            openCon.Close();
                            
                        }
                        catch (SqlException ex)
                        {
                        }
                    }

                }

                Response.Redirect("Default.aspx");
            }
            else
            {
                if (direcciondespacho != null && metodoventa != null && tipoventa != null && encaminador == false && correofinal != null && telefonofinal != null && transaccion !=null)
                {
                    using (SqlConnection openCon = new SqlConnection("workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma"))
                    {

                        string saveStaff = "UPDATE Cabecera SET TipoVenta = @TipoVenta, Metodo = @Metodo, Direccion = @Direccion, Status = @Status WHERE iDVenta = @iDVenta";
                        using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                        {
                            querySaveStaff.Connection = openCon;
                            querySaveStaff.Parameters.Add("@TipoVenta", SqlDbType.VarChar).Value = tipoventa;
                            querySaveStaff.Parameters.Add("@Metodo", SqlDbType.VarChar).Value = metodoventa;
                            querySaveStaff.Parameters.Add("@iDVenta", SqlDbType.UniqueIdentifier).Value = VENTA;
                            querySaveStaff.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = direcciondespacho;
                            querySaveStaff.Parameters.Add("@Status", SqlDbType.VarChar).Value = "PAGO POR VERIFICAR";
                            try
                            {
                                openCon.Open();
                                querySaveStaff.ExecuteNonQuery();
                                openCon.Close();
                            }
                            catch (SqlException ex)
                            {
                            }
                        }

                    }
                    using (SqlConnection openCon = new SqlConnection("workstation id=jebcpharma.mssql.somee.com;packet size=4096;user id=paladar_SQLLogin_1;pwd=bgofrm6416;data source=jebcpharma.mssql.somee.com;persist security info=False;initial catalog=jebcpharma"))
                    {

                        string saveStaff = "INSERT INTO Pagos(iDVenta, Metodo, Correo) VALUES (@iDVenta, @Metodo, @Correo)";
                        using (SqlCommand querySaveStaff = new SqlCommand(saveStaff))
                        {
                            querySaveStaff.Connection = openCon;
                            querySaveStaff.Parameters.Add("@Correo", SqlDbType.VarChar).Value = "" + correofinal + " " + telefonofinal + "";
                            querySaveStaff.Parameters.Add("@Metodo", SqlDbType.VarChar).Value = "" + metodoventa + " " + transaccion + "";
                            querySaveStaff.Parameters.Add("@iDVenta", SqlDbType.UniqueIdentifier).Value = VENTA;
                            try
                            {
                                openCon.Open();
                                querySaveStaff.ExecuteNonQuery();
                                openCon.Close();
                                
                            }
                            catch (SqlException ex)
                            {
                            }
                        }

                    }

                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Response.Write("<script language=javascript>alert('COMPLETE LA INFORMACION')</script>");
                }
                
            }
            
        }
    }
}