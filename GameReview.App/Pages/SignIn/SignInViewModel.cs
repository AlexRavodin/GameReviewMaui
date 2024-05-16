using GameReview.App.Features.SignIn;
using GameReview.App.Shared.ViewModels;

namespace GameReview.App.Pages.SignIn;

public class SignInViewModel : ViewModelBase
{
    public SignInViewModel(SignInFormViewModel signInFormViewModel)
    {
        SignInFormViewModel = signInFormViewModel;
    }

    public SignInFormViewModel SignInFormViewModel { get; }
}