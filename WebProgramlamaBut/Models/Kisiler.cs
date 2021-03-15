using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProgramlamaBut.Models
{
    public class Kisiler
    {
        public static List<Anket> anketler = new List<Anket>();
        public static string kullanici { get; set; }
        public static List<Anket> getAnketler()
        {
            if (kullanici == "Admin")
            {
                return anketler.ToList();
            }
            else
                return anketler.Where(a => a.kullanici == kullanici).ToList(); ;
        }
        public static List<Anket> getTumAnketler()
        {
            return anketler;
        }
        public static void anketEkle(Anket sA)
        {
            anketler.Add(sA);
        }
    }
}