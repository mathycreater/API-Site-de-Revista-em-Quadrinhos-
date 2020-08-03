using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathy.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mathy.API.Controllers
{
    [Route("api/[Controller]")]
    public class AutorController : Controller
    {
        private readonly IAutorRepository _repository;

        public AutorController(IAutorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var autor = _repository.Get();
                return new ObjectResult(autor);


            }catch(Exception e)
            {
                return StatusCode(500, new { erro = "Falha no servidor! Tente novamente mais tarde" });
            }
        }
    }
}