using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Models.Models;

public class InvoiceType : Entity
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    public ICollection<Invoice>? Invoices { get; set; }
}