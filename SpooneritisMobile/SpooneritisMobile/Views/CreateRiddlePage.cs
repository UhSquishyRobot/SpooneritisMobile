using SpooneritisMobile.Models;
using SpooneritisMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace SpooneritisMobile.Views
{
	public class CreateRiddlePage : ContentPage
	{
        private Entry _descriptionEntry;
        private Entry _answerEntry;
        private Button _saveButton;

        private IRiddleService _riddleService;

        public CreateRiddlePage(IRiddleService riddleService)
		{
            _riddleService = riddleService;

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

            var response = await _riddleService.CreateRiddle(riddle);

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