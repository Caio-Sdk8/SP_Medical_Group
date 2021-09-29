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
    public class TelefonesController : ControllerBase
    {
        private ITelefoneRepository _TelefoneRepository { get; set; }

        public TelefonesController()
        {
            _TelefoneRepository = new TelefoneRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_TelefoneRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idTelefone}")]
        public IActionResult BuscarPorId(int idTelefone)
        {
            return Ok(_TelefoneRepository.BuscarPorId(idTelefone));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Telefone novaTelefone)
        {
            _TelefoneRepository.Cadastrar(novaTelefone);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idTelefone}")]
        public IActionResult Atualizar(int idTelefone, Telefone TelefoneAtualizada)
        {
            _TelefoneRepository.Atualizar(idTelefone, TelefoneAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idTelefone}")]
        public IActionResult Deletar(int idTelefone)
        {
            _TelefoneRepository.Deletar(idTelefone);

            return StatusCode(204);
        }
    }
}
