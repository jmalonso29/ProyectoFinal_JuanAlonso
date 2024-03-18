using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Modelos;
using ProyectoFinal_JuanAlonso.Service;
using System.Collections.Generic;

namespace ProyectoFinal_JuanAlonso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : Controller
    {
        
        private ProductoService productoService;
        List<string> list;

        public ProductoController(ProductoService productoService)
        {
            this.productoService = productoService;
        }

        [HttpPost]
        public IActionResult AgregarUnNuevoProducto([FromBody] ProductoDTO producto)
        {
            if (this.productoService.AgregarUnProducto(producto))
            {
                return base.Ok(new { mensaje = "Producto agregado", producto });
            }
            else
            {
                return base.Conflict(new { mensaje = "No se agrego el producto" });
            }
        }

        [HttpDelete ("{idProducto}")]
            public IActionResult BorrarProducto (int id)
        {
            if(id > 0)
            {
               if (this.productoService.BorrarProductoPorId(id))
                {
                    return base.Ok(new { mensaje = "Producto borrado", status = 200 });
                }
                    return base.Conflict(new { mensaje = "No se borro el producto" });
                
            }
            return base.BadRequest(new {status = 400, mensaje = "El Id no puede ser negativo"});
        }

        [HttpPut ("{id}")]
        public IActionResult ActualizarProductoPorId (int id, ProductoDTO productoDTO) 
        {
            if (id > 0)
            {
                if (this.productoService.ActualizarProductoPorId (productoDTO))
                {
                    return base.Ok(new { mensaje = "Producto actualizado", status = 200, productoDTO });
                }
                    return base.Conflict(new { mensaje = "No se pudo actualizar el producto" });

            }
            return base.BadRequest(new { status = 400, mensaje = "El Id no puede ser negativo" });
        }
        
        [HttpGet("{idUsuario}")]

        public ActionResult<string> ObtenerProductosPorIdDeUsuario(int idUsuario)
        {
            if (idUsuario < 0 || idUsuario >= list.Count)
            {
                return BadRequest(new { mensaje = $"El número no puede ser negativo o mayor que {this.list.Count}", status = 400 });
            }
            return this.list[idUsuario];
        }

        public ActionResult<string> ObtenerProductoPorIdProducto(int id)
        {
            if (id < 0 || id >= list.Count)
            {
                return BadRequest(new { mensaje = $"El número no puede ser negativo o mayor que {this.list.Count}", status = 400 });
            }
            return this.list[id];
        }
    }
}
