using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjektZaliczeniowyASP.NET.Models
{
    public class ZapisNaKursModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public StudentModel? Student { get; set; }

        [Required]
        public int KursId { get; set; }
        public KursModel? Kurs { get; set; }
        [Required]
        public DateTime DataZapisu { get; set; }
    }
}
