using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCPrueba.ViewModel
{
    public class MunicipioTramiteViewModel
    {
        public int MunicipioTramiteId { get; set; }

        public string CodigoMunicipio { get; set; }
        public string NombreMunicipio { get; set; }

        public string CodigoTramite { get; set; }
        public string NombreTramite { get; set; }

        public SelectList MunicipioTramite { get; set; }
    }
}