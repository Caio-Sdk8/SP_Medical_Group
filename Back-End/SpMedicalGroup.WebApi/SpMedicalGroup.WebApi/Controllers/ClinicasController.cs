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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_clinicaRepository.Listar());
        }


        [HttpGet("{idclinica}")]
        public IActionResult BuscarPorId(int idclinica)
        {
            return Ok(_clinicaRepository.BuscarPorId(idclinica));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaclinica)
        {
            _clinicaRepository.Cadastrar(novaclinica);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idclinica}")]
        public IActionResult Atualizar(int idclinica, Clinica clinicaAtualizada)
        {
            _clinicaRepository.Atualizar(idclinica, clinicaAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idclinica}")]
        public IActionResult Deletar(int idclinica)
        {
            _clinicaRepository.Deletar(idclinica);

            return StatusCode(204);
        }
    }
}
