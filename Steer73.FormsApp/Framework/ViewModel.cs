using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Acr.UserDialogs;

namespace Steer73.FormsApp.Framework
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected IUserDialogs _dialogService;

        protected virtual void SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;

            field = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // dialog base
        public void ShowLoading(string loadtitle = "Please Wait")
        {
            _dialogService.ShowLoading(loadtitle);
        }

        public void DismissLoading()
        {
            _dialogService.HideLoading();
        }
    }
}
