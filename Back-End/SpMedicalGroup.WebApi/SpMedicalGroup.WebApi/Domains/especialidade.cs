using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class especialidade
    {
        public especialidade()
        {
            medicos = new HashSet<medico>();
        }

        public short idEspecialidade { get; set; }
        public string nomeEspecialidade { get; set; }

        public virtual ICollection<medico> medicos { get; set; }
    }
}
