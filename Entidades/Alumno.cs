using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Alumno
    {
        public Alumno()
        {
            AlumnoGrupo = new HashSet<AlumnoGrupo>();
            PositivoAlumno = new HashSet<PositivoAlumno>();
        }

        public int IdAlumno { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string ApPat { get; set; }
        public string ApMat { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public byte FEdoCivil { get; set; }
        public byte FNivel { get; set; }

        public virtual EstadoCivil FEdoCivilNavigation { get; set; }
        public virtual ICollection<AlumnoGrupo> AlumnoGrupo { get; set; }
        public virtual ICollection<PositivoAlumno> PositivoAlumno { get; set; }
    }
}
