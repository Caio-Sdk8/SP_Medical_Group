using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idMedico, medico MedicoAtualizado)
        {
            throw new NotImplementedException();
        }

        public medico BuscarPorId(int idMedico)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(medico novoMedico)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idMedico)
        {
            throw new NotImplementedException();
        }

        public List<medico> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
