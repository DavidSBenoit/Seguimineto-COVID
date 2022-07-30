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
    public partial class Delete : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = Interfaz.EliminarAlumno(8);
            //Label2.Text = Interfaz.Eliminar_GrupoAlumno(8);
            //Label3.Text = Interfaz.Eliminar_Carrera(5);
            //Label4.Text = Interfaz.Eliminar_Cuatrimestre(4);
            //Label5.Text = Interfaz.Eliminar_EstadoCivil(3);
            //Label6.Text = Interfaz.Eliminar_Grupo(7);
            //Label7.Text = Interfaz.Eliminar_Grupo_Cuatrimestre(7);
            //Label8.Text = Interfaz.Eliminar_Incapacidades(3);
            //Label9.Text = Interfaz.Eliminar_Medico(4);
            //Label10.Text = Interfaz.Eliminar_PositivoAlumno(3);
            Label11.Text = Interfaz.Eliminar_PositivoProfe(3);
            Label12.Text = Interfaz.Eliminar_ProfeGrupo(9);
            //Label13.Text = Interfaz.Eliminar_Profesor(6);
            //Label14.Text = Interfaz.Eliminar_ProgramaEducativo(5);
            //Label15.Text = Interfaz.Eliminar_SeguimientoAl(3);
            //Label16.Text = Interfaz.Eliminar_SeguimientoPRO(3);
        }
    }
}