﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Insertar.aspx.cs" Inherits="Seguimineto_COVID.Insertar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            matricula
            <asp:TextBox ID="TextBox_matricula" runat="server"></asp:TextBox>
            <br />
            nombre
            <asp:TextBox ID="TextBox_nombre" runat="server"></asp:TextBox>
            <br />
            paterno
            <asp:TextBox ID="TextBoxap_pat" runat="server"></asp:TextBox>
            <br />
            materno
            <asp:TextBox ID="TextBox_ap_mat" runat="server"></asp:TextBox>
            <br />
            genero
            <asp:TextBox ID="TextBox_genero" runat="server"></asp:TextBox>
            <br />
            correo
            <asp:TextBox ID="TextBox_correo" runat="server"></asp:TextBox>
            <br />
            celular
            <asp:TextBox ID="TextBox_celular" runat="server"></asp:TextBox>
            <br />
            estadocivil
            <asp:TextBox ID="TextBox_estadocivil" runat="server"></asp:TextBox>
            <br />
            nivel
            <asp:TextBox ID="TextBox_nivel" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button_insertar_alumno" runat="server" OnClick="Button_insertar_alumno_Click" Text="Button" />
            <br />
            <br />
            <asp:Label ID="Label_respuesta" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
