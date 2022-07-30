using Entidades;
using Logica_de_Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID
{
    public partial class Update : System.Web.UI.Page
    {
        DLL Interfaz = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;
            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void Button_Update_Alumno_Click(object sender, EventArgs e)
        {
            //Alumno alumno = new Alumno()
            //{
            //    Matricula = TextBox_matricula.Text,
            //    Nombre = TextBox_nombre.Text,
            //    ApPat = TextBox_app.Text,
            //    ApMat = TextBox_apm.Text,
            //    Genero = TextBox_genero.Text,
            //    Correo = TextBox_correo.Text,
            //    Celular = TextBox_celular.Text,
            //    FEdoCivil = Convert.ToByte(TextBox_edocivil.Text),
            //    FNivel = Convert.ToByte(TextBox_fnivel.Text)
            //};

            //int ID = Convert.ToInt32(TextBox_ID.Text);

            //Label_respuesta_UPD_alumno.Text =  Interfaz.ActualizarAlumno(alumno, ID);

            AlumnoGrupo AG = new AlumnoGrupo()
            {
                FAlumn = 2,
                FGruCuat = 2,
                Extra = "Prueba UPDATE Desde Front",
                Extra2 = "Prueba UPDATE Desde Front"
            };
            Carrera carrera = new Carrera()
            {
                NombreCarrera = "Prueba UPDATE Desde Front"
            };
            Cuatrimestre cuatri = new Cuatrimestre()
            {
                Periodo = "UPDATE",
                Anio = 2024,
                Inicio = DateTime.Now.AddDays(1),
                Fin = DateTime.Now.AddMonths(5),
                Extra = "Prueba UPDATE Desde Front"
            };
            EstadoCivil edocivil = new EstadoCivil()
            {
                Estado = "Prueba UPDATE Desde Front",
                Extra = "Prueba UPDATE Desde Front"
            };
            Grupo grupo = new Grupo()
            {
                Grado = 10,
                Letra = "P",
                Extra = "Prueba UPDATE Desde Front"
            };
            GrupoCuatrimestre grupoCuatrimestre = new GrupoCuatrimestre()
            {
                FProgEd = 1,
                FGrupo = 1,
                FCuatri = 3,
                Turno = "Prueba UPDATE Desde Front",
                Modalidad = "Prueba UPDATE Desde Front",
                Extra = "Prueba UPDATE Desde Front"
            };
            Incapacidades incapacidades = new Incapacidades()
            {
                Formato = "Prueba UPDATE Desde Front",
                FechaInicio = DateTime.Now.AddDays(1),
                FechaFinal = DateTime.Now.AddDays(8),
                IdPosProfe = 1
            };
            Medico medico = new Medico()
            {
                Nombre = "Prueba UPDATE Desde Front",
                App = "Prueba UPDATE Desde Front",
                Apm = "Prueba UPDATE Desde Front",
                Telefono = "Prueba UPDATE Desde Front",
                Correo = "Prueba UPDATE Desde Front",
                Horario = "Prueba UPDATE Desde Front",
                Especialidad = "Prueba UPDATE Desde Front",
                Extra = "Prueba UPDATE Desde Front"
            };
            PositivoAlumno positivoAlumno = new PositivoAlumno()
            {
                FechaConfirmado = DateTime.Now,
                Comprobacion = "Prueba UPDATE Desde Front",
                Antecedentes = "Prueba UPDATE Desde Front",
                Riesgo = "Prueba UPDATE Desde Front",
                NumContagio = 3,
                Extra = "Prueba UPDATE Desde Front",
                FAlumno = 2
            };
            PositivoProfe positivoProfe = new PositivoProfe()
            {
                FechaConfirmado = DateTime.Now,
                Comprobacion = "Prueba UPDATE Desde Front",
                Antecedentes = "Prueba UPDATE Desde Front",
                Riesgo = "Prueba UPDATE Desde Front",
                NumContaio = 3,
                Extra = "Prueba UPDATE Desde Front",
                FProfe = 3
            };
            ProfeGrupo profeGrupo = new ProfeGrupo()
            {
                FProfe = 2,
                FGruCuat = 2,
                Extra = "Prueba UPDATE Desde Front",
                Extra2 = "Prueba UPDATE Desde Front"
            };
            Profesor profesor = new Profesor()
            {
                RegistroEmpleado = 564,
                Nombre = "Prueba UPDATE Desde Front",
                ApPat = "Prueba UPDATE Desde Front",
                ApMat = "Prueba UPDATE Desde Front",
                Genero = "Prueba UPDATE Desde Front",
                Categoria = "UP",
                Correo = "Prueba UPDATE Desde Front",
                Celular = "Prueba UPDATE Desde Front",
                FEdoCivil = 2
            };
            ProgramaEducativo programaEducativo = new ProgramaEducativo()
            {
                ProgramaEd = "Prueba UPDATE Desde Front",
                FCarrera = 1,
                Extra = "Prueba UPDATE Desde Front"
            };
            SeguimientoAl seguimientoAl = new SeguimientoAl()
            {
                FPositivoAl = 1,
                FMedico = 1,
                Fecha = DateTime.Now.AddDays(1),
                FormComunica = "Prueba UPDATE Desde Front",
                Reporte = "Prueba UPDATE Desde Front",
                Entrevista = "Prueba UPDATE Desde Front",
                Extra = "Prueba UPDATE Desde Front"
            };
            SeguimientoPro seguimientoPro = new SeguimientoPro()
            {
                FPositivoProfe = 1,
                FMedico = 1,
                Fecha = DateTime.Now.AddDays(1),
                FormComunica = "Prueba UPDATE Desde Front",
                Reporte = "Prueba UPDATE Desde Front",
                Entrevista = "Prueba UPDATE Desde Front",
                Extra = "Prueba UPDATE Desde Front"
            };

            Label1.Text = Interfaz.Actualizar_GrupoAlumno(AG, 8);
            Label2.Text = Interfaz.Actualizar_Carrera(carrera, 5);
            Label3.Text = Interfaz.Actualizar_Cuatrimestre(cuatri, 4);
            Label4.Text = Interfaz.Actualizar_EstadoCivil(edocivil, 3);
            Label5.Text = Interfaz.Actualizar_Grupo(grupo, 7);
            Label6.Text = Interfaz.Actualizar_Grupo_Cuatrimestre(grupoCuatrimestre, 7);
            Label7.Text = Interfaz.Actualizar_Incapacidades(incapacidades, 3);
            Label8.Text = Interfaz.Actualizar_Medico(medico, 4);
            Label9.Text = Interfaz.Actualizar_PositivoAlumno(positivoAlumno, 3);
            Label10.Text = Interfaz.Actualizar_PositivoProfe(positivoProfe, 3);
            abel11.Text = Interfaz.Actualizar_ProfeGrupo(profeGrupo, 9);
            Label12.Text = Interfaz.Actualizar_Profesor(profesor, 6);
            Label13.Text = Interfaz.Actualizar_ProgramaEducativo(programaEducativo, 5);
            Label14.Text = Interfaz.Actualizar_SeguimientoAl(seguimientoAl, 3);
            Label15.Text = Interfaz.Actualizar_SeguimientoPRO(seguimientoPro, 3);

        }
    }
}