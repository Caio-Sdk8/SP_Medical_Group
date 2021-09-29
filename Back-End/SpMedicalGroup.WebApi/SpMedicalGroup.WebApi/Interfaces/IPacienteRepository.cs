using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> Listar();

        Paciente BuscarPorId(int idPaciente);

        void Cadastrar(PacienteViewModel pac);

        void Atualizar(int idPaciente, Paciente PacienteAtualizado);

        void Deletar(int idPaciente);
    }
}
