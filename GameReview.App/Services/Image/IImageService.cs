namespace GameReview.App.Services.Image;

public interface IImageService
{
    public Task<List<string>> GetImageUrlsByGameIdAsync(string gameId);
}