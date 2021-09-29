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

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.EmailUsuario == email && u.SenhaUsuario == senha);
        }

        public void Atualizar(int idUsuario, Usuario UsuarioAtualizado)
        {
            Usuario usuarioBusc = BuscarPorId(idUsuario);

            if(UsuarioAtualizado.NomeUsuario != null)
            {
                usuarioBusc.NomeUsuario = UsuarioAtualizado.NomeUsuario;
            }
            if(UsuarioAtualizado.SenhaUsuario != null)
            {
                usuarioBusc.SenhaUsuario = UsuarioAtualizado.SenhaUsuario;
            }
            if(UsuarioAtualizado.EmailUsuario != null)
            {
                usuarioBusc.EmailUsuario = UsuarioAtualizado.EmailUsuario;
            }

            ctx.Usuarios.Update(usuarioBusc);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(ab => ab.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            Usuario userBuscado = BuscarPorId(idUsuario);

            ctx.Usuarios.Remove(userBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
