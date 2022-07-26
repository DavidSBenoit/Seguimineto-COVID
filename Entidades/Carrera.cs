using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Carrera
    {
        public Carrera()
        {
            ProgramaEducativo = new HashSet<ProgramaEducativo>();
        }

        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }

        public virtual ICollection<ProgramaEducativo> ProgramaEducativo { get; set; }
    }
}
