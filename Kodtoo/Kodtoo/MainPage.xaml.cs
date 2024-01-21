using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kodtoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {


        List<ContentPage> pages = new List<ContentPage>() { new ValgusFoor(), new Horoskoop(), new Webbrauser() };
        List<string> tekst = new List<string> { "Ava ValgusFoor leht", "Ava Horoskoop leht","Ava Webbrauser leht",};
        StackLayout st;
        public MainPage()
        {
            //InitializeComponent ();
            st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.YellowGreen
            };

            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = tekst[i],
                    TabIndex = i,
                    BackgroundColor = Color.Red,
                    TextColor = Color.White,


                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;

            }
            ScrollView sv = new ScrollView { Content = st };
            Content = sv;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
}

