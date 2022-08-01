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
    public partial class Positivo_Alumno : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Alumno> alumnoslist = new List<Alumno>();
        List<PositivoAlumno> positivoAl = new List<PositivoAlumno>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                alumnoslist = Interfaz.ListaAlumno();
                DropDownList_select_alumn.Items.Add("");
                for (int i = 0; i < alumnoslist.Count; i++)
                {
                    DropDownList_select_alumn.Items.Add(alumnoslist[i].Matricula);
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

        protected void DropDownList_select_alumn_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button_agregar_Positivo_Alumno_Click(object sender, EventArgs e)
        {
            alumnoslist = Interfaz.ListaAlumno();
            positivoAl = Interfaz.ListaPositivoAlumno();
            byte ultimo = (byte)(positivoAl.Last().NumContagio + 1);
            string nombre = "", ruta ="~/Pages/A_Medicos/Comprobantes_POSAL/", resp ="";


            if (FileUpload_Comprobacion.HasFile)
            {
                nombre = FileUpload_Comprobacion.FileName;
                ruta = ruta + nombre;
                FileUpload_Comprobacion.SaveAs(Server.MapPath(ruta));
                resp = "Seguardó el archivo en: " + ruta;
            }

            PositivoAlumno posal = new PositivoAlumno()
            {
                FechaConfirmado = Calendar_confirmado.SelectedDate,
                Comprobacion = ruta,
                Antecedentes = TextBox_Antecedentes.Text,
                Riesgo = DropDownList_Riesgo.SelectedItem.Text,
                NumContagio = ultimo,
                FAlumno = alumnoslist.Where(x => x.Matricula == DropDownList_select_alumn.SelectedItem.Text).FirstOrDefault().IdAlumno,
                Extra = ""
                
            };

            Label1.Text = Interfaz.Agregar_PositivoAlumno(posal) + "-" + resp;
        }
    }
}