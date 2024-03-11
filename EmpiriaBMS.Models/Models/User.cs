using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using EmpiriaMS.Models.Models;
using EmpiriaMS.Models.Models.Base;

namespace EmpiriaBMS.Models.Models;
public class User : Entity
{
    // MicrosoftTeams Email
    public string ProxyAddress { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string? MidName { get; set; }

    [Required]
    public string Phone1 { get; set; }

    public string? Phone2 { get; set; }

    public string? Phone3 { get; set; }

    public string? Description { get; set; }

    public int? ProjectId { get; set; }
    public Project? Project { get; set; }

    public ICollection<Email> Emails { get; set; }

    public ICollection<Project> Projects { get; set; }

    public ICollection<Discipline> Disciplines { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    
    public ICollection<DrawingEmployee> DrawingsEmployees { get; set; }

    public ICollection<OtherEmployee> OthersEmployees { get; set; }

    public ICollection<ProjectPmanager> ProjectsPmanagers { get; set; }

    public ICollection<DisciplineEngineer> DisciplinesEngineers { get; set; }

    public ICollection<DailyTime> DailyTime { get; set; }

    public ICollection<DailyTime> PersonalTime { get; set; }

    public ICollection<DailyTime> TrainingTime { get; set; }

    public ICollection<DailyTime> CorporateEventTime { get; set; }
}