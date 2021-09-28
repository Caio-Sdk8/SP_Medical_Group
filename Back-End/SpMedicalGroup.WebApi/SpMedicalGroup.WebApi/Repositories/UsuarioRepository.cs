using SpMedicalGroup.WebApi.Contexts;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalGpContext ctx = new SpMedicalGpContext();
        public void Atualizar(int idUsuario, usuario UsuarioAtualizado)
        {
            usuario usuarioBusc = BuscarPorId(idUsuario);

            if(UsuarioAtualizado.nomeUsuario != null)
            {
                usuarioBusc.nomeUsuario = UsuarioAtualizado.nomeUsuario;
            }
            if(UsuarioAtualizado.senhaUsuario != null)
            {
                usuarioBusc.senhaUsuario = UsuarioAtualizado.senhaUsuario;
            }
            if(UsuarioAtualizado.emailUsuario != null)
            {
                usuarioBusc.emailUsuario = UsuarioAtualizado.emailUsuario;
            }

            ctx.usuarios.Update(usuarioBusc);

            ctx.SaveChanges();
        }

        public usuario BuscarPorId(int idUsuario)
        {
            return ctx.usuarios.FirstOrDefault(ab => ab.idUsuario == idUsuario);
        }

        public void Cadastrar(usuario novoUsuario)
        {
            ctx.usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            usuario userBuscado = BuscarPorId(idUsuario);

            ctx.usuarios.Add(userBuscado);

            ctx.SaveChanges();
        }

        public List<usuario> Listar()
        {
            return ctx.usuarios.ToList();
        }
    }
}
