using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        List<Medico> Listar();

        Medico BuscarPorId(int idMedico);

        void Cadastrar(MedicoViewModel med);

        void Atualizar(int idMedico, Medico MedicoAtualizado);

        void Deletar(int idMedico);
    }
}
