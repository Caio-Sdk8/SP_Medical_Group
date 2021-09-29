using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.Repositories;
using SpMedicalGroup.WebApi.ViewModels;
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

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_PacienteRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idPaciente}")]
        public IActionResult BuscarPorId(int idPaciente)
        {
            return Ok(_PacienteRepository.BuscarPorId(idPaciente));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(PacienteViewModel pac)
        {
            _PacienteRepository.Cadastrar(pac);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idPaciente}")]
        public IActionResult Atualizar(int idPaciente, Paciente PacienteAtualizada)
        {
            _PacienteRepository.Atualizar(idPaciente, PacienteAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idPaciente}")]
        public IActionResult Deletar(int idPaciente)
        {
            _PacienteRepository.Deletar(idPaciente);

            return StatusCode(204);
        }
    }
}
