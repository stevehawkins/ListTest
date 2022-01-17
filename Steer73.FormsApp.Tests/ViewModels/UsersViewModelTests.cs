using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using Steer73.FormsApp.ViewModels;
using Acr.UserDialogs;

namespace Steer73.FormsApp.Tests.ViewModels
{
    [TestFixture]
    public class UsersViewModelTests
    {
        [Test]
        public async Task InitializeFetchesTheData()
        {
            var userService = new Mock<IUserService>();
            var messageService = new Mock<IMessageService>();
            var dialogsService = Mock.Of<IUserDialogs>();

            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object,
                dialogsService);

            userService
                .Setup(p => p.GetUsers())
                .Returns(Task.FromResult(Enumerable.Empty<User>()))
                .Verifiable();

            await viewModel.Initialize();

            userService.VerifyAll();
        }

        [Test]
        public async Task InitializeShowErrorMessageOnFetchingError()
        {
            IUserService userService = null;
            var messageService = new Mock<IMessageService>();
            var dialogsService = Mock.Of<IUserDialogs>();

            var viewModel = new UsersViewModel(
                userService,
                messageService.Object,
                dialogsService);

            await viewModel.Initialize();

            Assert.Null(viewModel.Users);
        }
    }
}
