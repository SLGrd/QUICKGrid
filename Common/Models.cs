using System.ComponentModel.DataAnnotations;
using static Common.Data;

namespace Common;
public class Models
{
    public class Person
    {
        [Required]
        public int PersonId { get; set; }
        [MinLength(3, ErrorMessage = "min 3 characters")]
        [MaxLength(32, ErrorMessage = "max 32 characteres")]
        public string Name { get; set; }    //  First name + Last Name
        public Countries Country { get; set; }
        [Range(18, 24, ErrorMessage = "Age must range from 18 to 24 yo")]        
        public int Age { get; set; }
        public Gender MF { get; set; }
        [Range(typeof(DateTime), "2021/01/01", "2022/11/22", ErrorMessage = "Date out of range")]
        public DateTime InitialDate { get; set; }
        [Range(12, 22, ErrorMessage = "Hourly Wage must range from 12 to 22 CAD")]
        public decimal HourlyWage { get; set; }
        public Person()
        {
            PersonId = 0;
            Name = "";
            Country = 0;
            Age = 0;
            InitialDate = DateTime.Now;
            HourlyWage = 0;
            MF = 0;
        }
    }
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [MinLength(12, ErrorMessage = "min 8 characters")]
        [MaxLength(38, ErrorMessage = "max 38 characteres")]
        public string Description { get; set; }
        [Range(0.01, 1000.00, ErrorMessage = "Product price must range from 0,01 to 1000.00 CAD")]
        public decimal Price { get; set; }
        public Product()
        {
            ProductId = 0;
            Description = "";
            Price = 0;
        }
        public Product(int productId, string description, decimal price)
        {
            ProductId = productId;
            Description = description;
            Price = price;
        }
    }
    public class Sale
    {
        [Required]
        public int PersonId { get; set; }
        public int Qtty { get; set; }
        public Product SoldProduct { get; set; }
        public Sale()
        {
            PersonId = 0;
            SoldProduct = new Product();
        }
        public Sale(Person p, Product sld)
        {
            PersonId = p.PersonId;
            SoldProduct = sld;
        }
    }
}