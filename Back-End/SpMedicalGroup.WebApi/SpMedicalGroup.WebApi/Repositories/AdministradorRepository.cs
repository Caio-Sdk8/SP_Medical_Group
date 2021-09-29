using Microsoft.EntityFrameworkCore;
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
    public class AdministradorRepository : IAdministradorRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        UsuarioRepository usuarioPrafzr = new UsuarioRepository();
        public void Atualizar(int idAdministrador, Administrador AdministradorAtualizado)
        {
            Administrador AdminBuscado = BuscarPorId(idAdministrador);

            if (AdministradorAtualizado.RgAdministrador != null)
            {
                AdminBuscado.RgAdministrador = AdministradorAtualizado.RgAdministrador;
            }
            if (AdministradorAtualizado.CpfAdministrador != null)
            {
                AdminBuscado.CpfAdministrador = AdministradorAtualizado.CpfAdministrador;
            }

            ctx.Administradors.Update(AdminBuscado);

            ctx.SaveChanges();
        }

        public Administrador BuscarPorId(int idAdministrador)
        {
            return ctx.Administradors.FirstOrDefault(ab => ab.IdAdministrador == idAdministrador);
        }

        public void Cadastrar(AdminViewModel admin)
        {
            Administrador adm = new Administrador();
            Usuario u = new Usuario();

            u.EmailUsuario = admin.EmailUsuario;
            u.IdTipoUsuario = admin.IdTipoUsuario;
            u.SenhaUsuario = admin.SenhaUsuario;
            u.NomeUsuario = admin.NomeUsuario;

            usuarioPrafzr.Cadastrar(u);

            adm.RgAdministrador = admin.RgAdministrador;
            adm.CpfAdministrador = admin.CpfAdministrador;
            adm.IdUsuario = u.IdUsuario;

            ctx.Administradors.Add(adm);

            ctx.SaveChanges();
        }

        public void Deletar(int idAdministrador)
        {

            Administrador adminBuscado = BuscarPorId(idAdministrador);

            int idUsuario = adminBuscado.IdUsuario;

            ctx.Administradors.Remove(adminBuscado);

            ctx.SaveChanges();

            usuarioPrafzr.Deletar(idUsuario);
        }

        public List<Administrador> Listar()
        {
            return ctx.Administradors.Select(x => new Administrador
            {
                IdAdministrador = x.IdAdministrador,
                CpfAdministrador = x.CpfAdministrador,
                RgAdministrador = x.RgAdministrador,
                IdUsuarioNavigation = new Usuario
                {
                    NomeUsuario = x.IdUsuarioNavigation.NomeUsuario,
                    EmailUsuario = x.IdUsuarioNavigation.EmailUsuario
                }
            }).ToList();
        }
    }
}
