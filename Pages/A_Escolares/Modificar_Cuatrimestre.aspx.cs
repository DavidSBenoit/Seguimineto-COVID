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

    public partial class Modificar_Cuatrimestre : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<Cuatrimestre> cuatriList = new List<Cuatrimestre>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                cuatriList = Interfaz.ListaCuatrimestre();

                DropDownList_select_profe.Items.Add("");
                for(int i = 0; i< cuatriList.Count; i++)
                {
                    DropDownList_select_profe.Items.Add(cuatriList[i].Periodo);
                }

            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void DropDownList_select_profe_SelectedIndexChanged(object sender, EventArgs e)
        {
            cuatriList = Interfaz.ListaCuatrimestre();

            TextBox_periodo.Text = cuatriList.Where(x => x.Periodo == DropDownList_select_profe.SelectedItem.Text).FirstOrDefault().Periodo;
            TextBox_anio.Text = cuatriList.Where(x => x.Periodo == DropDownList_select_profe.SelectedItem.Text).FirstOrDefault().Anio.ToString();
            Label_fec_ini.Text = cuatriList.Where(x => x.Periodo == DropDownList_select_profe.SelectedItem.Text).FirstOrDefault().Inicio.ToString("d");
            Label_fec_fin.Text = cuatriList.Where(x => x.Periodo == DropDownList_select_profe.SelectedItem.Text).FirstOrDefault().Fin.ToString("d");


        }

        protected void Button_Actualizar_cuatrimestre_Click(object sender, EventArgs e)
        {
            int id = cuatriList.Where(x => x.Periodo == DropDownList_select_profe.SelectedItem.Text).FirstOrDefault().IdCuatrimestre;

            Cuatrimestre cuatri = new Cuatrimestre()
            {
                Periodo = TextBox_periodo.Text,
                Anio = Convert.ToInt32(TextBox_anio.Text),
                Inicio = Calendar_ini.SelectedDate,
                Fin = Calendar_fin.SelectedDate,
                Extra = ""

            };

            Interfaz.Actualizar_Cuatrimestre(cuatri, id);

        }

        protected void Button_Eliminar_cuatrimestre_Click(object sender, EventArgs e)
        {
            int id = cuatriList.Where(x => x.Periodo == DropDownList_select_profe.SelectedItem.Text).FirstOrDefault().IdCuatrimestre;

            Interfaz.Eliminar_Cuatrimestre(id);
        }
    }
}