using EmpiriaBMS.Front.Interop.TeamsSDK;
using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;

public partial class Login
{
    private string username;
    private string password;
    private string errorMessage;

    private void HandleSubmit()
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
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
}
