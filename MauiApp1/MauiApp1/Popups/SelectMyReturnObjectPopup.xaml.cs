using Mopups.PreBaked.Interfaces;

namespace MauiApp1.Popups;

public partial class SelectMyReturnObjectPopup : IGenericViewModel<SelectMyReturnObjectViewModel>
{
    TaskCompletionSource<MyReturnObject?>? _taskCompletionSource;
    public Task<MyReturnObject?> PopupDismissedTask =>  _taskCompletionSource?.Task ?? Task.FromResult<MyReturnObject>(null!)!;

    private SelectMyReturnObjectViewModel? ViewModel
    {
        get => BindingContext as SelectMyReturnObjectViewModel;
        set => BindingContext = value;
    }

    public SelectMyReturnObjectPopup() => InitializeComponent();

    public void SetViewModel(SelectMyReturnObjectViewModel? viewModel) => BindingContext = ViewModel = viewModel;

    public SelectMyReturnObjectViewModel GetViewModel() => ViewModel ?? throw new InvalidOperationException();

    protected override void OnAppearing()
    {
        _taskCompletionSource = new TaskCompletionSource<MyReturnObject?>();
        base.OnAppearing();
    }


    protected override bool OnBackButtonPressed()
    {
        ViewModel?.SafeCloseModal<SelectMyReturnObjectPopup>();
        return base.OnBackButtonPressed();
    }
    
    protected override bool OnBackgroundClicked()
    {
        ViewModel?.SafeCloseModal<SelectMyReturnObjectPopup>();
        return base.OnBackgroundClicked();
    }

    protected override async void OnDisappearing()
    {
        var returnableTask = ViewModel?.Returnable.Task;
        if (returnableTask != null)
        {
            var returnObject = await returnableTask;
            _taskCompletionSource?.SetResult(returnObject);
        }
        base.OnDisappearing();
    }
}