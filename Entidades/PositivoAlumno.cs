using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class PositivoAlumno
    {
        public PositivoAlumno()
        {
            SeguimientoAl = new HashSet<SeguimientoAl>();
        }

        public int IdPosAl { get; set; }
        public DateTime FechaConfirmado { get; set; }
        public string Comprobacion { get; set; }
        public string Antecedentes { get; set; }
        public string Riesgo { get; set; }
        public int NumContagio { get; set; }
        public string Extra { get; set; }
        public int FAlumno { get; set; }

        public virtual Alumno FAlumnoNavigation { get; set; }
        public virtual ICollection<SeguimientoAl> SeguimientoAl { get; set; }
    }
}
