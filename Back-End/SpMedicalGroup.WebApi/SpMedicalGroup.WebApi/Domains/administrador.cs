using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class Administrador
    {
        public Administrador()
        {
            Clinicas = new HashSet<Clinica>();
        }

        public short IdAdministrador { get; set; }
        public short IdUsuario { get; set; }
        public string RgAdministrador { get; set; }
        public string CpfAdministrador { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Clinica> Clinicas { get; set; }
    }
}
