using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class administrador
    {
        public administrador()
        {
            clinicas = new HashSet<clinica>();
        }

        public short idAdministrador { get; set; }
        public short idUsuario { get; set; }
        public string rgAdministrador { get; set; }
        public string cpfAdministrador { get; set; }

        public virtual usuario idUsuarioNavigation { get; set; }
        public virtual ICollection<clinica> clinicas { get; set; }
    }
}
