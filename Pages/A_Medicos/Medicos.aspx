<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medicos.aspx.cs" Inherits="Seguimineto_COVID.Pages.Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Médicos</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-gH2yIJqKdNHPEq0n4Mqa/HGKIhSkIHeL5AyhkYV8i59U5AR6csBvApHHNl/vI1Bx" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-A3rJD856KowSb7dwlZdYEkO39Gagi7vIsF0jrRAoQmDKKtQBHUuLZ9AsSv4jD4Xa" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <%--nav bar--%>
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
                                    <a class="nav-link active" aria-current="page" href="..\Home.aspx">Home</a>
                                </li>
                                
                                <li class="nav-item dropdown">
                                    <li class="nav-item dropdown">
                                    <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false">Áreas
                                    </a>

                                    <ul class="dropdown-menu dropdown-menu-dark">
                                        <li><a class="dropdown-item" href="..\Pages\A_Alumnos\Alumnos.aspx">Alumnos</a></li>
                                        <li>
                                            <hr class="dropdown-divider">
                                        </li>
                                        <li><a class="dropdown-item" href="..\Pages\A_Profesores\Profesores.aspx">Profesores</a></li>
                                        <li>
                                            <hr class="dropdown-divider">
                                        </li>
                                        <li><a class="dropdown-item" href="..\Pages\A_Medicos\Medicos.aspx">Médicos</a></li>
                                        <li>
                                            <hr class="dropdown-divider">
                                        </li>
                                        <li><a class="dropdown-item" href="..\Pages\A_Escolares\Escolares.aspx">Escolares</a></li>
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
        <div class="container">
            <div class="col-md-12">
                <a href="/Pages/A_Medicos/Agregar_Incapacidad.aspx" class="btn btn-primary" tabindex="-1" role="button" >Agregar Incapacidad</a>
                <a href="/Pages/A_Medicos/Agregar_Medico.aspx" class="btn btn-primary" tabindex="-1" role="button" >Agregar Médico</a>
                <a href="/Pages/A_Medicos/Modificar_Medico.aspx" class="btn btn-primary" tabindex="-1" role="button" >Modificar Médico</a>
                <a href="/Pages/A_Medicos/Mostrar_Contagios_Alumno.aspx" class="btn btn-primary" tabindex="-1" role="button" >Mostrar Alumnos Contagiados</a>
                <a href="/Pages/A_Medicos/Mostrar_Contagios_Alumnos_Grupo.aspx" class="btn btn-primary" tabindex="-1" role="button" >Mostrar Alumnos Contagiados por Grupo</a>
                <a href="/Pages/A_Medicos/Mostrar_Contagios_Profe.aspx" class="btn btn-primary" tabindex="-1" role="button" >Mostrar Profesores Contagiados<</a>
                <a href="/Pages/A_Medicos/Mostrar_Medicos.aspx" class="btn btn-primary" tabindex="-1" role="button" >Mostrar Médicos</a>
                <a href="/Pages/A_Medicos/Positivo_Alumno.aspx" class="btn btn-primary" tabindex="-1" role="button" >Agregar nuevo Positivo Alumno</a>
                <a href="/Pages/A_Medicos/Positivo_Profe.aspx" class="btn btn-primary" tabindex="-1" role="button" >Agregar nuevo Positivo Profesor</a>
                <a href="/Pages/A_Medicos/Seguimiento_Alumno.aspx" class="btn btn-primary" tabindex="-1" role="button" >Mostrar Seguimiento a Alumno</a>
                <a href="/Pages/A_Medicos/Seguimiento_Alumno_Cuatri.aspx" class="btn btn-primary" tabindex="-1" role="button" >Mostrar Seguimiento a Alumno</a>
                <a href="/Pages/A_Medicos/Seguimiento_Profe.aspx" class="btn btn-primary" tabindex="-1" role="button" >Mostrar Seguimiento a Profesor</a>
                <a href="/Pages/A_Medicos/Seguimiento_Profe2.aspx" class="btn btn-primary" tabindex="-1" role="button" >Mostrar Seguimiento a Alumno a detalle</a>
                
            </div>
        </div>
    </form>
</body>
</html>
