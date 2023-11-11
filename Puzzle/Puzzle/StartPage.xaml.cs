namespace Puzzle;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

	public async void OnStartButtonClicked(object sender, EventArgs e)
	{
        Button button = (Button)sender;
		await button.ScaleTo(1.1, 50);
		await button.ScaleTo(1, 50);
        await Navigation.PushAsync(new MainPage());
	}
    public async void OnInstructionButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        await button.ScaleTo(1.1, 50);
        await button.ScaleTo(1, 50);
        await Navigation.PushAsync(new InstructionPage());
    }


}