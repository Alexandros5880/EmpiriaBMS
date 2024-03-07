using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Areas.Admin.ViewModels.Projects;
using EmpiriaBMS.Front.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmpiriaBMS.Front.Areas.Admin.Controllers;

[Area("Admin")]
public class ProjectsController : Controller
{
    private readonly IDataProvider _dataProvider;
    private readonly AuthorizeServices _authorizeService;

    public ProjectsController(
        IDataProvider dataProvider
    ) {
        _dataProvider = dataProvider;
    }

    [HttpGet]
    public async Task<IActionResult> Table()
    {
        // Retrieve Bearer token from Authorization header
        string objectId = Request.Headers["ObjectId"];

        // Retrieve X-Role-Id header
        string xRoleId = Request.Headers["RoleId"];

        int userId = Convert.ToInt32(xRoleId);
        ProjectsTableVM viewmodel = new ProjectsTableVM();
        viewmodel.Projects = await _dataProvider.Projects.GetAll(userId);

        return View(viewmodel);
    }

    public IActionResult Add()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }
}
