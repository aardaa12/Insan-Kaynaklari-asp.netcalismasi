using Microsoft.AspNetCore.Mvc;

namespace İnsan_Kaynakları.Controllers
{
    public class AdayController1 : Controller
    {
        public IActionResult Index()
        {
           
            ViewBag.AdayAd1 = "Ahmet Yılmaz";
            ViewBag.AdayEmail1 = "ahmet@email.com";
            ViewBag.AdayPozisyon1 = "Yazılım Mühendisi";

            ViewBag.AdayAd2 = "Ayşe Demir";
            ViewBag.AdayEmail2 = "ayse@email.com";
            ViewBag.AdayPozisyon2 = "Pazarlama Uzmanı";

            return View();
        }
    }
}
