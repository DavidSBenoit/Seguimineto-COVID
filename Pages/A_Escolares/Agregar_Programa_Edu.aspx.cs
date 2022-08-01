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
    public partial class Agregar_Programa_Edu : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Carrera> carrerasList = new List<Carrera>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                carrerasList = Interfaz.ListaCarrera();

                DropDownList_carrera.Items.Add("");

                for(int i=0; i< carrerasList.Count; i++)
                {
                    DropDownList_carrera.Items.Add(carrerasList[i].NombreCarrera);
                }

            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void Button_agregar_programa_Click(object sender, EventArgs e)
        {
            carrerasList = Interfaz.ListaCarrera();

            ProgramaEducativo PE = new ProgramaEducativo()
            {
                ProgramaEd = TextBox_programa.Text,
                FCarrera = carrerasList.Where(x => x.NombreCarrera == DropDownList_carrera.SelectedItem.Text).FirstOrDefault().IdCarrera,
                Extra = ""
            };

            Label1.Text = Interfaz.Agregar_ProgramaEducativo(PE);

        }
    }
}