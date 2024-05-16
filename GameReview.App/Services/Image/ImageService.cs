using Firebase.Storage;
using GameReview.App.Models;
using Google.Cloud.Firestore;

namespace GameReview.App.Services.Image;

public class ImageService : IImageService
{
    private readonly FirestoreDb _firestoreDb;
    private const string CollectionName = "game_images";
    private readonly FirebaseStorage _firebaseStorage;

    public ImageService(string projectId, string firebaseStorageBucket)
    {
        _firestoreDb = FirestoreDb.Create(projectId);
        _firebaseStorage = new FirebaseStorage(firebaseStorageBucket);
    }

    public async Task<List<string>> GetImageUrlsByGameIdAsync(string gameId)
    {
        var urls = new List<string>();
        
        var querySnapshot = await  _firestoreDb.Collection(CollectionName).WhereEqualTo("GameId", gameId).GetSnapshotAsync();

        foreach (DocumentSnapshot document in querySnapshot.Documents)
        {
            if (!document.Exists) continue;
            
            GameImage gameImage = document.ConvertTo<GameImage>();
            urls.Add(gameImage.Url);
        }

        return urls;
    }

    private async Task<string> GetFullImageUrlAsync(string relativeUrl)
    {
        return await _firebaseStorage.Child(relativeUrl).GetDownloadUrlAsync();
    }
}