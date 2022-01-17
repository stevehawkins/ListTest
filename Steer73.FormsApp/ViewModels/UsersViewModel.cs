using Acr.UserDialogs;
using PropertyChanged;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steer73.FormsApp.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class UsersViewModel : ViewModel
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public List<User> Users { get; set; }

        public UsersViewModel(
            IUserService userService,
            IMessageService messageService,
            IUserDialogs dialogService)
        {
            _userService = userService;
            _messageService = messageService;
            _dialogService = dialogService;
        }

        public async Task Initialize()
        {
            try
            {
                ShowLoading("Loading Users");
                Users = (await _userService.GetUsers()).ToList();
                  
            }
            catch (Exception ex)
            {
                await _messageService.ShowError(ex.Message);
            }
            finally
            {
                DismissLoading();
            }
        }
    }
}
