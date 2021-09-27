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
    public class AdministradoresController : ControllerBase
    {
        private IAdministradorRepository _AdministradorRepository { get; set; }

        public AdministradoresController()
        {
            _AdministradorRepository = new AdministradorRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_AdministradorRepository.Listar());
        }

        [HttpGet("{idAdministrador}")]
        public IActionResult BuscarPorId(int idAdministrador)
        {
            return Ok(_AdministradorRepository.BuscarPorId(idAdministrador));
        }

        [HttpPost]
        public IActionResult Cadastrar(administrador novaAdministrador)
        {
            _AdministradorRepository.Cadastrar(novaAdministrador);

            return StatusCode(201);
        }

        [HttpPut("{idAdministrador}")]
        public IActionResult Atualizar(int idAdministrador, administrador AdministradorAtualizada)
        {
            _AdministradorRepository.Atualizar(idAdministrador, AdministradorAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idAdministrador}")]
        public IActionResult Deletar(int idAdministrador)
        {
            _AdministradorRepository.Deletar(idAdministrador);

            return StatusCode(204);
        }
    }
}
