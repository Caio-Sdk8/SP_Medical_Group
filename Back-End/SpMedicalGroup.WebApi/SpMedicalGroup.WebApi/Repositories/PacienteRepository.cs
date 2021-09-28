using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idPaciente, paciente PacienteAtualizado)
        {
            paciente pacienteBusc = BuscarPorId(idPaciente);

            pacienteBusc.idUsuario = PacienteAtualizado.idUsuario;

            if(PacienteAtualizado.rgPaciente != null) 
            {
                pacienteBusc.rgPaciente = PacienteAtualizado.rgPaciente;
            }
            if (PacienteAtualizado.cpfPaciente != null) 
            {
                pacienteBusc.cpfPaciente = PacienteAtualizado.cpfPaciente;
            }

            pacienteBusc.dataNascimento = PacienteAtualizado.dataNascimento;

            ctx.pacientes.Update(pacienteBusc);

            ctx.SaveChanges();
        }

        public paciente BuscarPorId(int idPaciente)
        {
            return ctx.pacientes.FirstOrDefault(ab => ab.idPaciente == idPaciente);
        }

        public void Cadastrar(paciente novoPaciente)
        {
            ctx.pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            paciente pacienteBuscado = BuscarPorId(idPaciente);

            ctx.pacientes.Add(pacienteBuscado);

            ctx.SaveChanges();
        }

        public List<paciente> Listar()
        {
            return ctx.pacientes.Select(x => new paciente
            {
                idPaciente = x.idPaciente,
                rgPaciente = x.rgPaciente,
                idUsuarioNavigation = new usuario
                {
                    nomeUsuario = x.idUsuarioNavigation.nomeUsuario,
                    emailUsuario = x.idUsuarioNavigation.emailUsuario,
                },
                cpfPaciente = x.cpfPaciente,
                dataNascimento = x.dataNascimento
            }).ToList();
        }
    }
}
