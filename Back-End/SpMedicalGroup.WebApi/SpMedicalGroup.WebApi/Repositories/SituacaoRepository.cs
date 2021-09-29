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
        public void Atualizar(int idSituacao, Situacao SituacaoAtualizada)
        {
            Situacao SituacaoBusc = BuscarPorId(idSituacao);

            if(SituacaoAtualizada.DescricaoSituacao != null)
            {
                SituacaoBusc.DescricaoSituacao = SituacaoAtualizada.DescricaoSituacao;
            }

            ctx.Situacaos.Update(SituacaoBusc);

            ctx.SaveChanges();
        }

        public Situacao BuscarPorId(int idSituacao)
        {
            return ctx.Situacaos.FirstOrDefault(ab => ab.IdSituacao == idSituacao);
        }

        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idSituacao)
        {
            Situacao situcaoBusc = BuscarPorId(idSituacao);

            ctx.Situacaos.Remove(situcaoBusc);

            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
