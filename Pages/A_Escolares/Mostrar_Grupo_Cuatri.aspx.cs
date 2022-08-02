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
    public partial class Mostrar_Grupo_Cuatri : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<ViewGrupoCuatri> viewList = new List<ViewGrupoCuatri>();
        List<GrupoCuatrimestre> grucuat = new List<GrupoCuatrimestre>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                viewList = Interfaz.listaGrupoCutriView();
                grucuat = Interfaz.ListaGrupoCuatrimestre();

                //GridView1.DataSource = viewList;
                //GridView1.DataBind();

                GridView2.DataSource = grucuat;
                GridView2.DataBind();

            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }
    }
}