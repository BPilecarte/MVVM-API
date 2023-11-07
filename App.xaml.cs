using MVVM_API_SampleProject.ViewModels;
using MVVM_API_SampleProject.Views;

namespace MVVM_API_SampleProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}