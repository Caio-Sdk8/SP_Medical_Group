using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class clinica
    {
        public clinica()
        {
            medicos = new HashSet<medico>();
        }

        public short idClinica { get; set; }
        public short idAdministrador { get; set; }
        public string nomeClinica { get; set; }
        public string razaoSocial { get; set; }
        public string cnpj { get; set; }
        public string enderecoClinica { get; set; }
        [Required]
        public TimeSpan horarioInicial { get; set; }
        public TimeSpan dataFinal { get; set; }

        public virtual administrador idAdministradorNavigation { get; set; }
        public virtual ICollection<medico> medicos { get; set; }
    }
}
