using EmpiriaBMS.Core.Dtos.Base;
using EmpiriaBMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos;

public class DocumentDto : EntityDto
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] Content { get; set; }

    public int IssueId { get; set; }
    public IssueDto Issue { get; set; }
}
