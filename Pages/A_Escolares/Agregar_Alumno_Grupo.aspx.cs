using System;
using System.Collections.Generic;
using Entidades;
using Logica_de_Negocios;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID.Pages.A_Escolares
{
    public partial class Agregar_Alumno_Grupo : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Alumno> alumnoList = new List<Alumno>();
        List<GrupoCuatrimestre> grupoCuatrimestresList = new List<GrupoCuatrimestre>();
        List<ProgramaEducativo> programaList = new List<ProgramaEducativo>();
        List<Grupo> gruposList = new List<Grupo>();
        List<Cuatrimestre> cuatriList = new List<Cuatrimestre>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                alumnoList = Interfaz.ListaAlumno();
                grupoCuatrimestresList = Interfaz.ListaGrupoCuatrimestre();

                programaList = Interfaz.ListaProgramaEducativo();
                gruposList = Interfaz.ListaGrupo();
                cuatriList = Interfaz.ListaCuatrimestre();

                DropDownList_Alumn.Items.Add("");
                DropDownList_Grupo.Items.Add("");

                for (int i = 0; i<alumnoList.Count; i++)
                {
                    DropDownList_Alumn.Items.Add(alumnoList[i].Matricula);
                }

                for(int i = 0; i < grupoCuatrimestresList.Count; i++)
                {
                    var texto1 = programaList.Where(x => x.IdPe == grupoCuatrimestresList[i].FProgEd).FirstOrDefault().ProgramaEd;
                    var texto2 = gruposList.Where(x => x.IdGrupo == grupoCuatrimestresList[i].FGrupo).FirstOrDefault().Grado+ " - " + gruposList.Where(x => x.IdGrupo == grupoCuatrimestresList[i].FGrupo).FirstOrDefault().Letra;
                    var text3 = cuatriList.Where(x => x.IdCuatrimestre == grupoCuatrimestresList[i].FCuatri).FirstOrDefault().Periodo;
                    var turno = grupoCuatrimestresList[i].Turno;
                    var modal = grupoCuatrimestresList[i].Modalidad;

                    var final = "Programa Educativo: " + texto1 + " Grado y Grupo: " + texto2 + " Cuatrimentre: " + text3 + " Turno: " + turno + " Modalidad: " + modal;

                    DropDownList_Grupo.Items.Add(final);
                }

                
            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void Button_agregar_GrupoCuatri_Click(object sender, EventArgs e)
        {

            alumnoList = Interfaz.ListaAlumno();
            grupoCuatrimestresList = Interfaz.ListaGrupoCuatrimestre();

            var a = alumnoList.Where(x => x.Matricula == DropDownList_Alumn.SelectedItem.Text).FirstOrDefault().IdAlumno;
            var b = grupoCuatrimestresList.Where(x => x.IdGruCuat == DropDownList_Grupo.SelectedIndex).FirstOrDefault().IdGruCuat;

            AlumnoGrupo AG = new AlumnoGrupo()
            {
                FAlumn =a,
                FGruCuat = b,
                Extra = "",
                Extra2=""
            };

            Label1.Text = Interfaz.Agregar_AlumnoGrupo(AG);
        }
    }
}