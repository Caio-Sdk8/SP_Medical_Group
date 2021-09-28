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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicosController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_MedicoRepository.Listar());
        }

        [HttpGet("{idMedico}")]
        public IActionResult BuscarPorId(int idMedico)
        {
            return Ok(_MedicoRepository.BuscarPorId(idMedico));
        }

        [HttpPost]
        public IActionResult Cadastrar(medico novaMedico)
        {
            _MedicoRepository.Cadastrar(novaMedico);

            return StatusCode(201);
        }

        [HttpPut("{idMedico}")]
        public IActionResult Atualizar(int idMedico, medico MedicoAtualizada)
        {
            _MedicoRepository.Atualizar(idMedico, MedicoAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            _MedicoRepository.Deletar(idMedico);

            return StatusCode(204);
        }
    }
}
