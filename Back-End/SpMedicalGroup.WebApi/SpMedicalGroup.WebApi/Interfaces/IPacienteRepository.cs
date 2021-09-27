using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IPacienteRepository
    {
        List<paciente> Listar();

        paciente BuscarPorId(int idPaciente);

        void Cadastrar(paciente novoPaciente);

        void Atualizar(int idPaciente, paciente PacienteAtualizado);

        void Deletar(int idPaciente);
    }
}
