using System.ComponentModel.DataAnnotations;

namespace Sales.Models;

public class Seller
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1}")]
    public string Name { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [EmailAddress(ErrorMessage = "Enter a valid email")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Display(Name = "Birth Date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "{0} required")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }

    [Display(Name = "Base Salary")]
    [Required(ErrorMessage = "{0} required")]
    [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
    //[DisplayFormat(DataFormatString = "{0:F2}")]
    [DataType(DataType.Currency)]
    public double BaseSalary { get; set; }

    public Department? Department { get; set; }
    [Display(Name = "Department")]
    public int? DepartmentId { get; set; }
    public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

    public Seller()
    {
    }

    public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        BaseSalary = baseSalary;
        Department = department;
    }

    public void AddSales(SalesRecord sr)
    {
        Sales.Add(sr);
    }

    public void RemoveSales(SalesRecord sr)
    {
        Sales.Remove(sr);
    }

    public double totalSales(DateTime initial, DateTime final)
    {
        return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
    }
}