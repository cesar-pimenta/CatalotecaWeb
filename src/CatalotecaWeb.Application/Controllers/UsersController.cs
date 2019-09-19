using System;
using System.Threading.Tasks;
using CatalotecaWeb.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace CatalotecaWeb.Application.Controllers
{
    //http://localhost:5000/api/users
    [Route ("api/[controller]")]
    [ApiController]  
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService service)
        {
            // Primeir coisa a validar é o state
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 400 Bad request - Solicitação Invalida
            }
            try
            {
                
            }
            catch (ArgumentException errors)
            {
                // tive que sair ...  Amanha continuo 
            }
        }
    }
}