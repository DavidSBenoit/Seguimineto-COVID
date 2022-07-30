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

        #region Create
        
        public string AgregarAlumno(Alumno alumno)
        {
            return DAL.AgregarAlumno(alumno);
        }

        public string Agregar_AlumnoGrupo(AlumnoGrupo AG)
        {
            return DAL.Agregar_AlumnoGrupo(AG);
        }

        public string Agregar_Carrera(Carrera carrera)
        {
            return DAL.Agregar_Carrera(carrera);
        }

        public string Agregar_Cuatrimestre(Cuatrimestre cuatrimestre)
        {
            return DAL.Agregar_Cuatrimestre(cuatrimestre);
        }

        public string Agregar_EstadoCivil(EstadoCivil estadoCivil)
        {
            return DAL.Agregar_EstadoCivil(estadoCivil);
        }

        public string Agregar_Grupo(Grupo grupo)
        {
            return DAL.Agregar_Grupo(grupo);
        }

        public string Agregar_Grupo_Cuatrimestre(GrupoCuatrimestre grupoCuatrimestre)
        {
            return DAL.Agregar_Grupo_Cuatrimestre(grupoCuatrimestre);
        }

        public string Agregar_Incapacidades(Incapacidades incapacidad)
        {
            return DAL.Agregar_Incapacidades(incapacidad);
        }

        public string Agregar_Medico(Medico medico)
        {
            return DAL.Agregar_Medico(medico);
        }

        public string Agregar_PositivoAlumno(PositivoAlumno posal)
        {
            return DAL.Agregar_PositivoAlumno(posal);
        }

        public string Agregar_PositivoProfe(PositivoProfe pospro)
        {
            return DAL.Agregar_PositivoProfe(pospro);
        }

        public string Agregar_ProfeGrupo(ProfeGrupo profeGrupo)
        {
            return DAL.Agregar_ProfeGrupo(profeGrupo);
        }

        public string Agregar_Profesor(Profesor profesor)
        {
            return DAL.Agregar_Profesor(profesor);
        }

        public string Agregar_ProgramaEducativo(ProgramaEducativo programaEducativo)
        {
            return DAL.Agregar_ProgramaEducativo(programaEducativo);
        }

        public string Agregar_SeguimientoAl(SeguimientoAl seguimientoAl)
        {
            return DAL.Agregar_SeguimientoAl(seguimientoAl);
        }

        public string Agregar_SeguimientoPRO(SeguimientoPro seguimientoPro)
        {
            return DAL.Agregar_SeguimientoPRO(seguimientoPro);
        }

        #endregion

        #region Update

        public string ActualizarAlumno(Alumno alumno, int ID)
        {
            return DAL.ActualizarAlumno(alumno, ID);
        }

        public string Actualizar_GrupoAlumno(AlumnoGrupo alumnoGrupo, int ID)
        {
            return DAL.Actualizar_GrupoAlumno(alumnoGrupo, ID);
        }

        public string Actualizar_Carrera(Carrera carrera, int ID)
        {
            return DAL.Actualizar_Carrera(carrera, ID);
        }

        public string Actualizar_Cuatrimestre(Cuatrimestre cuatrimestre, int ID)
        {
            return DAL.Actualizar_Cuatrimestre(cuatrimestre, ID);
        }

        public string Actualizar_EstadoCivil(EstadoCivil estadoCivil, int ID) 
        {
            return DAL.Actualizar_EstadoCivil(estadoCivil, ID);
        }

        public string Actualizar_Grupo(Grupo grupo, int ID)
        {
            return DAL.Actualizar_Grupo(grupo, ID);
        }

        public string Actualizar_Grupo_Cuatrimestre(GrupoCuatrimestre grupoCuatrimestre, int ID)
        {
            return DAL.Actualizar_Grupo_Cuatrimestre(grupoCuatrimestre, ID);
        }

        public string Actualizar_Incapacidades(Incapacidades incapacidad, int ID)
        {
            return DAL.Actualizar_Incapacidades(incapacidad, ID);
        }

        public string Actualizar_Medico(Medico medico, int ID)
        {
            return DAL.Actualizar_Medico(medico, ID);
        }

        public string Actualizar_PositivoAlumno(PositivoAlumno posal, int ID)
        {
            return DAL.Actualizar_PositivoAlumno(posal, ID);
        }

        public string Actualizar_PositivoProfe(PositivoProfe pospro, int ID)
        {
            return DAL.Actualizar_PositivoProfe(pospro, ID);
        }

        public string Actualizar_ProfeGrupo(ProfeGrupo profeGrupo, int ID)
        {
            return DAL.Actualizar_ProfeGrupo(profeGrupo, ID);
        }

        public string Actualizar_Profesor(Profesor profesor, int ID)
        {
            return DAL.Actualizar_Profesor(profesor, ID);
        }

        public string Actualizar_ProgramaEducativo(ProgramaEducativo programaEducativo, int ID)
        {
            return DAL.Actualizar_ProgramaEducativo(programaEducativo, ID);
        }

        public string Actualizar_SeguimientoAl(SeguimientoAl seguimientoAl, int ID)
        {
            return DAL.Actualizar_SeguimientoAl(seguimientoAl, ID);
        }

        public string Actualizar_SeguimientoPRO(SeguimientoPro seguimientoPro, int ID)
        {
            return DAL.Actualizar_SeguimientoPRO(seguimientoPro, ID);
        }
        #endregion

    }
}
