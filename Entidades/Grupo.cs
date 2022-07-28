using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Grupo
    {
        public Grupo()
        {
            GrupoCuatrimestre = new HashSet<GrupoCuatrimestre>();
        }

        public int IdGrupo { get; set; }
        public int Grado { get; set; }
        public string Letra { get; set; }
        public string Extra { get; set; }

        public virtual ICollection<GrupoCuatrimestre> GrupoCuatrimestre { get; set; }
    }
}
