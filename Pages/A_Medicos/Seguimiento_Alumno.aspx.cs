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
    public partial class Seguimiento_Alumno : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Medico> medicoslist = new List<Medico>();
        List<PositivoAlumno> positivoALlist = new List<PositivoAlumno>();
        List<Alumno> alumnolist = new List<Alumno>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                medicoslist = Interfaz.ListaMedico();
                positivoALlist = Interfaz.ListaPositivoAlumno();
                alumnolist = Interfaz.ListaAlumno();
                
                DropDownList_select_alumn.Items.Add("");
                for (int i = 0; i < positivoALlist.Count; i++)
                {
                    DropDownList_select_alumn.Items.Add(alumnolist.Where(x=>x.IdAlumno == positivoALlist[i].FAlumno).FirstOrDefault().Matricula);
                }

                DropDownList_Select_Medico.Items.Add("");
                for (int i = 0; i < medicoslist.Count; i++)
                {
                    DropDownList_Select_Medico.Items.Add(medicoslist[i].Nombre + " " + medicoslist[i].App + " " + medicoslist[i].Apm);
                }
            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void Button_guardar_seguimeinto_Click(object sender, EventArgs e)
        {
            medicoslist = Interfaz.ListaMedico();
            positivoALlist = Interfaz.ListaPositivoAlumno();
            alumnolist = Interfaz.ListaAlumno();

            string nombre = "", ruta_comu = "~/Pages/A_Medicos/Forms_Seguimiento_AL/Form_Comunica/", ruta_repor = "~/Pages/A_Medicos/Forms_Seguimiento_AL/Reporte/", ruta_entre = "~/Pages/A_Medicos/Forms_Seguimiento_AL/Entrevista/", resp_comu = "", resp_repo = "", resp_entre = "";

            if (FileUpload_Comunica.HasFile)
            {
                nombre = FileUpload_Comunica.FileName;
                ruta_comu = ruta_comu  + nombre;
                FileUpload_Comunica.SaveAs(Server.MapPath(ruta_comu));
                resp_comu = "Seguardó el archivo en: " + ruta_comu;
            }

            if (FileUpload_reporte.HasFile)
            {
                nombre = FileUpload_reporte.FileName;
                ruta_repor = ruta_repor + nombre;
                FileUpload_reporte.SaveAs(Server.MapPath(ruta_repor));
                resp_repo = "Seguardó el archivo en: " + ruta_repor;
            }

            if (FileUpload_Entrevista.HasFile)
            {
                nombre = FileUpload_Entrevista.FileName;
                ruta_entre = ruta_entre + nombre;
                FileUpload_Entrevista.SaveAs(Server.MapPath(ruta_entre));
                resp_entre = "Seguardó el archivo en: " + ruta_entre;
            }


            int iddr = medicoslist.Where(x => x.IdDr == DropDownList_Select_Medico.SelectedIndex).FirstOrDefault().IdDr;

            SeguimientoAl segui = new SeguimientoAl()
            {
                FPositivoAl = positivoALlist.Where(x => x.FAlumno == alumnolist.Where(y => y.Matricula == DropDownList_select_alumn.SelectedItem.Text).FirstOrDefault().IdAlumno).FirstOrDefault().IdPosAl,
                //FMedico = medicoslist.Where(x => x.IdDr == medicoslist.Where(y => y.Nombre.Contains(DropDownList_Select_Medico.SelectedItem.Text)).FirstOrDefault().IdDr).FirstOrDefault().IdDr,
                FMedico = iddr,
                Fecha = Calendar_fecha.SelectedDate,
                FormComunica = ruta_comu,
                Reporte = ruta_repor,
                Entrevista = ruta_entre,
                Extra =""
            };

            Label1.Text = Interfaz.Agregar_SeguimientoAl(segui) + "-" + resp_comu + "-" + resp_repo + "-" + resp_entre;

        }
    }
}