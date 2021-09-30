using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        UsuarioRepository usuarioPrafzr = new UsuarioRepository();

        public void Atualizar(int idMedico, Medico MedicoAtualizado)
        {
            Medico MedicoBusc = BuscarPorId(idMedico);

            MedicoBusc.IdClinica = MedicoAtualizado.IdClinica;

            ctx.Medicos.Update(MedicoBusc);

            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(ab => ab.IdMedico == idMedico);
        }

        public void Cadastrar(MedicoViewModel med)
        {
            Medico medicu = new Medico();
            Usuario u = new Usuario();

            u.EmailUsuario = med.EmailUsuario;
            u.IdTipoUsuario = med.IdTipoUsuario;
            u.SenhaUsuario = med.SenhaUsuario;
            u.NomeUsuario = med.NomeUsuario;

            usuarioPrafzr.Cadastrar(u);

            medicu.Crm = med.Crm;
            medicu.IdClinica = med.IdClinica;
            medicu.IdEspecialidade = med.IdEspecialidade;
            medicu.IdUsuario = u.IdUsuario;

            ctx.Medicos.Add(medicu);

            ctx.SaveChanges();
        }

        public void Deletar(int idMedico)
        {
            Medico MedicoBuscado = BuscarPorId(idMedico);

            int idUsuario = MedicoBuscado.IdUsuario;

            ctx.Medicos.Remove(MedicoBuscado);

            ctx.SaveChanges();

            usuarioPrafzr.Deletar(idUsuario);
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.Select(x => new Medico
            {
                IdMedico = x.IdMedico,
                IdClinicaNavigation = new Clinica
                {
                    NomeClinica = x.IdClinicaNavigation.NomeClinica
                },
                IdUsuarioNavigation = new Usuario
                {
                    NomeUsuario = x.IdUsuarioNavigation.NomeUsuario,
                    EmailUsuario = x.IdUsuarioNavigation.EmailUsuario,
                },
                IdEspecialidadeNavigation = new Especialidade
                {
                    NomeEspecialidade = x.IdEspecialidadeNavigation.NomeEspecialidade
                },
                Crm = x.Crm,
            }).ToList();
        }
    }
}
