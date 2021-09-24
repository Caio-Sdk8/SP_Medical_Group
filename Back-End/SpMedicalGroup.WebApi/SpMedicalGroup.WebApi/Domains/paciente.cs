using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class paciente
    {
        public paciente()
        {
            consulta = new HashSet<consultum>();
            telefones = new HashSet<telefone>();
        }

        public short idPaciente { get; set; }
        public short idUsuario { get; set; }
        public string rgPaciente { get; set; }
        public string cpfPaciente { get; set; }
        public DateTime dataNascimento { get; set; }

        public virtual usuario idUsuarioNavigation { get; set; }
        public virtual ICollection<consultum> consulta { get; set; }
        public virtual ICollection<telefone> telefones { get; set; }
    }
}
