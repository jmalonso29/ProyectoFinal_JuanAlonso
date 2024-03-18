using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Modelos;

namespace ProyectoFinal_JuanAlonso.Mapper
{
    public  class ProductoMapper


    {
        public static Producto MapearAProducto(ProductoDTO productoDTO)
        {
            Producto producto = new Producto();

            producto.Descripciones = productoDTO.Descripciones;
            producto.Id = productoDTO.Id;
            producto.PrecioVenta = productoDTO.PrecioVenta;
            producto.Stock = productoDTO.Stock;
            producto.Costo = productoDTO.Costo;
            producto.IdUsuario = productoDTO.IdUsuario;

            return producto;
        }
        public  ProductoDTO MappearProductoADTO(Producto producto)
        {
            ProductoDTO productoDTO = new ProductoDTO();

            productoDTO.Descripciones = producto.Descripciones;
            productoDTO.Id = producto.Id;
            productoDTO.PrecioVenta = producto.PrecioVenta;
            productoDTO.Stock = producto.Stock;
            productoDTO.Costo = producto.Costo;
            productoDTO.IdUsuario = producto.IdUsuario;

            return productoDTO;
        }
    }
}
