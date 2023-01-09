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
            // API anahtarýnýzý buraya yazýn
            string apiKey = "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";

            // TextBox'tan "prompt" deðerini alýyoruz
            string prompt = prompt_txt.Text;

            // API çaðrýsý için gereken veri bilgilerini oluþturuyoruz
            dynamic apiData = new
            {
                model = "text-davinci-002",
                prompt = prompt,
                max_tokens = 20

            };

            // HTTP POST isteði oluþturuyoruz
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

            // HTTP isteðini gönderip cevabý alýyoruz
            string response = await client.SendAsync(request).Result.Content.ReadAsStringAsync();

            // Cevabý TextBox'ta görüntülüyoruz
            result_txt.Text = response.ToString();
        }
    }
}
