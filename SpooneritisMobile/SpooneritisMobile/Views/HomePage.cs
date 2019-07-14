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

            Content = stackLayout;
		}

        private async void GoToSignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
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