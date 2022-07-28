using Acceso_a_Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica_de_Negocios
{
    public class DLL
    {
        private DAL DAL = null;

        public DLL(string connection)
        {
            DAL = new DAL(connection);
        }

        public DataTable tablaProfesoresServer(ref string mensaje, ref string mensajeC)
        {
            string comandoMySql = "select * from Alumno;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;


            dataSet = DAL.LecturaSet(comandoMySql, DAL.ConnectionEstablecida(ref mensajeC), ref mensaje, etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];


            }
            return dataTable;
        }

        //public List<Alumno> ListaAlumno(ref string mensaje, ref string mensajeC)
        //{
        //    string comandoMySql = "select * from Alumno;", etiqueta = "SeguimientoCovid";
        //    DataSet dataSet = null;
        //    DataTable dataTable = null;

        //    List<Alumno> listaAlumno = new List<Alumno>();

        //    dataSet = DAL.LecturaSet(comandoMySql, DAL.ConnectionEstablecida(ref mensajeC), ref mensaje, etiqueta);
        //    if (dataSet != null)
        //    {
        //        dataTable = dataSet.Tables[0];
        //        listaAlumno = dataTable.AsEnumerable().Select(row => new Alumno
        //        {
        //            IdAlumno = row.Field<int>("ID_Alumno"),
        //            Matricula = row.Field<string>("Matricula"),
        //            Nombre = row.Field<string>("Nombre"),
        //            ApPat = row.Field<string>("Ap_pat"),
        //            ApMat = row.Field<string>("Ap_mat"),
        //            Genero = row.Field<string>("Genero"),
        //            Correo = row.Field<string>("Correo"),
        //            Celular = row.Field<string>("Celular"),
        //            FEdoCivil = row.Field<byte>("F_EdoCivil"),
        //            FNivel = row.Field<byte>("F_Nivel"),

        //        }).ToList();

        //    }

        //    return listaAlumno;

        //}

        public List<Alumno> ListaAlumno(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaAlumno(ref mensaje,ref mensajeC);
        }
    }
}
