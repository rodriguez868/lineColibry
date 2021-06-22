using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colibry.Models
{   
    [Table("lineabase")]
    public class Lineabase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Id_orden")]
        public int Id_orden { get; set; }

        [Display(Name = "Id_tipo_datos")]
        public int Id_tipo_datos { get; set; }

        [Display(Name = "Id_sector")]
        public String Id_sector { get; set; }

        [Display(Name = "Nm_sector")]
        public String Nm_sector { get; set; }

        [Display(Name = "Id_item")]
        public String Id_item { get; set; }

        [Display(Name = "Nm_item")]
        public String Nm_item { get; set; }

        [Display(Name = "Antes")]
        public String Antes { get; set; }
       
        [Display(Name = "Despues")]
        public String Despues { get; set; }
    }
}