using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;

public class Complain : Entity
{
    public DateTime ComplaintDate { get; set; }

    public int ProjectId { get; set; }
    public Project? Project { get; set; }

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
