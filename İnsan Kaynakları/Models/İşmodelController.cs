namespace İnsan_Kaynakları.Models
{
    public class İş
    {
        public int Id { get; set; }                    // Unique job ID
        public string Başlık { get; set; }             // Job title
        public string Şirket { get; set; }             // Company name
        public string Açıklama { get; set; }           // Job description
        public string Gereksinimler { get; set; }      // Job requirements
        public string Konum { get; set; }              // Job location
        public string MaaşAralığı { get; set; }        // Salary range
        public int GerekenDeneyim { get; set; }        // Required experience (years)
        public string ÇalışmaTipi { get; set; }        // Work type (Full-time, Part-time, Remote)
        public DateTime İlanTarihi { get; set; }       // Job posting date
        public DateTime SonBaşvuruTarihi { get; set; } // Application deadline
        public string Durum { get; set; }              // Status (Active, Closed, Draft)
        public string İletişim { get; set; }           // Contact info
        public List<string> ArananYetenekler { get; set; } = new List<string>(); // Required skills

        // Navigation properties for Phase 6
        public List<int> BaşvuranAdaylar { get; set; } = new List<int>(); // Applied candidate IDs
    }
}