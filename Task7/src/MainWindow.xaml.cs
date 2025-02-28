using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace src
{
    public partial class MainWindow : Window
    {
        private const string ApiKey = "a2427b482fd8472eee58bf283c1564a4";
        private const string City = "Томск";

        public MainWindow()
        {
            InitializeComponent();
            LoadWeather();
        }

        private async void LoadWeather()
        {
            string weatherCondition = await GetWeatherCondition();
            SetBackgroundColor(weatherCondition);
        }

        private async Task<string> GetWeatherCondition()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?q={City}&appid={ApiKey}&units=metric");
                    dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(response);
                    return json.weather[0].main.ToString();
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {httpEx.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Неизвестно"; // Возвращаем значение по умолчанию
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return "Неизвестно"; // Возвращаем значение по умолчанию
            }
        }


        private void SetBackgroundColor(string condition)
        {
            switch (condition.ToLower())
            {
                case "clear":
                    this.Background = new SolidColorBrush(Colors.Yellow);
                    break;
                case "clouds":
                    this.Background = new SolidColorBrush(Colors.LightGray);
                    break;
                case "rain":
                    this.Background = new SolidColorBrush(Colors.Blue);
                    break;
                case "snow":
                    this.Background = new SolidColorBrush(Colors.White);
                    break;
                case "thunderstorm":
                    this.Background = new SolidColorBrush(Colors.DarkGray);
                    break;
                default:
                    this.Background = new SolidColorBrush(Colors.White);
                    break;
            }
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameInput.Text;
            if (IsValidName(name))
            {
                SecondWindow secondWindow = new SecondWindow(name);
                secondWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Некорректное имя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                NameInput.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && !name.Any(char.IsDigit);
        }
    }
}
