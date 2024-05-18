namespace Blazorbrudi;

public class MvvmOwningViewComponent<TViewModel> : ComponentBase
    where TViewModel : INotifyPropertyChanged
{
    private TViewModel _viewModel = default(TViewModel)!;

    [Inject] public TViewModel ViewModel
    {
        get => _viewModel;
        init
        {
            if (value is null)
            {
                return;
            }

            _viewModel = value;
            _viewModel.PropertyChanged += (_, _) => StateHasChanged();
        }
    }
}
