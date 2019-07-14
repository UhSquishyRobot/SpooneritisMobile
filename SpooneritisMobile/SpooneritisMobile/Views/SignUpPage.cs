using Newtonsoft.Json;
using SpooneritisMobile.Models;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace SpooneritisMobile.Views
{
	public class SignUpPage : ContentPage
	{
        private Entry _usernameEntry;
        private Entry _passwordEntry;
        private Button _saveButton;

        private readonly string _apiConnection = "http://10.0.2.2:3000/users";

        private HttpClient _client = new HttpClient();

        public SignUpPage ()
		{
            Title = "Sign Up";

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

            _saveButton.Clicked += _signUp;

            stackLayout.Children.Add(_usernameEntry);
            stackLayout.Children.Add(_passwordEntry);
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _signUp(object sender, EventArgs e)
        {
            User user = new User
            {
                Username = _usernameEntry.Text,
                Password = _passwordEntry.Text
            };

            var userJson = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_apiConnection, userJson);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert(null, "Success", "Ok");
            }
            else
            {
                await DisplayAlert(null, "Failure", "Fail");
            }
        }
    }
}