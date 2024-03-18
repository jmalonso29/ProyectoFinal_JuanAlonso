using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_JuanAlonso.database;
using ProyectoFinal_JuanAlonso.Modelos;
using ProyectoFinal_JuanAlonso.Service;

namespace ProyectoFinal_JuanAlonso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class NombreController : Controller 
    {
        List<string> list;
        public NombreController()
        {
            this.list = new List<string>() { "Guillermina", "Rosario", "Sara" };
        }

        [HttpGet]
        public string ObtenerNombre()
        {
            return "Juan Manuel Alonso";
        }

        [HttpGet ("listado")]
        public List<string> ObtenerListadoDeNombres()
        {        
            return list;
        }

        [HttpGet("listado/{id}")]

        public ActionResult <string> ObtenerNombrePorId(int id)
        {
            if (id < 0 || id  >= list.Count)
            {
                return BadRequest (new { mensaje = $"El número no puede ser negativo o mayor que {this.list.Count}", status = 400 });
            }
            return this.list[id];
        }
}
}
