using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using GetStartedApp.Services;

namespace GetStartedApp.Views;

public partial class OneHandKeyboardSettingsView : Window
{
    private string selectedAlignment = "right";

    public OneHandKeyboardSettingsView()
    {
        InitializeComponent();
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        selectedAlignment = LanguageService.OneHandKeyboardAlignment;
        UpdateAlignmentSelection(selectedAlignment);
        UpdateUI();
    }

    private void LeftButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateAlignmentSelection("left");
    }

    private void RightButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateAlignmentSelection("right");
    }

    private void UpdateAlignmentSelection(string alignment)
    {
        selectedAlignment = alignment;

        if (alignment == "left")
        {
            LeftButton.BorderBrush = new SolidColorBrush(Color.Parse("#3498DB"));
            LeftButton.BorderThickness = new Avalonia.Thickness(3);
            RightButton.BorderBrush = new SolidColorBrush(Color.Parse("#7F8C8D"));
            RightButton.BorderThickness = new Avalonia.Thickness(3);
        }
        else
        {
            LeftButton.BorderBrush = new SolidColorBrush(Color.Parse("#7F8C8D"));
            LeftButton.BorderThickness = new Avalonia.Thickness(3);
            RightButton.BorderBrush = new SolidColorBrush(Color.Parse("#3498DB"));
            RightButton.BorderThickness = new Avalonia.Thickness(3);
        }
    }

    private void UpdateUI()
    {
        TitleText.Text = LanguageService.Get("OneHandKeyboardTitle");
        DescText.Text = LanguageService.Get("OneHandKeyboardDesc");
        LeftAlignmentText.Text = LanguageService.Get("LeftAlignment");
        LeftAlignmentDescText.Text = LanguageService.Get("LeftAlignmentDesc");
        RightAlignmentText.Text = LanguageService.Get("RightAlignment");
        RightAlignmentDescText.Text = LanguageService.Get("RightAlignmentDesc");
        OpenButtonControl.Content = LanguageService.Get("SaveButton");
    }

    private void OpenButton_Click(object? sender, RoutedEventArgs e)
    {
        LanguageService.OneHandKeyboardAlignment = selectedAlignment;
        OneHandKeyboardView keyboardView = new OneHandKeyboardView();
        keyboardView.Show();
        Close();
    }
}
