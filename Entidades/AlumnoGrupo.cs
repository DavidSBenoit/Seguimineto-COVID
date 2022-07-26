using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class AlumnoGrupo
    {
        public int IdAlumnGru { get; set; }
        public int FAlumn { get; set; }
        public int FGruCuat { get; set; }
        public string Extra { get; set; }
        public string Extra2 { get; set; }

        public virtual Alumno FAlumnNavigation { get; set; }
        public virtual GrupoCuatrimestre FGruCuatNavigation { get; set; }
    }
}

