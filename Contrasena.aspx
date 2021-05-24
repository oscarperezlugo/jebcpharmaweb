<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contrasena.aspx.cs" Inherits="TiendaVirtual.Contrasena" %>

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
                <a class="botonbodegon" href="Default.aspx">FARMACIA</a>
            </div>
        </nav>
        <hr class="linea"/>
        <div class="baseform">
            <br />
            <br />
            <p><h2>Recuperar contraseña</h2></p>            
            <div class="fila col10L">
                <input class="formulario" placeholder="Correo" type="email" required id="text1" runat="server"/>            
            </div>                        
            <div class="fila col10L">
                <input class="formulario" placeholder="Nueva Contraseña" type="password" required id="text2" runat="server"/>            
            </div>
            <div class="fila col10L">
                <input class="formulario" placeholder="Repetir Contraseña" type="password" required id="text3" runat="server"/>            
            </div>            
            <p><a class="enlaces" href="Login.aspx">Volver al inicio de Sesión</a></p>
            <div class="fila col10L">
                <asp:Button runat="server" class="botonsubmit" value="CAMBIAR CONTRASEÑA" text="CAMBIAR CONTRASEÑA" type="submit" onclick="Unnamed1_Click1" />            
            </div>
        </div>
        <br />
    </form>
</body>
</html>
