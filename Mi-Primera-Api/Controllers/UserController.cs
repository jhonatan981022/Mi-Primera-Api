using Mi_Primera_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mi_Primera_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private static List<ResponseUser> users = new List<ResponseUser>()
        {
            new ResponseUser {Nombre = "olga", Edad = 43, Categoria = "mayor de edad"},
            new ResponseUser {Nombre = "federico", Edad = 16, Categoria = "menor de edad"},
            new ResponseUser {Nombre = "antonio", Edad = 23, Categoria = "mayor de edad"}
        };

        [HttpGet]
        [Route("GetUsers")]
        public IEnumerable<ResponseUser> GetUsers()
        {
            return users;
        }

        [HttpPost]
        [Route("CreateUser")]
        public ActionResult<ResponseUser> CreateUser(RequestUser requestUser)
        {
            if (requestUser.Edad < 0)
            {
                return BadRequest("La edad no puede ser negativa.");
            }

            var responseUser = new ResponseUser
            {
                Nombre = requestUser.Nombre,
                Edad = requestUser.Edad,
                Categoria = requestUser.Edad >= 18 ? "mayor de edad" : "menor de edad"
            };

            users.Add(responseUser);
            return Ok(responseUser);
         
        }
    }
}
