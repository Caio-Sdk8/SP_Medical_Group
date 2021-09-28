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
            consultum consultaSemDesc = BuscarPorId(idconsulta);

            consultaSemDesc.descricaoConsulta = consultaDesc;

            ctx.consulta.Update(consultaSemDesc);

            ctx.SaveChanges();
        }

        public void alterarSituacao(int idConsulta, short novaSituacao)
        {
            consultum consulta = BuscarPorId(idConsulta);

            consulta.idSituacao = novaSituacao;

            ctx.consulta.Update(consulta);

            ctx.SaveChanges();
        }

        public void cancelar(int idConsulta)
        {
            consultum consulta = BuscarPorId(idConsulta);

            consulta.idSituacao = 3;

            ctx.consulta.Update(consulta);

            ctx.SaveChanges();
        }

        public void Atualizar(int idConsulta, consultum consultaAtualizada)
        {
            consultum consultaBusc = BuscarPorId(idConsulta);

            consultaBusc.idMedico = consultaAtualizada.idMedico;
            consultaBusc.idPaciente = consultaAtualizada.idPaciente;
            consultaBusc.idSituacao = consultaAtualizada.idSituacao;
            if (consultaAtualizada.descricaoConsulta != null) {
                consultaBusc.descricaoConsulta = consultaAtualizada.descricaoConsulta;
            }
            consultaBusc.dataConsulta = consultaAtualizada.dataConsulta;
            consultaBusc.horarioConsulta = consultaAtualizada.horarioConsulta;

            ctx.consulta.Update(consultaBusc);

            ctx.SaveChanges();
        }

        public consultum BuscarPorId(int idConsulta)
        {
            return ctx.consulta.FirstOrDefault(ab => ab.idConsulta == idConsulta);
        }

        public void Cadastrar(consultum novaConsulta)
        {
            ctx.consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int idConsulta)
        {
            consultum consultaBuscada = BuscarPorId(idConsulta);

            ctx.consulta.Add(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<consultum> Listar()
        {
            return ctx.consulta.Select(x => new consultum
            {
                idConsulta = x.idConsulta,
                idSituacaoNavigation = new situacao
                {
                    descricaoSituacao = x.idSituacaoNavigation.descricaoSituacao
                },
                descricaoConsulta = x.descricaoConsulta,
                dataConsulta = x.dataConsulta,
                horarioConsulta = x.horarioConsulta,
                idMedicoNavigation = new medico
                {
                    idUsuarioNavigation = new usuario
                    {
                        nomeUsuario = x.idMedicoNavigation.idUsuarioNavigation.nomeUsuario
                    }
                },
                idPacienteNavigation = new paciente
                {
                    idUsuarioNavigation = new usuario
                    {
                        nomeUsuario = x.idMedicoNavigation.idUsuarioNavigation.nomeUsuario
                    }
                },
            }).ToList();
        }

        public List<consultum> listarMinhasPac(int idUsuario)
        {
            return ctx.consulta.Select(x => new consultum
            {
                idConsulta = x.idConsulta,
                idSituacaoNavigation = new situacao
                {
                    descricaoSituacao = x.idSituacaoNavigation.descricaoSituacao
                },
                descricaoConsulta = x.descricaoConsulta,
                dataConsulta = x.dataConsulta,
                horarioConsulta = x.horarioConsulta,
                idMedicoNavigation = new medico
                {
                    idUsuarioNavigation = new usuario
                    {
                        nomeUsuario = x.idMedicoNavigation.idUsuarioNavigation.nomeUsuario
                    }
                },
                idPacienteNavigation = new paciente
                {
                    idUsuarioNavigation = new usuario
                    {
                        nomeUsuario = x.idMedicoNavigation.idUsuarioNavigation.nomeUsuario
                    }
                },
            }).Where(x => x.idPacienteNavigation.idUsuario == idUsuario || x.idMedicoNavigation.idUsuario == idUsuario).ToList();
        }
    }
}
