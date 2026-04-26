using Avalonia;
using Avalonia.Media;

namespace FinanceProject.Elements;

public partial class TextElement
{
    #region Text

    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<TextElement, string>(nameof(Text));
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #region FontColor
    public static readonly StyledProperty<IBrush> TextFontColorProperty = AvaloniaProperty.Register<TextElement, IBrush>(nameof(TextFontColor));
    public IBrush TextFontColor
    {
        get => GetValue(TextFontColorProperty);
        set => SetValue(TextFontColorProperty, value);
    }
    #endregion

    #region FontWeight
    public static readonly StyledProperty<FontWeight> TextFontWeightProperty = AvaloniaProperty.Register<TextElement, FontWeight>(nameof(TextFontWeight));
    public FontWeight TextFontWeight
    {
        get => GetValue(TextFontWeightProperty);
        set => SetValue(TextFontWeightProperty, value);
    }
    #endregion

    #region FontSize
    public static readonly StyledProperty<int> TextFontSizeProperty = AvaloniaProperty.Register<TextElement, int>(nameof(TextFontSize));
    public int TextFontSize
    {
        get => GetValue(TextFontSizeProperty);
        set => SetValue(TextFontSizeProperty, value);
    }
    #endregion

    #region ActiveColor
    public static readonly StyledProperty<IBrush> FontActiveColorProperty = AvaloniaProperty.Register<TextElement, IBrush>(nameof(FontActiveColor));
    public IBrush FontActiveColor
    {
        get => GetValue(FontActiveColorProperty);
        set => SetValue(FontActiveColorProperty, value);
    }
    #endregion

    #region HoverColor
    public static readonly StyledProperty<IBrush> FontHoverColorProperty = AvaloniaProperty.Register<TextElement, IBrush>(nameof(FontHoverColor));
    public IBrush FontHoverColor
    {
        get => GetValue(FontHoverColorProperty);
        set => SetValue(FontHoverColorProperty, value);
    }
    #endregion

    #region PositionX
    public static readonly StyledProperty<double> TextPositionXProperty = AvaloniaProperty.Register<TextElement, double>(nameof(TextPositionX));
    public double TextPositionX
    {
        get => GetValue(TextPositionXProperty);
        set => SetValue(TextPositionXProperty, value);
    }
    #endregion

    #region PositionY
    public static readonly StyledProperty<double> TextPositionYProperty = AvaloniaProperty.Register<TextElement, double>(nameof(TextPositionY));
    public double TextPositionY
    {
        get => GetValue(TextPositionYProperty);
        set => SetValue(TextPositionYProperty, value);
    }
    #endregion

    #endregion

    #region Icon

    public static readonly StyledProperty<string> IconProperty = AvaloniaProperty.Register<TextElement, string>(nameof(Icon));
    public string Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #region IconColor
    public static readonly StyledProperty<IBrush> IconColorProperty = AvaloniaProperty.Register<TextElement, IBrush>(nameof(IconColor));
    public IBrush IconColor
    {
        get => GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }
    #endregion

    #region IconSize
    public static readonly StyledProperty<int> IconSizeProperty = AvaloniaProperty.Register<TextElement, int>(nameof(IconSize));
    public int IconSize
    {
        get => GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }
    #endregion

    #region PositionX
    public static readonly StyledProperty<double> IconPositionXProperty = AvaloniaProperty.Register<TextElement, double>(nameof(IconPositionX));
    public double IconPositionX
    {
        get => GetValue(IconPositionXProperty);
        set => SetValue(IconPositionXProperty, value);
    }
    #endregion

    #region PositionY
    public static readonly StyledProperty<double> IconPositionYProperty = AvaloniaProperty.Register<TextElement, double>(nameof(IconPositionY));
    public double IconPositionY
    {
        get => GetValue(IconPositionYProperty);
        set => SetValue(IconPositionYProperty, value);
    }
    #endregion

    #endregion
}