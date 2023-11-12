using CommunityToolkit.Mvvm.ComponentModel;
using TODO.ViewModel;

namespace TODO.Models
{
    public partial class WorkTask : BaseViewModel
    {

        [ObservableProperty]
        public string taskTitle;

        [ObservableProperty]
        public string description;

        [ObservableProperty]
        public bool isActive;
        public bool IsEditing { get; set; } = false;
        public bool IsNotEditing => !IsEditing;

    }
}
