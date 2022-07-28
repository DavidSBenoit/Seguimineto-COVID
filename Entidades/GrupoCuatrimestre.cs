using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class GrupoCuatrimestre
    {
        public GrupoCuatrimestre()
        {
            AlumnoGrupo = new HashSet<AlumnoGrupo>();
            ProfeGrupo = new HashSet<ProfeGrupo>();
        }

        public int IdGruCuat { get; set; }
        public int FProgEd { get; set; }
        public int FGrupo { get; set; }
        public int FCuatri { get; set; }
        public string Turno { get; set; }
        public string Modalidad { get; set; }
        public string Extra { get; set; }

        public virtual Cuatrimestre FCuatriNavigation { get; set; }
        public virtual Grupo FGrupoNavigation { get; set; }
        public virtual ProgramaEducativo FProgEdNavigation { get; set; }
        public virtual ICollection<AlumnoGrupo> AlumnoGrupo { get; set; }
        public virtual ICollection<ProfeGrupo> ProfeGrupo { get; set; }
    }
}
