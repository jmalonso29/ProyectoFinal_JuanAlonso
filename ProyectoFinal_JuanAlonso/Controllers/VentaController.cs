using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Service;
using System.Net;

namespace ProyectoFinal_JuanAlonso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : Controller
    {
        private readonly VentaService ventaService;
        private readonly ProductoVendidoService productoVendidoService;
        private readonly ProductoService productoService;
        List<string> list;
        
        

        public VentaController (VentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpPost("{idUsuario}")]

        public IActionResult AgregarNuevaVenta(int idUsuario, [FromBody] List<ProductoDTO> productoDTO) 
        {
            if (productoDTO.Count == 0)
            {
                return base.BadRequest(new { mensaje = "No se recibieron los productos necesarios para la venta", status = HttpStatusCode.BadRequest});
            }
            try
            {
                this.ventaService.AgregarNuevaVenta(idUsuario, productoDTO);
                IActionResult result = base.Created(nameof(AgregarNuevaVenta), new { mensaje = "Venta creada con éxito", status = HttpStatusCode.Created, nuevaVenta = productoDTO});
                return result;
            }
            catch (Exception ex)
            {
                return base.Conflict(new {mensaje = ex.Message,  status = HttpStatusCode.Conflict});
            }
        }

        [HttpPost("{idUsuario}")]
        public IActionResult CrearVenta(int idUsuario, List<ProductoDTO> productoDTO)
        {
            try
            {
                var idVenta = ventaService.AgregarNuevaVenta(idUsuario, productoDTO);
                MarcarComoProductosVendidos(productoDTO, idUsuario);
                ActualizarStockDeLosProductosVendidos(productoDTO);

                return Ok(new { mensaje = "Venta creada con éxito", status = HttpStatusCode.Created });
            }
            catch (Exception ex)
            {
                return Conflict(new { mensaje = ex.Message, status = HttpStatusCode.Conflict });
            }
        }

        [HttpPost("{idUsuario}")]
        private void MarcarComoProductosVendidos(List<ProductoDTO> productoDTO, int idVenta)
        {
            productoDTO.ForEach(p =>
            {
                ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();
                productoVendidoDTO.IdProducto = p.Id;
                productoVendidoDTO.IdVenta = idVenta;
                productoVendidoDTO.Stock = p.Stock;

                productoVendidoService.AgregarProductoVendido(productoVendidoDTO);
            });
        }

        [HttpPost("{idUsuario}")]
        private void ActualizarStockDeLosProductosVendidos(List<ProductoDTO> productoDTO)
        {
            productoDTO.ForEach(p =>
            {
                ProductoDTO productoActual = productoService.ObtenerProductoPorIdProducto(p.Id);
                productoActual.Stock -= p.Stock;
                productoService.ActualizarProductoPorId(productoActual);
            });
        }
    }
}
