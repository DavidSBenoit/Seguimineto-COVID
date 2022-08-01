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
    public partial class Modificar_Medico : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Medico> MedicosList = new List<Medico>();
        int ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                DropDownList_Selec_Medico.Items.Add("");
                MedicosList = Interfaz.ListaMedico();
                for (int i = 0; i < MedicosList.Count; i++)
                {
                    var nombre = MedicosList[i].Nombre + " " + MedicosList[i].App + " " + MedicosList[i].Apm;
                    DropDownList_Selec_Medico.Items.Add(nombre);
                }

                
            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void Button_Editar_Medico_Click(object sender, EventArgs e)
        {
            MedicosList = Interfaz.ListaMedico();
            ID = MedicosList.Where(x => x.IdDr == DropDownList_Selec_Medico.SelectedIndex + 1).Last().IdDr;

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

            Interfaz.Actualizar_Medico(medico, ID);
        }

        protected void Button_Eliminar_Medico_Click(object sender, EventArgs e)
        {
            MedicosList = Interfaz.ListaMedico();
            ID = MedicosList.Where(x => x.IdDr == DropDownList_Selec_Medico.SelectedIndex + 1).Last().IdDr;

            Interfaz.Eliminar_Medico(ID);
        }

        protected void DropDownList_Selec_Medico_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedicosList = Interfaz.ListaMedico();
            if (DropDownList_Selec_Medico.SelectedIndex == 0)
            {
                TextBox_nombre.Text = "";
                TextBox_app.Text = "";
                TextBox_apm.Text = "";
                TextBox_correo.Text = "";
                TextBox_Telefono.Text = "";
                TextBox_Horario.Text = "";
                TextBox_Especialidad.Text = "";
                
            }
            else
            {
                ID = MedicosList.Where(x => x.IdDr == DropDownList_Selec_Medico.SelectedIndex + 1).Last().IdDr;

                TextBox_nombre.Text = MedicosList.Where(x => x.IdDr == ID).Last().Nombre;
                TextBox_app.Text = MedicosList.Where(x => x.IdDr == ID).Last().App;
                TextBox_apm.Text = MedicosList.Where(x => x.IdDr == ID).Last().Apm;
                TextBox_correo.Text = MedicosList.Where(x => x.IdDr == ID).Last().Correo;
                TextBox_Telefono.Text = MedicosList.Where(x => x.IdDr == ID).Last().Telefono;
                TextBox_Horario.Text = MedicosList.Where(x => x.IdDr == ID).Last().Horario;
                TextBox_Especialidad.Text = MedicosList.Where(x => x.IdDr == ID).Last().Especialidad;

            }
        }
    }
}