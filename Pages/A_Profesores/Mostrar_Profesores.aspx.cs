using Entidades;
using Logica_de_Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID.Pages
{
    public partial class Mostrar_Profesores : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Profesor> profesoresList = new List<Profesor>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;
            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }

            profesoresList = Interfaz.ListaProfesor();
            GridView1.DataSource = profesoresList;
            GridView1.DataBind();
        }
    }
}