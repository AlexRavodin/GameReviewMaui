using System.Windows.Input;
using Firebase.Auth;
using GameReview.App.Shared.ViewModels;

namespace GameReview.App.Features.SignIn;

public class SignInFormViewModel : ViewModelBase
{
    private string _email;

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged();
        }
    }
    
    private string _password;

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand SignInCommand { get; }

    public SignInFormViewModel(FirebaseAuthClient authClient)
    {
        SignInCommand = new SignInCommand(this, authClient);
    }
}