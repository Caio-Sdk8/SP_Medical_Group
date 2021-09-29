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
    public class AdministradoresController : ControllerBase
    {
        private IAdministradorRepository _AdministradorRepository { get; set; }

        public AdministradoresController()
        {
            _AdministradorRepository = new AdministradorRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_AdministradorRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idAdministrador}")]
        public IActionResult BuscarPorId(int idAdministrador)
        {
            return Ok(_AdministradorRepository.BuscarPorId(idAdministrador));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(AdminViewModel admin)
        {
            _AdministradorRepository.Cadastrar(admin);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idAdministrador}")]
        public IActionResult Atualizar(int idAdministrador, Administrador AdministradorAtualizada)
        {
            _AdministradorRepository.Atualizar(idAdministrador, AdministradorAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idAdministrador}")]
        public IActionResult Deletar(int idAdministrador)
        {
            _AdministradorRepository.Deletar(idAdministrador);

            return StatusCode(204);
        }
    }
}
