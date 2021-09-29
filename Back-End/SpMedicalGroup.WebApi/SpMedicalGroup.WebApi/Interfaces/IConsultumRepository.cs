using SpMedicalGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Interfaces
{
    interface IConsultumRepository
    {
        public void alterarSituacao(int idConsulta, short idSituacao);

        public void adicionarDescricao(int consulta, string consultaDesc);

        List<Consultum> listarMinhas(int idPaciente);

        List<Consultum> Listar();

        Consultum BuscarPorId(int idConsulta);

        void Cadastrar(Consultum novaConsulta);

        void Atualizar(int idConsulta, Consultum consultaAtualizada);

        void Deletar(int idConsulta);
    }
}
