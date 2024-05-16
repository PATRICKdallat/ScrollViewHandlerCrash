namespace AnimationCrashOnNavigation;

public sealed class MainPage : ContentPage
{
    public MainPage()
    {
        Title = nameof(MainPage);
        Build();
    }

    private void Build()
    {
        Content = new VerticalStackLayout
        {
            Children = 
            {
                new Button
                {
                    Margin = 20,
                    HeightRequest = 50,
                    TextColor = Colors.White,
                    Text = "Navigate to second page",
                    VerticalOptions = LayoutOptions.Start,
                    Command = new Command(NavigateToSecondPage)
                },
            }
        };
    }

    private void NavigateToSecondPage()
    {
        Navigation.PushAsync(new SecondPage());
    }
}