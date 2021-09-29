using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.ViewModels
{
    public class MedicoViewModel
    {
        [Required]
        public short IdMedico { get; set; }
        [Required]
        public short IdUsuario { get; set; }

        public short IdClinica { get; set; }
        [Required]
        public short IdEspecialidade { get; set; }
        [Required]
        public string Crm { get; set; }
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        public string EmailUsuario { get; set; }
        [Required]
        public string SenhaUsuario { get; set; }
        [Required]
        public short? IdTipoUsuario { get; set; }
    }
}
