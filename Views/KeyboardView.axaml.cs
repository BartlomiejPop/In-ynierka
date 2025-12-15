using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GetStartedApp.Views;

public partial class KeyboardView : Window
{
    private bool isCapsLocked = false;

    public KeyboardView()
    {
        InitializeComponent();
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
