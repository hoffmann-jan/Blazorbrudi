using Microsoft.AspNetCore.Components;

namespace Blazorbrudi;

internal sealed class SplitViewInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public SplitViewInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new (() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blazorbrudi/js/layout/split-view.js").AsTask());
    }

    public async ValueTask StartResize(ElementReference containerRef, bool resizeHorizontal)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("startResize", [containerRef, resizeHorizontal]);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
