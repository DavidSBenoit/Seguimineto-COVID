using System;
using System.Collections.Generic;
using Entidades;
using Logica_de_Negocios;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID.Pages
{
    public partial class Agregar_Medico : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<EstadoCivil> ListaEstadoCivil = new List<EstadoCivil>();
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

        protected void Button_agregar_Medico_Click(object sender, EventArgs e)
        {
            Medico medico = new Medico()
            {
                Nombre = TextBox_nombre.Text,
                App = TextBox_app.Text,
                Apm = TextBox_apm.Text,
                Telefono = TextBox_Telefono.Text,
                Correo = TextBox_correo.Text,
                Horario = TextBox_Horario.Text,
                Especialidad = TextBox_Especialidad.Text,
                Extra = ""
            };

            Interfaz.Agregar_Medico(medico);
        }
    }
}