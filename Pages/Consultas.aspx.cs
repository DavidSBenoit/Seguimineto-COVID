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
    public partial class Index : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string mensaje = "", mensajeC = "";


            //GridView1.DataSource = Interfaz.tablaProfesoresServer();
            //GridView1.DataBind();
            //TextBox1.Text = mensajeC + " " + mensaje;

            List<Alumno> listaAlumno = Interfaz.ListaAlumno();
            List<AlumnoGrupo> ListaAlumnoGrupo = Interfaz.ListaAlumnoGrupo();
            List<Carrera> ListaCarrera = Interfaz.ListaCarrera();
            List<Cuatrimestre> ListaCuatrimestre = Interfaz.ListaCuatrimestre();
            List<EstadoCivil> ListaEstadoCivil = Interfaz.ListaEstadoCivil();
            List<Grupo> ListaGrupo = Interfaz.ListaGrupo();
            List<GrupoCuatrimestre> ListaGrupoCuatrimestre = Interfaz.ListaGrupoCuatrimestre();
            List<Incapacidades> ListaIncapacidades = Interfaz.ListaIncapacidades();
            List<Medico> ListaMedico = Interfaz.ListaMedico();
            List<PositivoAlumno> ListaPositivoAlimno = Interfaz.ListaPositivoAlumno();
            List<PositivoProfe> ListaPositivoProfe = Interfaz.ListaPositivoProfe();
            List<ProfeGrupo> ListaProfeGrupo = Interfaz.ListaProfeGrupo();
            List<Profesor> ListaProfesor = Interfaz.ListaProfesor();
            List<ProgramaEducativo> ListaProgramaEducativo = Interfaz.ListaProgramaEducativo();
            List<SeguimientoPro> ListaSeguimientoPro = Interfaz.ListaSeguimientoPro();
            List<SeguimientoAl> ListaSeguimientoAl = Interfaz.ListaSeguimientoAl();

            string estadoCivil = "";

            for (int i = 0; i < listaAlumno.Count; i++)
            {
                ListBox1.Items.Add("//////");
                ListBox1.Items.Add(listaAlumno[i].IdAlumno.ToString());
                ListBox1.Items.Add(listaAlumno[i].Matricula.ToString());
                ListBox1.Items.Add(listaAlumno[i].Nombre.ToString());
                ListBox1.Items.Add(listaAlumno[i].ApPat.ToString());
                ListBox1.Items.Add(listaAlumno[i].ApMat.ToString());
                ListBox1.Items.Add(listaAlumno[i].Celular.ToString());
                ListBox1.Items.Add(listaAlumno[i].Correo.ToString());
                ListBox1.Items.Add(listaAlumno[i].Genero.ToString());

                //ListBox1.Items.Add(listaAlumno[i].FEdoCivil.ToString());
                estadoCivil = ListaEstadoCivil.Where(x => x.IdEdo == (byte)listaAlumno[i].FEdoCivil).Last().Estado;
                ListBox1.Items.Add(estadoCivil);
                ListBox1.Items.Add(listaAlumno[i].FNivel.ToString());
                ListBox1.Items.Add("//////");
            }
            for(int i = 0; i < ListaAlumnoGrupo.Count; i++)
            {
                ALGRU.Items.Add("//////");
                ALGRU.Items.Add(ListaAlumnoGrupo[i].IdAlumnGru.ToString());
                ALGRU.Items.Add(ListaAlumnoGrupo[i].FAlumn.ToString());
                ALGRU.Items.Add(ListaAlumnoGrupo[i].FGruCuat.ToString());
                ALGRU.Items.Add(ListaAlumnoGrupo[i].Extra.ToString());
                ALGRU.Items.Add(ListaAlumnoGrupo[i].Extra2.ToString());
                ALGRU.Items.Add("//////");
            }
            for(int i = 0;i < ListaCarrera.Count; i++)
            {
                Carrera.Items.Add("////");
                Carrera.Items.Add(ListaCarrera[i].IdCarrera.ToString());
                Carrera.Items.Add(ListaCarrera[i].NombreCarrera.ToString());
                Carrera.Items.Add("////");
            }
            for(int i = 0; i < ListaCuatrimestre.Count; i++)
            {
                Cuatrimestre.Items.Add("/////");
                Cuatrimestre.Items.Add(ListaCuatrimestre[i].IdCuatrimestre.ToString());
                Cuatrimestre.Items.Add(ListaCuatrimestre[i].Periodo.ToString());
                Cuatrimestre.Items.Add(ListaCuatrimestre[i].Anio.ToString());
                Cuatrimestre.Items.Add(ListaCuatrimestre[i].Inicio.ToString());
                Cuatrimestre.Items.Add(ListaCuatrimestre[i].Fin.ToString());
                Cuatrimestre.Items.Add(ListaCuatrimestre[i].Extra.ToString());
                Cuatrimestre.Items.Add("/////");
            }
            for(int i =0; i <ListaEstadoCivil.Count; i++)
            {
                EstadoCivil.Items.Add("/////");
                EstadoCivil.Items.Add(ListaEstadoCivil[i].IdEdo.ToString());
                EstadoCivil.Items.Add(ListaEstadoCivil[i].Estado.ToString());
                EstadoCivil.Items.Add(ListaEstadoCivil[i].Extra.ToString());
                EstadoCivil.Items.Add("/////");
            }
            for(int i = 0; i< ListaGrupo.Count; i++)
            {
                Grupo.Items.Add("////");
                Grupo.Items.Add(ListaGrupo[i].IdGrupo.ToString());
                Grupo.Items.Add(ListaGrupo[i].Grado.ToString());
                Grupo.Items.Add(ListaGrupo[i].Letra.ToString());
                Grupo.Items.Add(ListaGrupo[i].Extra.ToString());
                Grupo.Items.Add("////");
            }
            for(int i = 0; i < ListaGrupoCuatrimestre.Count; i++)
            {
                GruCuat.Items.Add("/////");
                GruCuat.Items.Add(ListaGrupoCuatrimestre[i].IdGruCuat.ToString());
                GruCuat.Items.Add(ListaGrupoCuatrimestre[i].FProgEd.ToString());
                GruCuat.Items.Add(ListaGrupoCuatrimestre[i].FGrupo.ToString());
                GruCuat.Items.Add(ListaGrupoCuatrimestre[i].FCuatri.ToString());
                GruCuat.Items.Add(ListaGrupoCuatrimestre[i].Turno.ToString());
                GruCuat.Items.Add(ListaGrupoCuatrimestre[i].Modalidad.ToString());
                GruCuat.Items.Add(ListaGrupoCuatrimestre[i].Extra.ToString());
                GruCuat.Items.Add("/////");
            }
            for(int i =0; i < ListaIncapacidades.Count; i++)
            {
                Incapacidades.Items.Add("/////");
                Incapacidades.Items.Add(ListaIncapacidades[i].IdIncapacidad.ToString());
                Incapacidades.Items.Add(ListaIncapacidades[i].Formato.ToString());
                Incapacidades.Items.Add(ListaIncapacidades[i].FechaInicio.ToString());
                Incapacidades.Items.Add(ListaIncapacidades[i].FechaFinal.ToString());
                Incapacidades.Items.Add(ListaIncapacidades[i].IdPosProfe.ToString());
                Incapacidades.Items.Add("/////");
            }
            for(int i = 0; i< ListaMedico.Count; i++)
            {
                Medico.Items.Add("/////");
                Medico.Items.Add(ListaMedico[i].IdDr.ToString());
                Medico.Items.Add(ListaMedico[i].Nombre.ToString());
                Medico.Items.Add(ListaMedico[i].App.ToString());
                Medico.Items.Add(ListaMedico[i].Apm.ToString());
                Medico.Items.Add(ListaMedico[i].Telefono.ToString());
                Medico.Items.Add(ListaMedico[i].Correo.ToString());
                Medico.Items.Add(ListaMedico[i].Horario.ToString());
                Medico.Items.Add(ListaMedico[i].Especialidad.ToString());
                Medico.Items.Add(ListaMedico[i].Extra.ToString());
                Medico.Items.Add("/////");
            }
            for(int i = 0; i < ListaPositivoAlimno.Count; i++)
            {
                PositivoAlumno.Items.Add("//////");
                PositivoAlumno.Items.Add(ListaPositivoAlimno[i].IdPosAl.ToString());
                PositivoAlumno.Items.Add(ListaPositivoAlimno[i].FechaConfirmado.ToString());
                PositivoAlumno.Items.Add(ListaPositivoAlimno[i].Comprobacion.ToString());
                PositivoAlumno.Items.Add(ListaPositivoAlimno[i].Antecedentes.ToString());
                PositivoAlumno.Items.Add(ListaPositivoAlimno[i].Riesgo.ToString());
                PositivoAlumno.Items.Add(ListaPositivoAlimno[i].NumContagio.ToString());
                PositivoAlumno.Items.Add(ListaPositivoAlimno[i].Extra.ToString());
                PositivoAlumno.Items.Add(ListaPositivoAlimno[i].FAlumno.ToString());
                PositivoAlumno.Items.Add("//////");
            }
            for(int i = 0; i < ListaPositivoProfe.Count; i++)
            {
                PositivoProfe.Items.Add("/////");
                PositivoProfe.Items.Add(ListaPositivoProfe[i].IdPosProfe.ToString());
                PositivoProfe.Items.Add(ListaPositivoProfe[i].FechaConfirmado.ToString());
                PositivoProfe.Items.Add(ListaPositivoProfe[i].Comprobacion.ToString());
                PositivoProfe.Items.Add(ListaPositivoProfe[i].Antecedentes.ToString());
                PositivoProfe.Items.Add(ListaPositivoProfe[i].Riesgo.ToString());
                PositivoProfe.Items.Add(ListaPositivoProfe[i].NumContaio.ToString());
                PositivoProfe.Items.Add(ListaPositivoProfe[i].Extra.ToString());
                PositivoProfe.Items.Add(ListaPositivoProfe[i].FProfe.ToString());
                PositivoProfe.Items.Add("/////");
            }
            for(int i = 0; i < ListaProfeGrupo.Count; i++)
            {
                ProfeGrupo.Items.Add("/////");
                ProfeGrupo.Items.Add(ListaProfeGrupo[i].IdProfeGru.ToString());
                ProfeGrupo.Items.Add(ListaProfeGrupo[i].FProfe.ToString());
                ProfeGrupo.Items.Add(ListaProfeGrupo[i].FGruCuat.ToString());
                ProfeGrupo.Items.Add(ListaProfeGrupo[i].Extra.ToString());
                ProfeGrupo.Items.Add(ListaProfeGrupo[i].Extra2.ToString());
                ProfeGrupo.Items.Add("/////");
            }
            for(int i = 0; i < ListaProfesor.Count; i++)
            {
                Profesor.Items.Add("/////");
                Profesor.Items.Add(ListaProfesor[i].IdProfe.ToString());
                Profesor.Items.Add(ListaProfesor[i].RegistroEmpleado.ToString());
                Profesor.Items.Add(ListaProfesor[i].Nombre.ToString());
                Profesor.Items.Add(ListaProfesor[i].ApPat.ToString());
                Profesor.Items.Add(ListaProfesor[i].ApMat.ToString());
                Profesor.Items.Add(ListaProfesor[i].Genero.ToString());
                Profesor.Items.Add(ListaProfesor[i].Categoria.ToString());
                Profesor.Items.Add(ListaProfesor[i].Correo.ToString());
                Profesor.Items.Add(ListaProfesor[i].Celular.ToString());
                Profesor.Items.Add(ListaProfesor[i].FEdoCivil.ToString());
                Profesor.Items.Add("/////");
            }
            for(int i = 0; i <  ListaProgramaEducativo.Count; i++)
            {
                ProgramaEducativo.Items.Add("//////");
                ProgramaEducativo.Items.Add(ListaProgramaEducativo[i].IdPe.ToString());
                ProgramaEducativo.Items.Add(ListaProgramaEducativo[i].ProgramaEd.ToString());
                ProgramaEducativo.Items.Add(ListaProgramaEducativo[i].FCarrera.ToString());
                ProgramaEducativo.Items.Add(ListaProgramaEducativo[i].Extra.ToString());
                ProgramaEducativo.Items.Add("//////");
            }
            for(int i = 0; i < ListaSeguimientoAl.Count; i++)
            {
                SegumientoAlumno.Items.Add("/////");
                SegumientoAlumno.Items.Add(ListaSeguimientoAl[i].IdSeguimiento.ToString());
                SegumientoAlumno.Items.Add(ListaSeguimientoAl[i].FPositivoAl.ToString());
                SegumientoAlumno.Items.Add(ListaSeguimientoAl[i].FMedico.ToString());
                SegumientoAlumno.Items.Add(ListaSeguimientoAl[i].Fecha.ToString());
                SegumientoAlumno.Items.Add(ListaSeguimientoAl[i].FormComunica.ToString());
                SegumientoAlumno.Items.Add(ListaSeguimientoAl[i].Reporte.ToString());
                SegumientoAlumno.Items.Add(ListaSeguimientoAl[i].Entrevista.ToString());
                SegumientoAlumno.Items.Add(ListaSeguimientoAl[i].Extra.ToString());
                SegumientoAlumno.Items.Add("/////");
            }
            for (int i = 0; i < ListaSeguimientoPro.Count; i++)
            {
                SeguimientoPro.Items.Add("/////");
                SeguimientoPro.Items.Add(ListaSeguimientoPro[i].IdSegui.ToString());
                SeguimientoPro.Items.Add(ListaSeguimientoPro[i].FPositivoProfe.ToString());
                SeguimientoPro.Items.Add(ListaSeguimientoPro[i].FMedico.ToString());
                SeguimientoPro.Items.Add(ListaSeguimientoPro[i].Fecha.ToString());
                SeguimientoPro.Items.Add(ListaSeguimientoPro[i].FormComunica.ToString());
                SeguimientoPro.Items.Add(ListaSeguimientoPro[i].Reporte.ToString());
                SeguimientoPro.Items.Add(ListaSeguimientoPro[i].Entrevista.ToString());
                SeguimientoPro.Items.Add(ListaSeguimientoPro[i].Extra.ToString());
                SeguimientoPro.Items.Add("/////");
            }

        }
    }
}