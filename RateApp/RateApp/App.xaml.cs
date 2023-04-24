using Prism;
using Prism.Ioc;
using RateApp.ViewModels;
using RateApp.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace RateApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync($"NavigationPage/{nameof(SignInViewModel)}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<IntroductionPage, IntroductionViewModel>(nameof(IntroductionViewModel));
            containerRegistry.RegisterForNavigation<TitleSelectionPage, TitleSelectionViewModel>(nameof(TitleSelectionViewModel));
            containerRegistry.RegisterForNavigation<SignInPage, SignInViewModel>(nameof(SignInViewModel));
        }
    }
}
