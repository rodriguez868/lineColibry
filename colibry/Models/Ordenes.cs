using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace colibry.Models
{
    public class Ordenes
    {
        public int Id { get; set; }
        public String Sitio { get; set; }
     
        public String Fecha { get; set; }

        public String Direccion { get; set; }

        public String Tipo { get; set; }

        public float? Latitud { get; set; }

        public float? Longitud { get; set; }

        public int? Altura { get; set; }

        public int? Nivel_mar { get; set; }

        public int? Tipo_ingreso { get; set; }

        public String Actividad { get; set; }

        public int? Id_coordinador { get; set; }

        public int? Id_tecnico { get; set; }

        public int? Id_usuario { get; set; }

        public int? Estado { get; set; }

        public String nm_usuario { get; set; }
        public String nm_coordinador { get; set; }
        public String nm_tecnico { get; set; }
        public String nm_estado { get; set; }
        public String nm_tipo_torre { get; set; }
        public String nm_tipo_ingreso { get; set; }
        public String className { get; set; }


    }
}