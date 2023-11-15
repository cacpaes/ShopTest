using System.ComponentModel.DataAnnotations.Schema;


namespace ShopTest.Entities
{
    [Table("Supplier")]
    public class Suppliers : People
    {
        //Additional attributes specific to Suppliers

        public string? ProductTypes { get; set; }
        public int SupplierLevel { get; set; }
        public bool Sells { get; set; }

    }
}
