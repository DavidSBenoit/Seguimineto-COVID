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

        public string BaseSegura(string Sqlinstruc, SqlConnection prAb, SqlParameter[] evaluacion)
        {
            string resp = "";
            SqlCommand comando = null;

            if (prAb != null)
            {
                using (comando = new SqlCommand())
                {
                    comando.CommandText = Sqlinstruc;
                    comando.Connection = prAb;
                    foreach (SqlParameter x in evaluacion)
                    {
                        comando.Parameters.Add(x);
                    }
                    try
                    {
                        comando.ExecuteNonQuery();
                        resp = "Inyección Ejecutada";
                    }
                    catch (Exception h)
                    {
                        resp = "Error: "+ h;
                    }
                }
                prAb.Close();
                prAb.Dispose();
            }
            else
            {
                resp = "Error";
            }
            return resp;
        }

        public Boolean BaseSeguraSinParametros(string Sqlinstruc, SqlConnection prAb, ref string mensaje)
        {
            Boolean resp = false;
            SqlCommand comando = null;

            if (prAb != null)
            {
                mensaje = "";
                using (comando = new SqlCommand())
                {
                    comando.CommandText = Sqlinstruc;
                    comando.Connection = prAb;
                    try
                    {
                        comando.ExecuteNonQuery();
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

        public string AgregarAlumno(Alumno alumno)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO Alumno(Matricula, Nombre, Ap_pat, Ap_Mat, Genero, Correo, Celular, F_EdoCivil, F_Nivel)" +
                "values (@Matricula, @Nombre, @Ap_pat, @Ap_Mat, @Genero, @Correo, @Celular, @F_EdoCivil, @F_Nivel);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@Matricula", SqlDbType.VarChar, 20),
                new SqlParameter("@Nombre", SqlDbType.VarChar, 150),
                new SqlParameter("@Ap_pat", SqlDbType.VarChar, 100),
                new SqlParameter("@Ap_Mat", SqlDbType.VarChar, 100),
                new SqlParameter("@Genero", SqlDbType.VarChar, 10),
                new SqlParameter("@Correo", SqlDbType.VarChar, 200),
                new SqlParameter("@Celular", SqlDbType.VarChar, 20),
                new SqlParameter("@F_EdoCivil", SqlDbType.TinyInt),
                new SqlParameter("@F_Nivel", SqlDbType.TinyInt)
            };
            evaluacion[0].Value = alumno.Matricula;
            evaluacion[1].Value = alumno.Nombre;
            evaluacion[2].Value = alumno.ApPat;
            evaluacion[3].Value = alumno.ApMat;
            evaluacion[4].Value = alumno.Genero;
            evaluacion[5].Value = alumno.Correo;
            evaluacion[6].Value = alumno.Celular;
            evaluacion[7].Value = Convert.ToInt32(alumno.FEdoCivil);
            evaluacion[8].Value = Convert.ToInt32(alumno.FNivel);

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_AlumnoGrupo(AlumnoGrupo AG)
        {
            String respuesta = "";

            string instruccion = "INSERT INTO AlumnoGrupo(F_Alumn, F_GruCuat, Extra, Extra2)" +
                "values (@F_Alumn, @F_GruCuat, @Extra, @Extra2);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@F_Alumn", SqlDbType.Int),
                new SqlParameter("@F_GruCuat", SqlDbType.Int),
                new SqlParameter("@Extra", SqlDbType.VarChar, 50),
                new SqlParameter("@Extra2", SqlDbType.VarChar, 50),
                
            };
            evaluacion[0].Value = Convert.ToInt32(AG.FAlumn);
            evaluacion[1].Value = Convert.ToInt32(AG.FGruCuat);
            evaluacion[2].Value = AG.Extra;
            evaluacion[3].Value = AG.Extra2;
            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_Carrera(Carrera carrera)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO Carrera(nombreCarrera)" +
                "values (@nombreCarrera);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@nombreCarrea", SqlDbType.NChar, 100)
                
            };
            evaluacion[0].Value = carrera.NombreCarrera;

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_Cuatrimestre(Cuatrimestre cuatrimestre)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO Cuatrimestre(Periodo, Anio, Inicio, Fin, Extra)" +
                "values (@Periodo, @Anio, @Inicio, @Fin, @Extra);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@Periodo", SqlDbType.VarChar, 30),
                new SqlParameter("@Anio", SqlDbType.Int),
                new SqlParameter("@Inicio", SqlDbType.Date),
                new SqlParameter("@Fin", SqlDbType.Date),
                new SqlParameter("@Extra", SqlDbType.VarChar, 50),
                
            };
            evaluacion[0].Value = cuatrimestre.Periodo;
            evaluacion[1].Value = cuatrimestre.Anio;
            evaluacion[2].Value = Convert.ToDateTime(cuatrimestre.Inicio);
            evaluacion[3].Value = Convert.ToDateTime(cuatrimestre.Fin);
            evaluacion[4].Value = cuatrimestre.Extra;

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_EstadoCivil(EstadoCivil estadoCivil)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO EstadoCivil(Estado, Extra)" +
                "values (@Estado, @Extra);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@Estado", SqlDbType.VarChar, 50),
                new SqlParameter("@Extra", SqlDbType.VarChar, 50),
              
            };
            evaluacion[0].Value = estadoCivil.Estado;
            evaluacion[1].Value = estadoCivil.Extra;
            

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_Grupo(Grupo grupo)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO Grupo(Grado, Letra, Extra)" +
                "values (@Grado, @Letra, @Extra);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@Grado", SqlDbType.TinyInt),
                new SqlParameter("@Letra", SqlDbType.VarChar, 1),
                new SqlParameter("@Extra", SqlDbType.VarChar, 50),
                

            };
            evaluacion[0].Value = Convert.ToInt32(grupo.Grado);
            evaluacion[1].Value = grupo.Letra;
            evaluacion[2].Value = grupo.Extra;
            

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_Grupo_Cuatrimestre(GrupoCuatrimestre grupoCuatrimestre)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO GrupoCuatrimestre(F_ProgEd, F_Grupo, F_Cuatri, Turno, Modalidad, Extra)" +
                "values (@F_ProgEd, @F_Grupo, @F_Cuatri, @Turno, @Modalidad, @Extra);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@F_ProgEd", SqlDbType.TinyInt),
                new SqlParameter("@F_Grupo", SqlDbType.SmallInt),
                new SqlParameter("@F_Cuatri", SqlDbType.SmallInt),
                new SqlParameter("@Turno", SqlDbType.VarChar, 50),
                new SqlParameter("@Modalidad", SqlDbType.VarChar, 50),
                new SqlParameter("@Extra", SqlDbType.VarChar, 50),


            };
            evaluacion[0].Value = Convert.ToInt32(grupoCuatrimestre.FProgEd);
            evaluacion[1].Value = Convert.ToInt32(grupoCuatrimestre.FGrupo);
            evaluacion[2].Value = Convert.ToInt32(grupoCuatrimestre.FCuatri);
            evaluacion[3].Value = grupoCuatrimestre.Turno;
            evaluacion[4].Value = grupoCuatrimestre.Modalidad;
            evaluacion[5].Value = grupoCuatrimestre.Extra;


            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_Incapacidades(Incapacidades incapacidad)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO Incapacidades(Formato, fecha_inicio, fecha_final, Id_posProfe)" +
                "values (@Formato, @fecha_inicio, @fecha_final, @Id_posProfe);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@Formato", SqlDbType.VarChar, 100),
                new SqlParameter("@fecha_inicio", SqlDbType.DateTime),
                new SqlParameter("@fecha_final", SqlDbType.DateTime),
                new SqlParameter("@Id_posProfe", SqlDbType.Int),
                


            };
            evaluacion[0].Value = incapacidad.Formato;
            evaluacion[1].Value = incapacidad.FechaInicio;
            evaluacion[2].Value = incapacidad.FechaFinal;
            evaluacion[3].Value = incapacidad.IdPosProfe;
            
            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_Medico(Medico medico)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO Medico(Nombre, App, Apm, Telefono, correo, horario, especialidad, extra)" +
                "values (@Nombre, @App, @Apm, @Telefono, @correo, @horario, @especialidad, @extra);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@Nombre", SqlDbType.VarChar, 150),
                new SqlParameter("@App", SqlDbType.VarChar, 100),
                new SqlParameter("@Apm", SqlDbType.VarChar, 100),
                new SqlParameter("@Telefono", SqlDbType.VarChar, 20),
                new SqlParameter("@correo", SqlDbType.VarChar, 150),
                new SqlParameter("@horario", SqlDbType.VarChar, 50),
                new SqlParameter("@especialidad", SqlDbType.VarChar, 150),
                new SqlParameter("@extra", SqlDbType.VarChar, 150)



            };

            evaluacion[0].Value = medico.Nombre;
            evaluacion[1].Value = medico.App;
            evaluacion[2].Value = medico.Apm;
            evaluacion[3].Value = medico.Telefono;
            evaluacion[4].Value = medico.Correo;
            evaluacion[5].Value = medico.Horario;
            evaluacion[6].Value = medico.Especialidad;
            evaluacion[7].Value = medico.Extra;

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_PositivoAlumno(PositivoAlumno posal)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO PositivoAlumno(FechaConfirmado, Comprobacion, Antecedentes, Riesgo, NumContagio, Extra, F_Alumno)" +
                "values (@FechaConfirmado, @Comprobacion, @Antecedentes, @Riesgo, @NumContagio, @Extra, @F_Alumno);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@FechaConfirmado", SqlDbType.Date),
                new SqlParameter("@Comprobacion", SqlDbType.VarChar, 200),
                new SqlParameter("@Antecedentes", SqlDbType.VarChar, 200),
                new SqlParameter("@Riesgo", SqlDbType.VarChar, 100),
                new SqlParameter("@NumContagio", SqlDbType.TinyInt),
                new SqlParameter("@Extra", SqlDbType.VarChar, 150),
                new SqlParameter("@F_Alumno", SqlDbType.Int),
            };

            evaluacion[0].Value = Convert.ToDateTime(posal.FechaConfirmado);
            evaluacion[1].Value = posal.Comprobacion;
            evaluacion[2].Value = posal.Antecedentes;
            evaluacion[3].Value = posal.Riesgo;
            evaluacion[4].Value = Convert.ToInt32(posal.NumContagio);
            evaluacion[5].Value = posal.Extra;
            evaluacion[6].Value = Convert.ToInt32(posal.FAlumno);

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_PositivoProfe(PositivoProfe pospro)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO PositivoProfe(FechaConfirmado, Comprobacion, Antecedentes, Riesgo, NumContaio, Extra, F_Profe)" +
                "values (@FechaConfirmado, @Comprobacion, @Antecedentes, @Riesgo, @NumContaio, @Extra, @F_Profe);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@FechaConfirmado", SqlDbType.Date),
                new SqlParameter("@Comprobacion", SqlDbType.VarChar, 200),
                new SqlParameter("@Antecedentes", SqlDbType.VarChar, 200),
                new SqlParameter("@Riesgo", SqlDbType.VarChar, 100),
                new SqlParameter("@NumContaio", SqlDbType.TinyInt),
                new SqlParameter("@Extra", SqlDbType.VarChar, 150),
                new SqlParameter("@F_Profe", SqlDbType.Int),
            };

            evaluacion[0].Value = Convert.ToDateTime(pospro.FechaConfirmado);
            evaluacion[1].Value = pospro.Comprobacion;
            evaluacion[2].Value = pospro.Antecedentes;
            evaluacion[3].Value = pospro.Riesgo;
            evaluacion[4].Value = Convert.ToInt32(pospro.NumContaio);
            evaluacion[5].Value = pospro.Extra;
            evaluacion[6].Value = Convert.ToInt32(pospro.FProfe);

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_ProfeGrupo(ProfeGrupo profeGrupo)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO ProfeGRupo(F_Profe, F_GruCuat, Extra, Extra2)" +
                "values (@F_Profe, @F_GruCuat, @Extra, @Extra2);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@F_Profe", SqlDbType.Int),
                new SqlParameter("@F_GruCuat", SqlDbType.Int),
                new SqlParameter("@Extra", SqlDbType.VarChar, 50),
                new SqlParameter("@Extra2", SqlDbType.VarChar, 50),
            };

            evaluacion[0].Value = Convert.ToInt32(profeGrupo.FProfe);
            evaluacion[1].Value = Convert.ToInt32(profeGrupo.FGruCuat);
            evaluacion[2].Value = profeGrupo.Extra;
            evaluacion[3].Value = profeGrupo.Extra2;

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_Profesor(Profesor profesor)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO Profesor(RegistroEmpleado, Nombre, Ap_pat, Ap_mat, Genero, Categoria, Correo, Celular, F_EdoCivil)" +
                "values (@RegistroEmpleado, @Nombre, @Ap_pat, @Ap_mat, @Genero, @Categoria, @Correo, @Celular, @F_EdoCivil);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@RegistroEmpleado", SqlDbType.Int),
                new SqlParameter("@Nombre", SqlDbType.VarChar, 150),
                new SqlParameter("@Ap_pat", SqlDbType.VarChar, 100),
                new SqlParameter("@Ap_mat", SqlDbType.VarChar, 100),
                new SqlParameter("@Genero", SqlDbType.VarChar, 10),
                new SqlParameter("@Categoria", SqlDbType.VarChar, 5),
                new SqlParameter("@Correo", SqlDbType.VarChar, 200),
                new SqlParameter("@Celular", SqlDbType.VarChar, 20),
                new SqlParameter("@F_EdoCivil", SqlDbType.Int),
            };

            evaluacion[0].Value = profesor.RegistroEmpleado;
            evaluacion[1].Value = profesor.Nombre;
            evaluacion[2].Value = profesor.ApPat;
            evaluacion[3].Value = profesor.ApMat;
            evaluacion[4].Value = profesor.Genero;
            evaluacion[5].Value = profesor.Categoria;
            evaluacion[6].Value = profesor.Correo;
            evaluacion[7].Value = profesor.Celular;
            evaluacion[8].Value = profesor.FEdoCivil;

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_ProgramaEducativo(ProgramaEducativo programaEducativo)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO ProgramaEducativo(ProgramaEd, F_Carrera, Extra)" +
                "values (@ProgramaEd, @F_Carrera, @Extra);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@ProgramaEd", SqlDbType.VarChar, 150),
                new SqlParameter("@F_Carrera", SqlDbType.Int),
                new SqlParameter("@Extra", SqlDbType.VarChar, 50)
            };

            evaluacion[0].Value = programaEducativo.ProgramaEd;
            evaluacion[1].Value = programaEducativo.FCarrera;
            evaluacion[2].Value = programaEducativo.Extra;
            
            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_SeguimientoAl(SeguimientoAl seguimientoAl)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO SeguimientoAL(F_PositivoAL, F_medico, Fecha, Form_Comunica, Reporte, Entrevista, Extra)" +
                "values (@F_PositivoAL, @F_medico, @Fecha, @Form_Comunica, @Reporte, @Entrevista, @Extra);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@F_PositivoAL", SqlDbType.Int),
                new SqlParameter("@F_medico", SqlDbType.Int),
                new SqlParameter("@Fecha", SqlDbType.Date),
                new SqlParameter("@Form_Comunica", SqlDbType.VarChar, 50),
                new SqlParameter("@Reporte", SqlDbType.VarChar, 250),
                new SqlParameter("@Entrevista", SqlDbType.VarChar, 200),
                new SqlParameter("@Extra", SqlDbType.VarChar, 150)
            };

            evaluacion[0].Value = seguimientoAl.FPositivoAl;
            evaluacion[1].Value = seguimientoAl.FMedico;
            evaluacion[2].Value = seguimientoAl.Fecha;
            evaluacion[3].Value = seguimientoAl.FormComunica;
            evaluacion[4].Value = seguimientoAl.Reporte;
            evaluacion[5].Value = seguimientoAl.Entrevista;
            evaluacion[6].Value = seguimientoAl.Extra;

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        public string Agregar_SeguimientoPRO(SeguimientoPro seguimientoPro)
        {
            string respuesta = "";

            string instruccion = "INSERT INTO SeguimientoPro(F_PositivoProfe, F_medico, Fecha, Form_Comunica, Reporte, Entrevista, Extra)" +
                "values (@F_PositivoProfe, @F_medico, @Fecha, @Form_Comunica, @Reporte, @Entrevista, @Extra);";
            SqlParameter[] evaluacion = new SqlParameter[]
            {
                new SqlParameter("@F_PositivoProfe", SqlDbType.Int),
                new SqlParameter("@F_medico", SqlDbType.Int),
                new SqlParameter("@Fecha", SqlDbType.Date),
                new SqlParameter("@Form_Comunica", SqlDbType.VarChar, 50),
                new SqlParameter("@Reporte", SqlDbType.VarChar, 250),
                new SqlParameter("@Entrevista", SqlDbType.VarChar, 200),
                new SqlParameter("@Extra", SqlDbType.VarChar, 150)
            };

            evaluacion[0].Value = seguimientoPro.FPositivoProfe;
            evaluacion[1].Value = seguimientoPro.FMedico;
            evaluacion[2].Value = seguimientoPro.Fecha;
            evaluacion[3].Value = seguimientoPro.FormComunica;
            evaluacion[4].Value = seguimientoPro.Reporte;
            evaluacion[5].Value = seguimientoPro.Entrevista;
            evaluacion[6].Value = seguimientoPro.Extra;

            respuesta = BaseSegura(instruccion, ConnectionEstablecida(), evaluacion);

            return respuesta;
        }

        #endregion

        #region Update
        #endregion

        #region Delete
        #endregion


    }
}
