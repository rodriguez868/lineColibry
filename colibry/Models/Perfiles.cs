using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colibry.Models
{
    [Table("roles")]
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

    }
}