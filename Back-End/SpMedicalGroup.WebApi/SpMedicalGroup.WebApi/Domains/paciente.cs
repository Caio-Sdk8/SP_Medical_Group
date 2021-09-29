using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
            Telefones = new HashSet<Telefone>();
        }

        public short IdPaciente { get; set; }
        public short IdUsuario { get; set; }
        public string RgPaciente { get; set; }
        public string CpfPaciente { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
