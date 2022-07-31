<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Seguimineto_COVID.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Matrícula:
            <br />
            <asp:TextBox ID="TextBox_matricula" runat="server"></asp:TextBox>
            <br />
            Nombre:
            <br />
            <asp:TextBox ID="TextBox_nombre" runat="server"></asp:TextBox>
            <br />
            Apellido Paterno:
            <br />
            <asp:TextBox ID="TextBox_app" runat="server"></asp:TextBox>
            <br />
            Apellido Materno:
            <br />
            <asp:TextBox ID="TextBox_apm" runat="server"></asp:TextBox>
            <br />
            Genero:
            <br />
            <asp:TextBox ID="TextBox_genero" runat="server"></asp:TextBox>
            <br />
            Correo:
            <br />
            <asp:TextBox ID="TextBox_correo" runat="server"></asp:TextBox>
            <br />
            Celular:
            <br />
            <asp:TextBox ID="TextBox_celular" runat="server"></asp:TextBox>
            <br />
            Estado Civil:
            <br />
            <asp:TextBox ID="TextBox_edocivil" runat="server"></asp:TextBox>
            <br />
            Nivel:
            <br />
            <asp:TextBox ID="TextBox_fnivel" runat="server"></asp:TextBox>
            <br />
            ID:
            <br />
            <asp:TextBox ID="TextBox_ID" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button_Update_Alumno" runat="server" Text="Actualizar" OnClick="Button_Update_Alumno_Click" />
            <br />
            Respuesta:
            <br />
            <asp:Label ID="Label_respuesta_UPD_alumno" runat="server" Text="Label"></asp:Label>
            
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
            
        </div>
    </form>
</body>
</html>
