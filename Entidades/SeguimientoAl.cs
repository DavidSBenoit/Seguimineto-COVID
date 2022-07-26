using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class SeguimientoAl
    {
        public int IdSeguimiento { get; set; }
        public int FPositivoAl { get; set; }
        public int FMedico { get; set; }
        public DateTime Fecha { get; set; }
        public string FormComunica { get; set; }
        public string Reporte { get; set; }
        public string Entrevista { get; set; }
        public string Extra { get; set; }

        public virtual Medico FMedicoNavigation { get; set; }
        public virtual PositivoAlumno FPositivoAlNavigation { get; set; }
    }
}
