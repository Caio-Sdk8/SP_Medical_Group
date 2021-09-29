using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.ViewModels
{
    public class AdminViewModel
    {
        [Required]
        public short IdAdministrador { get; set; }

        public short IdUsuario { get; set; }
        [Required]
        public string RgAdministrador { get; set; }
        [Required]
        public string CpfAdministrador { get; set; }
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
