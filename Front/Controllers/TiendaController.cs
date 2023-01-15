using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class TiendaController : Controller
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

        [HttpPost]
        public ActionResult GetAll(Entitys.Tienda tienda)
        {
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

        public JsonResult GetEstado(int IdPais)
        {
            var result = Bussiness.Estado.GetByIdPais(IdPais);

            return Json(result.Objects);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = Bussiness.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = Bussiness.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects);
        }

        [HttpGet]
        public ActionResult Form(int? idTienda)
        {
            Entitys.Tienda tienda = new Entitys.Tienda();

            Entitys.Result resultpais = Bussiness.Pais.GetAll();
            tienda.DireccionTienda = new Entitys.DireccionTienda();
            tienda.DireccionTienda.Colonia = new Entitys.Colonia();
            tienda.DireccionTienda.Colonia.Municipio = new Entitys.Municipio();
            tienda.DireccionTienda.Colonia.Municipio.Estado = new Entitys.Estado();
            tienda.DireccionTienda.Colonia.Municipio.Estado.Pais = new Entitys.Pais();

            if (idTienda == null)
            {
                tienda.DireccionTienda.Colonia.Municipio.Estado.Pais.Paises = resultpais.Objects;

                return View(tienda);
            }
            else
            {
                Entitys.Result result = Bussiness.Tienda.GetById(idTienda.Value);
                if (result.Correct)
                {
                    tienda = (Entitys.Tienda)result.Object;
                    tienda.DireccionTienda.Colonia.Municipio.Estado.Pais.Paises = resultpais.Objects;

                    Entitys.Result resultEstado = Bussiness.Estado.GetByIdPais(tienda.DireccionTienda.Colonia.Municipio.Estado.Pais.IdPais);
                    tienda.DireccionTienda.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                    Entitys.Result resultMunicipio = Bussiness.Municipio.GetByIdEstado(tienda.DireccionTienda.Colonia.Municipio.Estado.IdEstado);
                    tienda.DireccionTienda.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    Entitys.Result resultColonia = Bussiness.Colonia.GetByIdMunicipio(tienda.DireccionTienda.Colonia.Municipio.IdMunicipio);
                    tienda.DireccionTienda.Colonia.Colonias = resultColonia.Objects;

                    return View(tienda);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al buscar la tienda";
                }
                return View(tienda);
            }
        }

        [HttpPost]
        public ActionResult Form(Entitys.Tienda tienda)
        {
            //ADD
            if (tienda.IdTienda == 0)
            {
                Entitys.Result result = Bussiness.Tienda.Add(tienda);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            else
            {
                //UPDATE
                if (tienda != null)
                {
                    Entitys.Result result = Bussiness.Tienda.Update(tienda);
                    if (result.Correct)
                    {
                        ViewBag.Message = result.Message;
                    }
                    else
                    {
                        ViewBag.Message = "Error: " + result.Message;
                    }
                }
            }
            return PartialView("Modal");
        }

        //[HttpDelete]
        public ActionResult Delete(int? idTienda)
        {
            Entitys.Tienda tienda = new Entitys.Tienda();
            if (tienda != null)
            {
                Entitys.Result result = Bussiness.Tienda.Delete(idTienda.Value);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            else
            {
                return Redirect("/Tienda/GetAll");
            }
            return PartialView("Modal");
        }
    }
}
