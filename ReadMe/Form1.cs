using System;
using System.Net.Http;
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
            listBox1.Items.Clear();

            string genre = GenreTextBox.Text;
            string mood = MoodTextBox.Text;

            var recommendationService = new BookRecommendationService(apiKey);
            string result = await recommendationService.GetBookRecommendations(genre, mood);

            // Process and display the result in your UI
            DisplayResults(result);
        }

        private void DisplayResults(string result)
        {
            try
            {
                var books = JsonConvert.DeserializeObject<BookList>(result);

                foreach (var book in books.Items)
                {
                    listBox1.Items.Add($"{book.VolumeInfo.Title} by {string.Join(", ", book.VolumeInfo.Authors)}");
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add($"Error: {ex.Message}");
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

        public async Task<string> GetBookRecommendations(string genre, string mood)
        {
            using (var httpClient = new HttpClient())
            {
                var apiUrl = $"{GoogleBooksApiUrl}?q={genre}+{mood}&key={apiKey}";

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
}
