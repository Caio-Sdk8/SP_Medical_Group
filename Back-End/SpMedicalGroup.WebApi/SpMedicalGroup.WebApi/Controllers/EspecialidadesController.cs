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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadeRepository _EspecialidadeRepository { get; set; }

        public EspecialidadesController()
        {
            _EspecialidadeRepository = new EspecialidadeRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_EspecialidadeRepository.Listar());
        }

        [HttpGet("{idEspecialidade}")]
        public IActionResult BuscarPorId(int idEspecialidade)
        {
            return Ok(_EspecialidadeRepository.BuscarPorId(idEspecialidade));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Especialidade novaEspecialidade)
        {
            _EspecialidadeRepository.Cadastrar(novaEspecialidade);

            return StatusCode(201);
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idEspecialidade}")]
        public IActionResult Atualizar(int idEspecialidade, Especialidade EspecialidadeAtualizada)
        {
            _EspecialidadeRepository.Atualizar(idEspecialidade, EspecialidadeAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{idEspecialidade}")]
        public IActionResult Deletar(int idEspecialidade)
        {
            _EspecialidadeRepository.Deletar(idEspecialidade);

            return StatusCode(204);
        }
    }
}
