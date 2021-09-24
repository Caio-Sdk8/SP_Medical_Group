using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class medico
    {
        public medico()
        {
            consulta = new HashSet<consultum>();
        }

        public short idMedico { get; set; }
        public short idUsuario { get; set; }
        public short idClinica { get; set; }
        public short idEspecialidade { get; set; }
        public string crm { get; set; }

        public virtual clinica idClinicaNavigation { get; set; }
        public virtual especialidade idEspecialidadeNavigation { get; set; }
        public virtual usuario idUsuarioNavigation { get; set; }
        public virtual ICollection<consultum> consulta { get; set; }
    }
}
