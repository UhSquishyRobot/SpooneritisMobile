using Newtonsoft.Json;
using SpooneritisMobile.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;

namespace SpooneritisMobile.Views
{
	public class AddRiddlePage : ContentPage
	{
        private Entry _descriptionEntry;
        private Entry _answerEntry;
        private Button _saveButton;

        private readonly string _apiConnection = "http://10.0.2.2:3000/riddles";

        private HttpClient _client = new HttpClient();

        public AddRiddlePage ()
		{
            Title = "Add Riddle";

            StackLayout stackLayout = new StackLayout();

            _descriptionEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "what's the difference between...?"
            };

            _answerEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "ex: hot, poop, pot, hoop"
            };

            _saveButton = new Button
            {
                Text = "Add"
            };

            _saveButton.Clicked += _submitRiddle;

            stackLayout.Children.Add(_descriptionEntry);
            stackLayout.Children.Add(_answerEntry);
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _submitRiddle(object sender, EventArgs e)
        {
            List<string> answer = _answerEntry.Text.Split(',').Select(word => word.Trim()).ToList();

            Riddle riddle = new Riddle
            {
                Description = _descriptionEntry.Text,
                Answer = answer
            };

            var riddleJson = new StringContent(JsonConvert.SerializeObject(riddle), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_apiConnection, riddleJson);

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