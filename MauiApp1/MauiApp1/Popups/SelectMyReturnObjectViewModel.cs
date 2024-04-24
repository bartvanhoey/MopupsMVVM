using CommunityToolkit.Mvvm.Input;
using Mopups.PreBaked.AbstractClasses;
using Mopups.PreBaked.Interfaces;

namespace MauiApp1.Popups;

public partial class SelectMyReturnObjectViewModel(IPreBakedMopupService popupService) : PopupViewModel<MyReturnObject>(popupService)
{
    [RelayCommand]
    private void Submit() 
        => SafeCloseModal<SelectMyReturnObjectPopup>(new MyReturnObject { FirstName = "John", LastName = "Doe"});
}

// Or 

// using System.Windows.Input;

// public class SelectMyReturnObjectViewModel : PopupViewModel<MyReturnObject>
// {    private ICommand? _submitCommand;
//  
//      public ICommand? SubmitCommand
//      {
//          get => _submitCommand;
//          set => SetValue(ref _submitCommand, value);
//      }
//     
//     public SelectMyReturnObjectViewModel(IPreBakedMopupService popupService) : base(popupService) 
//         => SubmitCommand = new Command(Submit);
//
//     private void Submit() 
//         => SafeCloseModal<SelectMyReturnObjectPopup>(new MyReturnObject { ReturnName = "JusATest" });
// }