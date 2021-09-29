using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.ViewModels
{
    public class PacienteViewModel
    {
        [Required]
        public string NomeUsuario { get; set; }
        [Required]
        public string EmailUsuario { get; set; }
        [Required]
        public string SenhaUsuario { get; set; }
        [Required]
        public short? IdTipoUsuario { get; set; }
        [Required]
        public short IdPaciente { get; set; }
        [Required]
        public short IdUsuario { get; set; }
        [Required]
        public string RgPaciente { get; set; }
        [Required]
        public string CpfPaciente { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}
