using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;

namespace MVVM_API_SampleProject.ViewModels
{
    internal partial class ToDoViewModel : ObservableObject, IDisposable
    {
        HttpClient client;

        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://jsonplaceholder.typicode.com";

        [ObservableProperty]
        public int _UserId;

        [ObservableProperty]
        public int _Id;

        [ObservableProperty]
        public string _Title;

        //Uma coleção de Post
        [ObservableProperty]
        public ObservableCollection<ToDo> _posts;

        public ToDoViewModel()
        {
            client = new HttpClient();
            Posts = new ObservableCollection<ToDo>();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        //Consumir a API Rest -> Criação dos Comandos 
        public ICommand GetPostsCommand => new Command(async () => await LoadPostsAsync());

        private async Task LoadPostsAsync()
        {
            var url = $"{baseUrl}/posts";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Posts = JsonSerializer.Deserialize<ObservableCollection<ToDo>>(content, _serializerOptions);

                }
            }
            catch (Exception e) { }
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}