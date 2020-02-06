using System.ComponentModel.DataAnnotations;

namespace Banking.Services.Resources
{
    public class AddAccountResource
    {
        [Required]
        public int CustomerId { get; set; }

        public double? InitialCredit { get; set; }
    }
}
