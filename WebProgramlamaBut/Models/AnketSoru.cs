using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProgramlamaBut.Models
{
    public class AnketSoru
    {
        public string tanim { get; set; }
        public List<string> satirlar { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string secilenCevap { get; set; }
    }
}