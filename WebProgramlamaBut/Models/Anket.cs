using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProgramlamaBut.Models
{
    public class Anket
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public List<AnketSoru> anketsorular;
        public string kullanici { get; set; }
        public Anket()
        {
            anketsorular = new List<AnketSoru>();
            kullanici = "";
        }
        public List<AnketSoru> getSorular() { return anketsorular; }
        public void soruEkle(AnketSoru q)
        {
            anketsorular.Add(q);
        }
    }
}