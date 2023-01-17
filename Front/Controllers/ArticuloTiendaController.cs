using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class ArticuloTiendaController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            Entitys.Tienda tienda = new Entitys.Tienda();
            Entitys.Result result = Bussiness.Tienda.GetAll(tienda);
            if (result.Correct)
            {
                tienda.Tiendas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(tienda);
        }

        [HttpGet]
        public ActionResult ArticuloTiendaAsignadas(int IdTienda)
        {
            Entitys.ArticuloTienda articuloTienda = new Entitys.ArticuloTienda();
            Entitys.Result result = Bussiness.ArticuloTienda.ArticuloTiendaAsignados(IdTienda);
            articuloTienda.Tienda = new Entitys.Tienda();
            articuloTienda.Articulo = new Entitys.Articulo();
            Entitys.Result result1 = Bussiness.Tienda.GetById(IdTienda);
            if (result.Correct && result1.Correct)
            {
                articuloTienda.ArticuloTiendas = result.Objects;
                articuloTienda.Tienda = (Entitys.Tienda)result1.Object;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(articuloTienda);
        }

        [HttpGet]
        public ActionResult ArticuloTiendaNoAsignadas(int IdTienda)
        {
            Entitys.ArticuloTienda articuloTienda = new Entitys.ArticuloTienda();
            Entitys.Result result = Bussiness.ArticuloTienda.ArticuloTiendaNoAsignados(IdTienda);
            articuloTienda.Tienda = new Entitys.Tienda();
            articuloTienda.Articulo = new Entitys.Articulo();
            Entitys.Result result1 = Bussiness.Tienda.GetById(IdTienda);
            if (result.Correct && result1.Correct)
            {
                articuloTienda.ArticuloTiendas = result.Objects;
                articuloTienda.Tienda = (Entitys.Tienda)result1.Object;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(articuloTienda);
        }

        [HttpPost]
        public ActionResult Add(int IdTienda, List<int> IdArticulo)
        {
            Entitys.ArticuloTienda articuloTienda = new Entitys.ArticuloTienda();
            Entitys.Result result = new Entitys.Result();
            if (articuloTienda != null)
            {
                foreach (var item in IdArticulo)
                {
                    result = Bussiness.ArticuloTienda.Add(IdTienda, item);
                }
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                    ViewBag.IdTienda = IdTienda;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            else
            {
                return Redirect("/ArticuloTienda/GetAll");
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdTienda, int IdArticulo)
        {
            Entitys.ArticuloTienda articuloTienda = new Entitys.ArticuloTienda();
            Entitys.Result result = Bussiness.ArticuloTienda.Delete(IdTienda,IdArticulo);
            if (articuloTienda != null)
            {
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                    ViewBag.IdTienda = IdTienda;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            else
            {
                return Redirect("/ArticuloTienda/GetAll");
            }
            return PartialView("Modal");
        }
    }
}
