using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace colibry.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ColibryDb : DbContext
    {
        public ColibryDb() : base("connectDB") 
        { 

        }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Orden> Ordenes { get; set; }
        public virtual DbSet<Evidencia> Evidencias { get; set; }
        public virtual DbSet<Lineabase> Lineabase { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }


    }

}
