using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> Listar();

        Especialidade BuscarPorId(int idEspecialidade);

        void Cadastrar(Especialidade novaEspecialidade);

        void Atualizar(int idEspecialidade, Especialidade EspecialidadeAtualizada);

        void Deletar(int idEspecialidade);
    }
}
