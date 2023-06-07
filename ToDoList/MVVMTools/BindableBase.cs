using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVMTools
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected void SetProperty<T>(ref T member, T val, [CallerMemberName] string? propertyName = null)
        {
            if (object.Equals(member, val)) return;
            member = val;
            OnPropertyChanged(propertyName);
        }
    }
}
