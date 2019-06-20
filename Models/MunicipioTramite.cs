using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCPrueba.Models
{
    public class MunicipioTramite
    {
        public int Id { get; set; }

        public int MunicipioId { get; set; }

        public int TramiteId { get; set; }

        public Tramite Tramite { get; set; }

        public Municipio Municipio { get; set; }
    }
}