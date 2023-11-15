using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ShopTest.Entities
{
    [Table("Transactions")]
    public class Transactions
    {
        // Attributes of the Transactions class

        [Key]
        public int TransactionId { get; set; }
        public int PersonId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
