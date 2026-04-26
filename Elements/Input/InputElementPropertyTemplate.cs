using Avalonia;
using Avalonia.Media;
using FinanceProject.Elements.Button;

namespace FinanceProject.Elements.Input;

public partial class InputElement
{
    #region Text

    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<ButtonElement, string>(nameof(Text));
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    #region FontColor
    public static readonly StyledProperty<IBrush> TextFontColorProperty = AvaloniaProperty.Register<ButtonElement, IBrush>(nameof(TextFontColor));
    public IBrush TextFontColor
    {
        get => GetValue(TextFontColorProperty);
        set => SetValue(TextFontColorProperty, value);
    }
    #endregion

    #region FontWeight
    public static readonly StyledProperty<FontWeight> TextFontWeightProperty = AvaloniaProperty.Register<ButtonElement, FontWeight>(nameof(TextFontWeight));
    public FontWeight TextFontWeight
    {
        get => GetValue(TextFontWeightProperty);
        set => SetValue(TextFontWeightProperty, value);
    }
    #endregion

    #region FontSize
    public static readonly StyledProperty<int> TextFontSizeProperty = AvaloniaProperty.Register<ButtonElement, int>(nameof(TextFontSize));
    public int TextFontSize
    {
        get => GetValue(TextFontSizeProperty);
        set => SetValue(TextFontSizeProperty, value);
    }
    #endregion

    #region ActiveColor
    public static readonly StyledProperty<IBrush> FontActiveColorProperty = AvaloniaProperty.Register<ButtonElement, IBrush>(nameof(FontActiveColor));
    public IBrush FontActiveColor
    {
        get => GetValue(FontActiveColorProperty);
        set => SetValue(FontActiveColorProperty, value);
    }
    #endregion

    #region HoverColor
    public static readonly StyledProperty<IBrush> FontHoverColorProperty = AvaloniaProperty.Register<ButtonElement, IBrush>(nameof(FontHoverColor));
    public IBrush FontHoverColor
    {
        get => GetValue(FontHoverColorProperty);
        set => SetValue(FontHoverColorProperty, value);
    }
    #endregion

    #region PositionX
    public static readonly StyledProperty<double> TextPositionXProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(TextPositionX));
    public double TextPositionX
    {
        get => GetValue(TextPositionXProperty);
        set => SetValue(TextPositionXProperty, value);
    }
    #endregion

    #region PositionY
    public static readonly StyledProperty<double> TextPositionYProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(TextPositionY));
    public double TextPositionY
    {
        get => GetValue(TextPositionYProperty);
        set => SetValue(TextPositionYProperty, value);
    }
    #endregion

    #endregion

    #region Value

    public static readonly StyledProperty<string> ValueTextProperty = AvaloniaProperty.Register<ButtonElement, string>(nameof(ValueText));
    public string ValueText
    {
        get => GetValue(ValueTextProperty);
        set => SetValue(ValueTextProperty, value);
    }

    #region ContainerWidth
    public static readonly StyledProperty<double> ValueContainerWidthProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(ValueContainerWidth));
    public double ValueContainerWidth
    {
        get => GetValue(ValueContainerWidthProperty);
        set => SetValue(ValueContainerWidthProperty, value);
    }
    #endregion

    #region ContainerHeight
    public static readonly StyledProperty<double> ValueContainerHeightProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(ValueContainerHeight));
    public double ValueContainerHeight
    {
        get => GetValue(ValueContainerHeightProperty);
        set => SetValue(ValueContainerHeightProperty, value);
    }
    #endregion

    #region FontColor
    public static readonly StyledProperty<IBrush> ValueFontColorProperty = AvaloniaProperty.Register<ButtonElement, IBrush>(nameof(ValueFontColor));
    public IBrush ValueFontColor
    {
        get => GetValue(ValueFontColorProperty);
        set => SetValue(ValueFontColorProperty, value);
    }
    #endregion

    #region FontWeight
    public static readonly StyledProperty<FontWeight> ValueFontWeightProperty = AvaloniaProperty.Register<ButtonElement, FontWeight>(nameof(ValueFontWeight));
    public FontWeight ValueFontWeight
    {
        get => GetValue(ValueFontWeightProperty);
        set => SetValue(ValueFontWeightProperty, value);
    }
    #endregion

    #region FontSize
    public static readonly StyledProperty<int> ValueFontSizeProperty = AvaloniaProperty.Register<ButtonElement, int>(nameof(ValueFontSize));
    public int ValueFontSize
    {
        get => GetValue(ValueFontSizeProperty);
        set => SetValue(ValueFontSizeProperty, value);
    }
    #endregion

    #region ActiveColor
    public static readonly StyledProperty<IBrush> ValueFontActiveColorProperty = AvaloniaProperty.Register<ButtonElement, IBrush>(nameof(ValueFontActiveColor));
    public IBrush ValueFontActiveColor
    {
        get => GetValue(ValueFontActiveColorProperty);
        set => SetValue(ValueFontActiveColorProperty, value);
    }
    #endregion

    #region HoverColor
    public static readonly StyledProperty<IBrush> ValueFontHoverColorProperty = AvaloniaProperty.Register<ButtonElement, IBrush>(nameof(ValueFontHoverColor));
    public IBrush ValueFontHoverColor
    {
        get => GetValue(ValueFontHoverColorProperty);
        set => SetValue(ValueFontHoverColorProperty, value);
    }
    #endregion

    #region PositionX
    public static readonly StyledProperty<double> ValuePositionXProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(ValuePositionX));
    public double ValuePositionX
    {
        get => GetValue(ValuePositionXProperty);
        set => SetValue(ValuePositionXProperty, value);
    }
    #endregion

    #region PositionY
    public static readonly StyledProperty<double> ValuePositionYProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(ValuePositionY));
    public double ValuePositionY
    {
        get => GetValue(ValuePositionYProperty);
        set => SetValue(ValuePositionYProperty, value);
    }
    #endregion

    #endregion

    #region Icon

    public static readonly StyledProperty<string> IconProperty = AvaloniaProperty.Register<ButtonElement, string>(nameof(Icon));
    public string Icon
    {
        get => GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    #region IconColor
    public static readonly StyledProperty<IBrush> IconColorProperty = AvaloniaProperty.Register<ButtonElement, IBrush>(nameof(IconColor));
    public IBrush IconColor
    {
        get => GetValue(IconColorProperty);
        set => SetValue(IconColorProperty, value);
    }
    #endregion

    #region IconSize
    public static readonly StyledProperty<int> IconSizeProperty = AvaloniaProperty.Register<ButtonElement, int>(nameof(IconSize));
    public int IconSize
    {
        get => GetValue(IconSizeProperty);
        set => SetValue(IconSizeProperty, value);
    }
    #endregion

    #region PositionX
    public static readonly StyledProperty<double> IconPositionXProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(IconPositionX));
    public double IconPositionX
    {
        get => GetValue(IconPositionXProperty);
        set => SetValue(IconPositionXProperty, value);
    }
    #endregion

    #region PositionY
    public static readonly StyledProperty<double> IconPositionYProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(IconPositionY));
    public double IconPositionY
    {
        get => GetValue(IconPositionYProperty);
        set => SetValue(IconPositionYProperty, value);
    }
    #endregion

    #endregion
}