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
    public partial class Insertar : System.Web.UI.Page
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

        protected void Button_insertar_alumno_Click(object sender, EventArgs e)
        {
            //Alumno alumno = new Alumno()
            //{
            //    Matricula = TextBox_matricula.Text,
            //    Nombre = TextBox_nombre.Text,
            //    ApPat = TextBoxap_pat.Text,
            //    ApMat = TextBox_ap_mat.Text,
            //    Genero = TextBox_genero.Text,
            //    Correo = TextBox_correo.Text,
            //    Celular = TextBox_celular.Text,
            //    FEdoCivil = Convert.ToByte(TextBox_estadocivil.Text),
            //    FNivel = Convert.ToByte(TextBox_nivel.Text)
            //};

            //Label_respuesta.Text = Interfaz.AgregarAlumno(alumno);


            AlumnoGrupo AG = new AlumnoGrupo()
            {
                FAlumn = 2,
                FGruCuat = 2,
                Extra = "Prueba Desde Objeto en Front",
                Extra2 = "Prueba Desde Objeto en Front"
            };
            Carrera carrera = new Carrera()
            {
                NombreCarrera = "TSU en Mecatrónica"
            };
            Cuatrimestre cuatri = new Cuatrimestre()
            {
                Periodo = "Enero - Abril",
                Anio = 2023,
                Inicio = DateTime.Now,
                Fin = DateTime.Now.AddMonths(4),
                Extra = "Prueba Desde Objeto en Front"
            };
            EstadoCivil edocivil = new EstadoCivil()
            {
                Estado = "Divorciado",
                Extra = "Prueba Desde Objeto en Front"
            };
            Grupo grupo = new Grupo()
            {
                Grado = 4,
                Letra = "C",
                Extra = "Prueba Desde Objeto en Front"
            };
            GrupoCuatrimestre grupoCuatrimestre = new GrupoCuatrimestre()
            {
                FProgEd = 1,
                FGrupo = 1,
                FCuatri = 3,
                Turno = "Vespertino",
                Modalidad = "En Línea",
                Extra = "Prueba Desde Objeto en Front"
            };
            Incapacidades incapacidades = new Incapacidades()
            {
                Formato = "c:/algun lugar",
                FechaInicio = DateTime.Now,
                FechaFinal = DateTime.Now.AddDays(7),
                IdPosProfe = 1
            };
            Medico medico = new Medico()
            {
                Nombre = "Noel",
                App = "Barranco",
                Apm = "Vivas",
                Telefono = "2211215689",
                Correo = "noelbarranco@mail.com",
                Horario = "vespertino",
                Especialidad = "Pediatría",
                Extra = "Prueba Desde Objeto en Front"
            };
            PositivoAlumno positivoAlumno = new PositivoAlumno()
            {
                FechaConfirmado = DateTime.Now,
                Comprobacion = "c:/algun lugar",
                Antecedentes = "Homeopatía, Varicela",
                Riesgo = "Alto",
                NumContagio = 3,
                Extra = "Prueba Desde Objeto en Front",
                FAlumno = 2
            };
            PositivoProfe positivoProfe = new PositivoProfe()
            {
                FechaConfirmado = DateTime.Now,
                Comprobacion = "c:/algun lugar",
                Antecedentes = "Homeopatía, Varicela",
                Riesgo = "Alto",
                NumContaio = 3,
                Extra = "Prueba Desde Objeto en Front",
                FProfe = 3
            };
            ProfeGrupo profeGrupo = new ProfeGrupo()
            {
                FProfe = 2,
                FGruCuat = 2,
                Extra = "Prueba Desde Objeto en Front",
                Extra2 = "Prueba Desde Objeto en Front 2"
            };
            Profesor profesor = new Profesor()
            {
                RegistroEmpleado = 564,
                Nombre = "Francisco",
                ApPat = "Martínez",
                ApMat = "Morales",
                Genero = "Masculino",
                Categoria = "TC",
                Correo = "Franc.Mar@mail.com",
                Celular = "2255467989",
                FEdoCivil = 2
            };
            ProgramaEducativo programaEducativo = new ProgramaEducativo()
            {
                ProgramaEd = "Mecatrónica",
                FCarrera = 1,
                Extra = "Prueba Desde Objeto en Front"
            };
            SeguimientoAl seguimientoAl = new SeguimientoAl()
            {
                FPositivoAl = 1,
                FMedico = 1,
                Fecha = DateTime.Now,
                FormComunica = "c:/algun lugar",
                Reporte = "c:/Algun Lugar",
                Entrevista = "c:/algun lugar",
                Extra = "Prueba Desde Objeto en Front"
            };
            SeguimientoPro seguimientoPro = new SeguimientoPro()
            {
                FPositivoProfe = 1,
                FMedico = 1,
                Fecha = DateTime.Now,
                FormComunica = "c:/algun lugar",
                Reporte = "c:/Algun Lugar",
                Entrevista = "c:/algun lugar",
                Extra = "Prueba Desde Objeto en Front"
            };

            Label1.Text = Interfaz.Agregar_AlumnoGrupo(AG);
            Label2.Text = Interfaz.Agregar_Carrera(carrera);
            Label3.Text = Interfaz.Agregar_Cuatrimestre(cuatri);
            Label4.Text = Interfaz.Agregar_EstadoCivil(edocivil);
            Label5.Text = Interfaz.Agregar_Grupo(grupo);
            Label6.Text = Interfaz.Agregar_Grupo_Cuatrimestre(grupoCuatrimestre);
            Label7.Text = Interfaz.Agregar_Incapacidades(incapacidades);
            Label8.Text = Interfaz.Agregar_Medico(medico);
            Label9.Text = Interfaz.Agregar_PositivoAlumno(positivoAlumno);
            Label10.Text = Interfaz.Agregar_PositivoProfe(positivoProfe);
            Label11.Text = Interfaz.Agregar_ProfeGrupo(profeGrupo);
            Label12.Text = Interfaz.Agregar_Profesor(profesor);
            Label13.Text = Interfaz.Agregar_ProgramaEducativo(programaEducativo);
            Label14.Text = Interfaz.Agregar_SeguimientoAl(seguimientoAl);
            Label15.Text = Interfaz.Agregar_SeguimientoPRO(seguimientoPro);
        }
    }
}