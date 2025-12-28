using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using GetStartedApp.Services;
using System.Linq;

namespace GetStartedApp.Views;

public partial class FontSizeSettingsView : Window
{
    public FontSizeSettingsView()
    {
        InitializeComponent();
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        ApplyThemeToBorders();
        FontSizeSlider.Value = LanguageService.GlobalFontSize;
    }

    private void ApplyThemeToBorders()
    {
        var panelBg = new SolidColorBrush(Color.Parse(LanguageService.GetPanelBackgroundColor()));
        var borders = this.GetVisualDescendants().OfType<Border>();
        foreach (var border in borders)
        {
            if (border.Background != null)
            {
                border.Background = panelBg;
            }
        }
    }

    private void FontSizeSlider_ValueChanged(object? sender, Avalonia.Controls.Primitives.RangeBaseValueChangedEventArgs e)
    {
        if (FontSizeDisplay != null && PreviewText != null)
        {
            int fontSize = (int)e.NewValue;
            FontSizeDisplay.Text = $"Rozmiar: {fontSize}px";
            PreviewText.FontSize = fontSize;
        }
    }

    private void SaveButton_Click(object? sender, RoutedEventArgs e)
    {
        int fontSize = (int)FontSizeSlider.Value;
        LanguageService.GlobalFontSize = fontSize;
        Close();
    }
}
