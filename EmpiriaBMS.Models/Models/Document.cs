using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Models.Models;
public class Document : Entity
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] Content { get; set; }

    public int IssueId { get; set; }
    public Issue Issue { get; set; }
}
