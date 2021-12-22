using NyamNyamMobileApp.ViewModels;
using NyamNyamMobileApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NyamNyamMobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
        }

    }
}
