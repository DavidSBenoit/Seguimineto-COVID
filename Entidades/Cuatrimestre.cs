using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Cuatrimestre
    {
        public Cuatrimestre()
        {
            GrupoCuatrimestre = new HashSet<GrupoCuatrimestre>();
        }

        public short IdCuatrimestre { get; set; }
        public string Periodo { get; set; }
        public int Anio { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Fin { get; set; }
        public string Extra { get; set; }

        public virtual ICollection<GrupoCuatrimestre> GrupoCuatrimestre { get; set; }
    }
}
