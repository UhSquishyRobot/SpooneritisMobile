using SpooneritisMobile.Services;
using System;

using Xamarin.Forms;

namespace SpooneritisMobile.Views
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
            Title = "Spooneritis";

            StackLayout stackLayout = new StackLayout();

            stackLayout.Children.Add(_createButton("Sign Up", GoToSignUp));
            stackLayout.Children.Add(_createButton("Add Riddle", GoToAddRiddle));
            stackLayout.Children.Add(_createButton("All Riddles", GoToRiddleList));

            Content = stackLayout;
		}

        private async void GoToRiddleList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RiddleListPage(new RiddleService()));
        }

        private async void GoToSignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage(new UserService()));
        }

        private async void GoToAddRiddle(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateRiddlePage(new RiddleService()));
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