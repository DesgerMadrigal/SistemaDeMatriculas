using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeMatriculas.Clases
{ 
    public class UsuarioDLL
    {
        private UsuarioDAL usuarioDAL;

        public UsuarioDLL(Cconexion conexion)
        {
            usuarioDAL = new UsuarioDAL(conexion);
        }

        // Método para verificar si un nombre de usuario ya existe en la base de datos

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarioDAL.ObtenerUsuarios();
        }

        public bool AsignarRolUsuario(int idUsuario, int idRol)
        {
            return usuarioDAL.AsignarRolUsuario(idUsuario, idRol);
        }

        public bool AsignarPermisoRol(int idRol, int idPermiso)
        {
            return usuarioDAL.AsignarPermisoRol(idRol, idPermiso);
        }

    }
}
