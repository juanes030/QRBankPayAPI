using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QRBankPayAPI.Data.Models
{
    public class SourceBankAccount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Dna { get; set; }
        
        public string SourceAccount { get; set; }
    }
}
