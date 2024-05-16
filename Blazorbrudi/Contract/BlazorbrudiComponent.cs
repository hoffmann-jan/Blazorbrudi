using Microsoft.AspNetCore.Components;

namespace Blazorbrudi;

public class BlazorbrudiComponent : ComponentBase
{
    [Parameter] public string? CssClasses { get; set; }
    [Parameter] public string? CssStyles { get; set; }
}
