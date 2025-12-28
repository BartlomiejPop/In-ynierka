using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using GetStartedApp.Services;

namespace GetStartedApp.Views;

public partial class SettingsView : Window
{
    public SettingsView()
    {
        InitializeComponent();
        UpdateUI();
    }

    public void UpdateUI()
    {
        Title = LanguageService.Get("SettingsTitle");
        
        // Apply theme
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        
        // Apply global font size
        double fontSize = LanguageService.GlobalFontSize;
        
        if (this.FindControl<TextBlock>("TitleText") is TextBlock titleText)
        {
            titleText.Text = LanguageService.Get("SettingsTitle");
            titleText.FontSize = fontSize * 2.4; // Title is 48px at base 20px
            titleText.Foreground = new SolidColorBrush(Color.Parse(LanguageService.GetForegroundColor()));
        }
        if (this.FindControl<Button>("InfoButton") is Button infoBtn)
        {
            infoBtn.Content = LanguageService.Get("InfoButton");
            infoBtn.FontSize = fontSize * 1.4; // Buttons are 28px at base 20px
        }
        if (this.FindControl<Button>("WiFiButton") is Button wifiBtn)
        {
            wifiBtn.Content = LanguageService.Get("WiFiButton");
            wifiBtn.FontSize = fontSize * 1.4;
        }
        if (this.FindControl<Button>("FontSizeButton") is Button fontSizeBtn)
        {
            fontSizeBtn.Content = LanguageService.Get("FontSizeButton");
            fontSizeBtn.FontSize = fontSize * 1.4;
        }
        if (this.FindControl<Button>("ButtonSizeButton") is Button buttonSizeBtn)
        {
            buttonSizeBtn.Content = LanguageService.Get("ButtonSizeButton");
            buttonSizeBtn.FontSize = fontSize * 1.4;
        }
        if (this.FindControl<Button>("WordListButton") is Button wordListBtn)
        {
            wordListBtn.Content = LanguageService.Get("WordListButton");
            wordListBtn.FontSize = fontSize * 1.4;
        }
        if (this.FindControl<Button>("ThemesButton") is Button themesBtn)
        {
            themesBtn.Content = LanguageService.Get("ThemesButton");
            themesBtn.FontSize = fontSize * 1.4;
        }
    }

    private void InfoButton_Click(object? sender, RoutedEventArgs e)
    {
        InfoView infoView = new InfoView();
        infoView.Show();
    }

    private void FontSizeButton_Click(object? sender, RoutedEventArgs e)
    {
        FontSizeSettingsView fontSizeView = new FontSizeSettingsView();
        fontSizeView.Closed += (s, args) => UpdateUI();
        fontSizeView.Show();
    }

    private void ButtonSizeButton_Click(object? sender, RoutedEventArgs e)
    {
        ButtonSizeSettingsView buttonSizeView = new ButtonSizeSettingsView();
        buttonSizeView.Show();
    }

    private void WordListButton_Click(object? sender, RoutedEventArgs e)
    {
        WordListView wordListView = new WordListView();
        wordListView.Show();
    }

    private void ThemesButton_Click(object? sender, RoutedEventArgs e)
    {
        ThemesView themesView = new ThemesView();
        themesView.Closed += (s, args) => UpdateUI();
        themesView.Show();
    }
}
