using MauiApp1.Popups;
using Mopups.PreBaked.Services;
using Mopups.Services;

namespace MauiApp1;

public partial class MainPage
{
    public MainPage() => InitializeComponent();

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        var popup = new SelectMyReturnObjectPopup();
        popup.SetViewModel(new SelectMyReturnObjectViewModel(PreBakedMopupService.GetInstance()));

        await MopupService.Instance.PushAsync(popup);

        var myReturnObject = await popup.PopupDismissedTask;
    }
}