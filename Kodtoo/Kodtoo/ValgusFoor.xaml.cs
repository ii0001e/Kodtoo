using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kodtoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ValgusFoor : ContentPage
    {
        Button on;
        Button off;
        Grid gr;
        Frame frm;
        List<Frame> frames = new List<Frame>();
        List<string> text = new List<string> { "Punane", "Kollane", "Roheline" };
        List<string> AltText = new List<string> { "STOP!", "WAIT!", "GO!" };
        List<Color> colors = new List<Color> { Color.Red, Color.Yellow, Color.Green };


        public ValgusFoor()
        {
            //InitializeComponent();

            gr = new Grid
            {

                RowDefinitions =
                    {
                        new RowDefinition{Height = new GridLength(3, GridUnitType.Star)}, //0
                        new RowDefinition{Height = new GridLength(3, GridUnitType.Star)}, //1
                        new RowDefinition{Height = new GridLength(3, GridUnitType.Star)}, //2
                        new RowDefinition{Height = new GridLength(1, GridUnitType.Star)}, //3
                    },
                ColumnDefinitions =
                    {
                        new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)}, //0
                        new ColumnDefinition{Width = new GridLength(3, GridUnitType.Star)}, //1
                        new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)}, //2
                    },



            };


            bool topMarginAdded = false;
            for (int i = 0; i < 3; i++)
            {

                frm = new Frame
                {
                    Content = new Label
                    {
                        Text = text[i],
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    },
                    CornerRadius = 40,
                    BackgroundColor = Color.Gray,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Margin = new Thickness(0, topMarginAdded ? 0 : 10, 0, 0),

                };
                frames.Add(frm);
                gr.Children.Add(frm, 1, i);
                gr.Children.Add(frm, 1, i);
                gr.Children.Add(frm, 1, i);
                TapGestureRecognizer tap = new TapGestureRecognizer();
                tap.Tapped += Tap_Tapped;
                frm.GestureRecognizers.Add(tap);

            };

            on = new Button
            {
                Text = "Sisse",
                BackgroundColor = Color.Gray

            };
            on.Clicked += On_Clicked;

            off = new Button
            {
                Text = "Välja",
                BackgroundColor = Color.Gray

            };
            off.Clicked += Off_Clicked;

            gr.Children.Add(on, 0, 3);
            gr.Children.Add(off, 2, 3);
            Content = gr;
        }

        bool onoff = false;

        private void Tap_Tapped(object sender, EventArgs e)
        {
            Frame frame = sender as Frame;
            if (onoff == true)
            {
                int index = frames.IndexOf(frame);
                if (index >= 0 && index < colors.Count)
                {
                    frame.BackgroundColor = colors[index];
                    frame.Content = new Label
                    {
                        Text = AltText[index],
                        FontSize = 40,
                        FontFamily = "Arial",
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand

                    };
                }
            }


        }

        private async void Off_Clicked(object sender, EventArgs e)
        {
            if (onoff == true)
            {
                onoff = false;
                for (int i = 0; i < 3; i++)
                {
                    frames[i].BackgroundColor = Color.Gray;
                    frames[i].Content = new Label
                    {
                        Text = text[i],
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    };


                };

                await Task.Delay(1500);

                for (int i = 0; i < 5; i++)
                {
                    await Task.Delay(500);
                    frames[1].BackgroundColor = Color.Yellow;
                    frames[1].Content = new Label
                    {
                        Text = AltText[1],
                        FontSize = 40,
                        FontFamily = "Arial",
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    };
                    await Task.Delay(500);
                    frames[1].BackgroundColor = Color.Gray;
                    frames[1].Content = new Label
                    {
                        Text = text[1],
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    };

                }
            }
        }



        private void On_Clicked(object sender, EventArgs e)
        {
            onoff = true;
        }
    }
}
