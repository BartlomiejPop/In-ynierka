using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.VisualTree;
using GetStartedApp.Services;
using System;
using System.IO;
using System.Linq;

namespace GetStartedApp.Views;

public partial class WordListView : Window
{
    private const string SavedWordsFileName = "saved_words.txt";

    public WordListView()
    {
        InitializeComponent();
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        ApplyThemeToElements();
        LoadSavedWords();
        WordListTextBox.TextChanged += WordListTextBox_TextChanged;
    }

    private void ApplyThemeToElements()
    {
        var keyboardBg = new SolidColorBrush(Color.Parse(LanguageService.GetKeyboardBackgroundColor()));
        var panelBg = new SolidColorBrush(Color.Parse(LanguageService.GetPanelBackgroundColor()));
        
        // Apply background to all StackPanels
        var stackPanels = this.GetVisualDescendants().OfType<StackPanel>();
        foreach (var panel in stackPanels)
        {
            panel.Background = keyboardBg;
        }
        
        // Apply background to Borders
        var borders = this.GetVisualDescendants().OfType<Border>();
        foreach (var border in borders)
        {
            if (border.Background != null)
            {
                border.Background = panelBg;
            }
        }
    }

    private void KeyButton_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Content is string key)
        {
            InsertTextAtCursor(key);
        }
    }

    private void Space_Click(object? sender, RoutedEventArgs e)
    {
        InsertTextAtCursor(" ");
    }

    private void Backspace_Click(object? sender, RoutedEventArgs e)
    {
        if (WordListTextBox.Text != null && WordListTextBox.Text.Length > 0 && WordListTextBox.CaretIndex > 0)
        {
            int caretIndex = WordListTextBox.CaretIndex;
            WordListTextBox.Text = WordListTextBox.Text.Remove(caretIndex - 1, 1);
            WordListTextBox.CaretIndex = caretIndex - 1;
        }
    }

    private void Enter_Click(object? sender, RoutedEventArgs e)
    {
        InsertTextAtCursor(Environment.NewLine);
    }

    private void InsertTextAtCursor(string text)
    {
        int caretIndex = WordListTextBox.CaretIndex;
        string currentText = WordListTextBox.Text ?? string.Empty;
        
        WordListTextBox.Text = currentText.Insert(caretIndex, text);
        WordListTextBox.CaretIndex = caretIndex + text.Length;
        WordListTextBox.Focus();
    }

    private void LoadSavedWords()
    {
        try
        {
            if (File.Exists(SavedWordsFileName))
            {
                string savedText = File.ReadAllText(SavedWordsFileName);
                WordListTextBox.Text = savedText;
                UpdateWordCount();
            }
        }
        catch (Exception ex)
        {
            // Handle error silently or show message
            Console.WriteLine($"Error loading saved words: {ex.Message}");
        }
    }

    private void WordListTextBox_TextChanged(object? sender, Avalonia.Controls.TextChangedEventArgs e)
    {
        UpdateWordCount();
    }

    private void UpdateWordCount()
    {
        if (WordCountText != null && WordListTextBox != null)
        {
            string text = WordListTextBox.Text ?? string.Empty;
            var lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var words = lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();
            WordCountText.Text = $"Liczba słów: {words.Length}";
        }
    }

    private void ClearButton_Click(object? sender, RoutedEventArgs e)
    {
        WordListTextBox.Text = string.Empty;
    }

    private void SaveButton_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            string text = WordListTextBox.Text ?? string.Empty;
            File.WriteAllText(SavedWordsFileName, text);
            
            // Show success feedback (you could add a temporary message)
            Close();
        }
        catch (Exception ex)
        {
            // Handle error - you could show an error dialog
            Console.WriteLine($"Error saving words: {ex.Message}");
        }
    }
}
