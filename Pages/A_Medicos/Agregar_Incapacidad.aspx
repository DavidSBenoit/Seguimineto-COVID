<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agregar_Incapacidad.aspx.cs" Inherits="Seguimineto_COVID.Pages.A_Medicos.Agregar_Incapacidad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Agregar Incapacidad</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <%--Nav Bar--%>
        <div>
            <nav class="navbar navbar-dark bg-dark fixed-top">
                <div class="container-fluid">
                    <a class="navbar-brand" href="#">Seguimiento de Covid</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasDarkNavbar" aria-controls="offcanvasDarkNavbar">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="offcanvas offcanvas-end text-bg-dark" tabindex="-1" id="offcanvasDarkNavbar" aria-labelledby="offcanvasDarkNavbarLabel">
                        <div class="offcanvas-header">
                            <h5 class="offcanvas-title" id="offcanvasDarkNavbarLabel">Dark offcanvas</h5>
                            <button type="button" class="btn-close btn-close-white" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div class="offcanvas-body">
                            <ul class="navbar-nav justify-content-end flex-grow-1 pe-3">
                                <li class="nav-item">
                                    <a class="nav-link active" aria-current="page" href="#">Home</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="/Pages/alumnos.aspx">Alumnos</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#">Profesores</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#">Médicos</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#">Escolares</a>
                                </li>
                                <li class="nav-item dropdown">
                                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Dropdown
                                    </a>
                                    <ul class="dropdown-menu dropdown-menu-dark">
                                        <li><a class="dropdown-item" href="#">Action</a></li>
                                        <li><a class="dropdown-item" href="#">Another action</a></li>
                                        <li>
                                            <hr class="dropdown-divider">
                                        </li>
                                        <li><a class="dropdown-item" href="#">Something else here</a></li>
                                    </ul>
                                </li>
                            </ul>

                        </div>
                    </div>
                </div>
            </nav>
        </div>
        <br />
        <br />
        <br />
        <%--Pagina--%>
        <h2>Registrar nueva Incapacidad</h2>
        <p>Ingrese los datos</p>

        <p>Seleccione Número de Registro</p>
        <asp:DropDownList ID="DropDownList_selected_Profe" runat="server"></asp:DropDownList>

        <p>Ingrese Fecha de Inicio</p>
        <asp:Calendar ID="Calendar_ini" runat="server"></asp:Calendar>

        <p>Ingrese Fecha de Final</p>
        <asp:Calendar ID="Calendar_final" runat="server"></asp:Calendar>

        <p>Ingrese Formato de Incapacidad</p>
        <p>Solo Archivos .PDF o .JPG</p>
        <asp:FileUpload ID="FileUpload_formato" runat="server" />

        <br />
        <br />
        <asp:Button ID="Button_guardar_incapacidad" runat="server" Text="Button" OnClick="Button_guardar_incapacidad_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
