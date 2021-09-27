using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<usuario> Listar();

        usuario BuscarPorId(int idUsuario);

        void Cadastrar(usuario novoUsuario);

        void Atualizar(int idUsuario, usuario UsuarioAtualizado);

        void Deletar(int idUsuario);
    }
}
