using NewToDo.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NewToDo
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public ShellContent MainPageContent;
        public AppShell()
        {
            InitializeComponent();
            MainPageContent = Home;
        }

    }
}
