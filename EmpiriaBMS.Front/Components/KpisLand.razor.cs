using Microsoft.AspNetCore.Components;

namespace EmpiriaBMS.Front.Components;

public partial class KpisLand : ComponentBase, IDisposable
{
    private bool disposedValue;



    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {

            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
