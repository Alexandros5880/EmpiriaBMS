using EmpiriaMS.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpiriaMS.Models.Models;
public class Customer : User
{
    public IEnumerable<Project>? Projects { get; set; }
}
