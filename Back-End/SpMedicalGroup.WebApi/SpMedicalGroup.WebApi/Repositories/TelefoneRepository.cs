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
        public void Atualizar(int idTelefone, telefone TelefoneAtualizado)
        {
            telefone telefoneBusc = BuscarPorId(idTelefone);

            if(TelefoneAtualizado.numeroTelefone != null)
            {
                telefoneBusc.numeroTelefone = TelefoneAtualizado.numeroTelefone;
            }
            if(TelefoneAtualizado.idPaciente != null)
            {
                telefoneBusc.idPaciente = TelefoneAtualizado.idPaciente;
            }

            ctx.telefones.Update(telefoneBusc);

            ctx.SaveChanges();
        }

        public telefone BuscarPorId(int idTelefone)
        {
            return ctx.telefones.FirstOrDefault(ab => ab.idTelefone == idTelefone);
        }

        public void Cadastrar(telefone novoTelefone)
        {
            ctx.telefones.Add(novoTelefone);

            ctx.SaveChanges();
        }

        public void Deletar(int idTelefone)
        {
            telefone telefoneBusc = BuscarPorId(idTelefone);

            ctx.telefones.Add(telefoneBusc);

            ctx.SaveChanges();
        }

        public List<telefone> Listar()
        {
            return ctx.telefones.Select(x => new telefone { 
             idTelefone = x.idTelefone,
             idPacienteNavigation = new paciente
             {
                 idUsuarioNavigation = new usuario
                 {
                     nomeUsuario = x.idPacienteNavigation.idUsuarioNavigation.nomeUsuario
                 }
             },
             numeroTelefone = x.numeroTelefone
            }).ToList();
        }
    }
}
