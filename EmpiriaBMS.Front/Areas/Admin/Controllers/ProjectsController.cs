using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Dtos;
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
    public IActionResult Table()
    {
        // TODO: Is Authorized
        //var logedUserId = _sharedAuthData.LogedUser.Id;

        return View();
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

    #region API

    [HttpPost]
    public async Task<IActionResult> GetAllProjects()
    {
        //var logedUserId = _sharedAuthData.LogedUser.Id;

        var projects = await _dataProvider.Projects.GetAll();

        if (projects == null)
            return NotFound("No projects found!");

        var returnData = projects.Select(p => new { name = p.Name, description = p.Description }).ToList();

        return Json(returnData);
    }
    #endregion
}
