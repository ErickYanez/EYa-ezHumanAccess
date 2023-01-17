using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class ArticuloClienteController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Entitys.Tienda tienda = new Entitys.Tienda();
            Entitys.Result resultTienda = Bussiness.Tienda.GetAll(tienda);
            Entitys.Articulo articulo = new Entitys.Articulo();
            articulo.Tienda = new Entitys.Tienda();
            Entitys.Result result = Bussiness.Articulo.GetAll(articulo);


            if (result.Correct)
            {
                articulo.Tienda.Tiendas = resultTienda.Objects;
                articulo.Articulos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }

            return View(articulo);
        }
    }
}
