using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class SeguimientoPro
    {
        public int IdSegui { get; set; }
        public int FPositivoProfe { get; set; }
        public int FMedico { get; set; }
        public DateTime Fecha { get; set; }
        public string FormComunica { get; set; }
        public string Reporte { get; set; }
        public string Entrevista { get; set; }
        public string Extra { get; set; }

        public virtual Medico FMedicoNavigation { get; set; }
        public virtual PositivoProfe FPositivoProfeNavigation { get; set; }
    }
}

