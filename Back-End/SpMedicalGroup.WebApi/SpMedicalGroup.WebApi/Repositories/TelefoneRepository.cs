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
            throw new NotImplementedException();
        }

        public telefone BuscarPorId(int idTelefone)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(telefone novoTelefone)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idTelefone)
        {
            throw new NotImplementedException();
        }

        public List<telefone> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
