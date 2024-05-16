namespace GameReview.App.Services.Game;

public interface IGameService
{
    public Task<IEnumerable<Models.GameDto>> GetAllGameDtosAsync();
    
    public Task<GameReview.App.Models.Game?> GetGameByIdAsync(string gameId);
    
    public Task<IEnumerable<Models.GameDto>> GetFavoriteGamesDtosByAuthIdAsync(string authId);
}