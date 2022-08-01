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
    public partial class Agregar_Carrera : System.Web.UI.Page
    {
        DLL Interfaz = null;
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
        }

        protected void Button_agregar_carrera_Click(object sender, EventArgs e)
        {
            Carrera carrera = new Carrera()
            {
                NombreCarrera = TextBox_nombrecarrera.Text
            };

            Label1.Text =  Interfaz.Agregar_Carrera(carrera);
        }
    }
}