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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _PacienteRepository { get; set; }

        public PacientesController()
        {
            _PacienteRepository = new PacienteRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_PacienteRepository.Listar());
        }

        [HttpGet("{idPaciente}")]
        public IActionResult BuscarPorId(int idPaciente)
        {
            return Ok(_PacienteRepository.BuscarPorId(idPaciente));
        }

        [HttpPost]
        public IActionResult Cadastrar(paciente novaPaciente)
        {
            _PacienteRepository.Cadastrar(novaPaciente);

            return StatusCode(201);
        }

        [HttpPut("{idPaciente}")]
        public IActionResult Atualizar(int idPaciente, paciente PacienteAtualizada)
        {
            _PacienteRepository.Atualizar(idPaciente, PacienteAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idPaciente}")]
        public IActionResult Deletar(int idPaciente)
        {
            _PacienteRepository.Deletar(idPaciente);

            return StatusCode(204);
        }
    }
}
