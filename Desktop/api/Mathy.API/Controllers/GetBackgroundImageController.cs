using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathy.API.Repository;
using Microsoft.AspNetCore.Mvc;
namespace Mathy.API.Controllers
{
    [Route("api/[Controller]")]
    public class GetBackgroundImageController : Controller
    {
        private readonly IImagensRepository _repository;

        public GetBackgroundImageController(IImagensRepository repository)
        {
            _repository = repository;
            
        }

        [HttpGet()]
        public IActionResult Get()
        {
            try
             {
                var imagens = _repository.GetBackgroundImage();

                return new ObjectResult(imagens);


            }catch(Exception e)
            {
                return StatusCode(500, new { erro = "Falha no servidor! Tente novamente mais tarde" });
            }
        }
    }
}