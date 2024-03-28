using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using EmpiriaMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class IssueDto : EntityDto
{
    public DateTime ComplaintDate { get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }

    public string About { get; set; }

    public string Description { get; set; }

    public string Solution { get; set; }

    public DateTime SolutionDate { get; set; }

    public string Evaluation { get; set; }

    public string Verification { get; set; }

    public DateTime VerificationDate { get; set; }

    public byte[] VerificatorSignature { get; set; }

    public byte[] PMSignature { get; set; }

    public bool IsClose { get; set; }
}
