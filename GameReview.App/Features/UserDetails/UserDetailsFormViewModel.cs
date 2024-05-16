using System.Windows.Input;
using GameReview.App.Services.User;
using GameReview.App.Shared.ViewModels;

namespace GameReview.App.Features.UserDetails;

public class UserDetailsFormViewModel : ViewModelBase
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
    
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }
    
    private string _favoriteGenre;

    public string FavoriteGenre
    {
        get => _favoriteGenre;
        set
        {
            _favoriteGenre = value;
            OnPropertyChanged();
        }
    }
    
    private string _favoriteGame;

    public string FavoriteGame
    {
        get => _favoriteGame;
        set
        {
            _favoriteGame = value;
            OnPropertyChanged();
        }
    }
    
    private int _age;

    public int Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand UpdateUserCommand { get; }
    
    public ICommand DeleteUserCommand { get; }

    public UserDetailsFormViewModel(IUserService userService)
    {
        UpdateUserCommand = new UpdateUserDetailsCommand(this, userService);
        DeleteUserCommand = new DeleteUserDetailsCommand(this);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        throw new NotImplementedException();
    }
}