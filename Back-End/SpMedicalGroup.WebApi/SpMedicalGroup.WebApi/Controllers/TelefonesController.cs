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

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_TelefoneRepository.Listar());
        }

        [HttpGet("{idTelefone}")]
        public IActionResult BuscarPorId(int idTelefone)
        {
            return Ok(_TelefoneRepository.BuscarPorId(idTelefone));
        }

        [HttpPost]
        public IActionResult Cadastrar(telefone novaTelefone)
        {
            _TelefoneRepository.Cadastrar(novaTelefone);

            return StatusCode(201);
        }

        [HttpPut("{idTelefone}")]
        public IActionResult Atualizar(int idTelefone, telefone TelefoneAtualizada)
        {
            _TelefoneRepository.Atualizar(idTelefone, TelefoneAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idTelefone}")]
        public IActionResult Deletar(int idTelefone)
        {
            _TelefoneRepository.Deletar(idTelefone);

            return StatusCode(204);
        }
    }
}
