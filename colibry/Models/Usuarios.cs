using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colibry.Models
{   
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public String Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public String Apellido { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public String Username { get; set; }
       
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public String Password { get; set; }

        [Required]
        [Display(Name = "Id_rol")]
        public String Id_rol { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int Estado { get; set; }
    }
}