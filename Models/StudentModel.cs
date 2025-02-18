namespace ProjektZaliczeniowyASP.NET.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }

        public List<ZapisNaKursModel> ZapisaneKursy { get; set; }
    }
}
