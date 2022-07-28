using Entidades;
using Logica_de_Negocios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguimineto_COVID
{
    public partial class Index : System.Web.UI.Page
    {
        DLL Interfaz = null;
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string mensaje = "", mensajeC = "";


            GridView1.DataSource = Interfaz.tablaProfesoresServer(ref mensaje, ref mensajeC);
            GridView1.DataBind();
            TextBox1.Text = mensajeC + " " + mensaje;

            List<Alumno> listaAlumno = Interfaz.ListaAlumno(ref mensaje, ref mensajeC);

            for (int i = 0; i < listaAlumno.Count; i++)
            {
                ListBox1.Items.Add("//////");
                ListBox1.Items.Add(listaAlumno[i].IdAlumno.ToString());
                ListBox1.Items.Add(listaAlumno[i].Matricula.ToString());
                ListBox1.Items.Add(listaAlumno[i].Nombre.ToString());
                ListBox1.Items.Add(listaAlumno[i].ApPat.ToString());
                ListBox1.Items.Add(listaAlumno[i].ApMat.ToString());
                ListBox1.Items.Add(listaAlumno[i].Celular.ToString());
                ListBox1.Items.Add(listaAlumno[i].Correo.ToString());
                ListBox1.Items.Add(listaAlumno[i].Genero.ToString());
                ListBox1.Items.Add(listaAlumno[i].FEdoCivil.ToString());
                ListBox1.Items.Add(listaAlumno[i].FNivel.ToString());
                ListBox1.Items.Add("//////");
            }
        }
    }
}