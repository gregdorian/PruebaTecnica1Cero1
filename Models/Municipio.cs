using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVCPrueba.Models
{
    public class Municipio
    {
        public int Id { get; set; }

        [StringLength(8,ErrorMessage ="No debe Exceder 8 caracteres")]
        [Display(Name ="Codigo de Municipio")]
        public string CodigoMunicipio { get; set; }

        [StringLength(50, ErrorMessage = "No debe Exceder 50 caracteres")]
        [Display(Name = "Nombre de Municipio")]
        public string NombreMunicipio { get; set; }

        public List<MunicipioTramite> MunicipioTramite { get; set; }
    }
}