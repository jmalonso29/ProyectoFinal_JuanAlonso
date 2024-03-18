using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProyectoFinal_JuanAlonso.database;
using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Mapper;
using ProyectoFinal_JuanAlonso.Modelos;
using System.Runtime.CompilerServices;

namespace ProyectoFinal_JuanAlonso.Service
{
    public class VentaService
    {
        private readonly CoderContext coderContext;
        private readonly VentaMapper ventaMapper;
        private readonly ProductoVendidoService productoVendidoService;
        private readonly ProductoService productoService;

        public VentaService(CoderContext coderContext, VentaMapper ventaMapper,
                            ProductoVendidoService productoVendidoService,ProductoService productoService)
        {
            this.coderContext = coderContext;
            this.ventaMapper = ventaMapper;
            this.productoVendidoService = productoVendidoService;
            this.productoService = productoService;
        }
        public List<VentaDTO> ObtenerVentasPorIdUsuario(int idUsuario)
        {
            return this.coderContext.Venta
                .Where(v => v.IdUsuario == idUsuario)
                .Select(v => ventaMapper.MapearVentaADTO(v)) 
                .ToList();
        }

        public bool AgregarNuevaVenta(int idUsuario, List<ProductoDTO> productoDTO)
        {
            Venta venta = new Venta();
            List<string> nombresDeProductos = productoDTO.Select(p => p.Descripciones).ToList();
            string comentarios = string.Join("- ", nombresDeProductos);
            venta.Comentarios = comentarios;
            venta.IdUsuario = idUsuario;

            EntityEntry<Venta>? resultado = this.coderContext.Venta.Add(venta);
            resultado.State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this.coderContext.SaveChanges();

            MarcarComoProductosVendidos(productoDTO, venta.Id);

            this.ActualizarStockDeLosProductosVendidos(productoDTO);

            return true;
        }
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
        private void ActualizarStockDeLosProductosVendidos(List<ProductoDTO> productoDTO)
        {
            productoDTO.ForEach(p =>
            {
                ProductoDTO productoActual = this.productoService.ObtenerProductoPorIdProducto(p.Id);
                productoActual.Stock -= p.Stock;
                this.productoService.ActualizarProductoPorId(productoActual);
            });
        }
    }

    

    
}
