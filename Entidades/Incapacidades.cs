using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public partial class Incapacidades
    {
        public int IdIncapacidad { get; set; }
        public string Formato { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? IdPosProfe { get; set; }

        public virtual PositivoProfe IdPosProfeNavigation { get; set; }
    }
}
