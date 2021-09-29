using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        public Usuario Login(string email, string senha);

        Usuario BuscarPorId(int idUsuario);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int idUsuario, Usuario UsuarioAtualizado);

        void Deletar(int idUsuario);
    }
}
