using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ReadMe
{
    public partial class Form1 : Form
    {
        private const string GoogleBooksApiUrl = "https://www.googleapis.com/books/v1/volumes";
        private readonly string apiKey = "AIzaSyCIMglnmoorDObDfZAs9VrKy9OU7WIRjKU";

        public Form1()
        {
            InitializeComponent();
        }

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            string genre = GenreTextBox.Text;
            string mood = MoodTextBox.Text;
            string title = TitleTextBox.Text;

            var recommendationService = new BookRecommendationService(apiKey);
            string result = await recommendationService.GetBookRecommendations(genre, mood, title);

            // Process and display the result in your UI
            DisplayResults(result);
        }

        private void DisplayResults(string result)
        {
            try
            {
                var books = JsonConvert.DeserializeObject<BookList>(result);

                if(books.Items != null) {
                    foreach (var book in books.Items)
                    {
                        listBox1.Items.Add($"{book.VolumeInfo.Title} by {string.Join(", ", book.VolumeInfo.Authors)}");
                    }
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"Error: {ex.Message}");
            }
        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            // Quando l'utente fa doppio clic su un elemento nella listBox1
            if (listBox1.SelectedItem != null)
            {
                // Ottenere il titolo del libro dalla listBox1
                string selectedBookTitle = listBox1.SelectedItem.ToString();

                // Eseguire una ricerca di Google basata sul titolo del libro
                LaunchGoogleSearch(selectedBookTitle);
            }
        }

        private void LaunchGoogleSearch(string query)
        {
            // Sostituire gli spazi con il carattere '+' per la query di ricerca
            string searchQuery = query.Replace(" ", "+");

            // Costruire l'URL di ricerca di Google
            string googleSearchUrl = $"https://www.google.com/search?q={searchQuery}";

            // Aprire il browser predefinito con la query di ricerca di Google
            OpenBrowser(googleSearchUrl);
        }

        private void OpenBrowser(string url)
        {
            // Utilizzare la classe ProcessStartInfo per aprire il browser predefinito
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "cmd" : "xdg-open",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = new System.Diagnostics.Process { StartInfo = startInfo };

            process.Start();
            process.StandardInput.WriteLine(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                $"start {url}" : $"open {url}");
            process.StandardInput.Flush();
            process.StandardInput.Close();
        }
    }

}

class BookRecommendationService
{
    private const string GoogleBooksApiUrl = "https://www.googleapis.com/books/v1/volumes";
    private readonly string apiKey;

    public BookRecommendationService(string apiKey)
    {
        this.apiKey = apiKey;
    }

    public async Task<string> GetBookRecommendations(string genre, string mood, string title)
    {
        using (var httpClient = new HttpClient())
        {
            var apiUrl = $"{GoogleBooksApiUrl}?q={genre}+{mood}+intitle:{title}&key={apiKey}";

            try
            {
                var response = await httpClient.GetStringAsync(apiUrl);
                return response;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }

}

// Define classes for deserialization
public class BookList
{
    public List<BookItem> Items { get; set; }
}

public class BookItem
{
    public VolumeInfo VolumeInfo { get; set; }
}

public class VolumeInfo
{
    public string Title { get; set; }
    public List<string> Authors { get; set; }
}
