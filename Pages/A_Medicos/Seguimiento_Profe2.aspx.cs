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
    public partial class Seguimiento_Profe2 : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Profesor> profesoresList = new List<Profesor>();
        List<PositivoProfe> positivoprofeList = new List<PositivoProfe>();
        List<SeguimientoPro> seguimientoPro = new List<SeguimientoPro>();
        List<Medico> medicosList = new List<Medico>();
        List<Incapacidades> incapacidadesList = new List<Incapacidades>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                positivoprofeList = Interfaz.ListaPositivoProfe();
                profesoresList = Interfaz.ListaProfesor();

                DropDownList_profesores.Items.Add("");
                for (int i = 0; i < positivoprofeList.Count; i++)
                {
                    DropDownList_profesores.Items.Add(profesoresList.Where(x => x.IdProfe == positivoprofeList[i].FProfe).FirstOrDefault().RegistroEmpleado.ToString());
                }


            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void DropDownList_profesores_SelectedIndexChanged(object sender, EventArgs e)
        {
            profesoresList = Interfaz.ListaProfesor();
            positivoprofeList = Interfaz.ListaPositivoProfe();
            seguimientoPro = Interfaz.ListaSeguimientoPro();
            medicosList = Interfaz.ListaMedico();
            incapacidadesList = Interfaz.ListaIncapacidades();

            var reg = DropDownList_profesores.SelectedItem.Text;

            Label_fecha_confirmado.Text = positivoprofeList.Where(x => x.FProfe == profesoresList.Where(y => y.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().FechaConfirmado.ToString();
            Label_num_contagio.Text = positivoprofeList.Where(x => x.FProfe == profesoresList.Where(y=>y.RegistroEmpleado== Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().NumContaio.ToString();
            Label_antecedentes.Text = positivoprofeList.Where(x => x.FProfe == profesoresList.Where(y => y.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().Antecedentes;
            Label_riesgo.Text = positivoprofeList.Where(x => x.FProfe == profesoresList.Where(y => y.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().Riesgo;
            var nombredr = medicosList.Where(x => x.IdDr == seguimientoPro.Where(y => y.FPositivoProfe == positivoprofeList.Where(z => z.FProfe == profesoresList.Where(w => w.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().IdPosProfe).FirstOrDefault().FMedico).FirstOrDefault().Nombre;
            var appdr = medicosList.Where(x => x.IdDr == seguimientoPro.Where(y => y.FPositivoProfe == positivoprofeList.Where(z => z.FProfe == profesoresList.Where(w => w.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().IdPosProfe).FirstOrDefault().FMedico).FirstOrDefault().App;
            var apmdr = medicosList.Where(x => x.IdDr == seguimientoPro.Where(y => y.FPositivoProfe == positivoprofeList.Where(z => z.FProfe == profesoresList.Where(w => w.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().IdPosProfe).FirstOrDefault().FMedico).FirstOrDefault().Apm;
            Label_medico.Text = nombredr + " " + appdr + " " + apmdr;
            Label_fecha_segui.Text = seguimientoPro.Where(x => x.FPositivoProfe == positivoprofeList.Where(y => y.FProfe == profesoresList.Where(z => z.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().IdPosProfe).FirstOrDefault().Fecha.ToString();
            Label_num_inca.Text = incapacidadesList.Where(x => x.IdPosProfe == positivoprofeList.Where(y => y.FProfe == profesoresList.Where(z => z.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().IdPosProfe).Count().ToString();
            var numi = incapacidadesList.Where(x => x.IdPosProfe == positivoprofeList.Where(y => y.FProfe == profesoresList.Where(z => z.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().IdPosProfe).Count();
            for (int i = 0; i< numi; i++)
            {
                ListBox1.Items.Add(incapacidadesList.Where(x => x.IdPosProfe == positivoprofeList.Where(y => y.FProfe == profesoresList.Where(z => z.RegistroEmpleado == Convert.ToInt32(reg)).FirstOrDefault().IdProfe).FirstOrDefault().IdPosProfe).FirstOrDefault().Formato);
            }
        }
    }
}