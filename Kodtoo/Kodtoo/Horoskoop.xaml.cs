using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kodtoo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Horoskoop : ContentPage
    {
        Picker picker;
        DatePicker datePicker;
        Dictionary<string, string> zodiacInfo;

        public Horoskoop()
        {
            zodiacInfo = new Dictionary<string, string>
            {
                { "Aries", "Текст для Овна.\nОвен – это знак страсти, силы и уверенности, неудержимая энергия которого касается всех сфер жизни. Люди, рожденные под этим знаком, стремятся к покорению новых вершин в жизни и умеют вдохновлять других своим примером. Важно отметить, что Овнам часто необходимо брать под контроль свою склонность к спонтанности." },
                { "Taurus", "Текст для Тельца.\nТельцы обладают благородным и независимым характером. Имея силу, они, как ни странно, не спешат ее использовать, дожидаясь наиболее благоприятного случая, но частенько упуская его. Упорный труд, а не везение, постоянство, а не порыв - вот ключ к успеху Тельцов в жизни." },
                { "Gemini", "Текст для Близнецов.\nБлизнецы (лат. Gemini) — авантюрный, яркий, интеллектуальный знак, представители которого являются сложными двойственными натурами. Они не только склонны к перепадам настроения, но и к ситуациям душевного смятения, поискам себя, вовлеченности в авантюры и сомнительные затеи." },
                { "Cancer", "Текст для Рака.\nЛюди, имеющие Солнце в знаке Рака, обладают скрытным характером и мечтательной натурой, они очень симпатичные, мягкие, нежные, любезные, часто идеалистически настроены и слишком впечатлительны. Они интересны как собеседники и большие любители природы, особенно привлекает их морское побережье." },
                { "Leo", "Текст для Лев.\nЛев (лат. Leo) — пятый знак, стихия которого — огонь, планета — Солнце. Представители этого знака зодиака — самые колоритные и яркие люди, которыми правят амбиции, гордость и зачастую граничащее с патологическим состоянием самолюбие. Именно Львы чаще других знаков стремятся к власти, признанию, богатству и роскоши." },
                { "Virgo", "Текст для Девы.\nДевы очень дисциплинированны, организованны и трудолюбивы. Они не прощают ошибок и оплошностей не только себе, но и другим людям. Девы, как правило, не любят публичность, они редко становятся центром всеобщего внимания. Их сложно встретить на шумной вечеринке." },
                { "Libra", "Текст для Весов.\nВесы - самый воспитанный из всех знаков Зодиака. Это чуткий человек, который ценит хорошие манеры, никого не задевающее остроумие, любит принимать и развлекать гостей. Весы обладают тонким чувством такта, взвешенными эмоциями, интуитивным пониманием искусства и всего прекрасного." },
                { "Scorpio", "Текст для Скорпиона.\nСкорпионы — гедонисты, они любят красивую жизнь, удовольствия и комфорт. Они очень амбициозны и честолюбивы, стремятся к славе и признанию, а ради достижения своих целей идут на все. Из-за этих качеств их часто считают агрессивными и даже жестокими." },
                { "Sagittarius", "Текст для Стрельца.\nГлавными качествами представителей этого созвездия являются любознательность, активность и стремление к новым впечатлениям. Стрельцы никогда не сидят на месте, они деятельны и предприимчивы, любят приключения и путешествия, легки на подъем и склонны к риску." },
                { "Capricorn", "Текст для Козерога.\nЛюдей, родившихся под знаком Козерога, объединяет большая жизненная стойкость и терпеливое стремление к хорошему результату во всем. Они гордятся своим умом, хоть иногда и безосновательно, и, если не ленивы, прилагают массу усилий для развития интеллектуальных способностей.." },
                { "Aquarius", "Текст для Водолея.\nЛюди, рожденные под знаком Водолея, отличаются особенной чувствительностью и ранимостью. Они могут быть окружены знакомыми, но редко имеют близких друзей, которым могут довериться. Интересно, что Водолеи как магнитом притягивают к себе неуравновешенных людей, склонных к опрометчивым поступкам." },
                { "Pisces", "Текст для Рыб.\nРыбы — мечтатели, живущие в мире собственных иллюзий. Они тонко чувствуют музыку, способны к самопожертвованию и часто действуют интуитивно. Не чувствуя любви и поддержки, Рыбы впадают в уныние, уходят в себя и способны оказаться в состоянии тяжелейшей затяжной депрессии." },
                { "Ophiuchus", "Текст для Змееносца.\nХарактеристика людей, рожденных под знаком Змееносца\r\nЭто сильные, целеустремленные люди со стержнем, привыкшие работать на результат. В этих знаках преобладают свойства Скорпиона и Стрельца. Кармическая задача знака - обуздать в себе злобу, быть чуткими и помогать окружающим, научиться сопереживать." }
            };

            picker = new Picker
            {
                Title = "Выберите знак зодиака",
                VerticalOptions = LayoutOptions.Center
            };

            foreach (var zodiacSign in zodiacInfo.Keys)
            {
                picker.Items.Add(zodiacSign);
            }

            datePicker = new DatePicker
            {
                Format = "D",
                MaximumDate = DateTime.Now
            };

            picker.SelectedIndexChanged += IndexChanged;
            datePicker.DateSelected += DateSelected;

            Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = "Выберите знак зодиака",
                        HorizontalOptions = LayoutOptions.Center
                    },
                    picker,
                    new Label
                    {
                        Text = "Выберите дату рождения",
                        HorizontalOptions = LayoutOptions.Center
                    },
                    datePicker
                }
            };
        }

        private void IndexChanged(object sender, EventArgs e)
        {
            string selectedSign = picker.Items[picker.SelectedIndex];
            ShowZodiacPage(selectedSign);
        }

        private void DateSelected(object sender, DateChangedEventArgs e)
        {
            ShowZodiacPage(GetZodiacSign(e.NewDate));
        }

        private void ShowZodiacPage(string zodiacSign)
        {
            DateTime selectedDate = datePicker.Date;

            StackLayout customLayout = new StackLayout();

            Label textLabel = new Label
            {
                Text = zodiacInfo[zodiacSign]
            };

            Image zodiacImage = new Image
            {
                Source = $"{zodiacSign}.jpg",
                Aspect = Aspect.AspectFit,
                WidthRequest = 200,
                HeightRequest = 200
            };

            customLayout.Children.Add(textLabel);
            customLayout.Children.Add(zodiacImage);

            ContentPage zodiacPage = new ContentPage
            {
                Content = customLayout
            };

            Button backButton = new Button
            {
                Text = "НАЗАД"
            };
            backButton.Clicked += async (s, e) =>
            {
                await Navigation.PopAsync();
            };
            customLayout.Children.Add(backButton);

            Navigation.PushAsync(zodiacPage);
        }

        private string GetZodiacSign(DateTime date)
        {
            if ((date.Month == 3 && date.Day >= 21) || (date.Month == 4 && date.Day <= 19))
            {
                return "Aries";
            }
            else if ((date.Month == 4 && date.Day >= 20) || (date.Month == 5 && date.Day <= 20))
            {
                return "Taurus";
            }
            else if ((date.Month == 5 && date.Day >= 21) || (date.Month == 6 && date.Day <= 20))
            {
                return "Gemini";
            }
            else if ((date.Month == 6 && date.Day >= 21) || (date.Month == 7 && date.Day <= 22))
            {
                return "Cancer";
            }
            else if ((date.Month == 7 && date.Day >= 23) || (date.Month == 8 && date.Day <= 22))
            {
                return "Leo";
            }
            else if ((date.Month == 8 && date.Day >= 23) || (date.Month == 9 && date.Day <= 22))
            {
                return "Virgo";
            }
            else if ((date.Month == 9 && date.Day >= 23) || (date.Month == 10 && date.Day <= 22))
            {
                return "Libra";
            }
            else if ((date.Month == 10 && date.Day >= 23) || (date.Month == 11 && date.Day <= 21))
            {
                return "Scorpio";
            }
            else if ((date.Month == 11 && date.Day >= 22) || (date.Month == 12 && date.Day <= 21))
            {
                return "Sagittarius";
            }
            else if ((date.Month == 12 && date.Day >= 22) || (date.Month == 1 && date.Day <= 19))
            {
                return "Capricorn";
            }
            else if ((date.Month == 1 && date.Day >= 20) || (date.Month == 2 && date.Day <= 18))
            {
                return "Aquarius";
            }
            else if ((date.Month == 2 && date.Day >= 19) || (date.Month == 3 && date.Day <= 20))
            {
                return "Pisces";
            }
            else
            {
                return "Unknown";
            }

        }
    }
}