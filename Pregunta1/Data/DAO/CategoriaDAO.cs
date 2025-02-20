using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Pregunta1.Models;

namespace Pregunta1.Data.DAO
{
    public class CategoriaDAO
    {
        public List<Categoria> ListarCategorias()
        {
            SqlConnection cnx = DBConnection.ObtenerConexion();

            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Listar_Categoria";

            List<Categoria> categorias = new List<Categoria>();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Categoria categoria = new Categoria(
                   Convert.ToInt32(dr["ID"]),
                     dr["Nombre"].ToString()
                );
                categorias.Add(categoria);
            }
            dr.Close();
            cnx.Close();
            return categorias;

        }
    }
}