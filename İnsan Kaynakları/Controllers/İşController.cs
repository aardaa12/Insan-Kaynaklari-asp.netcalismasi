using İnsan_Kaynakları.Models;
using Microsoft.AspNetCore.Mvc;

namespace İnsan_Kaynakları.Controllers
{
    public class İşController : Controller
    {
        // Sample job data - will replace ViewBag approach
        private static List<İş> İşİlanları = new List<İş>
        {
            new İş
            {
                Id = 1,
                Başlık = "Yazılım Mühendisi",
                Şirket = "TechCorp A.Ş.",
                Açıklama = "Modern web uygulamaları geliştiren deneyimli yazılım mühendisi arıyoruz. ASP.NET Core ve React teknolojilerinde çalışacaksınız.",
                Gereksinimler = "Bilgisayar Mühendisliği veya ilgili bölüm mezunu, C# ve JavaScript bilgisi",
                Konum = "İstanbul, Türkiye",
                MaaşAralığı = "15.000 - 25.000 TL",
                GerekenDeneyim = 2,
                ÇalışmaTipi = "Tam Zamanlı",
                İlanTarihi = DateTime.Now.AddDays(-5),
                SonBaşvuruTarihi = DateTime.Now.AddDays(25),
                Durum = "Aktif",
                İletişim = "hr@techcorp.com",
                ArananYetenekler = new List<string> { "C#", "ASP.NET Core", "JavaScript", "React", "SQL Server" }
            },
            new İş
            {
                Id = 2,
                Başlık = "Pazarlama Uzmanı",
                Şirket = "Digital Marketing Pro",
                Açıklama = "Sosyal medya kampanyaları yönetecek ve dijital pazarlama stratejileri geliştirecek dinamik pazarlama uzmanı arıyoruz.",
                Gereksinimler = "İşletme, Pazarlama veya ilgili bölüm mezunu, sosyal medya deneyimi",
                Konum = "Ankara, Türkiye",
                MaaşAralığı = "8.000 - 15.000 TL",
                GerekenDeneyim = 1,
                ÇalışmaTipi = "Tam Zamanlı",
                İlanTarihi = DateTime.Now.AddDays(-3),
                SonBaşvuruTarihi = DateTime.Now.AddDays(20),
                Durum = "Aktif",
                İletişim = "kariyer@digitalmarketing.com",
                ArananYetenekler = new List<string> { "Social Media", "SEO", "Google Ads", "Content Marketing", "Analytics" }
            },
            new İş
            {
                Id = 3,
                Başlık = "Grafik Tasarım Uzmanı",
                Şirket = "Creative Studio",
                Açıklama = "Yaratıcı projeler üzerinde çalışacak, marka kimliklerini tasarlayacak grafik tasarımcı arıyoruz.",
                Gereksinimler = "Grafik Tasarım mezunu, Adobe Creative Suite bilgisi zorunlu",
                Konum = "İzmir, Türkiye",
                MaaşAralığı = "10.000 - 18.000 TL",
                GerekenDeneyim = 3,
                ÇalışmaTipi = "Tam Zamanlı",
                İlanTarihi = DateTime.Now.AddDays(-7),
                SonBaşvuruTarihi = DateTime.Now.AddDays(15),
                Durum = "Aktif",
                İletişim = "jobs@creativestudio.com",
                ArananYetenekler = new List<string> { "Photoshop", "Illustrator", "InDesign", "Brand Design", "Typography" }
            }
        };

        // GET: İş İlanları Listesi
        public IActionResult Index()
        {
            return View(İşİlanları);
        }

        // GET: İş İlanı Detayları
        public IActionResult İşDetay(int id)
        {
            var iş = İşİlanları.FirstOrDefault(i => i.Id == id);
            if (iş == null)
                return NotFound();

            return View(iş);
        }

        // GET: Yeni İş İlanı Oluştur
        public IActionResult İlanOluştur()
        {
            return View();
        }

        // POST: Yeni İş İlanı Kaydet
        [HttpPost]
        public IActionResult İlanOluştur(İş iş, string ArananYetenekler)
        {
            // Parse skills from JSON string
            if (!string.IsNullOrEmpty(ArananYetenekler))
            {
                try
                {
                    iş.ArananYetenekler = System.Text.Json.JsonSerializer.Deserialize<List<string>>(ArananYetenekler);
                }
                catch
                {
                    iş.ArananYetenekler = new List<string>();
                }
            }

            if (ModelState.IsValid)
            {
                // Generate new ID
                iş.Id = İşİlanları.Any() ? İşİlanları.Max(i => i.Id) + 1 : 1;
                iş.İlanTarihi = DateTime.Now;
                if (string.IsNullOrEmpty(iş.Durum)) iş.Durum = "Aktif";

                İşİlanları.Add(iş);
                TempData["SuccessMessage"] = $"Yeni iş ilanı '{iş.Başlık}' başarıyla eklendi.";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "İş ilanı eklenirken bir hata oluştu.";
            return View(iş);
        }

        // GET: İş İlanı Düzenle
        public IActionResult Düzenle(int id)
        {
            var iş = İşİlanları.FirstOrDefault(i => i.Id == id);
            if (iş == null)
                return NotFound();

            return View(iş);
        }

        // POST: İş İlanı Güncelle
        [HttpPost]
        public IActionResult Düzenle(İş iş)
        {
            if (ModelState.IsValid)
            {
                var existingJob = İşİlanları.FirstOrDefault(i => i.Id == iş.Id);
                if (existingJob != null)
                {
                    existingJob.Başlık = iş.Başlık;
                    existingJob.Şirket = iş.Şirket;
                    existingJob.Açıklama = iş.Açıklama;
                    existingJob.Gereksinimler = iş.Gereksinimler;
                    existingJob.Konum = iş.Konum;
                    existingJob.MaaşAralığı = iş.MaaşAralığı;
                    existingJob.GerekenDeneyim = iş.GerekenDeneyim;
                    existingJob.ÇalışmaTipi = iş.ÇalışmaTipi;
                    existingJob.SonBaşvuruTarihi = iş.SonBaşvuruTarihi;
                    existingJob.Durum = iş.Durum;
                    existingJob.İletişim = iş.İletişim;

                    TempData["SuccessMessage"] = $"İş ilanı '{iş.Başlık}' başarıyla güncellendi.";
                    return RedirectToAction("Index");
                }
            }

            TempData["ErrorMessage"] = "İş ilanı güncellenirken bir hata oluştu.";
            return View(iş);
        }

        // Phase 6: Job-Candidate Matching
        // Phase 6: Job-Candidate Matching - Enhanced Version
        public IActionResult EşleşenAdaylar(int id)
        {
            var iş = İşİlanları.FirstOrDefault(i => i.Id == id);
            if (iş == null)
                return NotFound();

            // Get all candidates from AdayController
            var tümAdaylar = GetAllCandidates();

            // Smart matching algorithm
            var uygunAdaylar = tümAdaylar.Where(aday =>
            {
                // Basic filters
                bool isAvailable = aday.Statü != "İşe Alındı" && aday.Statü != "Reddedildi";

                // Experience filter (allow 1 year less experience)
                bool experienceOk = aday.Deneyim >= (iş.GerekenDeneyim - 1);

                // Position matching (fuzzy search)
                bool positionMatch = aday.Pozisyon.ToLower().Contains(iş.Başlık.ToLower().Split(' ')[0]) ||
                                   iş.Başlık.ToLower().Contains(aday.Pozisyon.ToLower().Split(' ')[0]);

                // Skills matching (at least one skill should match)
                var candidateSkills = aday.Yetenek.Split(',').Select(s => s.Trim().ToLower());
                var jobSkills = iş.ArananYetenekler.Select(s => s.ToLower());
                bool skillsMatch = candidateSkills.Intersect(jobSkills).Any();

                // Return candidates that meet basic criteria
                return isAvailable && (experienceOk || positionMatch || skillsMatch);
            }).ToList(); // ADD THIS .ToList() TO CREATE uygunAdaylar

            ViewBag.İş = iş;
            ViewBag.Adaylar = uygunAdaylar; // NOW THIS WILL WORK
            ViewBag.AppliedCandidates = Başvurular.Where(b => b.İşId == id).Select(b => b.AdayId).ToList();

            return View();
        }

        // Helper method to get candidates from AdayController
        private List<Aday> GetAllCandidates()
        {
            // Access the static list from AdayController
            // Note: This is a temporary solution. In real apps, you'd use a database service.
            var adayControllerType = typeof(AdayController);
            var adaylarField = adayControllerType.GetField("Adaylar",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);

            if (adaylarField != null)
            {
                return (List<Aday>)adaylarField.GetValue(null) ?? new List<Aday>();
            }

            // Fallback: return empty list if can't access
            return new List<Aday>();
        }


        // Add this to your İşController.cs

        // Static list to store applications
        private static List<Başvuru> Başvurular = new List<Başvuru>
{
    // Sample application data
    new Başvuru
    {
        Id = 1,
        AdayId = 1, // Ahmet Yılmaz
        İşId = 1,   // Yazılım Mühendisi
        BaşvuruTarihi = DateTime.Now.AddDays(-3),
        Durum = "Değerlendiriliyor",
        Not = "Güçlü teknik beceriler, iyi portfolio",
        Puan = 4
    },
    new Başvuru
    {
        Id = 2,
        AdayId = 2, // Ayşe Demir
        İşId = 2,   // Pazarlama Uzmanı
        BaşvuruTarihi = DateTime.Now.AddDays(-1),
        Durum = "Mülakata Çağrıldı",
        MülakatTarihi = DateTime.Now.AddDays(3),
        Not = "Sosyal medya deneyimi çok iyi",
        Puan = 5
    },
    new Başvuru
    {
        Id = 3,
        AdayId = 1, // Ahmet Yılmaz
        İşId = 3,   // Grafik Tasarım (farklı pozisyon için de başvurmuş)
        BaşvuruTarihi = DateTime.Now.AddDays(-7),
        Durum = "Reddedildi",
        Not = "Grafik tasarım deneyimi yetersiz",
        Puan = 2
    }
};

        // NEW: View applications for a specific job
        public IActionResult İşBaşvuruları(int id)
        {
            var iş = İşİlanları.FirstOrDefault(i => i.Id == id);
            if (iş == null)
                return NotFound();

            // Get applications for this job
            var işBaşvuruları = Başvurular.Where(b => b.İşId == id).ToList();

            // Populate candidate information for each application
            var allCandidates = GetAllCandidates();
            foreach (var başvuru in işBaşvuruları)
            {
                başvuru.Aday = allCandidates.FirstOrDefault(a => a.Id == başvuru.AdayId);
                başvuru.İş = iş;
            }

            ViewBag.İş = iş;
            ViewBag.Başvurular = işBaşvuruları;
          

          
            return View();
        }

        // NEW: Apply candidate to job
        [HttpPost]
        public IActionResult AdayBaşvur(int adayId, int işId, string not = "")
        {
            // Check if already applied
            var existingApp = Başvurular.FirstOrDefault(b => b.AdayId == adayId && b.İşId == işId);
            if (existingApp != null)
            {
                TempData["ErrorMessage"] = "Bu aday zaten bu işe başvurmuş.";
                return RedirectToAction("EşleşenAdaylar", new { id = işId });
            }

            // Create new application
            var başvuru = new Başvuru
            {
                Id = Başvurular.Any() ? Başvurular.Max(b => b.Id) + 1 : 1,
                AdayId = adayId,
                İşId = işId,
                BaşvuruTarihi = DateTime.Now,
                Durum = "Yeni Başvuru",
                Not = not,
                Puan = 0
            };

            Başvurular.Add(başvuru);
            TempData["SuccessMessage"] = "Aday başarıyla işe başvurdu.";

            return RedirectToAction("İşBaşvuruları", new { id = işId });
        }

        // NEW: Update application status
        [HttpPost]
        public IActionResult BaşvuruDurumGüncelle(int başvuruId, string durum, string not = "", int puan = 0, DateTime? mülakatTarihi = null)
        {
            var başvuru = Başvurular.FirstOrDefault(b => b.Id == başvuruId);
            if (başvuru != null)
            {
                başvuru.Durum = durum;
                başvuru.Not = not;
                başvuru.Puan = puan;
                başvuru.MülakatTarihi = mülakatTarihi;

                TempData["SuccessMessage"] = "Başvuru durumu güncellendi.";
            }
            else
            {
                TempData["ErrorMessage"] = "Başvuru bulunamadı.";
            }

            return RedirectToAction("İşBaşvuruları", new { id = başvuru?.İşId });
        }

        // NEW: Application dashboard - all applications overview
        public IActionResult BaşvuruPaneli()
        {
            var allCandidates = GetAllCandidates();

            // Populate candidate and job info for all applications
            var allApplications = Başvurular.Select(b =>
            {
                b.Aday = allCandidates.FirstOrDefault(a => a.Id == b.AdayId);
                b.İş = İşİlanları.FirstOrDefault(i => i.Id == b.İşId);
                return b;
            }).OrderByDescending(b => b.BaşvuruTarihi).ToList();

            return View(allApplications);
        }
    }
}