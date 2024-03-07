using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Areas.Admin.ViewModels.Projects;
using EmpiriaBMS.Front.Interop.TeamsSDK;
using EmpiriaBMS.Front.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmpiriaBMS.Front.Areas.Admin.Controllers;

[Area("Admin")]
public class ProjectsController : Controller
{
    private readonly IDataProvider _dataProvider;
    private readonly SharedAuthDataService _sharedAuthData;

    public ProjectsController(
        IDataProvider dataProvider,
        SharedAuthDataService sharedAuthData
    ) {
        _dataProvider = dataProvider;
        _sharedAuthData = sharedAuthData;
    }

    [HttpGet]
    public async Task<IActionResult> Table()
    {
        var logedUserId = _sharedAuthData.LogedUser.Id;

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
