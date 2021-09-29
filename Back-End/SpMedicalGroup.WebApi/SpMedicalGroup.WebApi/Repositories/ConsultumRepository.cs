using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class ConsultumRepository : IConsultumRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        private short idAdministrador;

        public void adicionarDescricao(int idconsulta, string consultaDesc)
        {
            Consultum consultaSemDesc = BuscarPorId(idconsulta);

            consultaSemDesc.DescricaoConsulta = consultaDesc;

            ctx.Consulta.Update(consultaSemDesc);

            ctx.SaveChanges();
        }

        public void alterarSituacao(int idConsulta, short novaSituacao)
        {
            Consultum consulta = BuscarPorId(idConsulta);

            consulta.IdSituacao = novaSituacao;

            ctx.Consulta.Update(consulta);

            ctx.SaveChanges();
        }

        public void Atualizar(int idConsulta, Consultum consultaAtualizada)
        {
            Consultum consultaBusc = BuscarPorId(idConsulta);

            consultaBusc.IdMedico = consultaAtualizada.IdMedico;
            consultaBusc.IdPaciente = consultaAtualizada.IdPaciente;
            consultaBusc.IdSituacao = consultaAtualizada.IdSituacao;
            if (consultaAtualizada.DescricaoConsulta != null) {
                consultaBusc.DescricaoConsulta = consultaAtualizada.DescricaoConsulta;
            }
            consultaBusc.DataConsulta = consultaAtualizada.DataConsulta;
            consultaBusc.HorarioConsulta = consultaAtualizada.HorarioConsulta;

            ctx.Consulta.Update(consultaBusc);

            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(ab => ab.IdConsulta == idConsulta);
        }

        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            Consultum consultaBuscada = BuscarPorId(idConsulta);

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consultum> Listar()
        {
            return ctx.Consulta.Select(x => new Consultum
            {
                IdConsulta = x.IdConsulta,
                IdSituacaoNavigation = new Situacao
                {
                    DescricaoSituacao = x.IdSituacaoNavigation.DescricaoSituacao
                },
                DescricaoConsulta = x.DescricaoConsulta,
                DataConsulta = x.DataConsulta,
                HorarioConsulta = x.HorarioConsulta,
                IdMedicoNavigation = new Medico
                {
                    IdUsuarioNavigation = new Usuario
                    {
                        NomeUsuario = x.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario
                    }
                },
                IdPacienteNavigation = new Paciente
                {
                    IdUsuarioNavigation = new Usuario
                    {
                        NomeUsuario = x.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario
                    }
                },
            }).ToList();
        }

        public List<Consultum> listarMinhas(int idUsuario)
        {
            return ctx.Consulta.Select(x => new Consultum
            {
                IdConsulta = x.IdConsulta,
                IdSituacaoNavigation = new Situacao
                {
                    DescricaoSituacao = x.IdSituacaoNavigation.DescricaoSituacao
                },
                DescricaoConsulta = x.DescricaoConsulta,
                DataConsulta = x.DataConsulta,
                HorarioConsulta = x.HorarioConsulta,
                IdMedicoNavigation = new Medico
                {
                    IdUsuarioNavigation = new Usuario
                    {
                        NomeUsuario = x.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario
                    }
                },
                IdPacienteNavigation = new Paciente
                {
                    IdUsuarioNavigation = new Usuario
                    {
                        NomeUsuario = x.IdMedicoNavigation.IdUsuarioNavigation.NomeUsuario
                    }
                },
            }).Where(x => x.IdPacienteNavigation.IdUsuario == idUsuario || x.IdMedicoNavigation.IdUsuario == idUsuario).ToList();
        }
    }
}
