using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRBankPayAPI.Data.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Value { get; set; }
        public string CuentaOrigen { get; set; }
    }
}
