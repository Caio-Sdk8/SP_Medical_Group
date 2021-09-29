using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface ITelefoneRepository
    {
        List<Telefone> Listar();

        Telefone BuscarPorId(int idTelefone);

        void Cadastrar(Telefone novoTelefone);

        void Atualizar(int idTelefone, Telefone TelefoneAtualizado);

        void Deletar(int idTelefone);
    }
}
