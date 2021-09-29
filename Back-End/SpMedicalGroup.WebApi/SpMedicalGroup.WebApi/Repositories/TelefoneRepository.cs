using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idTelefone, Telefone TelefoneAtualizado)
        {
            Telefone TelefoneBusc = BuscarPorId(idTelefone);

            if(TelefoneAtualizado.NumeroTelefone != null)
            {
                TelefoneBusc.NumeroTelefone = TelefoneAtualizado.NumeroTelefone;
            }
            if(TelefoneAtualizado.IdPaciente != null)
            {
                TelefoneBusc.IdPaciente = TelefoneAtualizado.IdPaciente;
            }

            ctx.Telefones.Update(TelefoneBusc);

            ctx.SaveChanges();
        }

        public Telefone BuscarPorId(int idTelefone)
        {
            return ctx.Telefones.FirstOrDefault(ab => ab.IdTelefone == idTelefone);
        }

        public void Cadastrar(Telefone novoTelefone)
        {
            ctx.Telefones.Add(novoTelefone);

            ctx.SaveChanges();
        }

        public void Deletar(int idTelefone)
        {
            Telefone TelefoneBusc = BuscarPorId(idTelefone);

            ctx.Telefones.Remove(TelefoneBusc);

            ctx.SaveChanges();
        }

        public List<Telefone> Listar()
        {
            return ctx.Telefones.Select(x => new Telefone { 
             IdTelefone = x.IdTelefone,
             IdPacienteNavigation = new Paciente
             {
                 IdUsuarioNavigation = new Usuario
                 {
                     NomeUsuario = x.IdPacienteNavigation.IdUsuarioNavigation.NomeUsuario
                 }
             },
             NumeroTelefone = x.NumeroTelefone
            }).ToList();
        }
    }
}
