using Entidades;
using Logica_de_Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID.Pages.A_Medicos
{

    public partial class Positivo_Profe : System.Web.UI.Page
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
                DropDownList_select_Profe.Items.Add("");
                for (int i = 0; i < profesorlist.Count; i++)
                {
                    DropDownList_select_Profe.Items.Add(profesorlist[i].RegistroEmpleado.ToString());
                }

                DropDownList_Riesgo.Items.Add("Bajo");
                DropDownList_Riesgo.Items.Add("Medio");
                DropDownList_Riesgo.Items.Add("Alto");
            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void Button_agregar_Positivo_Profesor_Click(object sender, EventArgs e)
        {
            profesorlist = Interfaz.ListaProfesor();
            positivoPRO = Interfaz.ListaPositivoProfe();
            byte ultimo = (byte)(positivoPRO.Last().NumContaio + 1);
            string nombre = "", ruta = "~/Pages/A_Medicos/Comprobantes_POSPRO/", resp = "";


            if (FileUpload_Comprobacion.HasFile)
            {
                nombre = FileUpload_Comprobacion.FileName;
                ruta = ruta + nombre;
                FileUpload_Comprobacion.SaveAs(Server.MapPath(ruta));
                resp = "Seguardó el archivo en: " + ruta;
            }

            PositivoProfe pospro = new PositivoProfe()
            {
                FechaConfirmado = Calendar_confirmado.SelectedDate,
                Comprobacion = ruta,
                Antecedentes = TextBox_Antecedentes.Text,
                Riesgo = DropDownList_Riesgo.SelectedItem.Text,
                NumContaio = ultimo,
                FProfe = profesorlist.Where(x => x.RegistroEmpleado == Convert.ToInt32(DropDownList_select_Profe.SelectedItem.Text)).FirstOrDefault().IdProfe,
                Extra = ""

            };

            Label1.Text = Interfaz.Agregar_PositivoProfe(pospro) + "-" + resp;
        }
    }
}