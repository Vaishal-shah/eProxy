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
    public sealed partial class Absent : Page
    {
        public Absent()
        {
            this.InitializeComponent();
            availPoints.Text = GlobalRollNumber.points.ToString();
            availPoints.IsReadOnly = true;
        
        }

        private async void submit_Click(object sender, RoutedEventArgs e)
        {
            List<Absentee> check1 = await App.MobileService.GetTable<Absentee>().Where(check => check.RollNumber == GlobalRollNumber.RollNumber && check.Slot == GlobalRollNumber.slot).ToListAsync();
            int init = check1.Count;
            
            Absentee goingObj = new Absentee
            {
                RollNumber = GlobalRollNumber.RollNumber,
                BidPrice = Int32.Parse(bidPrice.Text),
                SubjectId = GlobalRollNumber.subjectID,
                Slot = GlobalRollNumber.slot,
                Completed = true
            };

            if (init == 0)
            {
               
                await App.MobileService.GetTable<Absentee>().InsertAsync(goingObj);
            }
            else
            {
                check1[0].RollNumber = GlobalRollNumber.RollNumber;
                check1[0].BidPrice = Int32.Parse(bidPrice.Text);
                check1[0].SubjectId = GlobalRollNumber.subjectID;
                check1[0].Slot = GlobalRollNumber.slot;
                check1[0].Completed = true;
                await App.MobileService.GetTable<Absentee>().UpdateAsync(check1[0]);
            }
           // Absentee goingObj = new Absentee
          /*  {
                RollNumber = GlobalRollNumber.RollNumber,
                BidPrice = Int32.Parse(bidPrice.Text),
                SubjectId = GlobalRollNumber.subjectID,
                Slot = GlobalRollNumber.slot,
                Completed = true
            };*/
            
            this.Frame.Navigate(typeof(Tomorrow), null);
        }



    }
}
