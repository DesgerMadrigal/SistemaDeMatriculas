using System;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace SistemaDeMatriculas.Clases
{
    public class Aula
    {
        public int Id { get; set; } 
        public int Capacidad { get; set; }
        public string Condicion { get; set; }
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
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public bool Activo { get; set; }
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
        public int Id { get; set; }
        public string CodigoOferta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string ContraseñaHash { get; set; }
        public string Salt { get; set; }
        public bool EsFuncionario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimoInicioSesion { get; set; }
        public bool Activo { get; set; }
    }

    public class MateriaEstudiante
    {
        public int Id { get; set; }
        public int IdMateria { get; set; }
        public int IdEstudiante { get; set; }
        public string Condicion { get; set; } // Puede ser "Aprobado" o "Reprobado"
        public int Periodo { get; set; } // Puede ser el número del cuatrimestre, bimestre, etc.
        public int Año { get; set; }
        public string CodigoMateria { get; set; }
        public string NombreMateria { get; set; }

        public MateriaEstudiante()
        {
            // Constructor vacío necesario para la serialización/deserialización de objetos
        }

        public MateriaEstudiante(int idMateria, int idEstudiante, string condicion, int periodo, int año)
        {
            IdMateria = idMateria;
            IdEstudiante = idEstudiante;
            Condicion = condicion;
            Periodo = periodo;
            Año = año;
        }
    }
}

