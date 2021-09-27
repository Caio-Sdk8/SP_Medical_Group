using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idPaciente, paciente PacienteAtualizado)
        {
            throw new NotImplementedException();
        }

        public paciente BuscarPorId(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(paciente novoPaciente)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idPaciente)
        {
            throw new NotImplementedException();
        }

        public List<paciente> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
