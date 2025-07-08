using Microsoft.AspNetCore.Mvc;

namespace İnsan_Kaynakları.Controllers
{
    public class İşController : Controller
    {
        public IActionResult Index()
        {
            
            ViewBag.Isbaslık1 = "Yazılım Mühendisi";
            ViewBag.Sirket1 = "Yazılım şirketi";
            ViewBag.Isdetay1 = "Yanımızda çalışacak genç yetenek arıyoruz";

            ViewBag.Isbaslık2 = "Pazarlama Uzmanı";
            ViewBag.Sirket2 = "Digital Marketing Co";
            ViewBag.Isdetay2 = "Sosyal Medya içeriği ve hesapları yönet";

            return View();
        }
    }
}
