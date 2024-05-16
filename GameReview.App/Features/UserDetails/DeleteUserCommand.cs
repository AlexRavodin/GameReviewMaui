using FirebaseAdmin;
using FirebaseAdmin.Auth;
using GameReview.App.Shared.Commands;

namespace GameReview.App.Features.UserDetails;

public class DeleteUserDetailsCommand : AsyncCommandBase
{
    private readonly UserDetailsFormViewModel _viewModel;
    public DeleteUserDetailsCommand(UserDetailsFormViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    protected override async Task ExecuteAsync(object parameter)
    {
        try
        {
            await FirebaseAuth.DefaultInstance.DeleteUserAsync("");
            
            await Application.Current.MainPage.DisplayAlert(
                "Success", "Successfully deleted.", "Ok");
            
            await Shell.Current.GoToAsync("//SignIn");
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error", "Failed to delete. Please try again later.", "Ok");
        }
    }
}