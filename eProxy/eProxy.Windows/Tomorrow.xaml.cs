using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.UI;
//using System.Drawing;
using System.Diagnostics;
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
    public sealed partial class Tomorrow : Page
    {
        public int weekDay;

        public Tomorrow()
        {
            this.InitializeComponent();
            DateTime sysTime = DateTime.Now;
            weekDay = (int)sysTime.DayOfWeek;
            displaySubjects(weekDay);
        }

        public async void displaySubjects(int weekDay)
        {
            List<Timings> subNames = await App.MobileService.GetTable<Timings>().Where(timings => ((timings.Slot - 1) >= 9 * weekDay && (timings.Slot - 1 < 9 * weekDay + 9))).ToListAsync();
            subNames = subNames.OrderBy(x => x.Slot).ToList();
            List<GoingToClass> goingToClass = await App.MobileService.GetTable<GoingToClass>().Where(going => (going.Slot - 1) >= 9 * weekDay && (going.Slot - 1 < 9 * weekDay + 9) && going.RollNumber == GlobalRollNumber.RollNumber).ToListAsync();
            goingToClass = goingToClass.OrderBy(x => x.Slot).ToList();
            List<Absentee> notgoingToClass = await App.MobileService.GetTable<Absentee>().Where(going => (going.Slot - 1) >= 9 * weekDay && (going.Slot - 1 < 9 * weekDay + 9) && going.RollNumber == GlobalRollNumber.RollNumber).ToListAsync();
            notgoingToClass = notgoingToClass.OrderBy(x => x.Slot).ToList();
            int i = 0;
            int j = 0;
            int count = subNames.Count;
            int jCount = goingToClass.Count;
            int kCount = notgoingToClass.Count;
            int k = 0;
            if (i < count && ((subNames[i].Slot - 1) % 9) == 0)
            {
                t1.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 0)
                {
                    t1.Background = new SolidColorBrush(Colors.Green);
                    b1_Copy.IsEnabled = false;
                    j++;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 0)
                {
                    t1.Background = new SolidColorBrush(Colors.Red);
                    b1.IsEnabled = false;
                    k++;
                   
                }
                i++;
            }
            else
            {
                b1.IsEnabled = false;
                b1_Copy.IsEnabled = false;
            }
            if (i < count && ((subNames[i].Slot - 1) % 9) == 1)
            {
                t2.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 1)
                {
                    t2.Background = new SolidColorBrush(Colors.Green);
                    b2_Copy.IsEnabled = false;
                    j++;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 1)
                {
                    k++;
                    t2.Background = new SolidColorBrush(Colors.Red);
                    b2.IsEnabled = false;
                }
                i++;
            }
            else
            {
                b2.IsEnabled = false;
                b2_Copy.IsEnabled = false;
            }
            if (i < count && ((subNames[i].Slot - 1) % 9) == 2)
            {
                t3.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 2)
                {
                    j++;
                    t3.Background = new SolidColorBrush(Colors.Green);
                    b3_Copy.IsEnabled = false;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 2)
                {
                    k++;
                    t3.Background = new SolidColorBrush(Colors.Red);
                    b3.IsEnabled = false;
                }
                i++;
            }
            else
            {
                b3.IsEnabled = false;
                b3_Copy.IsEnabled = false;
            }
            if (i < count && ((subNames[i].Slot - 1) % 9) == 3)
            {
                t4.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 3)
                {
                    j++;
                    t4.Background = new SolidColorBrush(Colors.Green);
                    b4_Copy.IsEnabled = false;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 3)
                {
                    k++;
                    t4.Background = new SolidColorBrush(Colors.Red);
                    b4.IsEnabled = false;
                }
                i++;
            }
            else
            {
                b4.IsEnabled = false;
                b4_Copy.IsEnabled = false;
            }
            if (i < count && ((subNames[i].Slot - 1) % 9) == 4)
            {
                t5.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 4)
                {
                    j++;
                    t5.Background = new SolidColorBrush(Colors.Green);
                    b5_Copy.IsEnabled = false;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 4)
                {
                    k++;
                    t5.Background = new SolidColorBrush(Colors.Red);
                    b5.IsEnabled = false;
                }
                i++;
            }
            else
            {
                b5.IsEnabled = false;
                b5_Copy.IsEnabled = false;
            }
            if (i < count && ((subNames[i].Slot - 1) % 9) == 5)
            {
                t6.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 5)
                {
                    j++;
                    t6.Background = new SolidColorBrush(Colors.Green);
                    b6_Copy.IsEnabled = false;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 5)
                {
                    k++;
                    t6.Background = new SolidColorBrush(Colors.Red);
                    b6.IsEnabled = false;
                }
                i++;
            }
            else
            {
                b6.IsEnabled = false;
                b6_Copy.IsEnabled = false;
            }
            if (i < count && ((subNames[i].Slot - 1) % 9) == 6)
            {
                t7.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 6)
                {
                    j++;
                    t7.Background = new SolidColorBrush(Colors.Green);
                    b7_Copy.IsEnabled = false;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 6)
                {
                    k++;
                    t7.Background = new SolidColorBrush(Colors.Red);
                    b7.IsEnabled = false;
                }
                i++;
            }
            else
            {
                b7.IsEnabled = false;
                b7_Copy.IsEnabled = false;
            }
            if (i < count && ((subNames[i].Slot - 1) % 9) == 7)
            {
                t8.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 7)
                {
                    j++;
                    t8.Background = new SolidColorBrush(Colors.Green);
                    b8_Copy.IsEnabled = false;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 7)
                {
                    k++;
                    t8.Background = new SolidColorBrush(Colors.Red);
                    b8.IsEnabled = false;
                }
                i++;
            }
            else
            {
                b8.IsEnabled = false;
                b8_Copy.IsEnabled = false;
            }
            if (i < count && ((subNames[i].Slot - 1) % 9) == 8)
            {
                t9.Text = subNames[i].SubjectName;
                if (j < jCount && (goingToClass[j].Slot - 1) % 9 == 8)
                {
                    j++;
                    t9.Background = new SolidColorBrush(Colors.Green);
                    b9_Copy.IsEnabled = false;
                }
                else if (k < kCount && (notgoingToClass[k].Slot - 1) % 9 == 8)
                {
                    k++;
                    t9.Background = new SolidColorBrush(Colors.Red);
                    b9.IsEnabled = false;
                }
                i++;
            }
            else
            {
                b9.IsEnabled = false;
                b9_Copy.IsEnabled = false;
            }

        }

        public async void go(String subName, int slot) {
            List<Timings> subNames = await App.MobileService.GetTable<Timings>().Where(timings => ((timings.Slot == slot && timings.SubjectName == subName))).ToListAsync();
            String subId = subNames[0].SubjectId;

            List<Attending> check1 = await App.MobileService.GetTable<Attending>().Where(check => (check.RollNumber == GlobalRollNumber.RollNumber && check.Slot == slot)).ToListAsync();
            if (check1.Count == 0)
            {
                Attending attendObj = new Attending
                {
                    RollNumber = GlobalRollNumber.RollNumber,
                    SubjectId = subId,
                    Slot = slot,
                    Completed = true
                };
                await App.MobileService.GetTable<Attending>().InsertAsync(attendObj);

                GoingToClass goingObj = new GoingToClass
                {
                    SubjectId = subId,
                    RollNumber = GlobalRollNumber.RollNumber,
                    Slot = slot,
                    Completed = true
                };
                await App.MobileService.GetTable<GoingToClass>().InsertAsync(goingObj);
            }

            GlobalRollNumber.slot = slot;
            GlobalRollNumber.subjectID = subId;
            GlobalRollNumber.subName = subNames[0].SubjectName;

            this.Frame.Navigate(typeof(Going), null);
        }

        public async void proxy(String subName, int slot)
        {
            List<Timings> subNames = await App.MobileService.GetTable<Timings>().Where(timings => ((timings.Slot == slot && timings.SubjectName == subName))).ToListAsync();
            String subId = subNames[0].SubjectId;
            GlobalRollNumber.slot = slot;
            GlobalRollNumber.subName = subName;
            GlobalRollNumber.subjectID = subId;

            List<Absentee> check1 = await App.MobileService.GetTable<Absentee>().Where(check => (check.RollNumber == GlobalRollNumber.RollNumber && check.Slot == slot)).ToListAsync();
            if (check1.Count == 0)
            {

                Absentee absentObj = new Absentee
                {
                    SubjectId = subId,
                    BidPrice = 0,
                    RollNumber = GlobalRollNumber.RollNumber,
                    Slot = slot,
                    Completed = true
                };
                await App.MobileService.GetTable<Absentee>().InsertAsync(absentObj);
            }

           

            this.Frame.Navigate(typeof(Absent), null);
        }

        private void b1_Copy_Click(object sender, RoutedEventArgs e)
        {
            b1.IsEnabled = false;
            t1.Background = new SolidColorBrush(Colors.Red);
            proxy(t1.Text, weekDay * 9 + 1);
            
        }


        private void b1_Click(object sender, RoutedEventArgs e)
        {
            b1_Copy.IsEnabled = false;
            t1.Background = new SolidColorBrush(Colors.Green);
            go(t1.Text, weekDay * 9 + 1);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            b2_Copy.IsEnabled = false;
            t2.Background = new SolidColorBrush(Colors.Green);
            go(t2.Text, weekDay * 9 + 2);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            b3_Copy.IsEnabled = false;
            t3.Background = new SolidColorBrush(Colors.Green);
            go(t3.Text, weekDay * 9 + 3);
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            b4_Copy.IsEnabled = false;
            t4.Background = new SolidColorBrush(Colors.Green);
            go(t4.Text, weekDay * 9 + 4);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            b5_Copy.IsEnabled = false;
            t5.Background = new SolidColorBrush(Colors.Green);
            go(t5.Text, weekDay * 9 + 5);
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            b6_Copy.IsEnabled = false;
            t6.Background = new SolidColorBrush(Colors.Green);
            go(t6.Text, weekDay * 9 + 6);
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            b8_Copy.IsEnabled = false;
            t8.Background = new SolidColorBrush(Colors.Green);
            go(t8.Text, weekDay * 9 + 8);
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            b7_Copy.IsEnabled = false;
            t7.Background = new SolidColorBrush(Colors.Green);
            go(t7.Text, weekDay * 9 + 7);
        }

        private void b9_Click(object sender, RoutedEventArgs e)
        {
            b9_Copy.IsEnabled = false;
            t9.Background = new SolidColorBrush(Colors.Green);
            go(t9.Text, weekDay * 9 + 9);
        }

        private void b2_Copy_Click(object sender, RoutedEventArgs e)
        {
            b2.IsEnabled = false;
            t2.Background = new SolidColorBrush(Colors.Red);
            proxy(t2.Text, weekDay * 9 + 2);
        }

        private void b3_Copy_Click(object sender, RoutedEventArgs e)
        {
            b3.IsEnabled = false;
            t3.Background = new SolidColorBrush(Colors.Red);
            proxy(t3.Text, weekDay * 9 + 3);
        }

        private void b4_Copy_Click(object sender, RoutedEventArgs e)
        {
            b4.IsEnabled = false;
            t4.Background = new SolidColorBrush(Colors.Red);
            proxy(t4.Text, weekDay * 9 + 4);
        }

        private void b5_Copy_Click(object sender, RoutedEventArgs e)
        {
            b5.IsEnabled = false;
            t5.Background = new SolidColorBrush(Colors.Red);
            proxy(t5.Text, weekDay * 9 + 5);
        }

        private void b6_Copy_Click(object sender, RoutedEventArgs e)
        {
            b6.IsEnabled = false;
            t6.Background = new SolidColorBrush(Colors.Red);
            proxy(t6.Text, weekDay * 9 + 6);
        }

        private void b7_Copy_Click(object sender, RoutedEventArgs e)
        {
            b7.IsEnabled = false;
            t7.Background = new SolidColorBrush(Colors.Red);
            proxy(t7.Text, weekDay * 9 + 7);
        }

        private void b8_Copy_Click(object sender, RoutedEventArgs e)
        {
            b8.IsEnabled = false;
            t8.Background = new SolidColorBrush(Colors.Red);
            proxy(t8.Text, weekDay * 9 + 8);
        }

        private void b9_Copy_Click(object sender, RoutedEventArgs e)
        {
            b9.IsEnabled = false;
            t9.Background = new SolidColorBrush(Colors.Red);
            proxy(t9.Text, weekDay * 9 + 9);
        }

        private void b1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HomePage), null);
        }



    }
}
