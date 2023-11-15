using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ShopTest.Entities
{
    [Table("Stock")]
    public class Stock
    {
        //Attributes of the Stock class

        [Key]
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int UnitQuantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}

