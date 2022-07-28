<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Seguimineto_COVID.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            <asp:ListBox ID="ListBox1" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="ALGRU" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="Carrera" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="Cuatrimestre" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="EstadoCivil" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="Grupo" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="GruCuat" runat="server" Height="250px" style="margin-left: 0px"></asp:ListBox>
            <asp:ListBox ID="Incapacidades" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="Medico" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="PositivoAlumno" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="PositivoProfe" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="Profesor" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="ProgramaEducativo" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="SegumientoAlumno" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="SeguimientoPro" runat="server" Height="250px"></asp:ListBox>
            <asp:ListBox ID="ProfeGrupo" runat="server" Height="250px"></asp:ListBox>
        </div>
    </form>
</body>
</html>
