using TODO.ViewModel;

namespace TODO.View;

public partial class TODOTask : ContentPage
{
	public TODOTask(TODOTaskViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}