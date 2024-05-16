using System.Data;
using GameReview.App.Models;
using Google.Cloud.Firestore;

namespace GameReview.App.Services.User;

public class UserService : IUserService
{
    private readonly FirestoreDb _firestoreDb;

    private const string CollectionName = "users";
    private const string FavoriteItemsCollection = "favorite_items";

    public UserService(FirestoreDb firestoreDb)
    {
        _firestoreDb = firestoreDb;
    }

    public async Task CreateUserAsync(AppUser user)
    {
        await _firestoreDb.Collection(CollectionName).AddAsync(user);
    }
    
    public async Task UpdateUserAsync(string authId, AppUser updatedUser)
    {
        var userDoc = await FindUserByAuthIdAsync(authId);
        
        await userDoc.SetAsync(updatedUser, SetOptions.Overwrite);
    }

    public async Task DeleteUserAsync(string authId)
    {
        var userDoc = await FindUserByAuthIdAsync(authId);
        
        await userDoc.DeleteAsync();
    }
    
    private async Task<DocumentReference> FindUserByAuthIdAsync(string authId)
    {
        var querySnapshot = await _firestoreDb.Collection(CollectionName).WhereEqualTo("AuthId", authId).GetSnapshotAsync();

        if (querySnapshot.Documents.Count > 0)
        {
            return querySnapshot.Documents[0].Reference;
        }

        throw new DataException("User not exists");
    }
    
    public async Task ToggleFavoriteStatusAsync(string authId, string gameId)
    {
        var query = _firestoreDb.Collection(FavoriteItemsCollection)
            .WhereEqualTo("UserId", authId)
            .WhereEqualTo("GameId", gameId);
        var querySnapshot = await query.GetSnapshotAsync();

        if (querySnapshot.Documents.Count > 0)
        {
            foreach (var document in querySnapshot.Documents)
            {
                await document.Reference.DeleteAsync();
            }
        }
        else
        {
            var favoriteItem = new FavoriteItem { UserId = authId, GameId = gameId };
            
            await _firestoreDb.Collection(FavoriteItemsCollection).AddAsync(favoriteItem);
        }
    }
    public async Task<bool> IsFavoriteGameAsync(string authId, string gameId)
    {
        var query = _firestoreDb.Collection(FavoriteItemsCollection)
            .WhereEqualTo("UserId", authId)
            .WhereEqualTo("GameId", gameId);
        var querySnapshot = await query.GetSnapshotAsync();

        return querySnapshot.Documents.Count > 0;
    }
}