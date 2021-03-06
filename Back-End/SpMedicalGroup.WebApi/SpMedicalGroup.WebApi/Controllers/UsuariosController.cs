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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_UsuarioRepository.Listar());
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            return Ok(_UsuarioRepository.BuscarPorId(idUsuario));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Usuario novaUsuario)
        {
            _UsuarioRepository.Cadastrar(novaUsuario);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario UsuarioAtualizada)
        {
            _UsuarioRepository.Atualizar(idUsuario, UsuarioAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _UsuarioRepository.Deletar(idUsuario);

            return StatusCode(204);
        }
    }
}
