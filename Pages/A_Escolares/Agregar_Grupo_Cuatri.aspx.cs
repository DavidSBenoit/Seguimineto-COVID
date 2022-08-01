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
    public partial class Agregar_Grupo_Cuatri : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<ProgramaEducativo> programaList = new List<ProgramaEducativo>();
        List<Grupo> gruposList = new List<Grupo>();
        List<Cuatrimestre> cuatriList = new List<Cuatrimestre>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                programaList = Interfaz.ListaProgramaEducativo();
                gruposList = Interfaz.ListaGrupo();
                cuatriList = Interfaz.ListaCuatrimestre();

                DropDownList_programaEdu.Items.Add("");
                DropDownList_Grupo.Items.Add("");
                DropDownList_Cuatri.Items.Add("");
                DropDownList_turno.Items.Add("Matutino");
                DropDownList_turno.Items.Add("Vespertino");
                DropDownList_Modalidad.Items.Add("Prescencial");
                DropDownList_Modalidad.Items.Add("Virtual");

                for(int i = 0; i < programaList.Count; i++)
                {
                    DropDownList_programaEdu.Items.Add(programaList[i].ProgramaEd);
                }

                for (int i = 0; i < gruposList.Count; i++)
                {
                    DropDownList_Grupo.Items.Add(gruposList[i].Grado + " - "+ gruposList[i].Letra);

                }

                for (int i = 0; i < cuatriList.Count; i++)
                {
                    DropDownList_Cuatri.Items.Add(cuatriList[i].Periodo);
                }

            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void Button_agregar_GrupoCuatri_Click(object sender, EventArgs e)
        {
            programaList = Interfaz.ListaProgramaEducativo();
            gruposList = Interfaz.ListaGrupo();
            cuatriList = Interfaz.ListaCuatrimestre();

            GrupoCuatrimestre GC = new GrupoCuatrimestre()
            {
                FProgEd = programaList.Where(x => x.ProgramaEd == DropDownList_programaEdu.SelectedItem.Text).FirstOrDefault().IdPe,
                FGrupo = gruposList.Where(x => x.IdGrupo == DropDownList_Grupo.SelectedIndex).FirstOrDefault().IdGrupo,
                FCuatri = cuatriList.Where(x => x.Periodo == DropDownList_Cuatri.SelectedItem.Text).FirstOrDefault().IdCuatrimestre,
                Turno = DropDownList_turno.SelectedItem.Text,
                Modalidad = DropDownList_Modalidad.SelectedItem.Text,
                Extra = ""
            };

            Label1.Text = Interfaz.Agregar_Grupo_Cuatrimestre(GC);

        }
    }
}