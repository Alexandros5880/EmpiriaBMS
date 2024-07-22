using EmpiriaBMS.Core.Hellpers;

namespace EmpiriaBMS.Front.Components;

public partial class Login
{
    private string username;
    private string password;
    private string errorMessage;
    private bool loading = false;

    private async Task _login()
    {
        loading = true;
        StateHasChanged();

        if (!Validate())
        {
            loading = false;
            StateHasChanged();
            return;
        }

        var result = await authorizeServices.Login(username, password);

        if (string.IsNullOrEmpty(result))
        {
            MyNavigationManager.NavigateTo("/dashboard");
            errorMessage = null;
            return;
        }
        else
        {
            loading = false;
            StateHasChanged();

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
