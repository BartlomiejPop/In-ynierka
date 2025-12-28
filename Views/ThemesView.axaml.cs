using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using GetStartedApp.Services;

namespace GetStartedApp.Views;

public partial class ThemesView : Window
{
    private string selectedTheme = "dark";

    public ThemesView()
    {
        InitializeComponent();
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        UpdateThemeSelection(LanguageService.CurrentTheme);
    }

    private void DarkModeButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateThemeSelection("dark");
    }

    private void LightModeButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateThemeSelection("light");
    }

    private void UpdateThemeSelection(string theme)
    {
        selectedTheme = theme;

        // Update button appearances based on selection
        if (theme == "dark")
        {
            DarkModeButton.BorderBrush = new SolidColorBrush(Color.Parse("#3498DB"));
            DarkModeButton.BorderThickness = new Avalonia.Thickness(3);
            LightModeButton.BorderBrush = new SolidColorBrush(Color.Parse("#7F8C8D"));
            LightModeButton.BorderThickness = new Avalonia.Thickness(3);
        }
        else
        {
            DarkModeButton.BorderBrush = new SolidColorBrush(Color.Parse("#7F8C8D"));
            DarkModeButton.BorderThickness = new Avalonia.Thickness(3);
            LightModeButton.BorderBrush = new SolidColorBrush(Color.Parse("#3498DB"));
            LightModeButton.BorderThickness = new Avalonia.Thickness(3);
        }
    }

    private void SaveButton_Click(object? sender, RoutedEventArgs e)
    {
        LanguageService.CurrentTheme = selectedTheme;
        Close();
    }
}
