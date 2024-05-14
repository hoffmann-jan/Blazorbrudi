using Microsoft.AspNetCore.Components;

namespace Blazorbrudi;

public partial class SplitView : IAsyncDisposable
{
    [Parameter] public RenderFragment FirstContent { get; init; } = null!;
    [Parameter] public RenderFragment SecondContent { get; init; } = null!;
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

    public async ValueTask DisposeAsync()
    {
        await SplitViewInterop.DisposeAsync();
    }
}
