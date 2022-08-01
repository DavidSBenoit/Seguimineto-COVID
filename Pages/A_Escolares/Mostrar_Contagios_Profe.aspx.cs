using Entidades;
using Logica_de_Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID.Pages.A_Escolares
{
    public partial class Mostrar_Contagios_Profe : System.Web.UI.Page
    {

        DLL Interfaz = null;
        List<Cuatrimestre> cuatriList = new List<Cuatrimestre>();
        List<Profesor> profesoresList = new List<Profesor>();
        List<Profesor> profesoresListBind = new List<Profesor>();
        List<ProgramaEducativo> programaEduList = new List<ProgramaEducativo>();
        List<Carrera> carrerasList = new List<Carrera>();
        List<ProfeGrupo> profeGrupoList = new List<ProfeGrupo>();
        List<PositivoProfe> positivoprofeList = new List<PositivoProfe>();
        List<GrupoCuatrimestre> grupocuatriList = new List<GrupoCuatrimestre>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                cuatriList = Interfaz.ListaCuatrimestre();
                profesoresList = Interfaz.ListaProfesor();
                programaEduList = Interfaz.ListaProgramaEducativo();
                carrerasList = Interfaz.ListaCarrera();

                //for(int i = 0; i<cuatriList.Count; i++)
                //{
                //    DropDownList_cuatri.Items.Add(cuatriList[i].Periodo);
                //}
                DropDownList_PE.Items.Add("");
                for (int i = 0; i < programaEduList.Count; i++)
                {
                    var a = carrerasList.Where(x => x.IdCarrera == programaEduList[i].FCarrera).FirstOrDefault().NombreCarrera;
                    DropDownList_PE.Items.Add(programaEduList[i].ProgramaEd + "-"+ a);
                }

            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void DropDownList_PE_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_cuatri.Items.Clear();
            DropDownList_cuatri.Items.Add("");

            cuatriList = Interfaz.ListaCuatrimestre();
            for (int i = 0; i<cuatriList.Count; i++)
            {
                DropDownList_cuatri.Items.Add(cuatriList[i].Periodo);
            }
        }

        protected void DropDownList_cuatri_SelectedIndexChanged(object sender, EventArgs e)
        {
            positivoprofeList = Interfaz.ListaPositivoProfe();
            profesoresList = Interfaz.ListaProfesor();
            profeGrupoList = Interfaz.ListaProfeGrupo();
            grupocuatriList = Interfaz.ListaGrupoCuatrimestre();
            programaEduList = Interfaz.ListaProgramaEducativo();
            cuatriList = Interfaz.ListaCuatrimestre();
            int progra = 0, cuatri = 0;

            progra = programaEduList.Where(x => x.IdPe == DropDownList_PE.SelectedIndex).FirstOrDefault().IdPe;
            cuatri = cuatriList.Where(x => x.Periodo == DropDownList_cuatri.SelectedItem.Text).FirstOrDefault().IdCuatrimestre;

            profesoresListBind = profesoresList.Where(x => x.IdProfe == profeGrupoList.Where(y => y.FGruCuat == grupocuatriList.Where(z => z.FProgEd == progra && z.FCuatri == cuatri).FirstOrDefault().IdGruCuat).FirstOrDefault().IdProfeGru).ToList();

            GridView1.DataSource = profesoresListBind;
            GridView1.DataBind();
        }


    }
}