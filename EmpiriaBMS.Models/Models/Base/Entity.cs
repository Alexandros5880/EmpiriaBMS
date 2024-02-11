using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaMS.Models.Models.Base;
public class Entity : IEntity
{
    [Required]
    [Key]
    public string Id { get; set; } = "";

    [Required]
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime CreatedDate { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [Column(TypeName = "datetime2")]
    public DateTime LastUpdatedDate { get; set; }
}