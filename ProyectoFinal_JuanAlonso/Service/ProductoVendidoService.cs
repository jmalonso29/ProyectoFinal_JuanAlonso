using ProyectoFinal_JuanAlonso.database;
using ProyectoFinal_JuanAlonso.Modelos;
using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal_JuanAlonso.Service
{
    public class ProductoVendidoService
    {
        private readonly CoderContext coderContext;
        public ProductoVendidoService(CoderContext coderContext)
        {
            this.coderContext = coderContext;
        }

       public List<ProductoVendidoDTO>? ObtenerProductosVendidosPorIdDeUsuario(int idUsuario)
        {
            List<Producto>? productos = 
                this.coderContext.Productos
                .Include(p => p.ProductoVendidos)
                .Where(p => p.IdUsuario == idUsuario)
                .ToList();
            
            List<ProductoVendido?>? productosVendidos  = productos
                .Select(p => p.ProductoVendidos
                    .ToList()
                    .Find(pv => pv.IdProducto == p.Id))
                .Where(p => !object.ReferenceEquals(p,null))
                .ToList();

            List<ProductoVendidoDTO> productoVendidoDTO = productosVendidos
                 .Select(p => ProductoVendidoMapper.MapearProductoVendidoDTO(p))
                 .ToList();
            return productoVendidoDTO;
            
        }

        public bool AgregarProductoVendido(ProductoVendidoDTO productoVendidoDTO)
        {
            ProductoVendido d = ProductoVendidoMapper.MapearProductoVendido(productoVendidoDTO);

            coderContext.ProductoVendidos.Add(d);
            coderContext.SaveChanges();
            return true;
        }
    }
}
              