using System;
using System.Collections.Generic;

#nullable disable

namespace SpMedicalGroup.WebApi.Domains
{
    public partial class situacao
    {
        public situacao()
        {
            consulta = new HashSet<consultum>();
        }

        public short idSituacao { get; set; }
        public string descricaoSituacao { get; set; }

        public virtual ICollection<consultum> consulta { get; set; }
    }
}
