using Google.Cloud.Firestore;

namespace GameReview.App.Models;

[FirestoreData]
public class FavoriteItem
{
    [FirestoreProperty]
    public string GameId { get; set; }

    [FirestoreProperty]
    public string UserId { get; set; }
}