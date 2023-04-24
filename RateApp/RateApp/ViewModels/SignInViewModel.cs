using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace RateApp.ViewModels
{
    public class SignInViewModel : ViewModelBase
    {
        public SignInViewModel(INavigationService navigationService) : base(navigationService)
        {
            ContinueCommand = new AsyncCommand(Continue);
        }

        public ICommand ContinueCommand { get; set; }

        private async Task Continue()
        {
            await NavigationService.NavigateAsync(nameof(IntroductionViewModel));
        }
    }
}
