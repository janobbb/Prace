﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODO.Models;
using TODO.Services;

namespace TODO.ViewModel
{
    [QueryProperty("WorkTask", "WorkTask")]
    public partial class TODOTaskViewModel : BaseViewModel
    {
        [ObservableProperty]
        WorkTask workTask;

        [RelayCommand]
        private async Task SaveDetails()
        {
            await ToDoService.SaveDetails(WorkTask);
            await Shell.Current.GoToAsync("..");

        }     
    }
}
