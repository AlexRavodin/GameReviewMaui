using Firebase.Auth;
using GameReview.App.Shared.Commands;

namespace GameReview.App.Features.SignUp;

public class SignUpCommand : AsyncCommandBase
{
    private readonly SignUpFormViewModel _viewModel;
    
    private readonly FirebaseAuthClient _authClient;

    public SignUpCommand(SignUpFormViewModel viewModel, FirebaseAuthClient authClient)
    {
        _authClient = authClient;
        _viewModel = viewModel;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        if (_viewModel.Password != _viewModel.ConfirmPassword)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error", "Password and confirm password do not match.", "Ok");
            
            return;
        }
        
        try
        {
            await _authClient.CreateUserWithEmailAndPasswordAsync(_viewModel.Email,
                _viewModel.Password);
            
            await Application.Current.MainPage.DisplayAlert(
                "Success", "Successfully signed up.", "Ok");
            
            await Shell.Current.GoToAsync("//SignIn");
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error", "Failed to sign up. Please try again later.", "Ok");
        }
    }
}