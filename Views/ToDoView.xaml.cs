using MVVM_API_SampleProject.Models;
using MVVM_API_SampleProject.ViewModels;

namespace MVVM_API_SampleProject.Views;

public partial class ToDoView : ContentPage
{
    public ToDoView()

    {
        InitializeComponent();  
        BindingContext = new ToDoViewModel();
    }

    CheckBox checkBox = new CheckBox { IsChecked = true };
}