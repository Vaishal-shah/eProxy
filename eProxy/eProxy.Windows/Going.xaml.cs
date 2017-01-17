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
    public sealed partial class Going : Page
    {
        public Going()
        {
            this.InitializeComponent();
            availPoints.IsReadOnly = true;
            availPoints.Text = GlobalRollNumber.points.ToString();
            profit.Text = "0";
            updateneedy();

        }

        public async void updateneedy(){

            List<Absentee> subNames = await App.MobileService.GetTable<Absentee>().Where(absentee => ((absentee.Slot == GlobalRollNumber.slot && absentee.SubjectId == GlobalRollNumber.subjectID))).ToListAsync();
            
            for(int i=0 ;i<subNames.Count ; i++){
                String  adder = subNames[i].RollNumber + ","+subNames[i].BidPrice;
                needy.Items.Add(adder);
            }

        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Tomorrow), null);
        }

        private void forward_Click(object sender, RoutedEventArgs e)
        {
            //put in lucky
            if (needy.SelectedIndex != -1)
            {
                lucky.Items.Add(needy.SelectedItem);
                String a = needy.SelectedItem.ToString();
                needy.Items.Remove(needy.SelectedItem);
                String[] b = a.Split(',');
                int p = Int32.Parse(profit.Text)+ Int32.Parse(b[1]);
                profit.Text = p.ToString();

            }
        }

        private void backward_Click(object sender, RoutedEventArgs e)
        {
            if (lucky.SelectedIndex != -1)
            {
                needy.Items.Add(lucky.SelectedItem);
                String a = lucky.SelectedItem.ToString();
                lucky.Items.Remove(lucky.SelectedItem);
                String[] b = a.Split(',');
                int p = Int32.Parse(profit.Text) - Int32.Parse(b[1]);

                profit.Text = p.ToString();
            }
           
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Points> check1 = await App.MobileService.GetTable<Points>().Where(pt => pt.RollNumber == GlobalRollNumber.RollNumber).ToListAsync();
            check1[0].RollNumber = GlobalRollNumber.RollNumber;
                 check1[0].Name = GlobalRollNumber.studentName;
                 check1[0].CurrentPoints = GlobalRollNumber.points+Int32.Parse(profit.Text);
                 check1[0].Completed = true;
            
            /*
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

*/
          /*  Points attendObj = new Points
            {
                RollNumber = GlobalRollNumber.RollNumber,
                Name = GlobalRollNumber.studentName,
                CurrentPoints = GlobalRollNumber.points+Int32.Parse(profit.Text),
                Completed = true
            };
           * */
            GlobalRollNumber.points = GlobalRollNumber.points + Int32.Parse(profit.Text);
            await App.MobileService.GetTable<Points>().UpdateAsync(check1[0]);

            for (int i = 0; i < lucky.Items.Count; i++)
            {
                String rb = lucky.Items.ElementAt(i).ToString();
                String[] a = rb.Split(',');
                String roll = a[0];
                int bid = Int32.Parse(a[1]);


                List<Points> ret = await App.MobileService.GetTable<Points>().Where(points => (points.RollNumber==roll)).ToListAsync();


               // Points at = new Points
                //{
                    //ret.RollNumber = roll;
                    //ret.Name = ret[0].Name;
                    ret[0].CurrentPoints = ret[0].CurrentPoints- Int32.Parse(profit.Text);
                   // ret.Completed = true
                //};
                await App.MobileService.GetTable<Points>().UpdateAsync(ret[0]);

                List<Absentee> atq = await App.MobileService.GetTable<Absentee>().Where(points => (points.RollNumber == roll)).ToListAsync();

                /*Absentee atq = new Absentee
                {
                    RollNumber = roll//,
//                    Name = ret[0].Name,
 //                   CurrentPoints = ret[0].CurrentPoints - Int32.Parse(profit.Text),
   //                 Completed = true
                };*/
                await App.MobileService.GetTable<Absentee>().DeleteAsync(atq[0]);


                Proxy pr = new Proxy
                {

                    RollNumber = ret[0].RollNumber,
                    ProxyGivenBy = GlobalRollNumber.RollNumber,
                    BidPrice = Int32.Parse(profit.Text),
                    SubjectId = GlobalRollNumber.subjectID,
                    Slot = GlobalRollNumber.slot,
                    Completed = true
                };
                 await App.MobileService.GetTable<Proxy>().InsertAsync(pr);


                // after the update and all...the app stays on that page only with teh new values of profit and lucky table is null
                 lucky.Items.Clear();
                 availPoints.Text = GlobalRollNumber.points.ToString();
                 
                 profit.Text = "0";
                
            }


        }


    }
}
