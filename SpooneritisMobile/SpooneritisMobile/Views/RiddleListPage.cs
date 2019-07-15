using SpooneritisMobile.Services;
using Xamarin.Forms;
using Newtonsoft.Json;
using SpooneritisMobile.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace SpooneritisMobile.Views
{
	public class RiddleListPage : ContentPage
	{
        private ListView _listView;

        private IRiddleService _riddleService;

		public RiddleListPage (IRiddleService riddleService)
		{
            _riddleService = riddleService;

            Title = "Spooneritis";

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();

            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }

        protected override async void OnAppearing()
        {
            var response = await _riddleService.GetRiddles();
            var jsonString = response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var riddles = JsonConvert.DeserializeObject<IEnumerable<Riddle>>(jsonString.Result);

                _listView.ItemsSource = riddles;
                _listView.ItemSelected += NavigateToRiddlePage;
            }
        }

        private async void NavigateToRiddlePage(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new RiddlePage((Riddle)e.SelectedItem, new AnswerService()));
        }
    }
}