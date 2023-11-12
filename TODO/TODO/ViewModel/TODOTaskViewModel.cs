using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Models;

namespace TODO.ViewModel
{
    [QueryProperty("WorkTask", "WorkTask")]
    public partial class TODOTaskViewModel : BaseViewModel
    {
        public TODOTaskViewModel() 
        { 

        }
        [ObservableProperty]
        WorkTask workTask;

        [RelayCommand]
        private async Task GoToMainPageAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
    }
}
