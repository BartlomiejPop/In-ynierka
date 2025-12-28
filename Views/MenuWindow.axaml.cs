using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using GetStartedApp.Services;

namespace GetStartedApp.Views;

public partial class MenuWindow : Window
{
    public MenuWindow()
    {
        InitializeComponent();
        UpdateUI();
    }

    public void UpdateUI()
    {
        Title = LanguageService.Get("MainMenuTitle");
        
        // Apply theme
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        
        // Apply global font size
        double fontSize = LanguageService.GlobalFontSize;
        
        if (this.FindControl<TextBlock>("TitleText") is TextBlock titleText)
        {
            titleText.Text = LanguageService.Get("MainMenuTitle");
            titleText.FontSize = fontSize * 2.4; // Title is 48px at base 20px
            titleText.Foreground = new SolidColorBrush(Color.Parse(LanguageService.GetForegroundColor()));
        }
        if (this.FindControl<Button>("KeyboardButton") is Button keyboardBtn)
        {
            keyboardBtn.Content = LanguageService.Get("KeyboardButton");
            keyboardBtn.FontSize = fontSize * 1.6; // Buttons are 32px at base 20px
        }
        if (this.FindControl<Button>("SettingsButton") is Button settingsBtn)
        {
            settingsBtn.Content = LanguageService.Get("SettingsButton");
            settingsBtn.FontSize = fontSize * 1.6;
        }
        if (this.FindControl<Button>("LanguageButton") is Button languageBtn)
        {
            languageBtn.Content = LanguageService.Get("LanguageButton");
            languageBtn.FontSize = fontSize * 1.6;
        }
        if (this.FindControl<Button>("AndroidTvButton") is Button androidBtn)
        {
            androidBtn.Content = LanguageService.Get("AndroidTvButton");
            androidBtn.FontSize = fontSize * 1.6;
        }
        if (this.FindControl<Button>("OneHandKeyboardButton") is Button oneHandBtn)
        {
            if (oneHandBtn.Content is TextBlock textBlock)
            {
                textBlock.Text = LanguageService.Get("OneHandKeyboardButton");
                textBlock.FontSize = fontSize * 1.6;
            }
        }
    }

    private void KeyboardButton_Click(object? sender, RoutedEventArgs e)
    {
        KeyboardView keyboardView = new KeyboardView();
        keyboardView.Show();
    }

    private void SettingsButton_Click(object? sender, RoutedEventArgs e)
    {
        SettingsView settingsView = new SettingsView();
        settingsView.Closed += (s, args) => UpdateUI();
        settingsView.Show();
    }

    private void LanguageButton_Click(object? sender, RoutedEventArgs e)
    {
        LanguageView languageView = new LanguageView();
        languageView.Closed += (s, args) => UpdateUI();
        languageView.Show();
    }

    private void AndroidTvButton_Click(object? sender, RoutedEventArgs e)
    {
        AndroidTvView androidTvView = new AndroidTvView();
        androidTvView.Show();
    }

    private void OneHandKeyboardButton_Click(object? sender, RoutedEventArgs e)
    {
        OneHandKeyboardSettingsView oneHandSettings = new OneHandKeyboardSettingsView();
        oneHandSettings.Show();
    }
}

