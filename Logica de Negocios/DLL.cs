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
            string resp = "";
            try
            {
                DAL.AgregarAlumno(alumno);
                resp = "Elumno Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar Alumno";
            }

            return resp;
        }

        public string Agregar_AlumnoGrupo(AlumnoGrupo AG)
        {
            string resp = "";
            try
            {
                DAL.Agregar_AlumnoGrupo(AG);
                resp = "AlumnoGrupo Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar AlumnoGrupo";
            }

            return resp;
        }

        public string Agregar_Carrera(Carrera carrera)
        {
            string resp = "";
            try
            {
                DAL.Agregar_Carrera(carrera);
                resp = "Carrera Insertada Correctamente";
            }
            catch
            {
                resp = "Error al insertar Carrera";
            }

            return resp;
        }

        public string Agregar_Cuatrimestre(Cuatrimestre cuatrimestre)
        {
            string resp = "";
            try
            {
                DAL.Agregar_Cuatrimestre(cuatrimestre);
                resp = "cuatrimestre Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar cuatrimestre";
            }

            return resp;
        }

        public string Agregar_EstadoCivil(EstadoCivil estadoCivil)
        {
            string resp = "";
            try
            {
                DAL.Agregar_EstadoCivil(estadoCivil);
                resp = "Estado Civil Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar Estado Civil";
            }

            return resp;
        }

        public string Agregar_Grupo(Grupo grupo)
        {
            string resp = "";
            try
            {
                DAL.Agregar_Grupo(grupo);
                resp = "Grupo Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar Grupo";
            }

            return resp;
        }

        public string Agregar_Grupo_Cuatrimestre(GrupoCuatrimestre grupoCuatrimestre)
        {
            string resp = "";
            try
            {
                DAL.Agregar_Grupo_Cuatrimestre(grupoCuatrimestre);
                resp = "grupoCuatrimestre Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar grupoCuatrimestre";
            }

            return resp;
        }

        public string Agregar_Incapacidades(Incapacidades incapacidad)
        {
            string resp = "";
            try
            {
                DAL.Agregar_Incapacidades(incapacidad);
                resp = "incapacidad Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar incapacidad";
            }

            return resp;
        }

        public string Agregar_Medico(Medico medico)
        {
            string resp = "";
            try
            {
                DAL.Agregar_Medico(medico);
                resp = "medico Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar medico";
            }

            return resp;
        }

        public string Agregar_PositivoAlumno(PositivoAlumno posal)
        {
            string resp = "";
            try
            {
                DAL.Agregar_PositivoAlumno(posal);
                resp = "posal Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar posal";
            }

            return resp;
        }

        public string Agregar_PositivoProfe(PositivoProfe pospro)
        {
            string resp = "";
            try
            {
                DAL.Agregar_PositivoProfe(pospro);
                resp = "pospro Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar pospro";
            }

            return resp;
        }

        public string Agregar_ProfeGrupo(ProfeGrupo profeGrupo)
        {
            string resp = "";
            try
            {
                DAL.Agregar_ProfeGrupo(profeGrupo);
                resp = "profeGrupo Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar profeGrupo";
            }

            return resp;
        }

        public string Agregar_Profesor(Profesor profesor)
        {
            string resp = "";
            try
            {
                DAL.Agregar_Profesor(profesor);
                resp = "profesor Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar profesor";
            }

            return resp;
        }

        public string Agregar_ProgramaEducativo(ProgramaEducativo programaEducativo)
        {
            string resp = "";
            try
            {
                DAL.Agregar_ProgramaEducativo(programaEducativo);
                resp = "programaEducativo Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar programaEducativo";
            }

            return resp;
        }

        public string Agregar_SeguimientoAl(SeguimientoAl seguimientoAl)
        {
            string resp = "";
            try
            {
                DAL.Agregar_SeguimientoAl(seguimientoAl);
                resp = "seguimientoAl Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar seguimientoAl";
            }

            return resp;
        }

        public string Agregar_SeguimientoPRO(SeguimientoPro seguimientoPro)
        {
            string resp = "";
            try
            {
                DAL.Agregar_SeguimientoPRO(seguimientoPro);
                resp = "seguimientoPro Insertado Correctamente";
            }
            catch
            {
                resp = "Error al insertar seguimientoPro";
            }

            return resp;
        }

        #endregion

    }
}
