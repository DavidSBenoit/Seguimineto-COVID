﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mostrar_Medicos.aspx.cs" Inherits="Seguimineto_COVID.Pages.Mostrar_Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        <div class="col-md-12">
            <a href="/Pages/Registar_Alumno.aspx" class="btn btn-primary" tabindex="-1" role="button">Agregar Medico</a>
        </div>
        <a href="/Pages/Ediat_Profesor.aspx" class="btn btn-primary" tabindex="-1" role="button">Editar Medico</a>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
</body>
</html>