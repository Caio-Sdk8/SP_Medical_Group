using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class telefone
    {
        public short idTelefone { get; set; }
        public short? idPaciente { get; set; }
        public string numeroTelefone { get; set; }

        public virtual paciente idPacienteNavigation { get; set; }
    }
}
