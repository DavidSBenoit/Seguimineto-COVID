using Entidades;
using Logica_de_Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID.Pages.A_Medicos
{
    public partial class Mostrar_Contagios_Alumnos_Grupo : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Cuatrimestre> cuatriList = new List<Cuatrimestre>();
        List<Alumno> AlumnosList = new List<Alumno>();
        List<Alumno> AlumnosListBind = new List<Alumno>();
        List<ProgramaEducativo> programaEduList = new List<ProgramaEducativo>();
        List<Carrera> carrerasList = new List<Carrera>();
        List<AlumnoGrupo> alumnogrupoList = new List<AlumnoGrupo>();
        List<PositivoAlumno> positivoalumnList = new List<PositivoAlumno>();
        List<GrupoCuatrimestre> grupocuatriList = new List<GrupoCuatrimestre>();
        List<Grupo> gruposList = new List<Grupo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                programaEduList = Interfaz.ListaProgramaEducativo();
                carrerasList = Interfaz.ListaCarrera();


                DropDownList_PE.Items.Add("");
                for (int i = 0; i < programaEduList.Count; i++)
                {
                    var a = carrerasList.Where(x => x.IdCarrera == programaEduList[i].FCarrera).FirstOrDefault().NombreCarrera;
                    DropDownList_PE.Items.Add(programaEduList[i].ProgramaEd + "-" + a);
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
            for (int i = 0; i < cuatriList.Count; i++)
            {
                DropDownList_cuatri.Items.Add(cuatriList[i].Periodo);
            }
        }

        protected void DropDownList_cuatri_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_grupo.Items.Clear();
            DropDownList_grupo.Items.Add("");

            gruposList = Interfaz.ListaGrupo();
            for (int i = 0; i < gruposList.Count; i++)
            {
                DropDownList_grupo.Items.Add(gruposList[i].Grado.ToString() + " - " + gruposList[i].Letra);
            }
        }

        protected void DropDownList_grupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            positivoalumnList = Interfaz.ListaPositivoAlumno();
            AlumnosList = Interfaz.ListaAlumno();
            alumnogrupoList = Interfaz.ListaAlumnoGrupo();
            grupocuatriList = Interfaz.ListaGrupoCuatrimestre();
            programaEduList = Interfaz.ListaProgramaEducativo();
            cuatriList = Interfaz.ListaCuatrimestre();
            gruposList = Interfaz.ListaGrupo();
            int progra = 0, cuatri = 0, grupo=0;

            progra = programaEduList.Where(x => x.IdPe == DropDownList_PE.SelectedIndex).FirstOrDefault().IdPe;
            cuatri = cuatriList.Where(x => x.Periodo == DropDownList_cuatri.SelectedItem.Text).FirstOrDefault().IdCuatrimestre;
            grupo = gruposList.Where(x => x.IdGrupo == DropDownList_grupo.SelectedIndex).FirstOrDefault().IdGrupo;

            AlumnosListBind = AlumnosList.Where(x => x.IdAlumno == alumnogrupoList.Where(y => y.FGruCuat == grupocuatriList.Where(z => z.FProgEd == progra && z.FCuatri == cuatri && z.FGrupo == grupo).FirstOrDefault().IdGruCuat).FirstOrDefault().FAlumn).ToList();

            GridView1.DataSource = AlumnosListBind;
            GridView1.DataBind();
        }
    }
}