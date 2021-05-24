<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cierre.aspx.cs" Inherits="TiendaVirtual.Cierre" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="Oscar Perez Lugo" content="Developer">
        <meta name="description"  content="Una Experiencia JEBCPHARMA">
        <meta name="keywords"  content="Carne, Pollo, Valencia, Venezuela">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">        
        <title>JEBCPHARMA tienda</title>
        <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <link href="Content/Columnas.css" rel="stylesheet" /> 
        <link href="Content/estilos.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    </head>
<body>
    <form id="form2" runat="server">
        
        <nav class="fila col10L">
            <div class="col2L">
                <img id="logo" src="img/Recurso3.png"/>
            </div>
            <div class="col6L">&nbsp;</div>
            <div class="col2L">
                <br />
                <br />
                <a runat="server" class="botonbodegon" href="Default.aspx">FARMACIA</a>
            </div>
        </nav>
        <hr class="linea"/>
        <div class="baseform">
            <br />
            <br />
            <br />
            <p><h2>Finalizar Compra</h2></p>
            <div class="fila col10L">                
                <p class="nombrecierre"><h4 class="nombrecierre">Estimado(a): <asp:Label class="nombrecierre" runat="server" ID="clientefactura"></asp:Label></h4></p>
                <p><a class="titulocierre">Selecciona tu tipo de venta</a></p>                                
            </div>
            <input type="radio"  class="delivery" name="TipoVenta"  id="check" runat="server"/><label class="opcionescierre" >Delivery </label><input type="radio"  class="pickup" name="TipoVenta"  runat="server" id="pickup"/><a class="opcionescierre">Pick Up</a>
            <div class="direcverif">
                <p><h4>¿Esta sera tu direccion de entrega? <asp:Label runat="server" ID="clientedireccion"></asp:Label></h4></p>
                <input type="radio"  class="deliverysi" name="TipoDirec"  id="sidel" runat="server"/><label class="opcionescierre" >Si </label><input type="radio"  class="deliveryno" name="TipoDirec"  /><a class="opcionescierre">No</a>
                
                <div class="direccion">
                    <input class="formulario" placeholder="Direccion de Envio del pedido" id="nuevadireccion" type="text"  runat="server"/>                    
                </div>
                <div class="metodo">
                    <p><a class="titulocierre">Selecciona tu medio de pago</a></p> 
                    <input type="radio"  class="pagodig" name="Tipopag"  id="pagomivil1" runat="server"/><label class="opcionescierre" >Pago Movil </label><input type="radio"  class="pagodigdos" name="Tipopag" id="zelle1" runat="server" /><a class="opcionescierre">Zelle </a><input type="radio"  class="pagodigtres" name="Tipopag"  id="paypal1" runat="server"/><a class="opcionescierre">Transferencia </a><input type="radio"  class="efectivo" name="Tipopag"  id="efectivo1" runat="server"/><a class="opcionescierre">Efectivo </a>
                <p><h4 class="pagomovil">PagoMovil corporacion JEBCPHARMA, Banesco, J-40187255-7, 58 424 4522593</h4>
                <h4 class="zelle">Zelle, jebcpharma@gmail.com, Jebcpharma LLC</h4>
                <h4 class="transferencia">Banesco, corporacion JEBCPHARMA, J-40187255-7, 0155555555555555</h4></p>
                <div class="datospago">
                    
                    <div class="formpago">
                        <input class="formulario" placeholder="Nombre del Transferente" id="Text1" type="text"  runat="server"/>
                        <input class="formulario" placeholder="Correo Asociado" id="Text2" type="text"  runat="server"/>
                        <input class="formulario" placeholder="Telefono del Transferente" id="Text8" type="text"  runat="server"/>
                        <input class="formulario" placeholder="Numero de Transaccion" id="Text4" type="text"  runat="server"/>
                        <p><a class="enlaces" href="Terminos.aspx">Revisa nuestros Terminos y Condiciones</a></p>
                        <p><a class="enlaces" href="Somos.aspx">Preguntas Frecuentes</a></p>                        
                        <asp:Button class="botonsubmit" value="PAGADO" type="submit" runat="server" CssClass="botonsubmit" Text="REGISTRAR PAGO" OnClick="Unnamed1_Click" />                                
                        <br />
                        <br />
                    </div>
                    
                </div>
                    <div class="pagoefectivo">
                        <p><a class="enlaces" href="Terminos.aspx">Revisa nuestros Terminos y Condiciones</a></p>
                        <p><a class="enlaces" href="Somos.aspx">Preguntas Frecuentes</a></p>   
                        <asp:Button class="botonsubmit" value="PAGADO" type="submit" runat="server" CssClass="botonsubmit" Text="REGISTRAR PAGO" OnClick="Unnamed1_Click" />                                 
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <div class="metodo">
                    <p><a class="titulocierre">Selecciona tu medio de pago</a></p> 
                    <input type="radio"  class="pagodig" name="Tipopag" id="pagomovil2" runat="server"/><label class="opcionescierre" >Pago Movil </label><input type="radio"  class="pagodigdos" name="Tipopag"  id="zelle2" runat="server"/><a class="opcionescierre">Zelle </a><input type="radio"  class="pagodigtres" name="Tipopag" id="paypal2" runat="server" /><a class="opcionescierre">Transferencia </a><input type="radio"  class="efectivo" name="Tipopag"  id="efectivo2" runat="server"/><a class="opcionescierre">Efectivo </a>
                <p><h4 class="pagomovil">PagoMovil corporacion JEBCPHARMA, Banesco, J-40187255-7, 58 424 4522593</h4>
                <h4 class="zelle">Zelle, jebcpharma@gmail.com, Jebcpharma LLC</h4>
                <h4 class="transferencia">Banesco, corporacion JEBCPHARMA, J-40187255-7, 0155555555555555</h4></p>
                <div class="datospago">
                    <div class="formpago">
                        <input class="formulario" placeholder="Nombre del Transferente" id="Text3" type="text"  runat="server"/>
                        <input class="formulario" placeholder="Correo Asociado" id="Text5" type="text"  runat="server"/>
                        <input class="formulario" placeholder="Telefono del Transferente" id="Text7" type="text"  runat="server"/>
                        <input class="formulario" placeholder="Numero de Transaccion" id="Text6" type="text"  runat="server"/>
                        <p><a class="enlaces" href="Terminos.aspx">Revisa nuestros Terminos y Condiciones</a></p>
                        <p><a class="enlaces" href="Somos.aspx">Preguntas Frecuentes</a></p>                        
                        <asp:Button  OnClientClick="cierreButton()" value="PAGADO" type="submit" runat="server" CssClass="botonsubmit" Text="REGISTRAR PAGO" OnClick="Unnamed1_Click" />                                                        
                        <br />
                        <br />
                    </div>
                    
                </div>
                    <div class="pagoefectivo">
                        <p><a class="enlaces" href="Terminos.aspx">Revisa nuestros Terminos y Condiciones</a></p>
                        <p><a class="enlaces" href="Somos.aspx">Preguntas Frecuentes</a></p>   
                        <asp:Button  OnClientClick="cierreButton()" value="PAGADO" type="submit" runat="server" CssClass="botonsubmit" Text="REGISTRAR PAGO" OnClick="Unnamed1_Click" />                                 
                        <br />
                        <br />
                    </div>
                </div>
                       
            
        </div>
        <script src="Scripts/Cierre.js"></script>
    </form>
</body>
</html>
