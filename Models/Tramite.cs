using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVCPrueba.Models
{
    public class Tramite
    {
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "No debe Exceder 20 caracteres")]
        [Display(Name = "Codigo de Tramite")]
        public string CodigoTramite { get; set; }

        [StringLength(50, ErrorMessage = "No debe Exceder 50 caracteres")]
        [Display(Name = "Nombre de Tramite")]
        public string NombreTramite { get; set; }

        public List<MunicipioTramite> MunicipioTramite { get; set; }
    }
}