using AutoMapper;
using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Components.General;
using EmpiriaBMS.Front.Services;
using EmpiriaBMS.Front.ViewModel.Components;
using Microsoft.AspNetCore.Mvc;

namespace EmpiriaBMS.Front.Areas.Admin.Controllers;

[Area("Admin")]
public class DisciplineTypesController : Controller
{
    private readonly IDataProvider _dataProvider;
    private readonly SharedAuthDataService _sharedAuthData;

    public DisciplineTypesController(
        IDataProvider dataProvider,
        SharedAuthDataService sharedAuthData
    )
    {
        _dataProvider = dataProvider;
        _sharedAuthData = sharedAuthData;
    }

    [HttpGet]
    public async Task<IActionResult> Table()
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
    public async Task<IActionResult> GetAllMyDisciplineTypes()
    {
        var logedUserId = _sharedAuthData.LogedUser.Id;

        var dtos = await _dataProvider.DisciplinesTypes.GetAll(logedUserId);

        if (dtos == null)
            return NotFound("No projects found!");

        var returnData = dtos.Select(p => new { name = p.Name }).ToList();

        return Json(returnData);
    }
    #endregion
}
