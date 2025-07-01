<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SistemaWebCitas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" />

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.0/css/all.min.css" />
<link rel="stylesheet" type="text/css" href="css/AdminLTE.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Acceso al Sistema de Clinica</title>
</head>
<body class="bg-black min-vh-100" >

    <div class="form-box" id="login-box">

        <div class="header">Iniciar Sesion</div>
        <form id="form1" runat="server">
    <div class="body bg-gray">
   <div class="form-group">
       


       <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="Ingrese Usuario" runat="server"></asp:TextBox>
       


   </div>
        <div class="form-group">
    


    <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Ingrese Password" runat="server"></asp:TextBox>
    


</div>
        
    
    </div>
<div class="footer">

    <asp:Button ID="btnIngresar" runat="server" Text="Login" class="btn bg-olive  w-100" OnClick="btnIngresar_Click"/>

</div>

</form>
    </div>
    
</body>
<script src="js/jquery-3.1.0.min.js"></script>
<script src="js/bootstrap.min.js" type="text/javascript"></script>
</html>
