using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ShopTest.Entities
{

    [Table("Sells")]
    public class Sells
    {
        //Attributes of the Sells class

        [Key]
        public int SellsId { get; set; }
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime SellDate { get; set; }
    }
}
