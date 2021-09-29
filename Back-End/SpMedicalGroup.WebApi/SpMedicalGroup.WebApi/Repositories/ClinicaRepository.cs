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
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idClinica, Clinica ClinicaAtualizada)
        {
            Clinica ClinicaBuscada = BuscarPorId(idClinica);

            if (ClinicaAtualizada.NomeClinica != null)
            {
                ClinicaBuscada.NomeClinica = ClinicaAtualizada.NomeClinica;
            }
            if (ClinicaAtualizada.RazaoSocial != null)
            {
                ClinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;
            }
            if (ClinicaAtualizada.Cnpj != null)
            {
                ClinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;
            }
            if (ClinicaAtualizada.EnderecoClinica != null)
            {
                ClinicaBuscada.EnderecoClinica = ClinicaAtualizada.EnderecoClinica;
            }

            ClinicaBuscada.DataFinal = ClinicaAtualizada.DataFinal;
            ClinicaBuscada.HorarioInicial = ClinicaAtualizada.HorarioInicial;

            ctx.Clinicas.Update(ClinicaBuscada);

            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int idClinica)
        {
            return ctx.Clinicas.FirstOrDefault(ab => ab.IdClinica == idClinica);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            ctx.Clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            Clinica ClinicaBuscada = BuscarPorId(idClinica);

            ctx.Clinicas.Remove(ClinicaBuscada);

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinicas.Select(x => new Clinica
            {
                IdClinica = x.IdClinica,
                NomeClinica = x.NomeClinica,
                RazaoSocial = x.RazaoSocial,
                Cnpj = x.Cnpj,
                EnderecoClinica = x.EnderecoClinica,
                DataFinal = x.DataFinal,
                HorarioInicial = x.HorarioInicial,
                IdAdministradorNavigation = new Administrador
                {
                    IdUsuarioNavigation = new Usuario
                    {
                        NomeUsuario = x.IdAdministradorNavigation.IdUsuarioNavigation.NomeUsuario,
                        EmailUsuario = x.IdAdministradorNavigation.IdUsuarioNavigation.EmailUsuario
                    }
                }

            }).Include(a => a.IdAdministradorNavigation.IdUsuarioNavigation).ToList();
        }
    }
}
