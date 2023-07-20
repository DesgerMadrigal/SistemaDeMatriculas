using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    internal class Cconexion
    {
        static string servidor = "tcp:bdproyectos.database.windows.net";
        static string bd = "SistemaMatriculas";
        static string user = "rarz";
        static string pass = "exodus14@.#";

        private string cconexion = $"Server={servidor},1433;Initial Catalog={bd};Persist Security Info=False;User ID={user};Password={pass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cconexion);
        }
    }
}
