using GameReview.App.Features.SignUp;
using GameReview.App.Shared.ViewModels;

namespace GameReview.App.Pages.SignUp;

public class SignUpViewModel : ViewModelBase
{
    public SignUpViewModel(SignUpFormViewModel signUpFormViewModel)
    {
        SignUpFormViewModel = signUpFormViewModel;
    }

    public SignUpFormViewModel SignUpFormViewModel { get; }
}