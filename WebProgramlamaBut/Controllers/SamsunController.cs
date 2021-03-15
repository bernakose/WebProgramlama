using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlamaBut.Models;

namespace WebProgramlamaBut.Controllers
{
    public class SamsunController : Controller
    {
        Anket survey = new Anket();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string bir, List<string> iki, List<string> uc)
        {
            if (string.IsNullOrEmpty(bir))
            {
                ModelState.AddModelError("err1", "Bir seçenek seçmelisiniz.");
                return View();
            }
            if (iki == null)
            {
                ModelState.AddModelError("err2", "En az bir seçenek seçmelisiniz.");
                return View();
            }
            if (uc == null)
            {
                ModelState.AddModelError("err3", "En az bir seçenek seçmelisiniz.");
                return View();
            }
            if (string.IsNullOrEmpty(bir) || iki == null || uc == null)
            {
                ModelState.AddModelError("error", "Bu alan boş bırakılamaz.");
                return View();
            }
            if (uc != null)
            {
                foreach (var item in uc)
                {
                    if (item != "a" && item != "b" && item != "c")
                    {
                        ModelState.AddModelError("err3", "Lütfen kutucuklara sadece a,b,c şıklarını yazın.");
                        return View();
                    }
                }
            }
            
            AnketSoru soru1 = new AnketSoru();
            soru1.secilenCevap = bir;
            AnketSoru soru2 = new AnketSoru();
            string temp = "";
            for (int i = 0; i < iki.Count; i++)
            {
                if (i < iki.Count() - 1)
                    temp += iki[i] + ", ";
                else
                    temp += iki[i];
            }
            soru2.secilenCevap = temp;
            AnketSoru soru3 = new AnketSoru();
            string temp1 = "";
            for (int i = 0; i < uc.Count; i++)
            {
                if (i < uc.Count() - 1)
                    temp1 += uc[i] + ", ";
                else
                    temp1 += uc[i];
            }
            soru3.secilenCevap = temp1;
            survey.soruEkle(soru1);
            survey.soruEkle(soru2);
            survey.soruEkle(soru3);
            survey.kullanici = Kisiler.kullanici;
            Kisiler.anketEkle(survey);
            return RedirectToAction("sonucTablosu");
        }
        public ActionResult sonucTablosu()
        {

            if (Kisiler.getAnketler() != null)
                return View(Kisiler.getAnketler());
            else
                return HttpNotFound();
        }
        public ActionResult Sil(string id)
        {
            var ankets = Kisiler.getTumAnketler();
            int index = 0;
            int say = 0;
            if (ankets.Count > 0)
            {
                foreach (var item in ankets)
                {
                    if (item.kullanici == id)
                    {
                        index = say;
                    }
                    say++;
                }
                ankets.RemoveAt(index);
                return RedirectToAction("sonucTablosu");
            }
            else
            {
                return HttpNotFound();
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string kullanici)
        {
            var kisiler = Kisiler.getTumAnketler();
            bool aynikisivarmi = false;
            Kisiler.kullanici = kullanici;
            if (kisiler.Count == 0)
                return RedirectToAction("Index");
            else
            {
                foreach (var item in kisiler)
                {
                    if (item.kullanici == kullanici)
                    {
                        aynikisivarmi = true;
                    }
                }
                if (aynikisivarmi == true)
                {
                    return RedirectToAction("sonucTablosu");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
    }
}