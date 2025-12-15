using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GetStartedApp.Views;

public partial class MenuWindow : Window
{
    public MenuWindow()
    {
        InitializeComponent();
    }

    private void KeyboardButton_Click(object? sender, RoutedEventArgs e)
    {
        KeyboardView keyboardView = new KeyboardView();
        keyboardView.Show();
    }

    private void SettingsButton_Click(object? sender, RoutedEventArgs e)
    {
        // TODO: Implement settings view
    }

    private void LanguageButton_Click(object? sender, RoutedEventArgs e)
    {
        // TODO: Implement language view
    }
}

