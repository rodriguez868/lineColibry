using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colibry.Models
{   
    [Table("usuarios")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public String Id_rol { get; set; }
        public int Estado { get; set; }
        public String Rol { get; set; }
        public int rolId { get; set; }

    }
}