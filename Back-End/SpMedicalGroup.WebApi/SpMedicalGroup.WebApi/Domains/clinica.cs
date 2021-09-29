using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public short IdClinica { get; set; }
        public short IdAdministrador { get; set; }
        public string NomeClinica { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string EnderecoClinica { get; set; }
        public TimeSpan HorarioInicial { get; set; }
        public TimeSpan DataFinal { get; set; }

        public virtual Administrador IdAdministradorNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
