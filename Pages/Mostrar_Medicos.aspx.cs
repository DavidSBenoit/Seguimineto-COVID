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
    public partial class Mostrar_Medicos : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Medico> medicosList = new List<Medico>();

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

            medicosList = Interfaz.ListaMedico();
            GridView1.DataSource = medicosList;
            GridView1.DataBind();
        }
    }
}