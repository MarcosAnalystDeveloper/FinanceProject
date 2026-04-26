using Avalonia;
using Avalonia.Media;
using FinanceProject.Elements.Button;

namespace FinanceProject.Elements.Base;

public partial class BaseElement
{
    #region Width
    public new static readonly StyledProperty<double> WidthProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(Width));
    public new double Width
    {
        get => GetValue(WidthProperty);
        set => SetValue(WidthProperty, value);
    }
    #endregion

    #region Height
    public new static readonly StyledProperty<double> HeightProperty = AvaloniaProperty.Register<ButtonElement, double>(nameof(Height));
    public new double Height
    {
        get => GetValue(HeightProperty);
        set => SetValue(HeightProperty, value);
    }
    #endregion

    #region Background

    public static readonly StyledProperty<IBrush> BackgroundColorProperty = AvaloniaProperty.Register<BaseElement, IBrush>(nameof(BackgroundColor));
    public IBrush BackgroundColor
    {
        get => GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    #region ActiveColor
    public static readonly StyledProperty<IBrush> ActiveColorProperty = AvaloniaProperty.Register<BaseElement, IBrush>(nameof(ActiveColor));
    public IBrush ActiveColor
    {
        get => GetValue(ActiveColorProperty);
        set => SetValue(ActiveColorProperty, value);
    }
    #endregion

    #region HoverColor
    public static readonly StyledProperty<IBrush> HoverColorProperty = AvaloniaProperty.Register<BaseElement, IBrush>(nameof(HoverColor));
    public IBrush HoverColor
    {
        get => GetValue(HoverColorProperty);
        set => SetValue(HoverColorProperty, value);
    }
    #endregion

    #endregion

    #region Border

    public static readonly StyledProperty<IBrush> BorderColorProperty = AvaloniaProperty.Register<BaseElement, IBrush>(nameof(BorderColor));
    public IBrush BorderColor
    {
        get => GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    #region ActiveColor
    public static readonly StyledProperty<IBrush> BorderActiveColorProperty = AvaloniaProperty.Register<BaseElement, IBrush>(nameof(BorderActiveColor));
    public IBrush BorderActiveColor
    {
        get => GetValue(BorderActiveColorProperty);
        set => SetValue(BorderActiveColorProperty, value);
    }
    #endregion

    #region HoverColor
    public static readonly StyledProperty<IBrush> BorderHoverColorProperty = AvaloniaProperty.Register<BaseElement, IBrush>(nameof(BorderHoverColor));
    public IBrush BorderHoverColor
    {
        get => GetValue(BorderHoverColorProperty);
        set => SetValue(BorderHoverColorProperty, value);
    }
    #endregion

    #region BorderThickness
    public new static readonly StyledProperty<Thickness> BorderThicknessProperty = AvaloniaProperty.Register<BaseElement, Thickness>(nameof(BorderThickness));
    public new Thickness BorderThickness
    {
        get => GetValue(BorderThicknessProperty);
        set => SetValue(BorderThicknessProperty, value);
    }
    #endregion

    #endregion

    #region CornerRadius
    public new static readonly StyledProperty<Thickness> CornerRadiusProperty = AvaloniaProperty.Register<BaseElement, Thickness>(nameof(CornerRadius));
    public new Thickness CornerRadius
    {
        get => GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }
    #endregion
}