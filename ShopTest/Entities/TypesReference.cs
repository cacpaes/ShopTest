using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ShopTest.Entities
{
    [Table("TypesReference")]
    public class TypesReference
    {
        //Attributes of the TypesReference class

        [Key]
        //[Column("TypeId")] 
        public int TypeId { get; set; }
        public string? TypeSimbol { get; set; }
        public string? TypeName { get; set; }
        public string? TypeEntity { get; set; }
        public string? TypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}

