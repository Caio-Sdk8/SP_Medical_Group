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

        public void Cadastrar(Medico novoMedico, Usuario novoUsuario)
        {
            usuarioPrafzr.Cadastrar(novoUsuario);

            novoMedico.IdUsuario = novoUsuario.IdUsuario;

            ctx.Medicos.Add(novoMedico);

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
