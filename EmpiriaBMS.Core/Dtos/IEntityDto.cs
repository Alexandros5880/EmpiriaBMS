
namespace EmpiriaBMS.Core.Dtos
{
    public interface IEntityDto
    {
        DateTime CreatedDate { get; set; }
        int Id { get; set; }
        DateTime LastUpdatedDate { get; set; }
    }
}