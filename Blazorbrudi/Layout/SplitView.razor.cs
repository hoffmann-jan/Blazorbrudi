using Microsoft.AspNetCore.Components;

namespace Blazorbrudi;

public partial class SplitView : IAsyncDisposable
{
    [Parameter] public RenderFragment ContentTop { get; set; } = null!;
    [Parameter] public RenderFragment ContentBottom { get; set; } = null!;
    [Inject] internal SplitViewInterop SplitViewInterop { get; set; } = default!;

    private ElementReference _containerRef;

    private async Task StartResize(MouseEventArgs e)
    {
        await SplitViewInterop.StartResize(_containerRef);
    }

    public async ValueTask DisposeAsync()
    {
        await SplitViewInterop.DisposeAsync();
    }
}
