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
        public void Atualizar(int idClinica, clinica ClinicaAtualizada)
        {
            clinica clinicaBuscada = BuscarPorId(idClinica);

            if (ClinicaAtualizada.nomeClinica != null)
            {
                clinicaBuscada.nomeClinica = ClinicaAtualizada.nomeClinica;
            }
            if (ClinicaAtualizada.razaoSocial != null)
            {
                clinicaBuscada.razaoSocial = ClinicaAtualizada.razaoSocial;
            }
            if (ClinicaAtualizada.cnpj != null)
            {
                clinicaBuscada.cnpj = ClinicaAtualizada.cnpj;
            }
            if (ClinicaAtualizada.enderecoClinica != null)
            {
                clinicaBuscada.enderecoClinica = ClinicaAtualizada.enderecoClinica;
            }

            clinicaBuscada.dataFinal = ClinicaAtualizada.dataFinal;
            clinicaBuscada.horarioInicial = ClinicaAtualizada.horarioInicial;

            ctx.clinicas.Update(clinicaBuscada);

            ctx.SaveChanges();
        }

        public clinica BuscarPorId(int idClinica)
        {
            return ctx.clinicas.FirstOrDefault(ab => ab.idClinica == idClinica);
        }

        public void Cadastrar(clinica novaClinica)
        {
            ctx.clinicas.Add(novaClinica);

            ctx.SaveChanges();
        }

        public void Deletar(int idClinica)
        {
            clinica clinicaBuscada = BuscarPorId(idClinica);

            ctx.clinicas.Add(clinicaBuscada);

            ctx.SaveChanges();
        }

        public List<clinica> Listar()
        {
            return ctx.clinicas.Select(x => new clinica
            {
                idClinica = x.idClinica,
                nomeClinica = x.nomeClinica,
                razaoSocial = x.razaoSocial,
                cnpj = x.cnpj,
                enderecoClinica = x.enderecoClinica,
                dataFinal = x.dataFinal,
                horarioInicial = x.horarioInicial,
                idAdministradorNavigation = new administrador
                {
                    idUsuarioNavigation = new usuario
                    {
                        nomeUsuario = x.idAdministradorNavigation.idUsuarioNavigation.nomeUsuario,
                        emailUsuario = x.idAdministradorNavigation.idUsuarioNavigation.emailUsuario
                    }
                }

            }).Include(a => a.idAdministradorNavigation.idUsuarioNavigation).ToList();
        }
    }
}
