using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Pregunta1.Data.DAO.Interfaces;
using Pregunta1.Models;

namespace Pregunta1.Data.DAO
{
    public class ProductoDAO : IProductoDAO
    {
        public bool ActualizarProducto(Producto producto)
        {
            try
            {
                SqlConnection sqlConnection = DBConnection.ObtenerConexion();
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "SP_Actualizar_Producto";
                sqlCommand.Parameters.AddWithValue("@ProductoID", producto.ID);
                sqlCommand.Parameters.AddWithValue("@Codigo_inventario", producto.Codigo_inventario);
                sqlCommand.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
                sqlCommand.Parameters.AddWithValue("@Precio", producto.Precio);
                sqlCommand.Parameters.AddWithValue("@Stock", producto.Stock);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                return true;
            }

            catch (Exception ex)
            {

                throw new Exception("Error al actualizar el producto", ex);
            }
        }

        public bool AgregarProducto(Producto producto)
        {

            try
            {
                SqlConnection cnx = DBConnection.ObtenerConexion();
                cnx.Open();
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_Agregar_Producto";
                cmd.Parameters.AddWithValue("@Codigo_inventario", producto.Codigo_inventario);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@CategoriaID", producto.CategoriaID);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                cmd.ExecuteNonQuery();
                cnx.Close();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el producto", ex);
            }
        }

        public bool EliminarProducto(int id)
        {
            try
            {
                SqlConnection cnx = DBConnection.ObtenerConexion();
                cnx.Open();
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "SP_Eliminar_Producto";
                cmd.Parameters.AddWithValue("@ProductoID", id);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto", ex);
            }
        }

        public List<Producto> ListarProductos()
        {
            SqlConnection cnx = DBConnection.ObtenerConexion();

            cnx.Open();
            SqlCommand cmd = cnx.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Listar_Producto";

            List<Producto> productos = new List<Producto>();

            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Producto producto = new Producto(
                   Convert.ToInt32(dr["ID"]),
                     dr["Codigo_inventario"].ToString(),
                     dr["Descripcion"].ToString(),
                     Convert.ToInt32(dr["Stock"]),
                     Convert.ToDouble(dr["Precio"]),

                     dr["Categoria"].ToString()

                );
                productos.Add(producto);
            }
            dr.Close();
            cnx.Close();
            return productos;
        }

        public Producto ObtenerProducto(int id)
        {
            SqlConnection sqlConnection = DBConnection.ObtenerConexion();
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "SP_Buscar_Producto";

            Producto producto = new Producto();
            sqlCommand.Parameters.AddWithValue("@ProductoID", id);
            SqlDataReader dr = sqlCommand.ExecuteReader();

            while (dr.Read())
            {
                producto.ID = Convert.ToInt32(dr["ID"]);
                producto.Descripcion = dr["Descripcion"].ToString();
                producto.Codigo_inventario = dr["Codigo_inventario"].ToString();
                producto.Categoria = dr["Categoria"].ToString();
                producto.Stock = Convert.ToInt32(dr["Stock"]);
                producto.Precio = Convert.ToDouble(dr["Precio"]);

            }
            dr.Close();
            sqlConnection.Close();
            return producto;

        }
    }
}