using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FineFabrics.CustomersApp.ViewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void RaisePropertyChanges([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
