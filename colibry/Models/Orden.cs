using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colibry.Models
{
    [Table("ordenes")]
    public class Orden
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Sitio")]
        public String Sitio { get; set; }



        [Display(Name = "Fecha")]
        public String Fecha { get; set; }


        [Display(Name = "Direccion")]
        public String Direccion { get; set; }


        [Display(Name = "Tipo")]
        public String Tipo { get; set; }

        [Display(Name = "Latitud")]
        public float? Latitud { get; set; }


        [Display(Name = "Longitud")]
        public float? Longitud { get; set; }


        [Display(Name = "Altura")]
        public int? Altura { get; set; }


        [Display(Name = "Nivel_mar")]
        public int? Nivel_mar { get; set; }


        [Display(Name = "Tipo_ingreso")]
        public int? Tipo_ingreso { get; set; }


        [Display(Name = "Actividad")]
        public String Actividad { get; set; }

        [Display(Name = "Id_coordinador")]
        public int? Id_coordinador { get; set; }

        [Display(Name = "Id_tecnico")]
        public int? Id_tecnico { get; set; }

        [Display(Name = "Id_usuario")]
        public int? Id_usuario { get; set; }

        [Display(Name = "Estado")]
        public int? Estado { get; set; }
       
    }
}