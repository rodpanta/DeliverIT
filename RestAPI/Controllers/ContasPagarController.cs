using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableCors]
    [BasicAuth]
    public class ContasPagarController : ControllerBase
    {
        private IPagamentoConta _pagamentoconta;


        public ContasPagarController(IPagamentoConta pagamento)
        {
            _pagamentoconta = pagamento;
        }


        // GET: api/GetContas
        [HttpGet("GetContas")]
        public async Task<ActionResult<IEnumerable<ContasApagar>>> GetContas()
        {

            try
            {
                return _pagamentoconta.TodasContas();
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }

        }

        // GET: api/GetContasemAberto
        [HttpGet("GetContasemAberto")]
        public async Task<ActionResult<IEnumerable<ContasApagar>>> GetContasemAberto()
        {
            try
            {
                return _pagamentoconta.ContasEmAberto();
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }
        }


        // GET: api/GetContasPagas
        [HttpGet("GetContasPagas")]
        public async Task<ActionResult<IEnumerable<ContasApagar>>> GetContasPagas()
        {
            try
            {
                return _pagamentoconta.ContasPagas();
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }
        }

        // GET api/<ContasPagarController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContasApagar>> Get(int id)
        {

            try
            {
                return _pagamentoconta.Conta(id);
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }

        }

        // GET api/<ContasPagarController>/5
        [HttpGet("valoratual/{id}")]
        public async Task<ActionResult<ContasApagar>> ValorAtual(int id)
        {

            try
            {
                return _pagamentoconta.ValorAtualConta(id);
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }

        }

        // GET api/<ContasPagarController>/5
        [HttpGet("pagamento/{id}")]
        public async Task<ActionResult<ContasApagar>> Pagamento(int id)
        {
            using (var context = new TesteDeliverItContext())
            {
                var todoItemDTO = context.ContasApagars.Include(x => x.fornecedor).Where(x => x.Id == id && x.DataPagamento == null).FirstOrDefault();

                if (id != todoItemDTO.Id)
                {
                    return BadRequest();
                }


                if (todoItemDTO == null)
                {
                    return NotFound();
                }

                try
                {
                    _pagamentoconta.EfetuarPagamentoConta(id);
                }
                catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
                {
                    return NotFound();
                }

                return NoContent();
            }
        }

        // POST api/<ContasPagarController>
        [HttpPost]
        public async Task<ActionResult<ContasApagar>> Post (ContasApagar value)
        {
            try
            {
                if (value == null)
                    return BadRequest();

                using (var context = new TesteDeliverItContext())
                {

                    _pagamentoconta.CriarConta(value);

                    return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
                }
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }
        }


        [HttpPost("create")]
        public async Task<ActionResult<ContasApagar>> Create(ContasApagar value)
        {
            try
            {
                if (value == null)
                    return BadRequest();

                using (var context = new TesteDeliverItContext())
                {

                    _pagamentoconta.CriarConta(value);

                    return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
                }
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }
        }


        // PUT api/<ContasPagarController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ContasApagar>> Put (long id, ContasApagar todoItemDTO)
        {
            using (var context = new TesteDeliverItContext())
            {
                if (id != todoItemDTO.Id)
                {
                    return BadRequest();
                }

                var updateItem =  context.ContasApagars.Where(x => x.Id == id).FirstOrDefault();
                if (updateItem == null)
                {
                    return NotFound();
                }

                try
                {
                   return  _pagamentoconta.AlterarConta(todoItemDTO);

                }
                catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
                {
                    return NotFound();
                }

                return NoContent();
            }
        }

        private bool TodoItemExists(long id)
        {
            using (var context = new TesteDeliverItContext())
            {
                return context.ContasApagars.Any(e => e.Id == id);
            }
        }

        // DELETE api/<ContasPagarController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                _pagamentoconta.ExcluirConta(id);
            }
            catch (Exception oex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao criar o registro");
            }

            return NoContent();
        }

    }
}
