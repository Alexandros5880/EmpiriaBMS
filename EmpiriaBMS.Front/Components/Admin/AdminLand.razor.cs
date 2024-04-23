using Microsoft.Fast.Components.FluentUI;

namespace EmpiriaBMS.Front.Components.Admin;

public partial class AdminLand
{

    /* 
        FluentNavLink.Icon

        public Icon(string name, IconVariant variant, IconSize size, string content)
        {
            Name = name;
            Variant = variant;
            Size = size;
            Content = content;
        }
    */

    public AdminLand()
    {
        new Icons.Regular.Size24.GroupList();
    }

}
