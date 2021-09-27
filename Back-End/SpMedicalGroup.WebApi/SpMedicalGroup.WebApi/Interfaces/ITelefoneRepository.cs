using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface ITelefoneRepository
    {
        List<telefone> Listar();

        telefone BuscarPorId(int idTelefone);

        void Cadastrar(telefone novoTelefone);

        void Atualizar(int idTelefone, telefone TelefoneAtualizado);

        void Deletar(int idTelefone);
    }
}
