using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Pregunta1.Data.DAO;
using Pregunta1.Models;

namespace Pregunta1.Controllers
{
    public class HomeController : Controller
    {
        ProductoDAO productoDAO = new ProductoDAO();
        CategoriaDAO categoriaDAO = new CategoriaDAO();
        RankingDAO rankingDAO = new RankingDAO();
        // GET: Home
        public ActionResult Index()
        {
            List<Producto> productos = productoDAO.ListarProductos();
            ViewBag.Productos = productos;
            return View();
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Producto producto = productoDAO.ObtenerProducto(id);
            List<Categoria> categorias = categoriaDAO.ListarCategorias();
            ViewBag.Producto = producto;
            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpPost]
        public ActionResult Editar(FormCollection form)
        {
            Producto nuevoProducto = new Producto
            {
                ID = int.Parse(form["ID"]),
                Codigo_inventario = form["Codigo_inventario"],
                Descripcion = form["Descripcion"],
                CategoriaID = Convert.ToInt32(form["Categoria"]),
                Precio = double.Parse(form["Precio"]),
                Stock = int.Parse(form["Stock"])
            };

            bool productoActualizado = productoDAO.ActualizarProducto(nuevoProducto);
            Producto producto = productoDAO.ObtenerProducto(nuevoProducto.ID);

            ViewBag.Producto = producto;
            ViewBag.ProductoActualizado = productoActualizado;
            return View();

        }
        [HttpGet]
        public ActionResult Borrar(int id)
        {
            Producto producto = productoDAO.ObtenerProducto(id);
            ViewBag.Producto = producto;
            return View();
        }


        [HttpPost]
        public ActionResult Borrar(FormCollection form)
        {
            int id = int.Parse(form["ID"]);

            bool productoEliminado = productoDAO.EliminarProducto(id);

            if (productoEliminado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Agregar()
        {
            List<Categoria> categorias = categoriaDAO.ListarCategorias();
            ViewBag.Categorias = categorias;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(FormCollection form)
        {

            Producto nuevoProducto = new Producto
            {
                Codigo_inventario = form["Codigo_inventario"],
                Descripcion = form["Descripcion"],
                CategoriaID = Convert.ToInt32(form["Categoria"]),
                Precio = double.Parse(form["Precio"]),
                Stock = int.Parse(form["Stock"])
            };
            bool productoAgregado = productoDAO.AgregarProducto(nuevoProducto);


            if (productoAgregado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }



        }

        [HttpGet]
        public ActionResult Ranking()
        {
            List<RankingProducto> productos = rankingDAO.ObtenerRanking();
            ViewBag.Productos = productos;
            return View();

        }

        [HttpPost]
        public ActionResult Ranking(FormCollection form)
        {
            int cantidad = int.Parse(form["Cantidad"]);

            List<RankingProducto> productos = rankingDAO.ObtenerRanking(cantidad);

            ViewBag.Productos = productos;
            return View();
        }
    }
}