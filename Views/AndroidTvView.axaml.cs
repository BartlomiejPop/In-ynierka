using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.VisualTree;
using GetStartedApp.Services;
using System.Linq;

namespace GetStartedApp.Views;

public partial class AndroidTvView : Window
{
    public AndroidTvView()
    {
        InitializeComponent();
        Background = new SolidColorBrush(Color.Parse(LanguageService.GetBackgroundColor()));
        ApplyThemeToBorders();
    }

    private void ApplyThemeToBorders()
    {
        var borderBg = new SolidColorBrush(Color.Parse(LanguageService.GetBorderColor()));
        var borders = this.GetVisualDescendants().OfType<Border>();
        foreach (var border in borders)
        {
            if (border.Background != null)
            {
                border.Background = borderBg;
            }
        }
    }
}
