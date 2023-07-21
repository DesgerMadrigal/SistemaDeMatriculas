using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMatriculas.Clases.ClasesNormales
{
    public class Docente
    {
        public string CodigoDocente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaContratacion { get; set; }
    }
}
