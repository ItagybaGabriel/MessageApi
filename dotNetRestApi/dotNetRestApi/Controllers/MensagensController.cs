using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotNetRestApi.Data;
using dotNetRestApi.Models;
using dotNetRestApi.Domain.Services;

namespace dotNetRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensagensController : ControllerBase
    {
        private readonly MensagemService _mensagemService;

        public MensagensController(MensagemService mensagemService)
        {
            this._mensagemService = mensagemService;
        }

        // GET
        [HttpGet("lista-mensagens")]
        public async Task<ActionResult<IEnumerable<Mensagem>>> GetMensagem()
        {
            try
            {
                return Ok(await _mensagemService.ListaTodasMensagem());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET
        [HttpGet("lista-mensagens/{id}")]
        public async Task<ActionResult<Mensagem>> GetMensagembyId(int id)
        {
            try
            {
                return Ok(await _mensagemService.FindMensagemById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("alterar-mensagem/{id}")]
        public async Task<IActionResult> AleterarMensagem([FromBody]Mensagem mensagem)
        {
            try
            {
                return Ok(await _mensagemService.AleterarMensagem(mensagem));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("nova-mensagem")]
        public async Task<ActionResult<Mensagem>> NovaMensagem([FromBody] Mensagem mensagem)
        {
            try
            {
                return Ok(await _mensagemService.RegistrarNovaMensagem(mensagem));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE
        [HttpDelete("deletar-mensagem/{id}")]
        public async Task<IActionResult> DeleteMensagem(int id)
        {
            try
            {
                return Ok(await _mensagemService.DeleteMensagem(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
