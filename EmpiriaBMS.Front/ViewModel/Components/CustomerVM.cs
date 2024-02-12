using EmpiriaMS.Models.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmpiriaBMS.Front.ViewModel.Components;
public class CustomerVM : UserVM
{
    public virtual ICollection<ProjectVM>? Projects { get; set; }
}