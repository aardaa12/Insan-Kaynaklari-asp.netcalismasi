namespace İnsan_Kaynakları.Models
{
    public class Aday
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Mail { get; set; } 
        public string Pozisyon  { get; set; }
        public string Numara { get; set; }
        public DateTime UygulamaZamanı { get; set; }
        public int Deneyim {  get; set; }
        public string Yetenek { get; set; }
        public string Eğitim { get; set; }
        public string Fotourl { get; set; }
        public string Statü { get; set; }


    }
}
