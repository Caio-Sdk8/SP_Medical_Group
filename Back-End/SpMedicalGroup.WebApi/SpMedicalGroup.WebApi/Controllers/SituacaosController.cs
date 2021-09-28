using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaosController : ControllerBase
    {
        private ISituacaoRepository _SituacaoRepository { get; set; }

        public SituacaosController()
        {
            _SituacaoRepository = new SituacaoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_SituacaoRepository.Listar());
        }

        [HttpGet("{idSituacao}")]
        public IActionResult BuscarPorId(int idSituacao)
        {
            return Ok(_SituacaoRepository.BuscarPorId(idSituacao));
        }

        [HttpPost]
        public IActionResult Cadastrar(situacao novaSituacao)
        {
            _SituacaoRepository.Cadastrar(novaSituacao);

            return StatusCode(201);
        }

        [HttpPut("{idSituacao}")]
        public IActionResult Atualizar(int idSituacao, situacao SituacaoAtualizada)
        {
            _SituacaoRepository.Atualizar(idSituacao, SituacaoAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idSituacao}")]
        public IActionResult Deletar(int idSituacao)
        {
            _SituacaoRepository.Deletar(idSituacao);

            return StatusCode(204);
        }
    }
}
