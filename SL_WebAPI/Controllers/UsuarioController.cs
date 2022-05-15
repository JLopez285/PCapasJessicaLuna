using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebAPI.Controllers
{

    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        [HttpGet]
        [Route("usuario/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll2();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("usuario/Add")]
        public IHttpActionResult Add([FromBody] ML.Usuario usuario)
        {
            ML.Usuario resultUser = new ML.Usuario();
            resultUser.Usuarios = new List<object>();
            ML.Result result = new ML.Result();
            result = BL.Usuario.Add(usuario);
            //foreach (var dato in usuario.Usuarios)
            //{
            //    ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(dato.ToString());
            //   // resultUser.Usuarios.Add(resultItemList);
            //    

            //    if (!result.Correct) {
            //        break;
            //    }

            //}

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("usuario/Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            ML.Result result = BL.Usuario.Delete(id);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
