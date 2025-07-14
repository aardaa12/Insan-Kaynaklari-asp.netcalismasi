namespace İnsan_Kaynakları.Models
{
    public class Başvuru
    {
        public int Id { get; set; }                    // Application ID
        public int AdayId { get; set; }                // Candidate ID
        public int İşId { get; set; }                  // Job ID
        public DateTime BaşvuruTarihi { get; set; }    // Application date
        public string Durum { get; set; }              // Application status
        public string Not { get; set; }                // Notes/comments
        public DateTime? MülakatTarihi { get; set; }   // Interview date (if scheduled)
        public string MülakatNotu { get; set; }        // Interview notes
        public int Puan { get; set; }                  // Application score (1-5)

        // Navigation properties (we'll populate these manually)
        public Aday Aday { get; set; }                 // Candidate info
        public İş İş { get; set; }                     // Job info
    }
}