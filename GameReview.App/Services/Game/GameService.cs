using GameReview.App.Models;
using Google.Cloud.Firestore;

namespace GameReview.App.Services.Game;

public class GameService : IGameService
{
    private readonly FirestoreDb _firestoreDb;
    
    private const string GamesCollection = "games";
    private const string FavoriteItemsCollection = "favorite_items";

    public GameService(string projectId)
    {
        _firestoreDb = FirestoreDb.Create(projectId);
    }

    public async Task<IEnumerable<GameDto>> GetAllGameDtosAsync()
    {
        var games = new List<GameDto>();

        var gamesSnapshot = await _firestoreDb.Collection(GamesCollection).GetSnapshotAsync();

        foreach (var document in gamesSnapshot.Documents)
        {
            if (!document.Exists) continue;
            
            var game = document.ConvertTo<GameReview.App.Models.Game>();
            games.Add(new GameDto
            {
                GameId = document.Id,
                Name = game.Name
            });
        }
        return games;
    }

    public async Task<GameReview.App.Models.Game?> GetGameByIdAsync(string gameId)
    {
        var gameSnapshot = await _firestoreDb.Collection(GamesCollection).Document(gameId).GetSnapshotAsync();

        if (!gameSnapshot.Exists) return null;
        
        var game = gameSnapshot.ConvertTo<GameReview.App.Models.Game>();
        
        return game;
    }

    public async Task<IEnumerable<GameDto>> GetFavoriteGamesDtosByAuthIdAsync(string authId)
    {
        List<GameDto> favoriteGames = new();
        Query query = _firestoreDb.Collection(FavoriteItemsCollection).WhereEqualTo("UserId", authId);
        QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

        foreach (DocumentSnapshot document in querySnapshot.Documents)
        {
            if (!document.Exists) continue;
            
            string gameId = document.GetValue<string>("GameId");
            
            var gameDoc = await _firestoreDb.Collection(GamesCollection).Document(gameId).GetSnapshotAsync();
            if (!gameDoc.Exists) continue;
            
            Models.Game game = gameDoc.ConvertTo<Models.Game>();
            favoriteGames.Add(new GameDto
            {
                GameId = gameDoc.Id,
                Name = game.Name
            });
        }

        return favoriteGames;
    }
}