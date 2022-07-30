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
    public partial class Update : System.Web.UI.Page
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

        protected void Button_Update_Alumno_Click(object sender, EventArgs e)
        {
            Alumno alumno = new Alumno()
            {
                Matricula = TextBox_matricula.Text,
                Nombre = TextBox_nombre.Text,
                ApPat = TextBox_app.Text,
                ApMat = TextBox_apm.Text,
                Genero = TextBox_genero.Text,
                Correo = TextBox_correo.Text,
                Celular = TextBox_celular.Text,
                FEdoCivil = Convert.ToByte(TextBox_edocivil.Text),
                FNivel = Convert.ToByte(TextBox_fnivel.Text)
            };

            int ID = Convert.ToInt32(TextBox_ID.Text);

            Label_respuesta_UPD_alumno.Text =  Interfaz.ActualizarAlumno(alumno, ID);
        }
    }
}