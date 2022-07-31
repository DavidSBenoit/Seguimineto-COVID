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
    public partial class Agregar_Profesor : System.Web.UI.Page
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

            ListaEstadoCivil = Interfaz.ListaEstadoCivil();
            DropDownList_edocivil.Items.Add("");
            for (int i = 0; i < ListaEstadoCivil.Count; i++)
            {
                DropDownList_edocivil.Items.Add(ListaEstadoCivil[i].Estado.ToString());
            }

            DropDownList_Genero.Items.Add("");
            DropDownList_Genero.Items.Add("Masculino");
            DropDownList_Genero.Items.Add("Femenino");

            DropDownList_categoría.Items.Add("");
            DropDownList_categoría.Items.Add("Tiempo Completo");
            DropDownList_categoría.Items.Add("Medio Tiempo");
            DropDownList_categoría.Items.Add("Por Asignatura");
        }

        protected void Button_agregar_profesor_Click(object sender, EventArgs e)
        {
            var edo = DropDownList_edocivil.SelectedItem.Text;
            var gen = DropDownList_Genero.SelectedItem.Text;
            var cate = DropDownList_categoría.SelectedItem.Text;

            Profesor profesor = new Profesor()
            {
                RegistroEmpleado = Convert.ToInt32(TextBox_registro.Text),
                Nombre = TextBox_nombre.Text,
                ApPat = TextBox_app.Text,
                ApMat = TextBox_apm.Text,
                Genero = gen,
                Categoria = cate,
                Correo = TextBox_correo.Text,
                Celular = TextBox_calular.Text,
                FEdoCivil = ListaEstadoCivil.Where(x => x.Estado == edo).Last().IdEdo

            };

            Label1.Text = Interfaz.Agregar_Profesor(profesor);

        }
    }
}