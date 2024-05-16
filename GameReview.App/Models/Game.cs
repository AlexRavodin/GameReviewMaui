using Google.Cloud.Firestore;

namespace GameReview.App.Models;

[FirestoreData]
public class Game
{
    [FirestoreProperty]
    public string Description { get; set; }

    [FirestoreProperty]
    public string Genre { get; set; }

    [FirestoreProperty]
    public int MinimumAge { get; set; }

    [FirestoreProperty]
    public string Name { get; set; }
}