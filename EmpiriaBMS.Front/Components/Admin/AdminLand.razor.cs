using Microsoft.AspNetCore.Components.Web;
using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin;

public partial class AdminLand
{

    #region Tab Actions
    bool[] tabs = new bool[50];

    private void TabMenuClick(int tabIndex)
    {
        for (int i = 0; i < tabs.Length; i++) { tabs[i] = false; }
        tabs[tabIndex] = true;
    }
    #endregion

}
