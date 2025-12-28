using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using GetStartedApp.Services;

namespace GetStartedApp.Views;

public partial class LanguageView : Window
{
    private string selectedLanguage = "pl";

    public LanguageView()
    {
        InitializeComponent();
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        selectedLanguage = LanguageService.CurrentLanguage;
        UpdateLanguageSelection(selectedLanguage);
        UpdateUI();
    }

    private void PolishButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateLanguageSelection("pl");
    }

    private void EnglishButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateLanguageSelection("en");
    }

    private void UpdateLanguageSelection(string language)
    {
        selectedLanguage = language;

        // Update button appearances based on selection
        if (language == "pl")
        {
            PolishButton.BorderBrush = new SolidColorBrush(Color.Parse("#3498DB"));
            PolishButton.BorderThickness = new Avalonia.Thickness(3);
            EnglishButton.BorderBrush = new SolidColorBrush(Color.Parse("#7F8C8D"));
            EnglishButton.BorderThickness = new Avalonia.Thickness(3);
        }
        else
        {
            PolishButton.BorderBrush = new SolidColorBrush(Color.Parse("#7F8C8D"));
            PolishButton.BorderThickness = new Avalonia.Thickness(3);
            EnglishButton.BorderBrush = new SolidColorBrush(Color.Parse("#3498DB"));
            EnglishButton.BorderThickness = new Avalonia.Thickness(3);
        }
    }

    private void UpdateUI()
    {
        TitleText.Text = LanguageService.Get("LanguageTitle");
        SaveButtonControl.Content = LanguageService.Get("SaveButton");
    }

    private void SaveButton_Click(object? sender, RoutedEventArgs e)
    {
        LanguageService.CurrentLanguage = selectedLanguage;
        Close();
    }
}
