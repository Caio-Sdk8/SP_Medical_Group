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
            situacao situacaoBusc = BuscarPorId(idSituacao);

            if(SituacaoAtualizada.descricaoSituacao != null)
            {
                situacaoBusc.descricaoSituacao = SituacaoAtualizada.descricaoSituacao;
            }

            ctx.situacaos.Update(situacaoBusc);

            ctx.SaveChanges();
        }

        public situacao BuscarPorId(int idSituacao)
        {
            return ctx.situacaos.FirstOrDefault(ab => ab.idSituacao == idSituacao);
        }

        public void Cadastrar(situacao novaSituacao)
        {
            ctx.situacaos.Add(novaSituacao);

            ctx.SaveChanges();
        }

        public void Deletar(int idSituacao)
        {
            situacao situcaoBusc = BuscarPorId(idSituacao);

            ctx.situacaos.Add(situcaoBusc);

            ctx.SaveChanges();
        }

        public List<situacao> Listar()
        {
            return ctx.situacaos.ToList();
        }
    }
}
