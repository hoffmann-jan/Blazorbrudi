namespace Blazorbrudi;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public bool SetProperty<T>(ref T field, T value, string? propertyName)
    {
        if (EqualityComparer<T>.Default.Equals(value, field))
        {
            return false;
        }
    
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }
}
