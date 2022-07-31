using Entidades;
using Logica_de_Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID
{
    public partial class Mostrar_Alumnos : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Alumno> alumnosList = new List<Alumno>();
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

            alumnosList = Interfaz.ListaAlumno();
            GridView1.DataSource = alumnosList;
            GridView1.DataBind();

            

        }
    }
}