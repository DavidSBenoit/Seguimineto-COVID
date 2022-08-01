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
    public partial class Agregar_Profe_Grupo : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Profesor> profesoresList = new List<Profesor>();
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

                profesoresList = Interfaz.ListaProfesor();
                grupoCuatrimestresList = Interfaz.ListaGrupoCuatrimestre();

                programaList = Interfaz.ListaProgramaEducativo();
                gruposList = Interfaz.ListaGrupo();
                cuatriList = Interfaz.ListaCuatrimestre();

                DropDownList_Profe.Items.Add("");
                DropDownList_Grupo.Items.Add("");

                for (int i = 0; i < profesoresList.Count; i++)
                {
                    DropDownList_Profe.Items.Add(profesoresList[i].RegistroEmpleado.ToString());
                }

                for (int i = 0; i < grupoCuatrimestresList.Count; i++)
                {
                    var texto1 = programaList.Where(x => x.IdPe == grupoCuatrimestresList[i].FProgEd).FirstOrDefault().ProgramaEd;
                    var texto2 = gruposList.Where(x => x.IdGrupo == grupoCuatrimestresList[i].FGrupo).FirstOrDefault().Grado + " - " + gruposList.Where(x => x.IdGrupo == grupoCuatrimestresList[i].FGrupo).FirstOrDefault().Letra;
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
            profesoresList = Interfaz.ListaProfesor();
            grupoCuatrimestresList = Interfaz.ListaGrupoCuatrimestre();

            var a = profesoresList.Where(x => x.RegistroEmpleado == Convert.ToInt32(DropDownList_Profe.SelectedItem.Text)).FirstOrDefault().IdProfe;
            var b = grupoCuatrimestresList.Where(x => x.IdGruCuat == DropDownList_Grupo.SelectedIndex).FirstOrDefault().IdGruCuat;

            ProfeGrupo PG = new ProfeGrupo()
            {
                FProfe = a,
                FGruCuat = b,
                Extra = "",
                Extra2 = ""
            };

            Label1.Text = Interfaz.Agregar_ProfeGrupo(PG);
        }
    }
}