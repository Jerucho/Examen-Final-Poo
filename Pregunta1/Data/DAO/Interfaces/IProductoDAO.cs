using System.Collections.Generic;
using Pregunta1.Models;

namespace Pregunta1.Data.DAO.Interfaces
{
    internal interface IProductoDAO
    {
        List<Producto> ListarProductos();
        Producto ObtenerProducto(int id);
        bool AgregarProducto(Producto producto);
        bool ActualizarProducto(Producto producto);
        bool EliminarProducto(int id);
    }
}
