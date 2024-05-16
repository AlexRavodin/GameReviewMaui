using Google.Cloud.Firestore;

namespace GameReview.App.Models;

[FirestoreData]
public class AppUser
{
    [FirestoreProperty]
    public string AuthId { get; set; }
    
    [FirestoreProperty]
    public int Age { get; set; }
    
    [FirestoreProperty]
    public string Email { get; set; }

    [FirestoreProperty]
    public string FavoriteGame { get; set; }

    [FirestoreProperty]
    public string FavoriteGenre { get; set; }

    [FirestoreProperty]
    public string Name { get; set; }
}