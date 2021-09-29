using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface ISituacaoRepository
    {
        List<Situacao> Listar();

        Situacao BuscarPorId(int idSituacao);

        void Cadastrar(Situacao novaSituacao);

        void Atualizar(int idSituacao, Situacao SituacaoAtualizada);

        void Deletar(int idSituacao);
    }
}
