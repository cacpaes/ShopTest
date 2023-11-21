using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopTest.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductWeight { get; set; }
        public decimal ProductHeight { get; set; }
        public decimal ProductWidth { get; set; }
        public decimal ProductDepth { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal SaleValue { get; set; }
        public decimal PurchaseVatRate { get; set; }
        public decimal SaleVatRate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Product()
        {
            // Inicializa os campos de data com valores padrão
            CreatedDate = DateTime.Now; 
            UpdatedDate = null; 
        }
    }
}
