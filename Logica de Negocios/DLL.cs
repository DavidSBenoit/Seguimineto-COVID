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
            return DAL.ListaAlumno();
        }

        public List<AlumnoGrupo> ListaAlumnoGrupo(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaAlumnoGrupo();
        }

        public List<Carrera> ListaCarrera(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaCarrera();
        }
        
        public List<Cuatrimestre> ListaCuatrimestre(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaCuatrimestre();
        }
        
        public List<EstadoCivil> ListaEstadoCivil(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaEstadoCivil();
        }
        
        public List<Grupo> ListaGrupo(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaGrupo();
        }
        
        public List<GrupoCuatrimestre> ListaGrupoCuatrimestre(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaGrupoCuatrimestre();
        }
        
        public List<Incapacidades> ListaIncapacidades(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaIncapacidades();
        }
        
        public List<Medico> ListaMedico(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaMedico();
        }
        
        public List<PositivoAlumno> ListaPositivoAlumno(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaPositivoAlumno();
        }
        
        public List<PositivoProfe> ListaPositivoProfe(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaPositivoProfe();
        }
        
        public List<ProfeGrupo> ListaProfeGrupo(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaProfeGrupo();
        }
        
        public List<Profesor> ListaProfesor(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaProfesor();
        }
        
        public List<ProgramaEducativo> ListaProgramaEducativo(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaProgramaEducativo();
        }
        
        public List<SeguimientoPro> ListaSeguimientoPro(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaSeguimientoPro();
        }
        
        public List<SeguimientoAl> ListaSeguimientoAl(ref string mensaje, ref string mensajeC)
        {
            return DAL.ListaSeguimientoAl();
        }

        #endregion

    }
}
