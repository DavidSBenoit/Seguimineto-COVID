using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class ProfeGrupo
    {
        public int IdProfeGru { get; set; }
        public int FProfe { get; set; }
        public int FGruCuat { get; set; }
        public string Extra { get; set; }
        public string Extra2 { get; set; }

        public virtual GrupoCuatrimestre FGruCuatNavigation { get; set; }
        public virtual Profesor FProfeNavigation { get; set; }
    }
}
