using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Modelos;

namespace ProyectoFinal_JuanAlonso.Mapper
{
    public class ProductoVendidoMapper
    {
        public static ProductoVendido MapearProductoVendido (ProductoVendidoDTO productoVendidoDTO)
        {
            ProductoVendido productoVendido = new ProductoVendido ();
            productoVendido.Id = productoVendidoDTO.Id;
            productoVendido.IdProducto = productoVendidoDTO.IdProducto;
            productoVendido.Stock = productoVendidoDTO.Stock;
            productoVendido.IdVenta = productoVendidoDTO.IdVenta;

            return productoVendido;
        }
        public static ProductoVendidoDTO MapearProductoVendidoDTO (ProductoVendido productoVendido)
        {
            ProductoVendidoDTO productoVendidoDTO = new ProductoVendidoDTO();

            productoVendidoDTO.Id = productoVendido.Id;
            productoVendidoDTO.IdProducto = productoVendido.IdProducto;
            productoVendidoDTO.Stock = productoVendido.Stock;
            productoVendidoDTO.IdVenta = productoVendido.IdVenta;

            return productoVendidoDTO;
        }
     }
}
