using System.ComponentModel.DataAnnotations.Schema;


namespace ShopTest.Entities
{
    [Table("Employee")]
    public class Employees : People
    {
        //Additional attributes specific to Employees
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
    }
}
