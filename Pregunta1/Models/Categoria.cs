namespace Pregunta1.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        public string Nombre { get; set; }

        public Categoria() { }

        public Categoria(int id, string nombre)
        {

            ID = id;
            Nombre = nombre;
        }

    }
}