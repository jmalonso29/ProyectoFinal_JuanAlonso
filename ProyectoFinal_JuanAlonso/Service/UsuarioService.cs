    using ProyectoFinal_JuanAlonso.database;
using ProyectoFinal_JuanAlonso.Modelos;
using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Mapper;

namespace ProyectoFinal_JuanAlonso.Service
{
    public class UsuarioService
    {
        private readonly CoderContext coderContext;
        
        public UsuarioService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
            
        }
        public List <Usuario> ObtenerTodosLosUsuarios()
        {
            return this.coderContext.Usuarios.ToList();
        }

        public UsuarioDTO ObtenerUsuarioPorNombreDeUsuario(string nombreDeUsuario)
        {
            List<UsuarioDTO> usuarios = UsuarioDTO.ObtenerTodosLosUsuario();

            UsuarioDTO? usuarioBuscado = usuarios.Find(u=> u.NombreUsuario == nombreDeUsuario);
            if (usuarioBuscado == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            
            return usuarioBuscado;

        }

        public UsuarioDTO? ObtenerUsuarioPorUsuarioYPassword(string usuario, string contraseña)
        {
            List<Usuario> usuarios = ObtenerTodosLosUsuarios();

            var user = usuarios.Find(e => e.NombreUsuario == usuario && e.Contraseña == contraseña);
            
            var usuarioBuscado = UsuarioMapper.MapearUsuarioADTO(user);

            if (usuarioBuscado == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            return usuarioBuscado;
        }

        public bool CrearUsuario(UsuarioDTO usuarioDTO)
        {
            Usuario d = UsuarioMapper.MapearAUsuario(usuarioDTO);

            coderContext.Usuarios.Add(d);
            coderContext.SaveChanges();
            return true;
        }

        public bool ActualizarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            Usuario? usuario = coderContext.Usuarios.Where(d => d.Id == id).FirstOrDefault();
            if (usuario is not null)
            {
                usuario.Nombre = usuarioDTO.Nombre;
                usuario.Apellido = usuarioDTO.Apellido;
                usuario.NombreUsuario = usuarioDTO.NombreUsuario;
                usuario.Contraseña = usuarioDTO.Contraseña;
                usuario.Mail = usuarioDTO.Mail;

                coderContext.Usuarios.Update(usuario);
                coderContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
