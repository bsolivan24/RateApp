using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RateApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IntroductionItem _selectedItem;

        public MainPageViewModel(INavigationService navigationService)
                    : base(navigationService)
        {
            Title = "Main Page";
            IntroductionItems = new List<IntroductionItem>()
            {
                new IntroductionItem
                {
                    Image = "watch_2.png",
                    Title = "Watch",
                    Description = "Watch some stuff!"
                },
                new IntroductionItem
                {
                    Image = "rank_1.png",
                    Title = "Rank",
                    Description = "Rank some stuff!"
                },
                new IntroductionItem
                {
                    Image = "share_image.png",
                    Title = "Share",
                    Description = "Share some stuff!"
                }
            };

            NextCommand = new Command(Next);
            SelectedIntroductionItem = IntroductionItems.First();
        }

        public ICommand NextCommand { get; set; }

        public List<IntroductionItem> IntroductionItems { get; set; }

        public IntroductionItem SelectedIntroductionItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }

        private void Next(object obj)
        {
            if (SelectedIntroductionItem == null)
                return;

            var index = IntroductionItems.IndexOf(SelectedIntroductionItem);
            var nextIndex = (index + 1) % 3;
            SelectedIntroductionItem = IntroductionItems[nextIndex];
        }
    }
}
