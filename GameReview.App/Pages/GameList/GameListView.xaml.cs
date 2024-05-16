using GameReview.App.Models;
using GameReview.App.Services.Game;

namespace GameReview.App.Pages.GameList;

public partial class GameListView : ContentPage
{
    public GameListView(GameListViewModel gameListViewModel)
    {
        InitializeComponent();
        BindingContext = gameListViewModel;
    }

    private async void OnGameTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is not GameDto gameDto) return;

        if (BindingContext is GameListViewModel viewModel)
        {
            await viewModel.GameTappedCommand.ExecuteAsync(gameDto);
        }
    }
}