using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using TODO.ViewModel;

namespace TODO.Models
{
    public partial class WorkTask : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ObservableProperty]
        public string taskTitle;

        [ObservableProperty]
        public string description;

        [ObservableProperty]
        public bool isActive;

    }
}
