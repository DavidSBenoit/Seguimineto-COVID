using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class PositivoProfe
    {
        public PositivoProfe()
        {
            SeguimientoPro = new HashSet<SeguimientoPro>();
        }

        public int IdPosProfe { get; set; }
        public DateTime FechaConfirmado { get; set; }
        public string Comprobacion { get; set; }
        public string Antecedentes { get; set; }
        public string Riesgo { get; set; }
        public int NumContaio { get; set; }
        public string Extra { get; set; }
        public int FProfe { get; set; }

        public virtual Profesor FProfeNavigation { get; set; }
        public virtual ICollection<SeguimientoPro> SeguimientoPro { get; set; }
    }
}
