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
    public partial class Mostrar_Cuatrimestres : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Cuatrimestre> cuatriList = new List<Cuatrimestre>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                cuatriList = Interfaz.ListaCuatrimestre();

                GridView1.DataSource = cuatriList;
                GridView1.DataBind();

            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void DropDownList_select_profe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}