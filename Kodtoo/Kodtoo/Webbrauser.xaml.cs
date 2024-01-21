using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kodtoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Webbrauser : ContentPage
    {
        Button home;
        Button next;
        Button back;
        Button newurl;
        Button rebind_home;
        Entry entry;
        Button historyButton;
        WebView webView;
        List<string> pages = new List<string> { "https://www.google.com", "https://www.youtube.com", "https://www.tthk.ee" };
        List<string> history = new List<string>();
        Grid gr;
        public Webbrauser()
        {
            //InitializeComponent ();
            gr = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }, //0
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }, //1
					new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }, //2
					new RowDefinition { Height = new GridLength(4, GridUnitType.Star) }, //3
				},
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }, //0
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }, //1
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }, //2
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }, //3
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }, //4
				},
                BackgroundColor = Color.Gray,

            };
            home = new Button
            {
                Text = "Home",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                Margin = new Thickness(0, -50, 0, 0)

            };
            home.Clicked += Home_Clicked;
            gr.Children.Add(home, 0, 0);

            rebind_home = new Button
            {
                Text = "Rebind Home Page",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                Margin = new Thickness(0, -50, 0, 0)
            };
            gr.Children.Add(rebind_home, 4, 0);

            rebind_home.Clicked += Rebind_home_Clicked;

            next = new Button
            {
                Text = "Next",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                Margin = new Thickness(0, -50, 0, 0)
            };
            next.Clicked += Next_Clicked;
            gr.Children.Add(next, 1, 0);

            back = new Button
            {
                Text = "Back",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                Margin = new Thickness(0, -50, 0, 0)
            };
            back.Clicked += Back_Clicked;
            gr.Children.Add(back, 2, 0);

            newurl = new Button
            {
                Text = "NEW SITE",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                Margin = new Thickness(0, -50, 0, 0)
            };
            gr.Children.Add(newurl, 3, 0);
            newurl.Clicked += Newurl_Clicked;

            entry = new Entry
            {
                Placeholder = "Sissesta URL",
                Margin = new Thickness(0, 50, 0, 0)

            };
            gr.Children.Add(entry, 0, 0);
            Grid.SetColumnSpan(entry, 5);
            entry.Completed += Entry_Completed;

            historyButton = new Button
            {
                Text = "HISTORY",
                BackgroundColor = Color.Green,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button)),
                Margin = new Thickness(0, 0, 0, 0)
            };
            gr.Children.Add(historyButton, 1, 2);
            Grid.SetColumnSpan(historyButton, 3);
            historyButton.Clicked += HistoryButton_Clicked; ;


            Content = gr;
        }

        private void Rebind_home_Clicked(object sender, EventArgs e)
        {
            string value = newurl.Text;
            App.Current.Properties.Remove("key");
            App.Current.Properties.Add("key", value);
            newurl.Text = (string)App.Current.Properties["key"];
        }

        private async void HistoryButton_Clicked(object sender, EventArgs e)
        {
            string historyText = string.Join("\n", history);
            await DisplayAlert("Ajalugu:", historyText, "OK");

        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            string url = entry.Text;
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = url },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            entry.Text = "";
            gr.Children.Add(webView, 0, 3);
            Grid.SetColumnSpan(webView, 5);
            history.Add(url);
        }

        private async void Newurl_Clicked(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Add a new website:", "URL: ");
            pages.Add(result);

        }

        protected override void OnAppearing()
        {
            object key = "";
            if (App.Current.Properties.TryGetValue("key", out key))
            {
                newurl.Text = (string)App.Current.Properties["key"];

            };
            base.OnAppearing();
        }


        int indexNext = 0;
        //int indexBack = 0;
        private void Back_Clicked(object sender, EventArgs e)
        {
            if (indexNext == 0)
            {

                webView.Source = new UrlWebViewSource { Url = pages[pages.Count - 1] };
                history.Add(pages[pages.Count - 1]);
                indexNext = pages.Count - 1;


            }

            else if (indexNext != 0)
            {
                indexNext--;
                history.Add(pages[indexNext]);
                webView.Source = new UrlWebViewSource { Url = pages[indexNext] };
            }


        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            if (indexNext == pages.Count)
            {
                indexNext = 0;
                history.Add(pages[indexNext]);
            }
            webView.Source = new UrlWebViewSource { Url = pages[indexNext] };
            history.Add(pages[indexNext]);
            indexNext++;

        }

        private void Home_Clicked(object sender, EventArgs e)
        {
            int lenght = pages.Count;
            webView = new WebView
            {

                Source = new UrlWebViewSource { Url = pages[lenght - 1] },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            history.Add(pages[0]);
            gr.Children.Add(webView, 0, 3);
            Grid.SetColumnSpan(webView, 5);

        }
    }
}
