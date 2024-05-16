namespace GameReview.App.Pages.UserDetails;

public partial class UserDetailsView : ContentPage
{
    public UserDetailsView(object bindingContext)
    {
        InitializeComponent();

        BindingContext = bindingContext;
    }
}