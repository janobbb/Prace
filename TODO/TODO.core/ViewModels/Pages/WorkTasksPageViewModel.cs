namespace TODO.core
{
    public class WorkTasksPageViewModel
    {
        public List<WorkTaskViewModel> WorkTasks { get; set; } = new List<WorkTaskViewModel>();

        public string? NewWorkTaskTitle { get; set; }

        public void AddNewTask()
        {
            var newTask = new WorkTaskViewModel
            {
                Title = NewWorkTaskTitle,
                CreatedDate = DateTime.Now,
            };
            
            WorkTasks.Add(newTask);
        }
    }
}
