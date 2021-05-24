<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TiendaVirtual.Registro" %>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <meta name="Oscar Perez Lugo" content="Developer">
        <meta name="description"  content="Una Experiencia Paladar">
        <meta name="keywords"  content="Carne, Pollo, Valencia, Venezuela">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">        
        <title>Bodegón Paladar</title>
        <link href="favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <link href="Content/Columnas.css" rel="stylesheet" /> 
        <link href="Content/estilos.css" rel="stylesheet" />
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
        <style type="text/css">
            .auto-style1 {
                background-color: black;
                border-color: black;
                font-family: 'Trebuchet MS';
                color: white;
                border-radius: 5px;
                padding: 10px;
            }
        </style>
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
                <a class="botonbodegon" href="Default.aspx">FARMACIA</a>
            </div>
        </nav>
        <hr class="linea"/>
        <div class="baseform">
            <p><h2>Registro de Usuario</h2></p>
            <div class="fila col10L">
                <input class="formulario" placeholder="Nombre (Juan)" id="Nombre" type="text" required runat="server"/>            
            </div>
            <div class="fila col10L">
                <input class="formulario" placeholder="Apellido (Perez)" id="Apellido" type="text" required runat="server"/>            
            </div>
            <div class="fila col10L">
                <input class="formulario" placeholder="Correo (juan@gmail.com)" id="Correo" type="email" required runat="server"/>            
            </div>
            <div class="fila col10L">
                <input class="formulario" placeholder="Télefono (0414555555)" id="Telefono" type="text" maxlength="11" required runat="server"/>            
            </div>
            <div class="fila col10L">
                <input class="formulario" placeholder="Dirección (Valencia, Prebo Calle Libra #55)" id="Dirección" type="text" required runat="server"/>            
            </div>
            <div class="fila col10L">
                <input class="formulario" placeholder="Contraseña" id="Contraseña" type="password" required runat="server"/>            
            </div>
            <div class="fila col10L">
                <input class="formulario" placeholder="Repetir Contraseña" id="Repetir" type="password" required runat="server"/>            
            </div>
            <p><input type="checkbox" required> Acepto los Términos y Condiciones <a class="enlaces" href="Terminos.aspx">Términos y Condiciones</a></p>
            <p><a class="enlaces" href="Login.aspx">¿Ya Tienes una Cuenta? Inicia Sesión desde Aquí</a></p>
            <div class="fila col10L">
                <asp:Button class="botonsubmit" value="REGISTRARME" type="submit"  runat="server" CssClass="botonsubmit"  OnClick="Unnamed1_Click"  Text="REGISTRARME"/>            
            </div>
        </div>
        <br />
    </form>
</body>
</html>
