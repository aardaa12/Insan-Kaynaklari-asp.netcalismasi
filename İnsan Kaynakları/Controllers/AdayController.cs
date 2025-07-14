using İnsan_Kaynakları.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;

namespace İnsan_Kaynakları.Controllers
{
    public class AdayController : Controller
    {
        private static List<Aday> Adaylar = new List<Aday>
        {
                       
                new Aday
                {
                    Id = 1,
                    Ad = "Ahmet Yılmaz",
                    Mail = "ahmet@email.com",
                    Pozisyon = "Yazılım Mühendisi",
                    Numara = "+90 532 123 45 67",
                    UygulamaZamanı = DateTime.Now.AddDays(-5),
                    Deneyim = 3,
                    Yetenek = "C#, ASP.NET, SQL Server, JavaScript",
                    Eğitim = "Bilgisayar Mühendisliği",
                    Fotourl = "https://via.placeholder.com/150",
                    Statü = "Değerlendiriliyor"
                },
                new Aday
                {
                    Id = 2,
                    Ad = "Ayşe Demir",
                    Mail = "ayse@email.com",
                    Pozisyon = "Pazarlama Uzmanı",
                    Numara = "+90 533 987 65 43",
                    UygulamaZamanı = DateTime.Now.AddDays(-3),
                    Deneyim = 2,
                    Yetenek = "Digital Marketing, Social Media, SEO",
                    Eğitim = "İşletme",
                    Fotourl = "https://via.placeholder.com/150",
                    Statü = "Mülakata Çağrıldı"
                },
                new Aday
                {
                    Id = 3,
                    Ad = "Ahmey Kaya",
                    Mail = "ahmet@email.com",
                    Pozisyon = "Grafik Tasarım Uzmanı",
                    Numara = "+90 543 897 85 47",
                    UygulamaZamanı = DateTime.Now.AddDays(-9),
                    Deneyim = 7,
                    Yetenek = "Photoshop, İllüstrasyon,İç Dizayn",
                    Eğitim = "Grafik tasarım",
                    Fotourl = "https://via.placeholder.com/150",
                    Statü = "Yeni Başvuru"

                }

            

        };
        

        // READ - Show candidate details
        public IActionResult Detaylar(int id)
        {
            var Aday = Adaylar.FirstOrDefault(x => x.Id == id);
            if (Aday == null) return NotFound();
            return View(Aday);
        }

        // CREATE - Show create form
        public IActionResult Oluştur()
        {
            return View();
        }

        // CREATE - Handle form submission
        // CREATE - Handle form submission
        [HttpPost]
        public IActionResult Oluştur(Aday Aday)
        {
            // Skip validation for testing
            Aday.Id = Adaylar.Any() ? Adaylar.Max(c => c.Id) + 1 : 1;
            Aday.UygulamaZamanı = DateTime.Now;
            Aday.Fotourl = "https://via.placeholder.com/150";
            Adaylar.Add(Aday);

            TempData["SuccessMessage"] = $"Test: {Aday.Ad} eklendi!";
            return RedirectToAction("Index");
        }

        // UPDATE - Show edit form
        public IActionResult Edit(int id)
        {
            var candidate = Adaylar.FirstOrDefault(c => c.Id == id);
            if (candidate == null)
                return NotFound();

            return View(candidate);
        }

        // UPDATE - Handle form submission
        [HttpPost]
        public IActionResult Edit(Aday Aday)
        {
            if (ModelState.IsValid)
            {
                var existingCandidate = Adaylar.FirstOrDefault(c => c.Id == Aday.Id);
                if (existingCandidate != null)
                {
                    existingCandidate.Ad = Aday.Ad;
                    existingCandidate.Mail = Aday.Mail;
                    existingCandidate.Pozisyon = Aday.Pozisyon;
                    existingCandidate.Numara = Aday.Numara;
                    existingCandidate.Deneyim = Aday.Deneyim;
                    existingCandidate.Yetenek = Aday.Yetenek;
                    existingCandidate.Eğitim = Aday.Eğitim;
                    existingCandidate.Statü = Aday.Statü;

                    TempData["SuccessMessage"] = $"Aday '{Aday.Ad}' bilgileri başarıyla güncellendi.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Güncellenecek aday bulunamadı.";
                    return RedirectToAction("Index");
                }
               
            }
            TempData["ErrorMessage"] = "Aday güncellenirken bir hata oluştu. Lütfen bilgileri kontrol edin.";
            return View(Aday);
        }

        // DELETE - Show delete confirmation
        public IActionResult Delete(int id)
        {
            var candidate = Adaylar.FirstOrDefault(c => c.Id == id);
            if (candidate == null)
                return NotFound();

            return View(candidate);
        }

        // DELETE - Handle deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var candidate = Adaylar.FirstOrDefault(c => c.Id == id);
            if (candidate != null)
            {
                string candidateName = candidate.Ad;
                Adaylar.Remove(candidate);

                // Add success message
                TempData["SuccessMessage"] = $"Aday '{candidateName}' başarıyla silindi.";
            }

            else
            {
                TempData["ErrorMessage"] = "Silinecek aday bulunamadı.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 6; // Show 6 candidates per page (2 rows of 3 cards)

            // Get all candidates
            var allCandidates = Adaylar;

            // Create paginated list
            var paginatedCandidates = PaginatedList<Aday>.Create(allCandidates, page, pageSize);

            return View(paginatedCandidates);
        }
    }
}

