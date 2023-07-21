using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMatriculas.Clases
{
    public class Aula
    {
        public string CodigoAula { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
    }
    public class Docente
    {
        public string CodigoDocente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaContratacion { get; set; }
    }
    public class Estudiante
    {
        public string CodigoEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CorreoElectronico { get; set; }
    }
    public class Horario
    {
        public string CodigoHorario { get; set; }
        public string DiaSemana { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
    }
    public class Materia
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Creditos { get; set; }
    }
    public class Matricula
    {
        public int IdEstudiante { get; set; }
        public string CodigoMateria { get; set; }
        public double Nota { get; set; }
    }
    public class Oferta
    {
        public string CodigoOferta { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
}
