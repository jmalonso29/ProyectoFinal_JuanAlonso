using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_JuanAlonso.Service;
using ProyectoFinal_JuanAlonso.DTO;
using System.Timers;
using System.Net;

namespace ProyectoFinal_JuanAlonso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService usuarioService;

        public UsuarioController (UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        [HttpGet ("{nombreDeUsuario}")]
        public ActionResult<UsuarioDTO> ObtenerUsuariosPorNombreDeUsuario(string nombreDeUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreDeUsuario))
            {
                return base.BadRequest(new { mensaje = "El nombre de Usuario no puede quedar vacío o con espacios" });
            }
            try
            {
                UsuarioDTO usuarioDTO = usuarioService.ObtenerUsuarioPorNombreDeUsuario(nombreDeUsuario);
                return usuarioDTO;
            }
            catch
            {
                return base.Conflict(new { mensaje = "No se puedo obtener un usuario con los datos proporcionados", status = HttpStatusCode.Conflict });
            }
             
        }
        
        [HttpGet ("{usuario}/{contraseña}")] 
        public ActionResult<UsuarioDTO>  ObtenerUsuarioPorUsuarioYPassword(string usuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contraseña))
            {
                return base.BadRequest(new { mensaje = "El nombre de Usuario o la Contraseña, no pueden quedar vacíos o con espacios", status = HttpStatusCode.BadRequest});
            }

        try {
                return usuarioService.ObtenerUsuarioPorUsuarioYPassword(usuario, contraseña);
            }
            catch 
            {
                return base.Unauthorized(new
                {
                    mensaje = "No se puedo obtener un usuario con los datos proporcionados",
                    status = HttpStatusCode.Unauthorized
                });
            }
       
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] UsuarioDTO usuarioDTO) 
        {
            this.usuarioService.CrearUsuario(usuarioDTO);
            IActionResult result = CreatedAtAction(nameof(CrearUsuario),new {mensaje = "Usuario creado con éxito", nuevoUsuario = usuarioDTO});
            return result;
        }

        [HttpPut]
        public IActionResult ActualizarUsuario(int id, UsuarioDTO usuarioDTO)
        {
            this.usuarioService.ActualizarUsuario(id, usuarioDTO);
            IActionResult result = CreatedAtAction(nameof(ActualizarUsuario), new { mensaje = "Usuario actualizado con éxito", nuevoUsuario = usuarioDTO });
            return result;
        }
    }
}
