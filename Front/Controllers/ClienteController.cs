
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Front.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            Entitys.Cliente cliente = new Entitys.Cliente();
            Entitys.Result result = Bussiness.Cliente.GetAll(cliente);
            if (result.Correct)
            {
                cliente.Clientes = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult GetAll(Entitys.Cliente cliente)
        {
            Entitys.Result result = Bussiness.Cliente.GetAll(cliente);
            if (result.Correct)
            {
                cliente.Clientes = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(cliente);
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
        public ActionResult Form(int? IdCliente)
        {
            Entitys.Cliente cliente = new Entitys.Cliente();

            Entitys.Result resultpais = Bussiness.Pais.GetAll();
            cliente.DireccionCliente = new Entitys.DireccionCliente();
            cliente.DireccionCliente.Colonia = new Entitys.Colonia();
            cliente.DireccionCliente.Colonia.Municipio = new Entitys.Municipio();
            cliente.DireccionCliente.Colonia.Municipio.Estado = new Entitys.Estado();
            cliente.DireccionCliente.Colonia.Municipio.Estado.Pais = new Entitys.Pais();

            cliente.Usuario = new Entitys.Usuario();

            if (IdCliente == null)
            {
                cliente.DireccionCliente.Colonia.Municipio.Estado.Pais.Paises = resultpais.Objects;
                return View(cliente);
            }
            else
            {
                Entitys.Result result = Bussiness.Cliente.GetById(IdCliente.Value);           
                if (result.Correct)
                {
                    cliente = (Entitys.Cliente)result.Object;
                    cliente.DireccionCliente.Colonia.Municipio.Estado.Pais.Paises = resultpais.Objects;

                    Entitys.Result resultEstado = Bussiness.Estado.GetByIdPais(cliente.DireccionCliente.Colonia.Municipio.Estado.Pais.IdPais);
                    cliente.DireccionCliente.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                    Entitys.Result resultMunicipio = Bussiness.Municipio.GetByIdEstado(cliente.DireccionCliente.Colonia.Municipio.Estado.IdEstado);
                    cliente.DireccionCliente.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    Entitys.Result resultColonia = Bussiness.Colonia.GetByIdMunicipio(cliente.DireccionCliente.Colonia.Municipio.IdMunicipio);
                    cliente.DireccionCliente.Colonia.Colonias = resultColonia.Objects;

                    return View(cliente);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al buscar el cliente";
                }
                return View(cliente);
            }
        }

        [HttpPost]
        public ActionResult Form(Entitys.Cliente cliente)
        {
            IFormFile image = Request.Form.Files["FileImage"];
            if (image != null)
            {
                byte[] ImagenBytes = ConvertToBytes(image);
                cliente.Usuario.Imagen = Convert.ToBase64String(ImagenBytes);
            }
            //ADD
            if (cliente.IdCliente == 0)
            {
                Entitys.Result result = Bussiness.Cliente.Add(cliente);               
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
                if (cliente != null)
                {
                    Entitys.Result result = Bussiness.Cliente.Update(cliente);                    
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
        public ActionResult Delete(int? idCliente)
        {
            Entitys.Cliente cliente = new Entitys.Cliente();
            if (cliente != null)
            {
                Entitys.Result result = Bussiness.Cliente.Delete(idCliente.Value);               
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
                return Redirect("/Cliente/GetAll");
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
