using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TODO.Models;
using TODO.Services;
using TODO.View;

namespace TODO.ViewModel
{
    public partial class TODOViewModel : WorkTask
    {
        public ObservableCollection<WorkTask> WorkTasks { get; set; }

        [ObservableProperty]
        public string newWorkTaskTitle;

        [ObservableProperty]
        public string newWorkTaskDescritpion;

		public TODOViewModel()
        {
            Title = "TODO App";

            WorkTasks = new ObservableCollection<WorkTask>();
            LoadData().ConfigureAwait(false);

        }

        [RelayCommand]
        private async Task AddNewTask()
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

            await ToDoService.AddWorkTask(newTask.TaskTitle);
        }

        [RelayCommand]
        private async Task RemoveTask()
        {
            var newTasks = WorkTasks.Where(x => x.IsActive).ToList();

            foreach (var task in newTasks)
            {
                if (task.IsActive)
                {
                    WorkTasks.Remove(task);
                    await ToDoService.RemoveWorkTask(task.ID);

                }
            }
        }

        private async Task LoadData()
        {
            var tasksFromDatabase = (await ToDoService.GetTask());

            if(tasksFromDatabase != null)
            {
                foreach (var task in tasksFromDatabase)
                {
                    WorkTasks.Add(task);
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
