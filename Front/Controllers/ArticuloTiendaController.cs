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
            if (result.Correct)
            {
                articuloTienda.ArticuloTiendas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(articuloTienda);
        }
    }
}
