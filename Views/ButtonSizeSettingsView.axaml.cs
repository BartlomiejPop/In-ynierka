using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using GetStartedApp.Services;

namespace GetStartedApp.Views;

public partial class ButtonSizeSettingsView : Window
{
    private string selectedSize = "md";

    public ButtonSizeSettingsView()
    {
        InitializeComponent();
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        selectedSize = LanguageService.GlobalButtonSize;
        UpdateButtonSelection(selectedSize);
    }

    private void XsButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateButtonSelection("xs");
    }

    private void SButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateButtonSelection("s");
    }

    private void MdButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateButtonSelection("md");
    }

    private void LButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateButtonSelection("l");
    }

    private void XlButton_Click(object? sender, RoutedEventArgs e)
    {
        UpdateButtonSelection("xl");
    }

    private void UpdateButtonSelection(string size)
    {
        selectedSize = size;

        // Reset all buttons to default color
        XsButton.Background = new SolidColorBrush(Color.Parse("#7F8C8D"));
        SButton.Background = new SolidColorBrush(Color.Parse("#7F8C8D"));
        MdButton.Background = new SolidColorBrush(Color.Parse("#7F8C8D"));
        LButton.Background = new SolidColorBrush(Color.Parse("#7F8C8D"));
        XlButton.Background = new SolidColorBrush(Color.Parse("#7F8C8D"));

        // Highlight selected button
        var selectedColor = new SolidColorBrush(Color.Parse("#3498DB"));
        switch (size)
        {
            case "xs":
                XsButton.Background = selectedColor;
                break;
            case "s":
                SButton.Background = selectedColor;
                break;
            case "md":
                MdButton.Background = selectedColor;
                break;
            case "l":
                LButton.Background = selectedColor;
                break;
            case "xl":
                XlButton.Background = selectedColor;
                break;
        }
    }

    private void SaveButton_Click(object? sender, RoutedEventArgs e)
    {
        LanguageService.GlobalButtonSize = selectedSize;
        Close();
    }
}
