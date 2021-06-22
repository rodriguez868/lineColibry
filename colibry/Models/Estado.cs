using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colibry.Models
{
    [Table("estados")]
    public class Estados
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

    }
}