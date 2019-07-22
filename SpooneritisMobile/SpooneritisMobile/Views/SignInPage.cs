using SpooneritisMobile.Models;
using SpooneritisMobile.Services;
using System;

using Xamarin.Forms;

namespace SpooneritisMobile.Views
{
    public class SignInPage : ContentPage
    {
        private Entry _usernameEntry;
        private Entry _passwordEntry;
        private Button _saveButton;

        private IAuthService _authService;

        public SignInPage(IAuthService authService)
        {
            _authService  = authService;

            Title = "Sign In";

            StackLayout stackLayout = new StackLayout();

            _usernameEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "username"
            };

            _passwordEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "password"
            };

            _saveButton = new Button
            {
                Text = "Submit"
            };

            _saveButton.Clicked += _signIn;

            stackLayout.Children.Add(_usernameEntry);
            stackLayout.Children.Add(_passwordEntry);
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _signIn(object sender, EventArgs e)
        {
            User user = new User
            {
                Username = _usernameEntry.Text,
                Password = _passwordEntry.Text
            };

            var response = await _authService.Authenticate(user);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert(null, "Success", "Ok");
            }
            else
            {
                await DisplayAlert(null, "Failure", "Dismiss");
            }
        }
    }
}