using System;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using Steer73.FormsApp.ViewModels;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace Steer73.FormsApp.Views
{
    public partial class UsersView : ContentPage
    {
        public UsersView()
        {
            InitializeComponent();
            BindingContext = new UsersViewModel( new UserService(), new MessageService(), UserDialogs.Instance);
        }

        protected override async void OnAppearing()
        {
                base.OnAppearing();
                await (BindingContext as UsersViewModel).Initialize();
        }
    }
}
