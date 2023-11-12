using TODO.ViewModel;

namespace TODO
{
    public partial class MainPage : ContentPage
    {

        public MainPage(TODOViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }


    }
}