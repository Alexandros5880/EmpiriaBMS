using EmpiriaBMS.Core;
using EmpiriaBMS.Front.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmpiriaBMS.Front.Areas.Admin.Controllers;

[Area("Admin")]
public class OtherTypesController : Controller
{
    private readonly IDataProvider _dataProvider;
    private readonly SharedAuthDataService _sharedAuthData;

    public OtherTypesController(
        IDataProvider dataProvider,
        SharedAuthDataService sharedAuthData
    )
    {
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
    public async Task<IActionResult> GetAllOthersTypes()
    {
        //var logedUserId = _sharedAuthData.LogedUser.Id;

        var dtos = await _dataProvider.OthersTypes.GetAll();

        if (dtos == null)
            return NotFound("No others types found!");

        var returnData = dtos.Select(p => new { name = p.Name }).ToList();

        return Json(returnData);
    }
    #endregion
}
