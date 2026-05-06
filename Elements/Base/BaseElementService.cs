using Avalonia;
using Avalonia.Styling;

namespace FinanceProject.Elements;

public partial class BaseElement
{
    protected void InitializeBaseElement(string themeName)
    {
        this.DataContext = this;
        Theme = GetTheme(themeName);
    }
    protected ControlTheme GetTheme(string nameStyle)
    {
        ControlTheme theme = default!;
        if (Application.Current!.TryGetResource(nameStyle + "Theme", ThemeVariant.Default, out var result))
        {
            if (result is ControlTheme controlTheme)
                theme = controlTheme;
        }

        return theme;
    }
}