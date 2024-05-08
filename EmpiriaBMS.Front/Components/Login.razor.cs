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

    private void HandleSubmit()
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || !Validate())
        {
            errorMessage = "Please enter both username and password.";
            return;
        }

        // TODO: Login Check For User to Server. If User Not Exists Notify CEO, CTO, COO, Admin
        if (username == "admin" && password == "password")
        {
            MyNavigationManager.NavigateTo("/dashboard");
        }
        else
        {
            errorMessage = "Invalid username or password.";
        }
    }

    #region Validation
    private bool validUserName = true;
    private bool validPassword = true;

    private bool Validate(string fieldname = null)
    {
        if (fieldname == null)
        {
            validUserName = _isvalidUserName(username);
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
                    validUserName = _isvalidUserName(username);
                    return validUserName;
                case "Password":
                    validPassword = !string.IsNullOrEmpty(password);
                    return validPassword;
                default:
                    return true;
            }

        }
    }

    private bool _isvalideMAIL(string email) => GeneralValidator.IsValidEmail(email);
    #endregion
}
