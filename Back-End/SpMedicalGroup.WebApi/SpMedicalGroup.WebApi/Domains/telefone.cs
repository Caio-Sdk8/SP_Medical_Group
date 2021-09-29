using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Telefone
    {
        public short IdTelefone { get; set; }
        public short? IdPaciente { get; set; }
        public string NumeroTelefone { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
