using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableCors]
    [BasicAuth]
    public class FornecedorController : ControllerBase
    {
        // GET: api/<FornecedorController>
        [HttpGet]
        public IEnumerable<Fornecedore> Get()
        {
            using (var context = new TesteDeliverItContext())
            {
                return context.Fornecedores.ToList().OrderByDescending(x=> x.Nome);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Fornecedore>> Post(Fornecedore value)
        {
            try
            {
                if (value == null)
                    return BadRequest();

                using (var context = new TesteDeliverItContext())
                {

                    context.Fornecedores.Add(value);
                    context.SaveChanges();

                    return value;

                }
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }
        }



    }
}
