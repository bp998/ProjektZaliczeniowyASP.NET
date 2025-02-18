namespace ProjektZaliczeniowyASP.NET.Models
{
    public class KursModel
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }

        public List<ZapisNaKursModel> ZapisaniStudenci { get; set; }
    }
}
