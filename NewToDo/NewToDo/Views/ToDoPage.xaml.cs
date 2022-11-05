using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using NewToDo.Models;

namespace NewToDo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoPage : ContentPage
    {
        public ToDoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var todo = (ToDo)BindingContext;
            if (todo != null && !string.IsNullOrEmpty(todo.FileName))
            {
                ToDoText.Text = File.ReadAllText(todo.FileName);
            }
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var todo = (ToDo)BindingContext;
            if (todo == null || string.IsNullOrEmpty(todo.FileName))
            {
                todo = new ToDo();
                todo.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"{Path.GetRandomFileName()}.notes.txt");
            }
            File.WriteAllText(todo.FileName, ToDoText.Text);
            await Navigation.PopAsync();
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var todo = (ToDo)BindingContext;
            if (File.Exists(todo.FileName))
            {
                File.Delete(todo.FileName);
            }
            ToDoText.Text = string.Empty;
            await Navigation.PopAsync();
        }
    }
}