using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        List<medico> Listar();

        medico BuscarPorId(int idMedico);

        void Cadastrar(medico novoMedico);

        void Atualizar(int idMedico, medico MedicoAtualizado);

        void Deletar(int idMedico);
    }
}
