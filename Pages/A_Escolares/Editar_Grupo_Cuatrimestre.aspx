﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar_Grupo_Cuatrimestre.aspx.cs" Inherits="Seguimineto_COVID.Pages.A_Escolares.Editar_Grupo_Cuatrimestre" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modificar Grupo Cuatrimestre</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">
        <%--nav bar--%>
        <div>
            <nav class="navbar navbar-dark bg-dark fixed-top">
                <div class="container-fluid">
                    <a class="navbar-brand" href="..\..\Home.aspx">Seguimiento de Covid</a>
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
                                    <a class="nav-link active" aria-current="page" href="..\..\Home.aspx">Home</a>
                                </li>

                                <li class="nav-item dropdown">
                                    <li class="nav-item dropdown">
                                        <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Áreas
                                        </a>

                                        <ul class="dropdown-menu dropdown-menu-dark">
                                            <li><a class="dropdown-item" href="..\A_Alumnos\Alumnos.aspx">Alumnos</a></li>
                                            <li>
                                                <hr class="dropdown-divider">
                                            </li>
                                            <li><a class="dropdown-item" href="..\A_Profesores\Profesores.aspx">Profesores</a></li>
                                            <li>
                                                <hr class="dropdown-divider">
                                            </li>
                                            <li><a class="dropdown-item" href="..\A_Medicos\Medicos.aspx">Médicos</a></li>
                                            <li>
                                                <hr class="dropdown-divider">
                                            </li>
                                            <li><a class="dropdown-item" href="..\A_Escolares\Escolares.aspx">Escolares</a></li>
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
        <%--pagina--%>


        <div class="content centerContent">
            <div class="container-fluid col-xl-8 col-md-12">
                <div class="card">
                    <div class="card-body centerContent">
                        <h5 class="card-title">Editar Grupo Cuatrimestre</h5>
                        <div class="row">
                            <div class="col-sm-6">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">Datos Existentes</h5>

                                        <p>Selecciona Grupo Cuatrimestre para ver los datos</p>
                                        <asp:DropDownList ID="DropDownList_programaEdu" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_programaEdu_SelectedIndexChanged"></asp:DropDownList>
                                        <br />

                                        <p>Programa Educativo</p>
                                        <asp:Label ID="Label_Programa_Edu" runat="server" Text="Label"></asp:Label>
                                        <br />
                                        <br />
                                        <p>Grupo</p>
                                        <asp:Label ID="Label_grupo" runat="server" Text="Label"></asp:Label>
                                        <br />
                                        <br />
                                        <p>Cuatrimestre</p>
                                        <asp:Label ID="Label_cuatri" runat="server" Text="Label"></asp:Label>
                                        <br />
                                        <br />
                                        <p>Turno</p>
                                        <asp:Label ID="Label_turno" runat="server" Text="Label"></asp:Label>
                                        <br />
                                        <br />
                                        <p>Modalidad</p>
                                        <asp:Label ID="Label_modalidad" runat="server" Text="Label"></asp:Label>
                                        
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="card">
                                    <div class="card-body">
                                        <h5 class="card-title">Nuevos Datos</h5>
                                        <p>Seleccione los Datos</p>

                                        <p>Selecciona Programa Educativo</p>
                                        <asp:DropDownList ID="DropDownList_pro" runat="server"></asp:DropDownList>
                                        <br />

                                        <p>Selecciona Grupo</p>
                                        <asp:DropDownList ID="DropDownList_Grupo" runat="server"></asp:DropDownList>
                                        <br />

                                        <p>Selecciona Cuatrimestre</p>
                                        <asp:DropDownList ID="DropDownList_Cuatri" runat="server"></asp:DropDownList>
                                        <br />

                                        <p>Selecciona Turno</p>
                                        <asp:DropDownList ID="DropDownList_turno" runat="server"></asp:DropDownList>
                                        <br />

                                        <p>Selecciona Modalidad</p>
                                        <asp:DropDownList ID="DropDownList_Modalidad" runat="server"></asp:DropDownList>
                                        <br />
                                        <br />
                                        <asp:Button ID="Button1" class="btn btn-dark" runat="server" Text="Editar" OnClick="Button1_Click" />
                                        <asp:Button ID="Button2" class="btn btn-dark" runat="server" Text="Eliminar" OnClick="Button2_Click" />
                                        <br />
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>