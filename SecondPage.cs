namespace AnimationCrashOnNavigation;

public sealed class SecondPage : ContentPage
{
    private ScrollView _scrollView;

    public SecondPage()
    {
        Title = nameof(SecondPage);
        Build();
    }

    protected override void OnAppearing()
    {
        MainThread.BeginInvokeOnMainThread(() => 
            _scrollView.ScrollToAsync(0, 10000, true));
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _scrollView?.Handler?.DisconnectHandler();
    }

    private void Build()
    {
        _scrollView = new ScrollView
        {
            Content = new VerticalStackLayout
            {
                Children = 
                {
                    new BoxView
                    {
                        HeightRequest = 10000,
                        Background = new LinearGradientBrush(
                            new GradientStopCollection
                            {
                                new GradientStop(Colors.White, .1f),
                                new GradientStop(Colors.Black, .9f)
                            })
                    },
                    new Label 
                    {
                        FontSize = 40,
                        Text = "End of Second Page",
                        HorizontalOptions = LayoutOptions.Center,
                    },
                }
            }
        };

        Content = _scrollView;
    }
}