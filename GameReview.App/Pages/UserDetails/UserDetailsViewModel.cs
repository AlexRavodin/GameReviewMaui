using System.ComponentModel;
using System.Runtime.CompilerServices;
using GameReview.App.Features.UserDetails;
using GameReview.App.Shared.ViewModels;

namespace GameReview.App.Pages.UserDetails;

public class UserDetailsViewModel : ViewModelBase
{
    public UserDetailsViewModel(UserDetailsFormViewModel userDetailsFormViewModel)
    {
        UserDetailsFormViewModel = userDetailsFormViewModel;
    }

    public UserDetailsFormViewModel UserDetailsFormViewModel
    {
        get;
    }
}