namespace Pregunta1.Models
{
    public class Producto
    {

        public int ID { get; set; }
        public string Codigo_inventario { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public string Categoria { get; set; }

        public int CategoriaID { get; set; }
        public Producto()
        {
        }

        public Producto(int id, string codigo_inventario, string descripcion, int stock, double precio, string categoria)
        {
            ID = id;
            Codigo_inventario = codigo_inventario;
            Descripcion = descripcion;
            Stock = stock;
            Precio = precio;
            Categoria = categoria;
        }
    }
}