
namespace Puzzle;

public partial class InstructionPage : ContentPage
{
	public InstructionPage()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

	public async void OnBackButtonClicked(object sender, EventArgs e)
	{
        Button button = (Button)sender;
        await button.ScaleTo(1.1, 50);
        await button.ScaleTo(1, 50);
        await Navigation.PopToRootAsync();
	}
}