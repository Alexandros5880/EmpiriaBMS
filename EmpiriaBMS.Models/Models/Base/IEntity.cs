
namespace EmpiriaMS.Models.Models.Base
{
    public interface IEntity
    {
        DateTime CreatedDate { get; set; }
        string Id { get; set; }
        DateTime LastUpdatedDate { get; set; }
    }
}