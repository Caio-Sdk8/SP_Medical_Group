using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        List<clinica> Listar();

        clinica BuscarPorId(int idClinica);

        void Cadastrar(clinica novaClinica);

        void Atualizar(int idClinica, clinica ClinicaAtualizada);

        void Deletar(int idClinica);
    }
}
