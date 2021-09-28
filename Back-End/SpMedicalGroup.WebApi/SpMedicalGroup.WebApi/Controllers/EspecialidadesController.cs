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

        [HttpPost]
        public IActionResult Cadastrar(especialidade novaEspecialidade)
        {
            _EspecialidadeRepository.Cadastrar(novaEspecialidade);

            return StatusCode(201);
        }

        [HttpPut("{idEspecialidade}")]
        public IActionResult Atualizar(int idEspecialidade, especialidade EspecialidadeAtualizada)
        {
            _EspecialidadeRepository.Atualizar(idEspecialidade, EspecialidadeAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{idEspecialidade}")]
        public IActionResult Deletar(int idEspecialidade)
        {
            _EspecialidadeRepository.Deletar(idEspecialidade);

            return StatusCode(204);
        }
    }
}
