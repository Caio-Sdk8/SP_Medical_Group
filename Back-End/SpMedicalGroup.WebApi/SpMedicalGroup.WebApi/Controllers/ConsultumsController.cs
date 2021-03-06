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
    public class ConsultumsController : ControllerBase
    {
        private IConsultumRepository _ConsultumRepository { get; set; }

        public ConsultumsController()
        {
            _ConsultumRepository = new ConsultumRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_ConsultumRepository.Listar());
        }


        [HttpGet("{idConsultum}")]
        public IActionResult BuscarPorId(int idConsultum)
        {
            return Ok(_ConsultumRepository.BuscarPorId(idConsultum));
        }
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Consultum novaConsultum)
        {
            _ConsultumRepository.Cadastrar(novaConsultum);

            return StatusCode(201);
        }

        [Authorize(Roles = "1,3")]
        [HttpPut("{idConsultum}")]
        public IActionResult Atualizar(int idConsultum, Consultum ConsultumAtualizada)
        {
            _ConsultumRepository.Atualizar(idConsultum, ConsultumAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idConsultum}")]
        public IActionResult Deletar(int idConsultum)
        {
            _ConsultumRepository.Deletar(idConsultum);

            return StatusCode(204);
        }
    }
}
