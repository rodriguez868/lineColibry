using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colibry.Models
{   
    [Table("evidencias")]
    public class Evidencia
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Id_orden")]
        public int Id_orden { get; set; }
        
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [Display(Name = "Ruta")]
        public String Ruta { get; set; }

        [Display(Name = "Tamano")]
        public int Tamano { get; set; }
       
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }

        [Display(Name = "Content")]
        public String Content { get; set; }
    }
}