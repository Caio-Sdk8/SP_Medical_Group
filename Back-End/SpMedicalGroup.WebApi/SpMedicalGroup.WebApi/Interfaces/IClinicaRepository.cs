using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> Listar();

        Clinica BuscarPorId(int idClinica);

        void Cadastrar(Clinica novaClinica);

        void Atualizar(int idClinica, Clinica ClinicaAtualizada);

        void Deletar(int idClinica);
    }
}
