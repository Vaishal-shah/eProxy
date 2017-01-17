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
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            ViewTimeTable.IsEnabled = false;
            Tomm.IsEnabled = false;
            Proxy_List.IsEnabled = false;
        }

        private void ViewTimeTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tommorrow_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Tomorrow), null);
        }

        private void PutProxy_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void login_Click(object sender, RoutedEventArgs e)
        {
            GlobalRollNumber.RollNumber = rollno.Text;
            GlobalRollNumber.studentName = name.Text;

            ViewTimeTable.IsEnabled = true;
            Tomm.IsEnabled = true;
            Proxy_List.IsEnabled = true;
            login.IsEnabled = true;

            List<Points> init = await App.MobileService.GetTable<Points>().Where(login_ => (login_.RollNumber == rollno.Text)).ToListAsync();
            if (init.Count == 0)
            {
                Points newPoints = new Points {
                                       RollNumber = rollno.Text,
                                       Name = name.Text,
                                       CurrentPoints = 1000,
                                       Completed = true
                                   };

                await App.MobileService.GetTable<Points>().InsertAsync(newPoints);
                GlobalRollNumber.points = 1000;
            }
            else
            {
                GlobalRollNumber.points = init[0].CurrentPoints;
            }
          
        }
    }
}
