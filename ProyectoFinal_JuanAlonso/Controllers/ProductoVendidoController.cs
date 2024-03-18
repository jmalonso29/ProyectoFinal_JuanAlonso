using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Service;

namespace ProyectoFinal_JuanAlonso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoVendidoController : Controller
    {
        private readonly ProductoVendidoService productoVendidoService;
        List<string> list;

        public ProductoVendidoController(ProductoVendidoService productoVendidoService)
        {
            this.productoVendidoService = productoVendidoService;
        }

        [HttpGet("{idUsuario}")]

        public IActionResult ObtenerProductosVendidosPorIdDeUsuario(int idUsuario)

        {
            var productosVendidos = productoVendidoService.ObtenerProductosVendidosPorIdDeUsuario(idUsuario);

            if (productosVendidos == null)
            {
                return NotFound();
            }

            return Ok(productosVendidos);
        }
    }
}
