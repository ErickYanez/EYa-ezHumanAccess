using Microsoft.AspNetCore.Mvc;

namespace Front.Controllers
{
    public class ArticuloController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
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

        [HttpPost]
        public ActionResult GetAll(Entitys.Articulo articulo)
        {
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
        public ActionResult Form(int? idArticulo)
        {
            Entitys.Articulo articulo = new Entitys.Articulo();

            if (idArticulo == null)
            {
                return View(articulo);
            }
            else
            {
                Entitys.Result result = Bussiness.Articulo.GetById(idArticulo.Value);
                if (result.Correct)
                {
                    articulo = (Entitys.Articulo)result.Object;                    

                    return View(articulo);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al buscar el articulo";
                }
                return View(articulo);
            }
        }

        [HttpPost]
        public ActionResult Form(Entitys.Articulo articulo)
        {
            IFormFile image = Request.Form.Files["FileImage"];
            if (image != null)
            {
                byte[] ImagenBytes = ConvertToBytes(image);
                articulo.Imagen = Convert.ToBase64String(ImagenBytes);
            }
            //ADD
            if (articulo.IdArticulo == 0)
            {
                Entitys.Result result = Bussiness.Articulo.Add(articulo);
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
                if (articulo != null)
                {
                    Entitys.Result result = Bussiness.Articulo.Update(articulo);
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
        public ActionResult Delete(int? idArticulo)
        {
            Entitys.Articulo articulo = new Entitys.Articulo();
            if (articulo != null)
            {
                Entitys.Result result = Bussiness.Articulo.Delete(idArticulo.Value);
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
                return Redirect("/Articulo/GetAll");
            }
            return PartialView("Modal");
        }

        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}
