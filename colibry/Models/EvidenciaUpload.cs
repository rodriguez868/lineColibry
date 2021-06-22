using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace colibry.Models
{   

    public class EvidenciaUpload
    {
        public EvidenciaUpload()
        {
            Files = new List<HttpPostedFileBase>();
        }
        [Key]
        public List<HttpPostedFileBase> Files{ get; set; }
    }
}