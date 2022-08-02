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
    public partial class Editar_Grupo_Cuatrimestre : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<ProgramaEducativo> programaList = new List<ProgramaEducativo>();
        List<Grupo> gruposList = new List<Grupo>();
        List<Cuatrimestre> cuatriList = new List<Cuatrimestre>();
        List<GrupoCuatrimestre> GruCuat = new List<GrupoCuatrimestre>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                programaList = Interfaz.ListaProgramaEducativo();
                gruposList = Interfaz.ListaGrupo();
                cuatriList = Interfaz.ListaCuatrimestre();
                GruCuat = Interfaz.ListaGrupoCuatrimestre();

                DropDownList_programaEdu.Items.Add("");
                DropDownList_Grupo.Items.Add("");
                DropDownList_Cuatri.Items.Add("");
                DropDownList_turno.Items.Add("Matutino");
                DropDownList_turno.Items.Add("Vespertino");
                DropDownList_Modalidad.Items.Add("Prescencial");
                DropDownList_Modalidad.Items.Add("Virtual");

                for (int i = 0; i < GruCuat.Count; i++)
                {
                    DropDownList_programaEdu.Items.Add(GruCuat[i].IdGruCuat.ToString());
                }

                for (int i = 0; i < programaList.Count; i++)
                {
                    DropDownList_pro.Items.Add(programaList[i].ProgramaEd);
                }

                for (int i = 0; i < gruposList.Count; i++)
                {
                    DropDownList_Grupo.Items.Add(gruposList[i].Grado + " - " + gruposList[i].Letra);

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

        protected void DropDownList_programaEdu_SelectedIndexChanged(object sender, EventArgs e)
        {
            programaList = Interfaz.ListaProgramaEducativo();
            gruposList = Interfaz.ListaGrupo();
            cuatriList = Interfaz.ListaCuatrimestre();
            GruCuat = Interfaz.ListaGrupoCuatrimestre();

            Label_Programa_Edu.Text = programaList.Where(x => x.IdPe == GruCuat.Where(y => y.IdGruCuat == Convert.ToInt32(DropDownList_programaEdu.SelectedItem.Text)).FirstOrDefault().FProgEd).FirstOrDefault().ProgramaEd;
            Label_grupo.Text = gruposList.Where(x => x.IdGrupo == GruCuat.Where(y => y.IdGruCuat == Convert.ToInt32(DropDownList_programaEdu.SelectedItem.Text)).FirstOrDefault().FGrupo).FirstOrDefault().Grado + " - " + gruposList.Where(x => x.IdGrupo == GruCuat.Where(y => y.IdGruCuat == Convert.ToInt32(DropDownList_programaEdu.SelectedItem.Text)).FirstOrDefault().FGrupo).FirstOrDefault().Letra;
            Label_cuatri.Text = cuatriList.Where(x => x.IdCuatrimestre == GruCuat.Where(y => y.IdGruCuat == Convert.ToInt32(DropDownList_programaEdu.SelectedItem.Text)).FirstOrDefault().FCuatri).FirstOrDefault().Periodo;
            Label_turno.Text = GruCuat.Where(y => y.IdGruCuat == Convert.ToInt32(DropDownList_programaEdu.SelectedItem.Text)).FirstOrDefault().Turno;
            Label_modalidad.Text = GruCuat.Where(y => y.IdGruCuat == Convert.ToInt32(DropDownList_programaEdu.SelectedItem.Text)).FirstOrDefault().Modalidad;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList_programaEdu.SelectedItem.Text);

            programaList = Interfaz.ListaProgramaEducativo();
            gruposList = Interfaz.ListaGrupo();
            cuatriList = Interfaz.ListaCuatrimestre();

            var a = programaList.Where(x => x.ProgramaEd == DropDownList_pro.SelectedItem.Text).FirstOrDefault().IdPe;
            var b = gruposList.Where(x => x.IdGrupo == DropDownList_Grupo.SelectedIndex).FirstOrDefault().IdGrupo;
            var c = cuatriList.Where(x => x.Periodo == DropDownList_Cuatri.SelectedItem.Text).FirstOrDefault().IdCuatrimestre;
            var d = DropDownList_turno.SelectedItem.Text;
            var g = DropDownList_Modalidad.SelectedItem.Text;
            var f = "";

            GrupoCuatrimestre GC = new GrupoCuatrimestre()
            {
                FProgEd = a,
                FGrupo = b,
                FCuatri = c,
                Turno = d,
                Modalidad = g,
                Extra = f
            };

            Interfaz.Actualizar_Grupo_Cuatrimestre(GC, id);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(DropDownList_programaEdu.SelectedItem.Text);

            Interfaz.Eliminar_Grupo_Cuatrimestre(id);
        }
    }
}