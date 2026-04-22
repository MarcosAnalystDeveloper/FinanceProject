using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using System;

namespace FinanceProject.Elements.Base;

public partial class BaseElement
{
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        if (Design.IsDesignMode)
            return;

        PointerPressed += BaseElementPointerPressed;
    }

    private void BaseElementPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        throw new NotImplementedException();
    }
}