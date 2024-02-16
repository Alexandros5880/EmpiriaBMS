using Microsoft.EntityFrameworkCore.Update.Internal;
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

    public Entity()
    {
        Id = Guid.NewGuid().ToString().Replace("\\", string.Empty).Replace("/", string.Empty);
        CreatedDate = DateTime.Now.ToUniversalTime();
        LastUpdatedDate = DateTime.Now.ToUniversalTime();
    }

    public void SetValues(Entity entity)
    {
        Id = entity.Id;
        CreatedDate = entity.CreatedDate;
        LastUpdatedDate = DateTime.Now.ToUniversalTime();
    }
}