using ProyectoFinal_JuanAlonso.DTO;
using ProyectoFinal_JuanAlonso.Modelos;

namespace ProyectoFinal_JuanAlonso.Mapper
{
    public class VentaMapper
    {
        public Venta MapearAVenta (VentaDTO ventaDTO)
        {
            Venta venta = new Venta ();
            venta.Id = ventaDTO.Id;
            venta.IdUsuario = ventaDTO.IdUsuario;
            venta.Comentarios = ventaDTO.Comentarios;

            return venta;
        }

        public  VentaDTO MapearVentaADTO (Venta venta)
        {
            VentaDTO ventaDTO = new VentaDTO ();
            ventaDTO.Id = venta.Id;
            ventaDTO.IdUsuario = venta.IdUsuario;
            ventaDTO.Comentarios = venta.Comentarios;

            return ventaDTO;
        }
    }
}
