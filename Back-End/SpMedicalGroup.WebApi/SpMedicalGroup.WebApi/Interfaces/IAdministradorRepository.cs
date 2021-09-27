using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IAdministradorRepository
    {
        List<administrador> Listar();

        administrador BuscarPorId(int idAdministrador);

        void Cadastrar(administrador novoAdministrador);

        void Atualizar(int idAdministrador, administrador AdministradorAtualizado);

        void Deletar(int idAdministrador);
    }
}
