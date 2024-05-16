using System.Windows.Input;
using Firebase.Auth;
using GameReview.App.Shared.ViewModels;

namespace GameReview.App.Features.SignUp;

public class SignUpFormViewModel : ViewModelBase
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
    
    private string _confirmPassword;

    public string ConfirmPassword
    {
        get => _confirmPassword;
        set
        {
            _confirmPassword = value;
            OnPropertyChanged();
        }
    }

    public ICommand SignUpCommand { get; }

    public SignUpFormViewModel(FirebaseAuthClient authClient)
    {
        SignUpCommand = new SignUpCommand(this, authClient);
    }
}