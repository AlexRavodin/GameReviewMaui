using GameReview.App.Models;

namespace GameReview.App.Services.User;

public interface IUserService
{
    public Task DeleteUserAsync(string userId);

    public Task CreateUserAsync(AppUser user);

    public Task UpdateUserAsync(string userId, AppUser user);
    
    public Task ToggleFavoriteStatusAsync(string authId, string gameId);
    
    public Task<bool> IsFavoriteGameAsync(string authId, string gameId);
}