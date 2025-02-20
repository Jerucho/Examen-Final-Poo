using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Pregunta1.Models;

namespace Pregunta1.Data.DAO
{
    public class RankingDAO
    {
        public List<RankingProducto> ObtenerRanking(int cantidad = 5)
        {
            SqlConnection cnx = DBConnection.ObtenerConexion();

            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_GetTopProductos";

            cmd.Parameters.AddWithValue("@TopN", cantidad);

            List<RankingProducto> productos = new List<RankingProducto>();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                RankingProducto producto = new RankingProducto(
                   Convert.ToInt32(dr["ID"]),
                     dr["Descripcion"].ToString(),
                     Convert.ToDouble(dr["TotalCantidad"].ToString()),
                     Convert.ToInt32(dr["Ranking"])

                );
                productos.Add(producto);
            }
            dr.Close();
            cnx.Close();
            return productos;

        }
    }
}