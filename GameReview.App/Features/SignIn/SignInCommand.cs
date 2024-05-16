using Firebase.Auth;
using GameReview.App.Shared.Commands;

namespace GameReview.App.Features.SignIn;

public class SignInCommand : AsyncCommandBase
{
    private readonly SignInFormViewModel _viewModel;
    
    private readonly FirebaseAuthClient _authClient;

    public SignInCommand(SignInFormViewModel viewModel, FirebaseAuthClient authClient)
    {
        _authClient = authClient;
        _viewModel = viewModel;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        try
        {
            var result = await _authClient.SignInWithEmailAndPasswordAsync(_viewModel.Email,
                _viewModel.Password);
            
            await Application.Current.MainPage.DisplayAlert(
                "Success", "Successfully signed in.", "Ok");

            await Shell.Current.GoToAsync($"//UserDetails?authId={result.User.Uid}");
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error", "Failed to sign in. Please try again later.", "Ok");
        }
    }
}