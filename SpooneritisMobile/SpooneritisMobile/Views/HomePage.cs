using SpooneritisMobile.Services;
using System;

using Xamarin.Forms;

namespace SpooneritisMobile.Views
{
    public class HomePage : ContentPage
    {
        private readonly ISettingsProvider _settingsProvider;
        private readonly IBaseApiAccessor _baseApiAccessor;

        public HomePage(ISettingsProvider settingsProvider, IBaseApiAccessor baseApiAccessor)
        {
            _settingsProvider = settingsProvider;
            _baseApiAccessor = baseApiAccessor;

            Title = "Spooneritis";

            StackLayout stackLayout = new StackLayout();

            stackLayout.Children.Add(_createButton("Sign Up", GoToSignUp));
            stackLayout.Children.Add(_createButton("Add Riddle", GoToAddRiddle));
            stackLayout.Children.Add(_createButton("All Riddles", GoToRiddleList));
            stackLayout.Children.Add(_createButton("Sign In", GoToSignIn));

            Content = stackLayout;
        }

        private async void GoToRiddleList(object sender, EventArgs e)
        {
            var riddleService = new RiddleService(_baseApiAccessor);
            var answerService = new AnswerService(_settingsProvider, _baseApiAccessor);

            await Navigation.PushAsync(new RiddleListPage(riddleService, answerService));
        }

        private async void GoToSignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage(new UserService(_baseApiAccessor)));
        }

        private async void GoToAddRiddle(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateRiddlePage(new RiddleService(_baseApiAccessor)));
        }

        private async void GoToSignIn(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignInPage(new AuthService(_settingsProvider, _baseApiAccessor)));
        }

        private Button _createButton(string text, EventHandler action)
        {
            Button button = new Button
            {
                Text = text
            };

            button.Clicked += action;

            return button;
        }
    }
}