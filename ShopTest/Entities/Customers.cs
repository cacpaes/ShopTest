using System.ComponentModel.DataAnnotations.Schema;


namespace ShopTest.Entities
{
    [Table("Customer")]
    public class Customers : People
    {
        // Additional attributes specific to Customers
        public decimal CreditLimit { get; set; }
        public bool HasCard { get; set; }
    }
}
