
namespace EmpiriaBMS.Models.Models;

public class Issue : Entity
{
    public DateTime ComplaintDate { get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public int DisplayedRoleId { get; set; }
    public Role? DisplayedRole { get; set; }

    public int CreatorId { get; set; }
    public User? Creator { get; set; }

    public ICollection<Document> Documents { get; set; }

    public string Description { get; set; }

    public string? Solution { get; set; }

    public DateTime? SolutionDate { get; set; }

    public string? Evaluation { get; set; }

    public string? Verification { get; set; }

    public DateTime? VerificationDate { get; set; }

    public byte[]? VerificatorSignature { get; set; }

    public byte[]? PMSignature { get; set; }

    public bool IsClose { get; set; }
}
