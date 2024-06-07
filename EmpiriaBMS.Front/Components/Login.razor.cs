using AutoMapper;
using EmpiriaBMS.Core.Dtos;
using EmpiriaBMS.Core.Hellpers;
using EmpiriaBMS.Front.ViewModel.Components;
using EmpiriaBMS.Front.ViewModel.Interfaces;
using EmpiriaBMS.Models.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Fast.Components.FluentUI;
using Microsoft.Graph.Models;
using System;
using System.Text.RegularExpressions;
using static Microsoft.Fast.Components.FluentUI.Emojis.Objects.Color.Default;

namespace EmpiriaBMS.Front.Components;

public partial class Login
{
    private string username;
    private string password;
    private string errorMessage;

    private async Task _login()
    {
        if (!Validate())
            return;

        var result = await authorizeServices.Login(username, password);

        if (string.IsNullOrEmpty(result))
        {
            MyNavigationManager.NavigateTo("/dashboard");
            errorMessage = null;
            return;
        }
        else
        {
            errorMessage = result;
        }
    }

    #region Validation
    private bool validUserName = true;
    private bool validPassword = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validUserName = _isvalidEmail(username);
            validPassword = !string.IsNullOrEmpty(password);

            return validUserName && validPassword;
        }
        else
        {
            validUserName = true;
            validPassword = true;

            switch (fieldname)
            {
                case "Emails":
                    validUserName = _isvalidEmail(username);
                    return validUserName;
                case "Password":
                    validPassword = !string.IsNullOrEmpty(password);
                    return validPassword;
                default:
                    return true;
            }

        }
    }

    private bool _isvalidEmail(string email) => GeneralValidator.IsValidEmail(email);
    #endregion
}
