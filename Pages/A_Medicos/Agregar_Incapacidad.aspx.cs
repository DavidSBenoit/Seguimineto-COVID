using System;
using System.Collections.Generic;
using Entidades;
using Logica_de_Negocios;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID.Pages.A_Medicos
{
    public partial class Agregar_Incapacidad : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Profesor> profesorlist = new List<Profesor>();
        List<PositivoProfe> positivoPRO = new List<PositivoProfe>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                profesorlist = Interfaz.ListaProfesor();
                DropDownList_selected_Profe.Items.Add("");
                for (int i = 0; i < profesorlist.Count; i++)
                {
                    DropDownList_selected_Profe.Items.Add(profesorlist[i].RegistroEmpleado.ToString());
                }

            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void Button_guardar_incapacidad_Click(object sender, EventArgs e)
        {
            profesorlist = Interfaz.ListaProfesor();
            positivoPRO = Interfaz.ListaPositivoProfe();
            byte ultimo = (byte)(positivoPRO.Last().NumContaio + 1);
            string nombre = "", ruta = "~/Pages/A_Medicos/Incapacidades/", resp = "";

            if (FileUpload_formato.HasFile)
            {
                nombre = FileUpload_formato.FileName;
                ruta = ruta + nombre;
                FileUpload_formato.SaveAs(Server.MapPath(ruta));
                resp = "Seguardó el archivo en: " + ruta;
            }


            Incapacidades incapacidad = new Incapacidades()
            {
                Formato = ruta,
                FechaInicio = Calendar_ini.SelectedDate,
                FechaFinal = Calendar_final.SelectedDate,
                IdPosProfe = positivoPRO.Where(x => x.IdPosProfe == profesorlist.Where(y => y.RegistroEmpleado == Convert.ToInt32(DropDownList_selected_Profe.SelectedItem.Text)).FirstOrDefault().IdProfe).FirstOrDefault().IdPosProfe
            };

            Label1.Text = Interfaz.Agregar_Incapacidades(incapacidad) + "-" + resp;

        }
    }
}