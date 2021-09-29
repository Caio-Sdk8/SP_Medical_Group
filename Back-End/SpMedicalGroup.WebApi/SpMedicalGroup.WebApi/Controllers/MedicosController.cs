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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _MedicoRepository { get; set; }

        public MedicosController()
        {
            _MedicoRepository = new MedicoRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_MedicoRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idMedico}")]
        public IActionResult BuscarPorId(int idMedico)
        {
            return Ok(_MedicoRepository.BuscarPorId(idMedico));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(MedicoViewModel med)
        {
            _MedicoRepository.Cadastrar(med);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idMedico}")]
        public IActionResult Atualizar(int idMedico, Medico MedicoAtualizada)
        {
            _MedicoRepository.Atualizar(idMedico, MedicoAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            _MedicoRepository.Deletar(idMedico);

            return StatusCode(204);
        }
    }
}
