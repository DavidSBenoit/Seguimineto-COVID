using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class ProgramaEducativo
    {
        public ProgramaEducativo()
        {
            GrupoCuatrimestre = new HashSet<GrupoCuatrimestre>();
        }

        public int IdPe { get; set; }
        public string ProgramaEd { get; set; }
        public int FCarrera { get; set; }
        public string Extra { get; set; }

        public virtual Carrera FCarreraNavigation { get; set; }
        public virtual ICollection<GrupoCuatrimestre> GrupoCuatrimestre { get; set; }
    }
}

