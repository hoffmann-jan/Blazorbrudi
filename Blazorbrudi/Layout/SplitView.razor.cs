using Microsoft.AspNetCore.Components;

namespace Blazorbrudi;

/// <summary>
/// Resizeable split of two components. 
/// </summary>
public partial class SplitView : BlazorbrudiComponent, IAsyncDisposable
{
    /// <summary>
    /// Placed top or left.
    /// </summary>
    [Parameter] public RenderFragment FirstContent { get; init; } = null!;
    /// <summary>
    /// Placed bottom or right.
    /// </summary>
    [Parameter] public RenderFragment SecondContent { get; init; } = null!;
    /// <summary>
    /// Changes Split direction.
    /// </summary>
    [Parameter] public SplitMode SplitMode { get; init; } = SplitMode.Vertical;
    [Inject] internal SplitViewInterop SplitViewInterop { get; init; } = default!;

    private ElementReference _containerRef;

    private async Task StartResize(MouseEventArgs _)
    {
        await SplitViewInterop.StartResize(_containerRef, SplitMode is SplitMode.Horizontal);
    }

    private string GetContainerClass()
    {
        var classes = "split-container";

        if (SplitMode == SplitMode.Horizontal)
        {
            classes += " split-container--horizontal";
        }

        if (string.IsNullOrWhiteSpace(CssClasses) is false)
        {
            classes += $" {CssClasses}";
        }

        return classes;
    }

    private string GetSplitBarClass()
    {
        var classes = "split-bar";
        classes += SplitMode switch {
            SplitMode.Horizontal => " split-bar--horizontal",
            SplitMode.Vertical => " split-bar--vertical",
            _ => string.Empty
        };

        return classes;
    }

    /// <inheritdoc />
    public async ValueTask DisposeAsync()
    {
        await SplitViewInterop.DisposeAsync();
    }
}
