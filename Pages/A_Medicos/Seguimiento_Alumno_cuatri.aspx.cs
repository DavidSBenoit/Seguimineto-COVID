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
    public partial class Seguimiento_Alumno_cuatri : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Alumno> AlumnosList = new List<Alumno>();
        List<Cuatrimestre> cuatriList = new List<Cuatrimestre>();
        List<SeguimientoAl> seguiALList = new List<SeguimientoAl>();
        List<PositivoAlumno> PositivoAlumnoList = new List<PositivoAlumno>();
        List<AlumnoGrupo> algruList = new List<AlumnoGrupo>();
        List<GrupoCuatrimestre> grucuatList = new List<GrupoCuatrimestre>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                cuatriList = Interfaz.ListaCuatrimestre();


                DropDownList_Cuatri.Items.Add("");
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

        protected void DropDownList_Cuatri_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList_Alumn.Items.Clear();

            //cuatriList = Interfaz.ListaCuatrimestre();
            //algruList = Interfaz.ListaAlumnoGrupo();
            //grucuatList = Interfaz.ListaGrupoCuatrimestre();
            //AlumnosList = Interfaz.ListaAlumno();

            //List<Alumno> temp = AlumnosList.Where(x => x.IdAlumno == algruList.Where(y => y.FGruCuat == grucuatList.Where(z => z.FCuatri == cuatriList.Where(w => w.Periodo == DropDownList_Cuatri.SelectedItem.Text).FirstOrDefault().IdCuatrimestre).FirstOrDefault().IdGruCuat).FirstOrDefault().FAlumn).ToList();

            //DropDownList_Alumn.Items.Add("");
            //for (int i = 0; i < temp.Count; i++)
            //{
            //    DropDownList_Alumn.Items.Add(temp[i].Matricula);
            //}

            AlumnosList = Interfaz.ListaAlumno();

            DropDownList_Alumn.Items.Add("");
            for(int i = 0; i<AlumnosList.Count; i++)
            {
                DropDownList_Alumn.Items.Add(AlumnosList[i].Matricula);
            }

        }

        protected void DropDownList_Alumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            seguiALList = Interfaz.ListaSeguimientoAl();
            PositivoAlumnoList = Interfaz.ListaPositivoAlumno();
            cuatriList = Interfaz.ListaCuatrimestre();
            algruList = Interfaz.ListaAlumnoGrupo();
            grucuatList = Interfaz.ListaGrupoCuatrimestre();
            AlumnosList = Interfaz.ListaAlumno();

            List<SeguimientoAl> temp = seguiALList.Where(f => f.FPositivoAl == PositivoAlumnoList.Where(x => x.FAlumno == AlumnosList.Where(y => y.Matricula == DropDownList_Alumn.SelectedItem.Text).FirstOrDefault().IdAlumno).FirstOrDefault().IdPosAl).ToList();

            GridView1.DataSource = temp;
            GridView1.DataBind();
        }
    }
}