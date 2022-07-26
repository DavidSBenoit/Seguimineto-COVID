using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Medico
    {
        public Medico()
        {
            SeguimientoAl = new HashSet<SeguimientoAl>();
            SeguimientoPro = new HashSet<SeguimientoPro>();
        }

        public int IdDr { get; set; }
        public string Nombre { get; set; }
        public string App { get; set; }
        public string Apm { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Horario { get; set; }
        public string Especialidad { get; set; }
        public string Extra { get; set; }

        public virtual ICollection<SeguimientoAl> SeguimientoAl { get; set; }
        public virtual ICollection<SeguimientoPro> SeguimientoPro { get; set; }
    }
}
