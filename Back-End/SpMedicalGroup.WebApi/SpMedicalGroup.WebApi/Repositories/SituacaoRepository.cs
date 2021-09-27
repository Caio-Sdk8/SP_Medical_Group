using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idSituacao, situacao SituacaoAtualizada)
        {
            throw new NotImplementedException();
        }

        public situacao BuscarPorId(int idSituacao)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(situacao novaSituacao)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idSituacao)
        {
            throw new NotImplementedException();
        }

        public List<situacao> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
