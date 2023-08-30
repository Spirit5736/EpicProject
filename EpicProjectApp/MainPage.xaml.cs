using System.Linq;

namespace EpicProjectApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private const string apiUrl= "http://localhost:5077/WeatherForecast";

        private async void GetUsersFromApi(object sender, EventArgs e)
        {
            List<WeatherForecast> users = new List<WeatherForecast>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string response = await client.GetStringAsync(apiUrl);
                    users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<WeatherForecast>>(response);
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine("Error: " + ex.Message);
            }

            CounterBtn.Text = users[1].Summary.ToString();
            SemanticScreenReader.Announce(CounterBtn.Text);
        }

    }
}