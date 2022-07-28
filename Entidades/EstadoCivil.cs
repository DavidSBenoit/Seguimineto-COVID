using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class EstadoCivil
    {
        public EstadoCivil()
        {
            Alumno = new HashSet<Alumno>();
            Profesor = new HashSet<Profesor>();
        }

        public int IdEdo { get; set; }
        public string Estado { get; set; }
        public string Extra { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual ICollection<Profesor> Profesor { get; set; }
    }
}
