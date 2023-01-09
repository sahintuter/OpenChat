using Newtonsoft.Json;
using System.Text;

namespace OpenChat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void run_Btn_Click(object sender, EventArgs e)
        {
            // API anahtar�n�z� buraya yaz�n
            string apiKey = "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";

            // TextBox'tan "prompt" de�erini al�yoruz
            string prompt = prompt_txt.Text;

            // API �a�r�s� i�in gereken veri bilgilerini olu�turuyoruz
            dynamic apiData = new
            {
                model = "text-davinci-002",
                prompt = prompt,
                max_tokens = 20

            };

            // HTTP POST iste�i olu�turuyoruz
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.openai.com/v1/completions"),
                Headers =
                 {
                     { "Authorization", $"Bearer {apiKey}" }
                 },
                Content = new StringContent(JsonConvert.SerializeObject(apiData), Encoding.UTF8, "application/json")
            };

            // HTTP iste�ini g�nderip cevab� al�yoruz
            string response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();

            // Cevab� TextBox'ta g�r�nt�l�yoruz
            result_txt.Text = response.ToString();
        }
    }
}
