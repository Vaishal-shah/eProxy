using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace eProxy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
           
        }

        private void Click_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Tomorrow), null);
           /* Timings timeObj = new Timings
            {
                SubjectName = "DB",
                SubjectId = "CS62001",
                Slot = 8,
                Completed = true
            };
            Timings timeObj2 = new Timings
            {
                SubjectName = "Networks",
                SubjectId = "CS63001",
                Slot = 12,
                Completed = true
            };

            await App.MobileService.GetTable<Timings>().InsertAsync(timeObj);
            await App.MobileService.GetTable<Timings>().InsertAsync(timeObj2);
            */
        }
    }
}
