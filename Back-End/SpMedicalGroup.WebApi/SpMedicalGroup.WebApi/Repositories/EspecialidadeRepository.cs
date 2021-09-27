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
        public void Atualizar(int idEspecialidade, especialidade EspecialidadeAtualizada)
        {
            especialidade especialidadeBusc = BuscarPorId(idEspecialidade);

            if (EspecialidadeAtualizada.nomeEspecialidade != null)
            {
                especialidadeBusc.nomeEspecialidade = EspecialidadeAtualizada.nomeEspecialidade;
            }

            ctx.especialidades.Update(especialidadeBusc);

            ctx.SaveChanges();
        }

        public especialidade BuscarPorId(int idEspecialidade)
        {
            return ctx.especialidades.FirstOrDefault(ab => ab.idEspecialidade == idEspecialidade);
        }

        public void Cadastrar(especialidade novaEspecialidade)
        {
            ctx.especialidades.Add(novaEspecialidade);

            ctx.SaveChanges();
        }

        public void Deletar(int idEspecialidade)
        {
            especialidade especialidadeBusc = BuscarPorId(idEspecialidade);

            ctx.especialidades.Add(especialidadeBusc);

            ctx.SaveChanges();
        }

        public List<especialidade> Listar()
        {
            return ctx.especialidades.ToList();
        }
    }
}
