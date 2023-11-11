using System.Numerics;

namespace Puzzle;

public partial class MainPage : ContentPage
{
    GameController gameController = GameController.Instance;
    Button nullButton;

    public MainPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        gameController.GenerateRandomArray();
        UpdateButtonLabels();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        await button.ScaleTo(1.1, 50);
        await button.ScaleTo(1, 50);
        await Navigation.PopAsync();
    }
    private async void SwitchButtons(object sender, EventArgs e)
    {
        Button currentButton = (Button)sender;
        Button[] buttons = new Button[9] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

        for (int i = 0; i < buttons.Length; i++)
        {
            if (String.IsNullOrEmpty(buttons[i].Text))
            {
                nullButton = buttons[i];
            }
        }

        await currentButton.ScaleTo(1.1, 50);
        await currentButton.ScaleTo(1, 50);
        ReplaceButtons(nullButton, currentButton);

        if (gameController.Win())
        {
            await DisplayAlert("Gratulacje", $"Przeszedłeś plansze w {gameController.moveCount} ruchach", "OK");
            gameController.results.Add(gameController.moveCount);
            await Navigation.PushAsync(new ScorePage());
        }
    }
    private async void CreateRandomArray(object sender, EventArgs e)
    {
        await ShuffleBtn.ScaleTo(1.1, 50);
        gameController.GenerateRandomArray();
        await ShuffleBtn.ScaleTo(1, 50);

        gameController.moveCount = 0;
        ScoreLbl.Text = $"WYKONANE RUCHY: {gameController.moveCount.ToString()}";
        UpdateButtonLabels();
    }
    private void UpdateButtonLabels()
    {
        Button[] buttons = new Button[9] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
        int[,] array = gameController.GetArray();
        button1.Text = array[0, 0].ToString();
        button2.Text = array[0, 1].ToString();
        button3.Text = array[0, 2].ToString();
        button4.Text = array[1, 0].ToString();
        button5.Text = array[1, 1].ToString();
        button6.Text = array[1, 2].ToString();
        button7.Text = array[2, 0].ToString();
        button8.Text = array[2, 1].ToString();
        button9.Text = array[2, 2].ToString();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].Text == "0")
            {
                buttons[i].Text = null;
            }
        }
    }

    private void ReplaceButtons(Button button1, Button button2)
    {
        int x1 = -1, y1 = -1, x2 = -1, y2 = -1;
        int[,] array = gameController.GetArray();

        if (button1 != null && string.IsNullOrEmpty(button1.Text))
        {
            string text = "0";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == int.Parse(text))
                    {
                        x1 = i;
                        y1 = j;
                    }
                }
            }
        }

        if (!string.IsNullOrEmpty(button2.Text))
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == int.Parse(button2.Text))
                    {
                        x2 = i;
                        y2 = j;
                    }
                }
            }
        }

        if (Math.Abs(x1 - x2) + Math.Abs(y1 - y2) == 1)
        {
            gameController.Switch(x1, y1, x2, y2);
            ScoreLbl.Text = $"WYKONANE RUCHY: {gameController.moveCount.ToString()}";
            UpdateButtonLabels();
        }
    }
}

