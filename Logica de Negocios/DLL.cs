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

        //public DataTable tablaProfesoresServer(ref string mensaje, ref string mensajeC)
        //{
        //    string comandoMySql = "select * from Alumno;", etiqueta = "SeguimientoCovid";
        //    DataSet dataSet = null;
        //    DataTable dataTable = null;


        //    dataSet = DAL.LecturaSet(comandoMySql, DAL.ConnectionEstablecida(ref mensajeC), ref mensaje, etiqueta);
        //    if (dataSet != null)
        //    {
        //        dataTable = dataSet.Tables[0];


        //    }
        //    return dataTable;
        //}

        #region Consultas
        public List<Alumno> ListaAlumno(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaAlumno(ref mensaje, ref mensajeC);
        }

        public List<AlumnoGrupo> ListaAlumnoGrupo(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaAlumnoGrupo(ref mensaje, ref mensajeC);
        }

        public List<Carrera> ListaCarrera(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaCarrera(ref mensaje, ref mensajeC);
        }
        
        public List<Cuatrimestre> ListaCuatrimestre(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaCuatrimestre(ref mensaje, ref mensajeC);
        }
        
        public List<EstadoCivil> ListaEstadoCivil(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaEstadoCivil(ref mensaje, ref mensajeC);
        }
        
        public List<Grupo> ListaGrupo(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaGrupo(ref mensaje, ref mensajeC);
        }
        
        public List<GrupoCuatrimestre> ListaGrupoCuatrimestre(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaGrupoCuatrimestre(ref mensaje, ref mensajeC);
        }
        
        public List<Incapacidades> ListaIncapacidades(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaIncapacidades(ref mensaje, ref mensajeC);
        }
        
        public List<Medico> ListaMedico(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaMedico(ref mensaje, ref mensajeC);
        }
        
        public List<PositivoAlumno> ListaPositivoAlumno(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaPositivoAlumno(ref mensaje, ref mensajeC);
        }
        
        public List<PositivoProfe> ListaPositivoProfe(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaPositivoProfe(ref mensaje, ref mensajeC);
        }
        
        public List<ProfeGrupo> ListaProfeGrupo(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaProfeGrupo(ref mensaje, ref mensajeC);
        }
        
        public List<Profesor> ListaProfesor(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaProfesor(ref mensaje, ref mensajeC);
        }
        
        public List<ProgramaEducativo> ListaProgramaEducativo(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaProgramaEducativo(ref mensaje, ref mensajeC);
        }
        
        public List<SeguimientoPro> ListaSeguimientoPro(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaSeguimientoPro(ref mensaje, ref mensajeC);
        }
        
        public List<SeguimientoAl> ListaSeguimientoAl(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaSeguimientoAl(ref mensaje, ref mensajeC);
        }

        #endregion

    }
}
