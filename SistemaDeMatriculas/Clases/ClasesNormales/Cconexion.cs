using System.Data.SqlClient;

namespace SistemaDeMatriculas.Clases
{
    public class Cconexion
    {
        private string cconexion = "Server=tcp:bdproyectos.database.windows.net,1433;Initial Catalog=SistemaMatriculas;Persist Security Info=False;User ID=rarz;Password=exodus14@.#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cconexion);
        }
    }


}
