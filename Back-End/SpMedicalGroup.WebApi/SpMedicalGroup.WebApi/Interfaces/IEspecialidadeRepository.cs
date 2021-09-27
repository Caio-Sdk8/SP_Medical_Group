using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<especialidade> Listar();

        especialidade BuscarPorId(int idEspecialidade);

        void Cadastrar(especialidade novaEspecialidade);

        void Atualizar(int idEspecialidade, especialidade EspecialidadeAtualizada);

        void Deletar(int idEspecialidade);
    }
}
