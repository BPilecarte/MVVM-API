using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using System.Diagnostics;

namespace MVVM_API_SampleProject.ViewModels
{
    internal partial class ToDoViewModel : ObservableObject, IDisposable
    {
        HttpClient client;

        JsonSerializerOptions _serializerOptions;

        string baseUrl = "http://jsonplaceholder.typicode.com";

        [ObservableProperty]
        public int _UserId;

        [ObservableProperty]
        public int _Id;

        [ObservableProperty]
        public string _Title;

        [ObservableProperty]
        public string _Completed;

        [ObservableProperty]
        public ObservableCollection<ToDo> _toDos;


        public ToDoViewModel()
        {
            client = new HttpClient();
            ToDos = new ObservableCollection<ToDo>();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public ICommand GetToDoCommand => new Command(async () => await LoadToDoAsync());

        private async Task LoadToDoAsync()
        {
            var url = $"{baseUrl}/todos";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ToDos = JsonSerializer.Deserialize<ObservableCollection<ToDo>>(content, _serializerOptions);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}