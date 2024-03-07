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
        IDataProvider dataProvider,
        AuthorizeServices authorizeServices
    ) {
        _dataProvider = dataProvider;
        _authorizeService = authorizeServices;
    }

    [HttpGet]
    public async Task<IActionResult> Table()
    {
        // Retrieve Bearer token from Authorization header
        string objectId = Request.Headers["ObjectId"];
        string xRoleId = Request.Headers["RoleId"];
        int roleId = Convert.ToInt32(xRoleId);
        await _authorizeService.Authorize(roleId: roleId);
        var logedUserId = _authorizeService.LogedUser.Id;

        ProjectsTableVM viewmodel = new ProjectsTableVM();
        viewmodel.Projects = await _dataProvider.Projects.GetAll(logedUserId);

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
