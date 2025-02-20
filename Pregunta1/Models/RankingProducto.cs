namespace Pregunta1.Models
{
    public class RankingProducto
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public double TotalCantidad { get; set; }
        public int Ranking { get; set; }


        public RankingProducto() { }

        public RankingProducto(int id, string descripcion, double totalCantidad, int ranking)
        {
            ID = id;
            Descripcion = descripcion;
            TotalCantidad = totalCantidad;
            Ranking = ranking;
        }
    }
}