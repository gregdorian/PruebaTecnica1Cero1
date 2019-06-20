using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebMVCPrueba.Models
{
    public class MunicipiosDB : DbContext
    {
        public MunicipiosDB()
            : base ("MpioConnectionString")
        {

        }

        public static MunicipiosDB Create()
        {
            return new MunicipiosDB();
        }

        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Tramite> Tramites { get; set; }
        public DbSet<MunicipioTramite> MunicipioTramite { get; set; }

    }
}