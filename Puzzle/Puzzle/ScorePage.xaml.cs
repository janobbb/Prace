namespace Puzzle;

public partial class ScorePage : ContentPage
{
    GameController gameController = GameController.Instance;

    public ScorePage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        DisplayResults();
    }
    public void DisplayResults()
    {
        int count = 1;
        Button[] buttons = new Button[] { score1, score2, score3, score4, score5, score6, score7, score8, score9, score10 };
        List<int> results = gameController.GetResults();
        for (int i = 0; i < results.Count; i++)
        {
            buttons[i].Text = $"{count}. {results[i]}";
            count++;
        }
    }

    public async void OnBackButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        await button.ScaleTo(1.1, 50);
        await button.ScaleTo(1, 50);
        await Navigation.PopToRootAsync();
    }
}