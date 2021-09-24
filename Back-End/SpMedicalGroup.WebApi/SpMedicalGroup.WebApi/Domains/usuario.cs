using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class usuario
    {
        public short idUsuario { get; set; }
        public string nomeUsuario { get; set; }
        public string emailUsuario { get; set; }
        public string senhaUsuario { get; set; }

        public virtual administrador administrador { get; set; }
        public virtual medico medico { get; set; }
        public virtual paciente paciente { get; set; }
    }
}
