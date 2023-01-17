using Front.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Front.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            Entitys.Articulo articulo = new Entitys.Articulo();
            Entitys.Result result = Bussiness.Articulo.GetAll(articulo);
            if (result.Correct)
            {
                articulo.Articulos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }

            return View(articulo);
        }      

        [HttpGet]
        public ActionResult CartPost(Entitys.Articulo articulo)
        {
            bool existe = false;
            Entitys.ClienteArticulo clienteArticulo = new Entitys.ClienteArticulo();
            clienteArticulo.ClienteArticulos = new List<object>();

            if (HttpContext.Session.GetString("Articulo") == null)
            {
                articulo.Cantidad = articulo.Cantidad = 1;
                articulo.SubTotal = int.Parse(articulo.Precio.ToString()) * articulo.Cantidad;
                clienteArticulo.ClienteArticulos.Add(articulo);
                HttpContext.Session.SetString("Articulo", Newtonsoft.Json.JsonConvert.SerializeObject(clienteArticulo.ClienteArticulos));
                var session = HttpContext.Session.GetString("Articulo");
            }
            else
            {
                GetCarrito(clienteArticulo);
                foreach (Entitys.Articulo venta in clienteArticulo.ClienteArticulos.ToList())
                {
                    if (articulo.IdArticulo == venta.IdArticulo)
                    {
                        venta.Cantidad = venta.Cantidad + 1;
                        venta.SubTotal = int.Parse(articulo.Precio.ToString()) * venta.Cantidad;
                        existe = true;
                    }
                    else
                    {
                        existe = false;
                    }
                    if (existe == true)
                    {
                        break;
                    }
                }
                if (existe == false)
                {
                    articulo.Cantidad = articulo.Cantidad = 1;
                    articulo.SubTotal = int.Parse(articulo.Precio.ToString()) * articulo.Cantidad;
                    clienteArticulo.ClienteArticulos.Add(articulo);
                }
                HttpContext.Session.SetString("Articulo", Newtonsoft.Json.JsonConvert.SerializeObject(clienteArticulo.ClienteArticulos));
            }
            if (HttpContext.Session.GetString("Articulo") != null)
            {
                ViewBag.Message = "Se ha agregado el articulo a tu carrito!";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se pudo agregar tu articulo ):";
                return PartialView("Modal");
            }

        }
        [HttpGet]
        public ActionResult Compra(Entitys.ClienteArticulo clienteArticulo)
        {
            decimal costoTotal = 0;
            if (HttpContext.Session.GetString("Articulo") == null)
            {
                return View();
            }
            else
            {
                clienteArticulo.ClienteArticulos = new List<object>();
                GetCarrito(clienteArticulo);
                clienteArticulo.Total = costoTotal;
            }

            return View(clienteArticulo);
        }
        public Entitys.ClienteArticulo GetCarrito(Entitys.ClienteArticulo clienteArticulo)
        {
            var ventaSession = Newtonsoft.Json.JsonConvert.DeserializeObject<List<object>>(HttpContext.Session.GetString("Articulo"));

            foreach (var obj in ventaSession)
            {
                Entitys.Articulo objArticulo = Newtonsoft.Json.JsonConvert.DeserializeObject<Entitys.Articulo>(obj.ToString());
                clienteArticulo.ClienteArticulos.Add(objArticulo);
            }
            return clienteArticulo;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}