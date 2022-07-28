using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Profesor
    {
        public Profesor()
        {
            PositivoProfe = new HashSet<PositivoProfe>();
            ProfeGrupo = new HashSet<ProfeGrupo>();
        }

        public int IdProfe { get; set; }
        public int RegistroEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApPat { get; set; }
        public string ApMat { get; set; }
        public string Genero { get; set; }
        public string Categoria { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public int FEdoCivil { get; set; }

        public virtual EstadoCivil FEdoCivilNavigation { get; set; }
        public virtual ICollection<PositivoProfe> PositivoProfe { get; set; }
        public virtual ICollection<ProfeGrupo> ProfeGrupo { get; set; }
    }
}
