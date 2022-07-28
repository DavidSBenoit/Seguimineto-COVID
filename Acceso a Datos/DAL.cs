using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso_a_Datos
{
    public class DAL
    {
        private string cableConn;
        public DAL(string connection)
        {
            cableConn = connection;
        }

        public SqlConnection ConnectionEstablecida(ref string mensajeC)
        {
            SqlConnection puerto = new SqlConnection();
            puerto.ConnectionString = cableConn;
            try
            {
                puerto.Open();
                mensajeC = "Connexion Establecida";
            }
            catch (Exception e)
            {
                mensajeC = "Error: " + e;
                puerto = null;
            }
            return puerto;
        }

        public Boolean BaseSegura(string Sqlinstruc, SqlConnection prAb, ref string mensaje, SqlParameter[] evaluacion)
        {
            Boolean resp = false;
            SqlCommand carrito = null;

            if (prAb != null)
            {
                mensaje = "";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = Sqlinstruc;
                    carrito.Connection = prAb;
                    foreach (SqlParameter x in evaluacion)
                    {
                        carrito.Parameters.Add(x);
                    }
                    try
                    {
                        carrito.ExecuteNonQuery();
                        mensaje = "Se agregaron correctamente";
                        resp = true;
                    }
                    catch (Exception h)
                    {
                        mensaje = "Error : " + h.Message + " !";
                        resp = false;
                    }
                }
                prAb.Close();
                prAb.Dispose();
            }
            else
            {
                mensaje = "Error de Conexión";
            }
            return resp;
        }

        public Boolean BaseSeguraSinParametros(string Sqlinstruc, SqlConnection prAb, ref string mensaje)
        {
            Boolean resp = false;
            SqlCommand carrito = null;

            if (prAb != null)
            {
                mensaje = "";
                using (carrito = new SqlCommand())
                {
                    carrito.CommandText = Sqlinstruc;
                    carrito.Connection = prAb;
                    try
                    {
                        carrito.ExecuteNonQuery();
                        mensaje = "Se agregaron correctamente";
                        resp = true;
                    }
                    catch (Exception h)
                    {
                        mensaje = "Error : " + h.Message + " !";
                        resp = false;
                    }
                }
                prAb.Close();
                prAb.Dispose();
            }
            else
            {
                mensaje = "Error de Conexión";
            }
            return resp;
        }
        public DataSet LecturaSet(string comandoMySql, SqlConnection conAbierta, ref string mensaje, string etiqueta)
        {
            SqlCommand comando = null;
            DataSet dataSet = null;
            SqlDataAdapter dataAdapter = null;

            if (conAbierta == null)
            {
                dataSet = null;
            }
            else
            {
                using (comando = new SqlCommand(comandoMySql, conAbierta))
                {
                    using (dataAdapter = new SqlDataAdapter())
                    {
                        dataSet = new DataSet();
                        dataAdapter.SelectCommand = comando;
                        try
                        {
                            dataAdapter.Fill(dataSet, etiqueta);
                            mensaje = "Recuperacion Correcta";
                        }
                        catch (Exception e)
                        {
                            mensaje = "Lo siento: " + e.Message;
                            dataSet = null;
                        }
                    }
                }
            }
            return dataSet;
        }

        public List<Alumno> ListaAlumno(ref string mensaje, ref string mensajeC)
        {
            string comandoMySql = "select * from Alumno;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Alumno> listaAlumno = new List<Alumno>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(ref mensajeC), ref mensaje, etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                listaAlumno = dataTable.AsEnumerable().Select(row => new Alumno
                {
                    IdAlumno = row.Field<int>("ID_Alumno"),
                    Matricula = row.Field<string>("Matricula"),
                    Nombre = row.Field<string>("Nombre"),
                    ApPat = row.Field<string>("Ap_pat"),
                    ApMat = row.Field<string>("Ap_mat"),
                    Genero = row.Field<string>("Genero"),
                    Correo = row.Field<string>("Correo"),
                    Celular = row.Field<string>("Celular"),
                    FEdoCivil = row.Field<byte>("F_EdoCivil"),
                    FNivel = row.Field<byte>("F_Nivel"),

                }).ToList();

            }

            return listaAlumno;

        }


    }
}
