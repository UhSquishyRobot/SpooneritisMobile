using System;
using System.Linq;
using SpooneritisMobile.Models;
using SpooneritisMobile.Services;
using Xamarin.Forms;

namespace SpooneritisMobile.Views
{
    public class RiddlePage : ContentPage
	{
        private Entry _answerEntry;
        private Button _saveButton;

        private Riddle _riddle;

        private IAnswerService _answerService;

        public RiddlePage (Riddle riddle, IAnswerService answerService)
		{
            _answerService = answerService;

            _riddle = riddle;

            Label label = new Label
            {
                Text = _riddle.Description
            };

            _answerEntry = new Entry
            {
                Keyboard = Keyboard.Text,
                Placeholder = "take your shot, chief"
            };

            _saveButton = new Button
            {
                Text = "Submit"
            };

            _saveButton.Clicked += SubmitAnswer;

            StackLayout stackLayout = new StackLayout();

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(_answerEntry);
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void SubmitAnswer(object sender, EventArgs e)
        {
            var answer = _answerEntry.Text.Split(',').Select(word => word.Trim()).ToList();

            var isCorrect = _riddle.Check(answer);

            if (isCorrect)
            {
                var response = await _answerService.CreateAnswer(_riddle);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert(null, "Correct", "Dismiss");
                }
                else
                {
                    await DisplayAlert(null, "There hast been an error", "Dismiss");
                }
            }
            else
            {
                await DisplayAlert(null, "This Ain't It Chief", "Dismiss");
            }
        }
    }
}