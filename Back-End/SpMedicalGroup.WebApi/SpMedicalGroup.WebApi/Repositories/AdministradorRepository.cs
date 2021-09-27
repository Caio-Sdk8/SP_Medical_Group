using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idAdministrador, administrador AdministradorAtualizado)
        {
            administrador adminBuscado = BuscarPorId(idAdministrador);

            if (AdministradorAtualizado.rgAdministrador != null)
            {
                adminBuscado.rgAdministrador = AdministradorAtualizado.rgAdministrador;
            }
            if (AdministradorAtualizado.cpfAdministrador != null)
            {
                adminBuscado.cpfAdministrador = AdministradorAtualizado.cpfAdministrador;
            }

            ctx.administradors.Update(adminBuscado);

            ctx.SaveChanges();
        }

        public administrador BuscarPorId(int idAdministrador)
        {
            return ctx.administradors.FirstOrDefault(ab => ab.idAdministrador == idAdministrador);
        }

        public void Cadastrar(administrador novoAdministrador)
        {
            ctx.administradors.Add(novoAdministrador);

            ctx.SaveChanges();
        }

        public void Deletar(int idAdministrador)
        {

            administrador adminBuscado = BuscarPorId(idAdministrador);

            ctx.administradors.Add(adminBuscado);

            ctx.SaveChanges();
        }

        public List<administrador> Listar()
        {
            return ctx.administradors.Select(x => new administrador
            {
                idAdministrador = x.idAdministrador,
                cpfAdministrador = x.cpfAdministrador,
                rgAdministrador = x.rgAdministrador,
                idUsuarioNavigation = new usuario
                {
                    nomeUsuario = x.idUsuarioNavigation.nomeUsuario,
                    emailUsuario = x.idUsuarioNavigation.emailUsuario
                }
            }).ToList();
        }
    }
}
