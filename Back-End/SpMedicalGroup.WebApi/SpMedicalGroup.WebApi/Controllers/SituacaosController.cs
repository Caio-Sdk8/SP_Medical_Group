using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_SituacaoRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idSituacao}")]
        public IActionResult BuscarPorId(int idSituacao)
        {
            return Ok(_SituacaoRepository.BuscarPorId(idSituacao));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Situacao novaSituacao)
        {
            _SituacaoRepository.Cadastrar(novaSituacao);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idSituacao}")]
        public IActionResult Atualizar(int idSituacao, Situacao SituacaoAtualizada)
        {
            _SituacaoRepository.Atualizar(idSituacao, SituacaoAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idSituacao}")]
        public IActionResult Deletar(int idSituacao)
        {
            _SituacaoRepository.Deletar(idSituacao);

            return StatusCode(204);
        }
    }
}
