namespace ProjektZaliczeniowyASP.NET.Models
{
    public class ZapisNaKursModel
    {
        public int Id { get; set; }

      
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }

    
        public int KursId { get; set; }
        public KursModel Kurs { get; set; }

        public DateTime DataZapisu { get; set; }
    }
}
