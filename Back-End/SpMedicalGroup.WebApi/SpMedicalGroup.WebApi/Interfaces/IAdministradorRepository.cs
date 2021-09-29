using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IAdministradorRepository
    {
        List<Administrador> Listar();

        Administrador BuscarPorId(int idAdministrador);

        void Cadastrar(AdminViewModel admin);

        void Atualizar(int idAdministrador, Administrador AdministradorAtualizado);

        void Deletar(int idAdministrador);
    }
}
