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
        UsuarioRepository usuarioPrafzr = new UsuarioRepository();
        
        public void Atualizar(int idPaciente, Paciente PacienteAtualizado)
        {
            Paciente PacienteBusc = BuscarPorId(idPaciente);

            PacienteBusc.IdUsuario = PacienteAtualizado.IdUsuario;

            if(PacienteAtualizado.RgPaciente != null) 
            {
                PacienteBusc.RgPaciente = PacienteAtualizado.RgPaciente;
            }
            if (PacienteAtualizado.CpfPaciente != null) 
            {
                PacienteBusc.CpfPaciente = PacienteAtualizado.CpfPaciente;
            }

            PacienteBusc.DataNascimento = PacienteAtualizado.DataNascimento;

            ctx.Pacientes.Update(PacienteBusc);

            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(ab => ab.IdPaciente == idPaciente);
        }

        public void Cadastrar(Paciente novoPaciente, Usuario novoUsuario)
        {
            usuarioPrafzr.Cadastrar(novoUsuario);

            novoPaciente.IdUsuario = novoUsuario.IdUsuario;

            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        public void Deletar(int idPaciente)
        {
            Paciente PacienteBuscado = BuscarPorId(idPaciente);

            int idUsuario = PacienteBuscado.IdUsuario;

            ctx.Pacientes.Remove(PacienteBuscado);

            ctx.SaveChanges();

            usuarioPrafzr.Deletar(idUsuario);
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes.Select(x => new Paciente
            {
                IdPaciente = x.IdPaciente,
                RgPaciente = x.RgPaciente,
                IdUsuarioNavigation = new Usuario
                {
                    NomeUsuario = x.IdUsuarioNavigation.NomeUsuario,
                    EmailUsuario = x.IdUsuarioNavigation.EmailUsuario,
                },
                CpfPaciente = x.CpfPaciente,
                DataNascimento = x.DataNascimento
            }).ToList();
        }
    }
}
