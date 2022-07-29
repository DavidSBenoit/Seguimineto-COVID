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

        #region Conexion

        public SqlConnection ConnectionEstablecida()
        {
            SqlConnection puerto = new SqlConnection();
            puerto.ConnectionString = cableConn;
            try
            {
                puerto.Open();
            }
            catch (Exception e)
            {
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
        public DataSet LecturaSet(string comandoMySql, SqlConnection conAbierta, string etiqueta)
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
                        }
                        catch (Exception e)
                        {
                            dataSet = null;
                        }
                    }
                }
            }
            return dataSet;
        }
        #endregion

        #region Consultas

        public List<Alumno> ListaAlumno()
        {
            string comandoMySql = "select * from Alumno;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Alumno> listaAlumno = new List<Alumno>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
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

        public List<AlumnoGrupo> ListaAlumnoGrupo()
        {
            string comandoMySql = "select * from AlumnoGrupo;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<AlumnoGrupo> listaAlumnoGrupo = new List<AlumnoGrupo>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                listaAlumnoGrupo = dataTable.AsEnumerable().Select(row => new AlumnoGrupo
                {
                    IdAlumnGru = row.Field<int>("ID_AlumnGru"),
                    FAlumn = row.Field<int>("F_Alumn"),
                    FGruCuat = row.Field<int>("F_GruCuat"),
                    Extra = row.Field<string>("Extra"),
                    Extra2 = row.Field<string>("Extra2"),

                }).ToList();

            }

            return listaAlumnoGrupo;

        }

        public List<Carrera> ListaCarrera()
        {
            string comandoMySql = "select * from Carrera;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Carrera> listaCarrera = new List<Carrera>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                listaCarrera = dataTable.AsEnumerable().Select(row => new Carrera
                {
                    IdCarrera = row.Field<int>("Id_Carrera"),
                    NombreCarrera = row.Field<string>("nombreCarrera")

                }).ToList();

            }

            return listaCarrera;

        }

        public List<Cuatrimestre> ListaCuatrimestre()
        {
            string comandoMySql = "select * from Cuatrimestre;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Cuatrimestre> lista_Cuatrimestre = new List<Cuatrimestre>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_Cuatrimestre = dataTable.AsEnumerable().Select(row => new Cuatrimestre
                {
                    IdCuatrimestre = row.Field<short>("id_Cuatrimestre"),
                    Periodo = row.Field<string>("Periodo"),
                    Anio = row.Field<int>("Anio"),
                    Inicio = row.Field<DateTime>("Inicio"),
                    Fin = row.Field<DateTime>("Fin"),
                    Extra = row.Field<string>("Extra"),

                }).ToList();

            }

            return lista_Cuatrimestre;

        }

        public List<EstadoCivil> ListaEstadoCivil()
        {
            string comandoMySql = "select * from EstadoCivil;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<EstadoCivil> lista_EstadoCivil = new List<EstadoCivil>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_EstadoCivil = dataTable.AsEnumerable().Select(row => new EstadoCivil
                {
                    IdEdo = row.Field<byte>("Id_Edo"),
                    Estado = row.Field<string>("Estado"),
                    Extra = row.Field<string>("Extra"),

                }).ToList();

            }

            return lista_EstadoCivil;

        }

        public List<Grupo> ListaGrupo()
        {
            string comandoMySql = "select * from Grupo;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Grupo> listaGrupo = new List<Grupo>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                listaGrupo = dataTable.AsEnumerable().Select(row => new Grupo
                {
                    IdGrupo = row.Field<short>("Id_grupo"),
                    Grado = row.Field<byte>("Grado"),
                    Letra = row.Field<string>("Letra"),
                    Extra = row.Field<string>("extra"),

                }).ToList();

            }

            return listaGrupo;

        }

        public List<GrupoCuatrimestre> ListaGrupoCuatrimestre()
        {
            string comandoMySql = "select * from GrupoCuatrimestre;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<GrupoCuatrimestre> lista_GrupoCuatrimestre = new List<GrupoCuatrimestre>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_GrupoCuatrimestre = dataTable.AsEnumerable().Select(row => new GrupoCuatrimestre
                {
                    IdGruCuat = row.Field<int>("Id_GruCuat"),
                    FProgEd = row.Field<byte>("F_ProgEd"),
                    FGrupo = row.Field<short>("F_Grupo"),
                    FCuatri = row.Field<short>("F_Cuatri"),
                    Turno = row.Field<string>("Turno"),
                    Modalidad = row.Field<string>("Modalidad"),
                    Extra = row.Field<string>("Extra")

                }).ToList();

            }

            return lista_GrupoCuatrimestre;

        }

        public List<Incapacidades> ListaIncapacidades()
        {
            string comandoMySql = "select * from Incapacidades;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Incapacidades> lista_Incapacidades = new List<Incapacidades>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_Incapacidades = dataTable.AsEnumerable().Select(row => new Incapacidades
                {
                    IdIncapacidad = row.Field<int>("Id_Incapacidad"),
                    Formato = row.Field<string>("Formato"),
                    FechaInicio = row.Field<DateTime>("fecha_Inicio"),
                    FechaFinal = row.Field<DateTime>("fecha_final"),
                    IdPosProfe = row.Field<int>("Id_posProfe"),

                }).ToList();

            }

            return lista_Incapacidades;

        }

        public List<Medico> ListaMedico()
        {
            string comandoMySql = "select * from Medico;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Medico> lista_Medico = new List<Medico>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_Medico = dataTable.AsEnumerable().Select(row => new Medico
                {
                    IdDr = row.Field<int>("ID_Dr"),
                    Nombre = row.Field<string>("Nombre"),
                    App = row.Field<string>("App"),
                    Apm = row.Field<string>("Apm"),
                    Telefono = row.Field<string>("Telefono"),
                    Correo = row.Field<string>("correo"),
                    Horario = row.Field<string>("horario"),
                    Especialidad = row.Field<string>("especialidad"),
                    Extra = row.Field<string>("extra"),

                }).ToList();

            }

            return lista_Medico;

        }

        public List<PositivoAlumno> ListaPositivoAlumno()
        {
            string comandoMySql = "select * from PositivoAlumno;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<PositivoAlumno> lista_PositivoAlumno = new List<PositivoAlumno>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_PositivoAlumno = dataTable.AsEnumerable().Select(row => new PositivoAlumno
                {
                    IdPosAl = row.Field<int>("ID_posAl"),
                    FechaConfirmado = row.Field<DateTime>("FechaConfirmado"),
                    Comprobacion = row.Field<string>("Comprobacion"),
                    Antecedentes = row.Field<string>("Antecedentes"),
                    Riesgo = row.Field<string>("Riesgo"),
                    NumContagio = row.Field<byte>("NumContagio"),
                    Extra = row.Field<string>("Extra"),
                    FAlumno = row.Field<int>("F_Alumno"),

                }).ToList();

            }

            return lista_PositivoAlumno;

        }

        public List<PositivoProfe> ListaPositivoProfe()
        {
            string comandoMySql = "select * from PositivoProfe;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<PositivoProfe> lista_PositivoProfe = new List<PositivoProfe>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_PositivoProfe = dataTable.AsEnumerable().Select(row => new PositivoProfe
                {
                    IdPosProfe = row.Field<int>("Id_posProfe"),
                    FechaConfirmado = row.Field<DateTime>("FechaConfirmado"),
                    Comprobacion = row.Field<string>("Comprobacion"),
                    Antecedentes = row.Field<string>("Antecedentes"),
                    Riesgo = row.Field<string>("Riesgo"),
                    NumContaio = row.Field<byte>("NumContaio"),
                    Extra = row.Field<string>("Extra"),
                    FProfe = row.Field<int>("F_Profe"),

                }).ToList();

            }

            return lista_PositivoProfe;

        }

        public List<ProfeGrupo> ListaProfeGrupo()
        {
            string comandoMySql = "select * from ProfeGRupo;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<ProfeGrupo> lista_ProfeGrupo = new List<ProfeGrupo>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_ProfeGrupo = dataTable.AsEnumerable().Select(row => new ProfeGrupo
                {
                    IdProfeGru = row.Field<int>("ID_ProfeGru"),
                    FProfe = row.Field<int>("F_Profe"),
                    FGruCuat = row.Field<int>("F_GruCuat"),
                    Extra = row.Field<string>("Extra"),
                    Extra2 = row.Field<string>("Extra2"),

                }).ToList();

            }

            return lista_ProfeGrupo;

        }

        public List<Profesor> ListaProfesor()
        {
            string comandoMySql = "select * from Profesor;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<Profesor> lista_Profesor = new List<Profesor>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_Profesor = dataTable.AsEnumerable().Select(row => new Profesor
                {
                    IdProfe = row.Field<int>("ID_Profe"),
                    RegistroEmpleado = row.Field<int>("RegistroEmpleado"),
                    Nombre = row.Field<string>("Nombre"),
                    ApPat = row.Field<string>("Ap_pat"),
                    ApMat = row.Field<string>("Ap_mat"),
                    Genero = row.Field<string>("Genero"),
                    Categoria = row.Field<string>("Categoria"),
                    Correo = row.Field<string>("Correo"),
                    Celular = row.Field<string>("Celular"),
                    FEdoCivil = row.Field<byte>("F_EdoCivil"),

                }).ToList();

            }

            return lista_Profesor;

        }

        public List<ProgramaEducativo> ListaProgramaEducativo()
        {
            string comandoMySql = "select * from ProgramaEducativo;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<ProgramaEducativo> lista_ProgramaEducativo = new List<ProgramaEducativo>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_ProgramaEducativo = dataTable.AsEnumerable().Select(row => new ProgramaEducativo
                {
                    IdPe = row.Field<byte>("Id_pe"),
                    ProgramaEd = row.Field<string>("ProgramaEd"),
                    FCarrera = row.Field<int>("F_Carrera"),
                    Extra = row.Field<string>("Extra")

                }).ToList();

            }

            return lista_ProgramaEducativo;

        }

        public List<SeguimientoPro> ListaSeguimientoPro()
        {
            string comandoMySql = "select * from SeguimientoPRO;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<SeguimientoPro> lista_SeguimientoPro = new List<SeguimientoPro>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_SeguimientoPro = dataTable.AsEnumerable().Select(row => new SeguimientoPro
                {
                    IdSegui = row.Field<int>("id_Segui"),
                    FPositivoProfe = row.Field<int>("F_positivoProfe"),
                    FMedico = row.Field<int>("F_medico"),
                    Fecha = row.Field<DateTime>("Fecha"),
                    FormComunica = row.Field<string>("Form_Comunica"),
                    Reporte = row.Field<string>("Reporte"),
                    Entrevista = row.Field<string>("Entrevista"),
                    Extra = row.Field<string>("Extra"),

                }).ToList();

            }

            return lista_SeguimientoPro;

        }

        public List<SeguimientoAl> ListaSeguimientoAl()
        {
            string comandoMySql = "select * from SeguimientoAL;", etiqueta = "SeguimientoCovid";
            DataSet dataSet = null;
            DataTable dataTable = null;

            List<SeguimientoAl> lista_SeguimientoAl = new List<SeguimientoAl>();

            dataSet = LecturaSet(comandoMySql, ConnectionEstablecida(), etiqueta);
            if (dataSet != null)
            {
                dataTable = dataSet.Tables[0];
                lista_SeguimientoAl = dataTable.AsEnumerable().Select(row => new SeguimientoAl
                {
                    IdSeguimiento = row.Field<int>("Id_Seguimiento"),
                    FPositivoAl = row.Field<int>("F_PositivoAL"),
                    FMedico = row.Field<int>("F_medico"),
                    Fecha = row.Field<DateTime>("Fecha"),
                    FormComunica = row.Field<string>("Form_Comunica"),
                    Reporte = row.Field<string>("Reporte"),
                    Entrevista = row.Field<string>("Entrevista"),
                    Extra = row.Field<string>("Extra"),

                }).ToList();

            }

            return lista_SeguimientoAl;

        }

        #endregion

        #region Intert

        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion


    }
}
