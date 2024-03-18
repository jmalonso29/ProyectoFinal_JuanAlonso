using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Modelos;

namespace ProyectoFinal_JuanAlonso.Mapper
{
    public class UsuarioMapper
    {
        public static Usuario MapearAUsuario (UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario ();
            usuario.Id = usuarioDTO.Id;
            usuario.Mail = usuarioDTO.Mail;
            usuario.Nombre = usuarioDTO.Nombre;
            usuario.Apellido = usuarioDTO.Apellido;
            usuario.NombreUsuario = usuarioDTO.NombreUsuario;
            usuario.Contraseña = usuarioDTO.Contraseña;

            return usuario;
        }

        public static UsuarioDTO MapearUsuarioADTO(Usuario usuario)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO ();

            usuarioDTO.Id = usuario.Id;
            usuarioDTO.Mail = usuario.Mail;
            usuarioDTO.Nombre = usuario.Nombre;
            usuarioDTO.Apellido = usuario.Apellido;
            usuarioDTO.NombreUsuario = usuario.NombreUsuario;
            usuarioDTO.Contraseña = usuario.Contraseña;

            return usuarioDTO;
        }
    }
}
