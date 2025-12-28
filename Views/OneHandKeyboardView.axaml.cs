using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using GetStartedApp.Services;
using System.Linq;

namespace GetStartedApp.Views;

public partial class OneHandKeyboardView : Window
{
    private bool isCapsLocked = false;

    public OneHandKeyboardView()
    {
        InitializeComponent();
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetKeyboardBackgroundColor()));
        ApplyThemeToStackPanels();
        ApplyAlignment();
    }

    private void ApplyThemeToStackPanels()
    {
        var keyboardBg = new SolidColorBrush(Color.Parse(LanguageService.GetKeyboardBackgroundColor()));
        
        // Apply background to all StackPanels
        var stackPanels = this.GetVisualDescendants().OfType<StackPanel>();
        foreach (var panel in stackPanels)
        {
            panel.Background = keyboardBg;
        }
    }

    private void ApplyAlignment()
    {
        string alignment = LanguageService.OneHandKeyboardAlignment;
        
        // Get screen dimensions
        var screen = Screens.Primary;
        if (screen != null)
        {
            var workingArea = screen.WorkingArea;
            
            if (alignment == "left")
            {
                Position = new Avalonia.PixelPoint(0, (int)(workingArea.Height - Height) / 2);
            }
            else
            {
                Position = new Avalonia.PixelPoint((int)(workingArea.Width - Width), (int)(workingArea.Height - Height) / 2);
            }
        }
    }

    private void KeyButton_Click(object? sender, RoutedEventArgs e)
    {
        // Button click handler - can be used for future functionality
    }

    private void SpecialKey_Click(object? sender, RoutedEventArgs e)
    {
        // Special key click handler - can be used for future functionality
    }

    private void Space_Click(object? sender, RoutedEventArgs e)
    {
        // Space key handler - can be used for future functionality
    }

    private void Backspace_Click(object? sender, RoutedEventArgs e)
    {
        // Backspace handler - can be used for future functionality
    }

    private void ToggleCaps_Click(object? sender, RoutedEventArgs e)
    {
        isCapsLocked = !isCapsLocked;
        
        if (sender is Button capsButton)
        {
            capsButton.Background = isCapsLocked 
                ? new Avalonia.Media.SolidColorBrush(Avalonia.Media.Color.Parse("#004d99"))
                : new Avalonia.Media.SolidColorBrush(Avalonia.Media.Color.Parse("#0066cc"));
        }
    }

    private void Enter_Click(object? sender, RoutedEventArgs e)
    {
        // Enter key handler - can be used for future functionality
    }
}
