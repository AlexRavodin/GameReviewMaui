using GameReview.App.Services.User;
using GameReview.App.Shared.Commands;

namespace GameReview.App.Features.UserDetails;

public class UpdateUserDetailsCommand : AsyncCommandBase
{
    private readonly UserDetailsFormViewModel _viewModel;

    private readonly IUserService _userService;
    public UpdateUserDetailsCommand(UserDetailsFormViewModel viewModel, IUserService userService)
    {
        _viewModel = viewModel;
        _userService = userService;
    }

    protected override Task ExecuteAsync(object parameter)
    {
        try
        {
            _userService.UpdateUserAsync()
            
            await _user.DefaultInstance.DeleteUserAsync("");
            
            await Application.Current.MainPage.DisplayAlert(
                "Success", "Successfully updated.", "Ok");
        }
        catch (Exception)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Error", "Failed to update. Please try again later.", "Ok");
        }
    }
}