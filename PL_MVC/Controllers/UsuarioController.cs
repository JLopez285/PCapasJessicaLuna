using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAll();
            //siempre inicialiar lista de objetos (colección)
            usuario.Usuarios = new List<object>();

            if(result.Correct)
            {
                usuario.Usuarios = result.Objects;//unboxing
                return View(usuario);
            }
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = new ML.Result();
            if( idUsuario == null )
            {
                return View(usuario);
            }
            else
            {
                result = BL.Usuario.GetById(idUsuario.Value);
                if(result.Correct)
                {
                    usuario = (ML.Usuario) result.Object;
                    return View(usuario);
                }
                else
                {
                    return View(usuario);
                }
            }
        }
        
        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            if(usuario.IdUsuario==0)
            {
                result = BL.Usuario.Add(usuario);
                if(result.Correct)
                {
                    ViewBag.Message = "El usuario se agrego correctamente";
                }
                else
                {
                    ViewBag.Message = "El usuario se no se agrego";
                }
            }
            else
            {
                result = BL.Usuario.Update(usuario);
                if(result.Correct)
                {
                    ViewBag.Message = "El usuario se actualizo correctamente";

                }
                else
                {
                    ViewBag.Message = "El usuario no se actualizo";
                }
            }
            return PartialView("ValidationModal");
        }
    }
}