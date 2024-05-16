using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAdmin;
using GameReview.App.Features.SignIn;
using GameReview.App.Features.SignUp;
using GameReview.App.Features.UserDetails;
using GameReview.App.Pages;
using GameReview.App.Pages.GameDetails;
using GameReview.App.Pages.GameList;
using GameReview.App.Pages.SignIn;
using GameReview.App.Pages.SignUp;
using GameReview.App.Pages.UserDetails;
using GameReview.App.Services.Game;
using GameReview.App.Services.Image;
using GameReview.App.Services.User;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Logging;

namespace GameReview.App;

public static class MauiProgram
{
    private const string ProjectId = "my-test-project-cd10b";
    private const string CredentialsPath = "D:\\Projects\\GameReview\\GameReview\\GameReview.App\\google-services.json";
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        
        builder.Services.AddSingleton<IGameService, GameService>();
        builder.Services.AddSingleton<IUserService, UserService>();
        builder.Services.AddSingleton<IImageService, ImageService>();
        
        builder.Services.AddTransient<GameListView>();
        builder.Services.AddTransient<GameListViewModel>();
        
        builder.Services.AddTransient<GameDetailsView>();
        builder.Services.AddTransient<GameDetailsView>();
        
        builder.Services.AddTransient<UserDetailsViewModel>();
        builder.Services.AddTransient<UserDetailsFormViewModel>();
        builder.Services.AddTransient<UserDetailsView>(
            s => new UserDetailsView(s.GetRequiredService<UserDetailsViewModel>()));

        builder.Services.AddTransient<SignInViewModel>();
        builder.Services.AddTransient<SignInFormViewModel>();
        builder.Services.AddTransient<SignInView>(
            s => new SignInView(s.GetRequiredService<SignInViewModel>()));

        builder.Services.AddTransient<SignUpViewModel>();
        builder.Services.AddTransient<SignUpFormViewModel>();
        builder.Services.AddTransient<SignUpView>(
            s => new SignUpView(s.GetRequiredService<SignUpViewModel>()));

        builder.Services.AddSingleton(new FirebaseAuthClient(
            new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyB0Hkv5pPGYUgIrdLE1Helk3ZCQ-4gikBY",
                AuthDomain = "my-test-project-cd10b.firebaseapp.com",
                Providers = [new EmailProvider()],
            }));
        
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile(CredentialsPath)
        });
        
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredentialsPath);
        builder.Services.AddSingleton(FirestoreDb.Create(ProjectId));
        
        return builder.Build();
    }
}