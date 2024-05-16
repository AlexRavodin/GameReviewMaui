using Google.Cloud.Firestore;

namespace GameReview.App.Models;

[FirestoreData]
public class GameImage
{
    [FirestoreProperty]
    public string GameId { get; set; }

    [FirestoreProperty]
    public string Url { get; set; }
}