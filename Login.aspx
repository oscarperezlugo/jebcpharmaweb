<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TiendaVirtual.Login" %>

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
            <p><h2>Iniciar sesión</h2></p>
            <div class="fila col10L">
                <input class="formulario" placeholder="Correo" id="Correo" type="email" required runat="server"/>            
            </div>                       
            <div class="fila col10L">
                <input class="formulario" placeholder="Contraseña" id="Contrasena" type="password" required runat="server"/>            
            </div>            
            <p><a class="enlaces" href="Registro.aspx">¿No tienes una cuenta? Registrate aquí</a></p>
            <p><a class="enlaces" href="Contrasena.aspx">Cambiar Contraseña</a></p>
            <div class="fila col10L">
                <asp:Button class="botonsubmit" value="REGISTRARME" type="submit" runat="server" CssClass="botonsubmit" Text="LOGIN" OnClick="Unnamed1_Click" />            
            </div>
        </div>
    </form>
</body>
</html>
