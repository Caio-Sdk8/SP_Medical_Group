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

        public void cancelar(int idConsulta);

        public void adicionarDescricao(int consulta, string consultaDesc);

        List<consultum> listarMinhasPac(int idPaciente);

        List<consultum> Listar();

        consultum BuscarPorId(int idConsulta);

        void Cadastrar(consultum novaConsulta);

        void Atualizar(int idConsulta, consultum consultaAtualizada);

        void Deletar(int idConsulta);
    }
}
