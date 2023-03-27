using System.Runtime.CompilerServices;

namespace BuffTracker.Shared;

public abstract class NotifyStateChangedBase
{    
    public event Action StateChanged;

    public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(storage, value))
        {
            return false;
        }
        storage = value;
        StateChanged?.Invoke();
        return true;
    }
}