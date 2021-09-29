using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int IdEspecialIdade, Especialidade EspecialIdadeAtualizada)
        {
            Especialidade EspecialIdadeBusc = BuscarPorId(IdEspecialIdade);

            if (EspecialIdadeAtualizada.NomeEspecialidade != null)
            {
                EspecialIdadeBusc.NomeEspecialidade = EspecialIdadeAtualizada.NomeEspecialidade;
            }

            ctx.Especialidades.Update(EspecialIdadeBusc);

            ctx.SaveChanges();
        }

        public Especialidade BuscarPorId(int IdEspecialIdade)
        {
            return ctx.Especialidades.FirstOrDefault(ab => ab.IdEspecialidade == IdEspecialIdade);
        }

        public void Cadastrar(Especialidade novaEspecialIdade)
        {
            ctx.Especialidades.Add(novaEspecialIdade);

            ctx.SaveChanges();
        }

        public void Deletar(int IdEspecialIdade)
        {
            Especialidade EspecialIdadeBusc = BuscarPorId(IdEspecialIdade);

            ctx.Especialidades.Remove(EspecialIdadeBusc);

            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
