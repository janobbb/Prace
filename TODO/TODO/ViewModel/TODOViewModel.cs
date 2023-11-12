using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TODO.Models;
using TODO.View;

namespace TODO.ViewModel
{
    public partial class TODOViewModel : WorkTask
    {
        public ObservableCollection<WorkTask> WorkTasks { get; set; } = new();

        [ObservableProperty]
        public string newWorkTaskTitle;

        [ObservableProperty]
        public string newWorkTaskDescritpion;

		public TODOViewModel()
        {
            Title = "TODO App";
        }

        [RelayCommand]
        private void AddNewTask()
        {
            if (IsBusy)
                return;

            var newTask = new WorkTask
            {
                TaskTitle = NewWorkTaskTitle,
                Description = NewWorkTaskDescritpion,
                IsActive = false
            };
            WorkTasks.Add(newTask);

            IsBusy = false;
            NewWorkTaskTitle = null;
        }

        [RelayCommand]
        private void RemoveTask()
        {
            var newTasks = WorkTasks.Where(x => x.IsActive).ToList();

            foreach (var task in newTasks)
            {
                if (task.IsActive)
                {
                    WorkTasks.Remove(task);
                }
            }
        }

        [RelayCommand]
        private async Task GoToDetailsAsync(WorkTask workTask)
        {
            if (workTask == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(TODOTask)}", true,
                new Dictionary<string, object>
                {
                    { "WorkTask", workTask }
                });
        }


        
    }
}
