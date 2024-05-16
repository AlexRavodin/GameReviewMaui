using System.Collections.ObjectModel;
using System.Security.Authentication;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GameReview.App.Models;
using GameReview.App.Services.Game;

namespace GameReview.App.Pages.GameList;

public partial class GameListViewModel : ObservableObject, IQueryAttributable
{
    private readonly IGameService _gameService;
    
    private string _authId;
    public ObservableCollection<GameDto> Games { get; } = new();

    [ObservableProperty]
    private bool _showFavorites;

    public GameListViewModel(IGameService gameService)
    {
        _gameService = gameService;

        _showFavorites = false;
        LoadGamesCommand = new AsyncRelayCommand(LoadGamesAsync);
    }

    public GameListViewModel(string authId)
    {
        _authId = authId;
        throw new NotImplementedException();
    }

    public IAsyncRelayCommand LoadGamesCommand { get; }

    public async Task LoadGamesAsync()
    {
        Games.Clear();
        var games = ShowFavorites
            ? await _gameService.GetFavoriteGamesDtosByAuthIdAsync(_authId)
            : await _gameService.GetAllGameDtosAsync();

        foreach (var game in games)
        {
            Games.Add(game);
        }
    }

    [RelayCommand]
    private async Task ToggleShowFavorites()
    {
        await LoadGamesAsync();
    }

    [RelayCommand]
    private async Task GameTapped(GameDto? gameDto)
    {
        if (gameDto != null)
        {
            await Shell.Current.GoToAsync($"//GameDetails?gameId={gameDto.GameId}");
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("authId", out var authId))
        {
            _authId = authId as string ?? throw new InvalidOperationException("Bad user id.");
        }
        else
        {
            throw new AuthenticationException("No user id provided.");
        }
    }
}