using System;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }
}