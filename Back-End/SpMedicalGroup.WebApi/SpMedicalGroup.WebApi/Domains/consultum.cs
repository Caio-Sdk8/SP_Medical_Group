using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class consultum
    {
        public short idConsulta { get; set; }
        public short idMedico { get; set; }
        public short idSituacao { get; set; }
        public short idPaciente { get; set; }
        public DateTime dataConsulta { get; set; }
        public TimeSpan horarioConsulta { get; set; }
        public string descricaoConsulta { get; set; }

        public virtual medico idMedicoNavigation { get; set; }
        public virtual paciente idPacienteNavigation { get; set; }
        public virtual situacao idSituacaoNavigation { get; set; }
    }
}
