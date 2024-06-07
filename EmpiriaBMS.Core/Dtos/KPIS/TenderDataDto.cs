using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaBMS.Core.Dtos.KPIS;

public class TenderDataDto
{
    public string ProjectName { get; set; }
    public string ProjectStage { get; set; }
    public string ProjectCategory { get; set; }
    public string ProjectSubCategory { get; set; }
    public double ProjectPrice { get; set; } // Sum of offers OfferPrice
    public double ProjectPudgedPrice { get; set; } // Sum of offers PudgedPrice
    public string ClientCompanyName { get; set; }
    public string ClientFullName { get; set; }
    public string ClientPhone { get; set; }
    public string ClientEmail { get; set; }
}
