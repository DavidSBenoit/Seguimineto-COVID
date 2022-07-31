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
    public partial class Ediat_Profesores : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<EstadoCivil> ListaEstadoCivil = new List<EstadoCivil>();
        List<Profesor> ProfesoresList = new List<Profesor>();
        int ID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                DropDownList_Selec_profe.Items.Add("");
                ProfesoresList = Interfaz.ListaProfesor();
                for (int i = 0; i < ProfesoresList.Count; i++)
                {
                    var nombre = ProfesoresList[i].Nombre + " " + ProfesoresList[i].ApPat + " " + ProfesoresList[i].ApMat;
                    DropDownList_Selec_profe.Items.Add(nombre);
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
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }
        }

        protected void DropDownList_Selec_profe_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selected_alumn = DropDownList_Selec_alumn.SelectedItem.Text;
            ProfesoresList = Interfaz.ListaProfesor();
            if (DropDownList_Selec_profe.SelectedIndex == 0)
            {
                TextBox_registro.Text = "";
                TextBox_nombre.Text = "";
                TextBox_app.Text = "";
                TextBox_apm.Text = "";
                TextBox_correo.Text = "";
                TextBox_calular.Text = "";
                DropDownList_Genero.SelectedIndex = 0;
                DropDownList_Genero.SelectedIndex = 0;
                DropDownList_categoría.SelectedIndex = 0;

            }
            else
            {
                ID = ProfesoresList.Where(x => x.IdProfe == DropDownList_Selec_profe.SelectedIndex + 1).Last().IdProfe;
                TextBox_registro.Text = (ProfesoresList.Where(x => x.IdProfe == ID).Last().RegistroEmpleado).ToString();
                TextBox_nombre.Text = ProfesoresList.Where(x => x.IdProfe == ID).Last().Nombre;
                TextBox_app.Text = ProfesoresList.Where(x => x.IdProfe == ID).Last().ApPat;
                TextBox_apm.Text = ProfesoresList.Where(x => x.IdProfe == ID).Last().ApMat;
                TextBox_correo.Text = ProfesoresList.Where(x => x.IdProfe == ID).Last().Correo;
                TextBox_calular.Text = ProfesoresList.Where(x => x.IdProfe == ID).Last().Celular;

                var genero = ProfesoresList.Where(x => x.IdProfe == ID).Last().Genero;

                var edo = ProfesoresList.Where(x => x.IdProfe == ID).Last().FEdoCivil;

                var cat = ProfesoresList.Where(x => x.IdProfe == ID).Last().Categoria;

                if (genero.Contains("Masculino"))
                {
                    DropDownList_Genero.SelectedIndex = 1;
                }
                else if (genero.Contains("Femenino"))
                {
                    DropDownList_Genero.SelectedIndex = 2;
                }

                if (edo == 1)
                {
                    DropDownList_edocivil.SelectedIndex = 1;
                }
                else if (edo == 2)
                {
                    DropDownList_edocivil.SelectedIndex = 2;
                }

                if (cat.Contains("Completo"))
                {
                    DropDownList_categoría.SelectedIndex = 1;
                }
                else if (cat.Contains("Medio"))
                {
                    DropDownList_categoría.SelectedIndex = 2;
                }
                else if (cat.Contains("Asignatura"))
                {
                    DropDownList_categoría.SelectedIndex = 3;
                }
            }
        }

        protected void Button_Editar_profesor_Click(object sender, EventArgs e)
        {
            ListaEstadoCivil = Interfaz.ListaEstadoCivil();
            ProfesoresList = Interfaz.ListaProfesor();

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
            
            ID = ProfesoresList.Where(x => x.IdProfe == DropDownList_Selec_profe.SelectedIndex + 1).Last().IdProfe;

            Label1.Text = Interfaz.Actualizar_Profesor(profesor, ID);
        }

        protected void Button_Eliminar_profesor_Click(object sender, EventArgs e)
        {
            ProfesoresList = Interfaz.ListaProfesor();
            ID = ProfesoresList.Where(x => x.IdProfe == DropDownList_Selec_profe.SelectedIndex + 1).Last().IdProfe;

            Label1.Text = Interfaz.Eliminar_Profesor(ID);
        }
    }
}