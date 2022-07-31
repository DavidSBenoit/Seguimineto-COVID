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
    public partial class Editar_Alumno : System.Web.UI.Page
    {
        DLL Interfaz = null;
        List<EstadoCivil> ListaEstadoCivil = new List<EstadoCivil>();
        List<Alumno> alumnosList = new List<Alumno>();
        int ID=0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Interfaz = new DLL(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                Session["DLL"] = Interfaz;

                DropDownList_Selec_alumn.Items.Add("");
                alumnosList = Interfaz.ListaAlumno();
                for (int i = 0; i < alumnosList.Count; i++)
                {
                    var nombre = alumnosList[i].Nombre + " " + alumnosList[i].ApPat + " " + alumnosList[i].ApMat;
                    DropDownList_Selec_alumn.Items.Add(nombre);
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
            }
            else
            {
                Interfaz = (DLL)Session["DLL"];
            }

            
        }
        //Editar Alumno
        protected void Button_agregar_alumno_Click(object sender, EventArgs e)
        {
            var edo = DropDownList_edocivil.SelectedItem.Text;
            var gen = DropDownList_Genero.SelectedItem.Text;

            ListaEstadoCivil = Interfaz.ListaEstadoCivil();

            Alumno alumno = new Alumno()
            {
                Matricula = TextBox_matricula.Text,
                Nombre = TextBox_nombre.Text,
                ApPat = TextBox_app.Text,
                ApMat = TextBox_apm.Text,
                Genero = gen,
                Correo = TextBox_correo.Text,
                Celular = TextBox_calular.Text,
                FEdoCivil = ListaEstadoCivil.Where(x => x.Estado == edo).Last().IdEdo,
                FNivel = 1
            };

            alumnosList = Interfaz.ListaAlumno();
            ID = alumnosList.Where(x => x.IdAlumno == DropDownList_Selec_alumn.SelectedIndex + 1).Last().IdAlumno;

            Interfaz.ActualizarAlumno(alumno, ID);
        }

        protected void Button_eliminar_alumno_Click(object sender, EventArgs e)
        {
            alumnosList = Interfaz.ListaAlumno();
            ID = alumnosList.Where(x => x.IdAlumno == DropDownList_Selec_alumn.SelectedIndex + 1).Last().IdAlumno;
            Interfaz.EliminarAlumno(ID);
        }

        protected void DropDownList_Selec_alumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var selected_alumn = DropDownList_Selec_alumn.SelectedItem.Text;
            alumnosList = Interfaz.ListaAlumno();
            if(DropDownList_Selec_alumn.SelectedIndex == 0)
            {
                TextBox_matricula.Text = "";
                TextBox_nombre.Text = "";
                TextBox_app.Text = "";
                TextBox_apm.Text = "";
                TextBox_correo.Text = "";
                TextBox_calular.Text = "";
                DropDownList_Genero.SelectedIndex = 0;
                DropDownList_Genero.SelectedIndex = 0;
                
            }
            else
            {
                ID = alumnosList.Where(x => x.IdAlumno == DropDownList_Selec_alumn.SelectedIndex + 1).Last().IdAlumno;
                TextBox_matricula.Text = alumnosList.Where(x => x.IdAlumno == ID).Last().Matricula;
                TextBox_nombre.Text = alumnosList.Where(x => x.IdAlumno == ID).Last().Nombre;
                TextBox_app.Text = alumnosList.Where(x => x.IdAlumno == ID).Last().ApPat;
                TextBox_apm.Text = alumnosList.Where(x => x.IdAlumno == ID).Last().ApMat;
                TextBox_correo.Text = alumnosList.Where(x => x.IdAlumno == ID).Last().Correo;
                TextBox_calular.Text = alumnosList.Where(x => x.IdAlumno == ID).Last().Celular;
                
                var genero = alumnosList.Where(x => x.IdAlumno == ID).Last().Genero;
                
                var edo = alumnosList.Where(x => x.IdAlumno == ID).Last().FEdoCivil;
                
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
            }
            
        }
    }
}