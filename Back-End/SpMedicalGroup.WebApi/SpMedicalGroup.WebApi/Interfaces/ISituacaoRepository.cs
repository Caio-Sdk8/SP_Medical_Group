using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface ISituacaoRepository
    {
        List<situacao> Listar();

        situacao BuscarPorId(int idSituacao);

        void Cadastrar(situacao novaSituacao);

        void Atualizar(int idSituacao, situacao SituacaoAtualizada);

        void Deletar(int idSituacao);
    }
}
