using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idMedico, medico MedicoAtualizado)
        {
            medico medicoBusc = BuscarPorId(idMedico);

            medicoBusc.idClinica = MedicoAtualizado.idClinica;

            ctx.medicos.Update(medicoBusc);

            ctx.SaveChanges();
        }

        public medico BuscarPorId(int idMedico)
        {
            return ctx.medicos.FirstOrDefault(ab => ab.idMedico == idMedico);
        }

        public void Cadastrar(medico novoMedico)
        {
            ctx.medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            medico medicoBuscado = BuscarPorId(idMedico);

            ctx.medicos.Add(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<medico> Listar()
        {
            return ctx.medicos.Select(x => new medico
            {
                idMedico = x.idMedico,
                idClinicaNavigation = new clinica
                {
                    nomeClinica = x.idClinicaNavigation.nomeClinica
                },
                idUsuarioNavigation = new usuario
                {
                    nomeUsuario = x.idUsuarioNavigation.nomeUsuario,
                    emailUsuario = x.idUsuarioNavigation.emailUsuario,
                },
                idEspecialidadeNavigation = new especialidade
                {
                    nomeEspecialidade = x.idEspecialidadeNavigation.nomeEspecialidade
                },
                crm = x.crm,
            }).ToList();
        }
    }
}
