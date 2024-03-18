using ProyectoFinal_JuanAlonso.database;
using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Mapper;
using ProyectoFinal_JuanAlonso.Modelos;

namespace ProyectoFinal_JuanAlonso.Service
{
    public class ProductoService
    {
        private readonly CoderContext coderContext;
        private readonly ProductoMapper productoMapper;

        public ProductoService(CoderContext coderContext, ProductoMapper productoMapper)
        {
            this.coderContext = coderContext;
            this.productoMapper = productoMapper;
        }



        public bool AgregarUnProducto(ProductoDTO productoDTO)
        {
            Producto p = ProductoMapper.MapearAProducto(productoDTO);
            
            coderContext.Productos.Add(p);
            coderContext.SaveChanges();
            return true;
        }

        public bool BorrarProductoPorId (int id)
        {
           Producto? producto = coderContext.Productos.Where(p=> p.Id == id).FirstOrDefault();
            if (producto is not null) 
            {
                coderContext.Remove (producto);
                coderContext.SaveChanges ();
                return true;
            }
            return false;
        }

        public bool ActualizarProductoPorId (ProductoDTO productoDTO)
        {
            Producto? producto = coderContext.Productos.Where(p => p.Id == productoDTO.Id).FirstOrDefault();
            if (producto is not null)
            {
                producto.PrecioVenta = productoDTO.PrecioVenta;
                producto.Stock = productoDTO.Stock;
                producto.Descripciones = productoDTO.Descripciones;
                producto.IdUsuario = productoDTO.IdUsuario;
                producto.Costo = productoDTO.Costo;

                coderContext.Productos.Update (producto);
                coderContext.SaveChanges ();
                return true;
            }
            return false;
        }

        public List<ProductoDTO> ObtenerProductosPorIdDeUsuario(int idUsuario)
        {
            return coderContext.Productos
                .Where(p => p.IdUsuario == idUsuario)
                .Select(p => productoMapper.MappearProductoADTO(p))
                .ToList();
        }

        public ProductoDTO ObtenerProductoPorIdProducto(int id)
        {
            return coderContext.Productos
                .Where(p => p.Id == id)
                .Select(p => productoMapper.MappearProductoADTO(p))
                .FirstOrDefault();
        }
    }
}
